using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour
{
    public Vector2 vel;
    public float speed = 10;

    private void Start()
    {
        Destroy(gameObject, 20);
    }

    private void Update()
    {
        transform.position = transform.position + (Vector3)(vel * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Kill(collision);
        }
    }

    private void Kill(Collider2D col)
    {
        col.GetComponent<Goblin>().Die();
    }
}
