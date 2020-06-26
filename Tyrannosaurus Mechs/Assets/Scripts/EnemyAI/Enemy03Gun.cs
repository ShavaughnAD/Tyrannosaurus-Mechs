using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03Gun : MonoBehaviour
{
    public GameObject EnemyBullet;

    private GameObject target;
    private Vector3 targetPoint;
    private Quaternion targetRotation;

    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
        target = GameManager.gameManager.playerShipMovement.gameObject;
    }

    
    void Update()
    {
        //targetPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
        //targetRotation = Quaternion.LookRotation(-targetPoint, Vector3.up);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
    }

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.FindGameObjectWithTag("Player");

        if(playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);

            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
