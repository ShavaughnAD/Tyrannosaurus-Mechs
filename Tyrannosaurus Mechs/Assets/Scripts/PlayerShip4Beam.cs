using UnityEngine;
using UnityEngine.UI;

public class PlayerShip4Beam : PlayerMovement
{
    public Transform beamSpawnPoint;
    public GameObject laserBeam;
    public float maxCanisterSize = 100;
    public float currentCanisterSize = 100;
    public float canisterRefillRate = 5;
    public float canisterDecayRate = .010f;

    bool isFiring = false;

    void Awake()
    {
        currentCanisterSize = maxCanisterSize;
    }

    public override void Update()
    {
        base.Update();

        if (isFiring == false)
        {
            currentCanisterSize += canisterRefillRate * Time.deltaTime;
            currentCanisterSize = Mathf.Clamp(currentCanisterSize, 0, maxCanisterSize);
        }

        if (Input.GetKey(KeyCode.Mouse0) && currentCanisterSize >= 1)
        {
            laserBeam.SetActive(true);
            currentCanisterSize -= canisterDecayRate;
            isFiring = true;
        }
        else
        {
            laserBeam.SetActive(false);
            isFiring = false;
        }
    }
}
