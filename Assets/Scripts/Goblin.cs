using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour {

    private bool knockingBack = false;
    private Vector3 startPosition;
    private Vector3 targetKnockback;
    private float startTime;
    private float lerpTime = 1;

    public AudioClip deathEffect;
    public GameObject deathParticles;

	public void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        AudioManager.instance.PlaySingle(deathEffect);
        Destroy(gameObject);
    }

    public void KnockBack(Vector2 dist)
    {
        knockingBack = true;
        startTime = Time.time;
        startPosition = transform.position;
        targetKnockback = transform.position + (Vector3) dist;
    }

    private void Update()
    {
        if (knockingBack)
        {
            float t = Time.time - startTime / lerpTime;
            t = Mathf.Sin(t * Mathf.PI * 0.5f);
            transform.position = Vector3.Lerp(startPosition, targetKnockback, t);
            if (t > 0.99f)
            {
                knockingBack = false;
            }
        }
    }
}
