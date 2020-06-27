using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquallBlast : MonoBehaviour
{
    public float moveSpeed = 4;
    public float damage;

    void Awake()
    {
        Destroy(gameObject, 2);
    }

    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

}