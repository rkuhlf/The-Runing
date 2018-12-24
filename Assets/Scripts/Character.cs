using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour {

    public float speed = 100;
    public GameObject fireball;
    public GameObject waterball;
    public GameObject wind;
    public GameObject earth;

    public AudioClip fireSound;
    public AudioClip waterSound;
    public AudioClip earthSound;
    public AudioClip windSound;

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
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyUp(KeyCode.Space)) && EventSystem.current.currentSelectedGameObject == null)
        {
            string spell = GameObject.FindGameObjectWithTag("SpellHolder").GetComponent<SpellHolder>().GetSelectedSpell();
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (spell == "fireball")
            {
                Fireball(mousePos);
                GameObject.FindGameObjectWithTag("SpellHolder").GetComponent<SpellHolder>().UseSelectedSpell();
            } else if (spell == "waterball")
            {
                WaterBall(mousePos);
                GameObject.FindGameObjectWithTag("SpellHolder").GetComponent<SpellHolder>().UseSelectedSpell();
            }
            else if (spell == "wind")
            {
                Wind(mousePos);
                GameObject.FindGameObjectWithTag("SpellHolder").GetComponent<SpellHolder>().UseSelectedSpell();
            }
            else if (spell == "earth")
            {
                Earth();
                GameObject.FindGameObjectWithTag("SpellHolder").GetComponent<SpellHolder>().UseSelectedSpell();
            }
        }
    }

    private void Fireball(Vector2 mousePos)
    {
        AudioManager.instance.PlaySingle(fireSound);
        Vector2 dir = new Vector3(mousePos.x, mousePos.y) - transform.position;
        
        dir = dir.normalized;
        GameObject newFireball = Instantiate(fireball, transform.position, Quaternion.LookRotation(Vector3.forward, dir));
        newFireball.GetComponent<FireBall>().vel = dir;
    }

    private void WaterBall(Vector2 mousePos)
    {
        AudioManager.instance.PlaySingle(waterSound);
        Vector2 dir = new Vector3(mousePos.x, mousePos.y) - transform.position;

        dir = dir.normalized;
        GameObject newWaterball = Instantiate(waterball, transform.position, Quaternion.LookRotation(Vector3.forward, dir));
        newWaterball.GetComponent<WaterBall>().vel = dir;
    }

    private void Wind(Vector2 mousePos)
    {
        AudioManager.instance.PlaySingle(windSound);
        Vector2 dir = new Vector3(mousePos.x, mousePos.y) - transform.position;

        dir = dir.normalized;
        GameObject newWind = Instantiate(wind, transform.position, Quaternion.LookRotation(Vector3.forward, dir));
        newWind.GetComponent<Wind>().vel = dir;
    }

    private void Earth()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("Shake");
        AudioManager.instance.PlaySingle(earthSound);
        Instantiate(earth, transform.position, Quaternion.identity);
    }
}
