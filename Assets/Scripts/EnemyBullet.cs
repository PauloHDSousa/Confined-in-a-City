using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject hitEffect;

    Transform player;
    Rigidbody2D rb;
    Vector2 target;
    void Start()
    {
        var playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
            target = new Vector2(player.position.x, player.position.y);
        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, 5f * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
            DestroyProjectile();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Enemy"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
