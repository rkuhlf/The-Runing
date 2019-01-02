using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderByY : MonoBehaviour
{
    public Transform bottom;
    public SpriteRenderer[] sprites;
    public ParticleSystemRenderer[] particles;

    private void Update()
    {
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.sortingOrder = (int) (-1000 * bottom.position.y);
        }

        foreach (ParticleSystemRenderer particle in particles)
        {
            if (particle != null)
                particle.sortingOrder = (int)(-1000 * bottom.position.y);
        }
    }
}
