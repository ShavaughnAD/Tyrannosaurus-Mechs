using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.5f;
    public float duration = 4f;
    public GameObject pS;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && transform.tag == "Speed")
        {
           StartCoroutine (PickUp (collision) );
        }
        if(collision.tag == "Player" && transform.tag == "Damage")
        {
           StartCoroutine (Pickup2 (collision));
        }
        if(collision.tag == "Player" && transform.tag == "Nuke")
        {
           PickUp3();

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
    void PickUp3()
    {
        transform.GetComponent<SpriteRenderer>().enabled = false;
        transform.GetComponent<Collider2D>().enabled = false;
        Explode();
        pS.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);  
    }
    void Explode()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, 5f);
        foreach(Collider2D enemys in collider2Ds)
        {
           
            EnemyHealth enemy = enemys.GetComponent<EnemyHealth>();
            if(enemy!= null)
            {
                enemy.TakeDamage(350);
            }
        }
    }
}