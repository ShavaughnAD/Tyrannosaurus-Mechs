﻿using UnityEngine;

public class PlayerShip02PointAndClick : PlayerMovement
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public GameObject crosshair;
    public float bulletSpeed = 60f;

    Camera cam;
    Vector2 mousePos;
    Vector3 target;

    void Start()
    {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        //Cursor.visible = false;
        cam = Camera.main;
        crosshair.GetComponent<SpriteRenderer>().sortingLayerName = "Crosshair";
    }

    public override void Update()
    {
        target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z));
        crosshair.transform.position = new Vector2(target.x, target.y);
        base.Update();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - playerRB.position;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(lookDir * bulletSpeed, ForceMode2D.Impulse);
            Destroy(bullet, 2);
        }
    }
}
