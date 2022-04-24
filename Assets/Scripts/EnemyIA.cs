using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyIA : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    Transform firePoint_2;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float timeBetweenShots;

    [SerializeField]
    AudioClip deathSound;

    [SerializeField]
    float enemyHealth;

    [SerializeField]
    GameObject enemyHealthBar;

    [SerializeField]
    GameObject deathVFX;

    float currentHealth;
    Rigidbody2D rb;
    Vector3 healthBarLocalScale;
    void Start()
    {
        currentHealth = enemyHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("EnemyShoot", timeBetweenShots, timeBetweenShots);

        healthBarLocalScale = enemyHealthBar.transform.localScale;
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver)
            return;

        //Enemy Health Bar
        healthBarLocalScale.x = currentHealth / enemyHealth;
        enemyHealthBar.transform.localScale = healthBarLocalScale;

        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = angle;
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.IsGameOver)
            return;

        if (Vector2.Distance(transform.position, player.transform.position) > 5)
            rb.position = Vector2.MoveTowards(rb.position, player.transform.position, 1f * Time.deltaTime);
    }

    void EnemyShoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        if (firePoint_2 != null)
            Instantiate(bulletPrefab, firePoint_2.position, Quaternion.identity);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerBullet"))
            currentHealth -= 25;

        if (currentHealth <= 0)
        {
            GameObject effect = Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(effect, 2f);

            var playerController = player.GetComponent<PlayerController>();
            playerController.EnemyKilled();

            var texts = GameObject.FindObjectsOfType<TMP_Text>();
            if (texts.Length == 1)
            {
                TMP_Text TMPpoints = GameObject.FindObjectOfType<TMP_Text>();
                int current = int.Parse(TMPpoints.text);
                current++;
                TMPpoints.SetText(current.ToString());
            }

            Destroy(gameObject);
            GameManager.Instance.totalEnemiesKilled += 1;
            GameManager.Instance.enemiesKilled += 1;
            if (GameManager.Instance.enemiesKilled == GameManager.Instance.enemiesperWave)
            {
                GameManager.Instance.GoToNextWave();
            }
        }
    }
}
