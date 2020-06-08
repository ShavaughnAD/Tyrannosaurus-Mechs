using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(GameManager.gameManager.playerShipMovement.weaponDamage);
            Destroy(gameObject);
        }
    }
}
