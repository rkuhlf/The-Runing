using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float speed = 100;
    public GameObject fireball;

    private void Update()
    {
        // Movement
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        if (xInput < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else if (xInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        transform.Translate(new Vector3(xInput, yInput) * Time.deltaTime * speed);

        // attack
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Fireball(mousePos);
        }
    }

    private void Fireball(Vector2 mousePos)
    {
        Vector2 dir = new Vector3(mousePos.x, mousePos.y) - transform.position;
        
        dir = dir.normalized;
        GameObject newFireball = Instantiate(fireball, transform.position, Quaternion.LookRotation(Vector3.forward, dir));
        newFireball.GetComponent<FireBall>().vel = dir;
    }
}
