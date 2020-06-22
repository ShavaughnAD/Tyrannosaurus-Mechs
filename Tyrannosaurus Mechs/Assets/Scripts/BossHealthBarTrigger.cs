using UnityEngine;

public class BossHealthBarTrigger : MonoBehaviour
{
    public GameObject healthBar;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            healthBar.SetActive(true);
        }
    }
}