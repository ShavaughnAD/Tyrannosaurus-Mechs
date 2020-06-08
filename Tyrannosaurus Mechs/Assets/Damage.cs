using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;
    void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.tag == "Player")
      {
            collision.GetComponent<Health>().TakeDamage(damage);
      }   
    }
}
