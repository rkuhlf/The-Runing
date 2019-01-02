using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject block;
    public Transform position1;
    public Transform position2;
    public AudioClip pressClip;
    public float duration = 1;

    private float t = 0;
    private int counting = 0;
    private Animator anim;
    private float numOn = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsInteractable(collision))
        {
            numOn++;
            AudioManager.instance.PlaySingle(pressClip);
        }

        if (numOn > 0)
        {
            counting = 1;
            anim.SetBool("Activated", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsInteractable(collision))
        {
            numOn--;
            AudioManager.instance.PlaySingle(pressClip);
        }

        if (numOn == 0)
        {
            counting = -1;
            anim.SetBool("Activated", false);
        }
    }

    private bool IsInteractable(Collider2D collider)
    {
        return collider.CompareTag("Player") || collider.CompareTag("Enemy");
    }

    private void Update()
    {
        t += Time.deltaTime * counting;

        if (counting == 1 && t >= duration)
        {
            counting = 0;
        } else if (counting == -1 && t <= 0)
        {
            counting = 0;
        }


        block.transform.position = Vector3.Lerp(position1.position, position2.position, t / duration);
    }
}
