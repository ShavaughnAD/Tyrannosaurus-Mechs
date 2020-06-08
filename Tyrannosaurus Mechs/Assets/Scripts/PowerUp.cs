using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.5f;
    public float duration = 4f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine (PickUp (collision) );
        }
    }
    IEnumerator PickUp(Collider2D player)
    {
        PlayerMovement statts = player.GetComponent<PlayerMovement>();
        statts.moveSpeed *= multiplier;
        transform.GetComponent<SpriteRenderer>().enabled = false;
        transform.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        statts.moveSpeed /= multiplier;
        Destroy(gameObject);
    }
 
}