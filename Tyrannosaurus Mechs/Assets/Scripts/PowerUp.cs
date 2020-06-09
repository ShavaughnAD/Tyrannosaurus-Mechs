using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.5f;
    public float duration = 4f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && transform.tag == "Speed")
        {
            StartCoroutine (PickUp (collision) );
        }
        if(collision.tag == "Player" && transform.tag == "Damage")
        {
           StartCoroutine( Pickup2(collision));
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
 IEnumerator Pickup2(Collider2D player)
    {
        PlayerMovement wepStat = player.GetComponent<PlayerMovement>();
        wepStat.weaponDamage *= multiplier;
        transform.GetComponent<SpriteRenderer>().enabled = false;
        transform.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        wepStat.weaponDamage /= multiplier;
        Destroy(gameObject);
    }
}