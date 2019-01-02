using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    public float range = 3;
    public Vector2 vel;
    public float speed = 10;

    public GameObject explodeParticles;
    public AudioClip explodeEffect;

    private void Start()
    {
        Destroy(gameObject, 20);
    }

    private void Update()
    {
        transform.position = transform.position + (Vector3) (vel * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Obstacle"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Shake");
        AudioManager.instance.PlaySingle(explodeEffect);
        Instantiate(explodeParticles, transform.position, Quaternion.identity);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.GetComponent<Goblin>().Die();
            }
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, range);
    }
}
