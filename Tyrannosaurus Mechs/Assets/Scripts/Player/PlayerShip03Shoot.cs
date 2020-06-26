using UnityEngine;

public class PlayerShip03Shoot : PlayerMovement
{
    public Transform[] firePoints;
    public GameObject projectilePrefab;
    public float launchForce = 700f;

    public AudioClip ShiptwoFiring;
    public override void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0))
        {
            auSource.PlayOneShot(ShiptwoFiring);
            LaunchProjectile();
        }
    }

    void LaunchProjectile()
    {
        foreach (var firePoint in firePoints)
        {
            var projectileInstance = Instantiate(
                projectilePrefab,
                firePoint.position,
                firePoint.rotation);

            //projectileInstance.AddForce(firePoint.forward * launchForce);
        }
    }
}
