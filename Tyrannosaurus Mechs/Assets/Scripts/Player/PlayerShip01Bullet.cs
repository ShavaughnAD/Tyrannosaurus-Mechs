using UnityEngine;

public class PlayerShip01Bullet : MonoBehaviour
{
    public float damage;
    public float speed;

    public GameObject Explosion;

    void Awake()
    {
        //damage = GameManager.gameManager.playerMovement.weaponDamage;
        if(speed <= 0)
        {
            speed = 8;
        }
    }
    
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        transform.position = position;
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            PlayExplosion();

            Debug.LogError(collision.name + " Recieved " + GameManager.gameManager.playerShipMovement.weaponDamage + "  Damage");
            collision.GetComponent<Health>().TakeDamage(GameManager.gameManager.playerShipMovement.weaponDamage);
            Destroy(gameObject);
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        explosion.transform.position = transform.position;
    }
}