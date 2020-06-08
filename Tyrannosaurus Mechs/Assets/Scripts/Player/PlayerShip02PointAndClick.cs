using UnityEngine;

public class PlayerShip02PointAndClick : PlayerMovement
{
    public GameObject crosshairs;
    public GameObject player;
    private Vector3 target;
    
    public GameObject bulletPrefab;
    public float bulletSpeed = 60f;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        //Vector3 difference = target - player.transform.position;
        //float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            //fireBullet(direction, rotationZ);
        }

        void fireBullet(Vector2 direction, float rotationZ)
        {
            GameObject b = Instantiate(bulletPrefab) as GameObject;
            b.transform.position = player.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
