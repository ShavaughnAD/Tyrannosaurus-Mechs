using UnityEngine;

public class PlayerShip01Shoot : PlayerMovement
{
    public GameObject PlayerShip01Bullet;
    public GameObject bulletPosition01;
    public GameObject bulletPosition02;

    public override void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet01 = Instantiate(PlayerShip01Bullet);
            bullet01.transform.position = bulletPosition01.transform.position;

            GameObject bullet02 = Instantiate(PlayerShip01Bullet);
            bullet02.transform.position = bulletPosition02.transform.position;

            muzzleFlash.Play();
        }
    }
}