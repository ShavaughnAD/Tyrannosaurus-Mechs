using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float speed;

    private void Awake()
    {
        speed = Random.Range(-0.5f, 0.75f);
    }

    void Update()
    {
        transform.Rotate(0f, 0f, speed);
    }
}
