using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public float time = 20;

    private void Start()
    {
        Destroy(gameObject, time);
    }
}
