using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFirePattern2 : MonoBehaviour
{
    public static BossFirePattern2 BFP2;
    private float angle = 0f;
    
     public void Start()
    {
        BFP2 = this;
    }

    public void Fire()
    {
        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
        float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        GameObject bul = BossBulletPool.bulletPoolInstanse.GetBullet();
        bul.transform.position = transform.position;
        bul.transform.rotation = transform.rotation;
        bul.SetActive(true);
        bul.GetComponent<BossBullet>().SetMoveDirection(bulDir);

        angle += 10f;
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Player")
    //    {
    //        Shoot();
    //    }
    //}

    public void Shoot()
    {
        InvokeRepeating("Fire", 0f, 0.1f);
    }
    void Update()
    {
        
    }
}
