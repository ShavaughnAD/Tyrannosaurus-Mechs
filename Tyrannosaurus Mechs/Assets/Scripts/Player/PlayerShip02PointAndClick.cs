using UnityEngine;

public class PlayerShip02PointAndClick : PlayerMovement
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 60f;

    Camera cam;
    Vector2 mousePos;

    void Start()
    {
        //Cursor.visible = false;
        cam = Camera.main;
    }

    public override void Update()
    {
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

    //target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
    //    crosshairs.transform.position = new Vector2(target.x, target.y);

    //    //Vector3 difference = target - player.transform.position;
    //    //float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    //    //player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        //fireBullet(direction, rotationZ);
    //    }

    //    void fireBullet(Vector2 direction, float rotationZ)
    //{
    //    GameObject b = Instantiate(bulletPrefab) as GameObject;
    //    b.transform.position = player.transform.position;
    //    b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    //    b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    //}
}
