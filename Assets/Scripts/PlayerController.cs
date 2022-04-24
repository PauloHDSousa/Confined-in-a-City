using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;
    float initalMoveSpeed;

    public float health = 100f;

    [SerializeField]
    Image healtBar;

    [SerializeField]
    AudioClip levelUPSound;

    [SerializeField]
    AudioClip enemyKilled;

    [SerializeField]
    AudioClip deathSound;

    [SerializeField]
    AudioClip hitSound;

    [SerializeField]
    AudioClip HPUPSound;

    [SerializeField]
    GameObject deathVFX;

    SpriteRenderer playerSprite;
    BoxCollider2D playerBC;

    AudioSource audioSource;


    [SerializeField]
    Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }


    private void Start()
    {
        GameManager.Instance.isPaused = false;
        GameManager.Instance.IsGameOver = false;
        Time.timeScale = 1;

        playerBC = GetComponent<BoxCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        initalMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameOver)
            return;


        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }

        healtBar.fillAmount = health / 100;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            health -= 5;
            shakeDuration = 0.05f;

            if (health <= 0)
            {
                playerBC.enabled = false;
                healtBar.fillAmount = health / 100;
                GameManager.Instance.IsGameOver = true;
                audioSource.PlayOneShot(deathSound);
                GameObject effect = Instantiate(deathVFX, transform.position, Quaternion.identity);
                Destroy(effect, 2f);
                GameManager.Instance.GameOver();
                playerSprite.color = new Color(1f, 1f, 1f, 0f);
                Destroy(gameObject, 2f);
            }
            else
                audioSource.PlayOneShot(hitSound);
        }

        if (collision.collider.CompareTag("HP"))
        {
            if (health <= 95)
            {
                if (health == 95)
                    health += 5;
                else
                    health += 10;
            }

            audioSource.PlayOneShot(HPUPSound);
            Destroy(collision.collider.gameObject);
        }
    }

    public void EnemyKilled()
    {
        audioSource.PlayOneShot(enemyKilled);
    }
}
