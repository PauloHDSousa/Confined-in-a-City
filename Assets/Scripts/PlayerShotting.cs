using UnityEngine;

public class PlayerShotting : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    Transform firePoint_2;

    [SerializeField]
    Transform firePoint_3;

    [SerializeField]
    AudioClip powerUPSound;


    [SerializeField]
    AudioClip powerUP_2Sound;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    GameObject bulletPrefab2;

    [SerializeField]
    GameObject bulletPrefab3;

    public float bulletForce = 20f;

    [SerializeField]
    AudioClip shotSound;

    AudioSource audioSource;
    PlayerController player;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (GameManager.Instance.IsGameOver || GameManager.Instance.isPaused)
            return;

        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        audioSource.PlayOneShot(shotSound);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        if (bulletPrefab.name == "bullet_3")
        {
            GameObject bullet_2 = Instantiate(bulletPrefab, firePoint_2.position, Quaternion.identity);
            Rigidbody2D rb_2 = bullet_2.GetComponent<Rigidbody2D>();
            rb_2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            GameObject bullet_3 = Instantiate(bulletPrefab, firePoint_3.position, Quaternion.identity);
            Rigidbody2D rb_3 = bullet_3.GetComponent<Rigidbody2D>();
            rb_3.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PowerUP"))
        {
           

            if (bulletPrefab.name == "Bullet") {
                bulletPrefab = bulletPrefab2;
                audioSource.PlayOneShot(powerUPSound);
            }
            else if (bulletPrefab.name == "Bullet_2") { 
                bulletPrefab = bulletPrefab3;
                audioSource.PlayOneShot(powerUPSound);
            }
            else if (player.moveSpeed < 15) { 
                player.moveSpeed += 1;
                audioSource.PlayOneShot(powerUP_2Sound);
            }
            else if (bulletForce < 50) { 
                bulletForce += 5;
                audioSource.PlayOneShot(powerUP_2Sound);
            }

            Destroy(collision.collider.gameObject);
        }
    }
}