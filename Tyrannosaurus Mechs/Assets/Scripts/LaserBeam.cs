using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public float laserBeamLength;
    public Transform rayPoint;
    LineRenderer lineRend;

    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
    }


    void FixedUpdate()
    {
        // Cast a ray straight up.
        RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, Vector2.up, laserBeamLength);

        if (hit.collider != null)
        {
            if(hit.collider.GetComponent<Health>() && hit.collider.tag == "Enemy")
            {
                hit.collider.GetComponent<Health>().TakeDamage(GameManager.gameManager.playerShipMovement.weaponDamage);
            }
        }
    }

    void Update()
    {
        Vector3 endPos = transform.position + (transform.up * laserBeamLength);
        lineRend.SetPositions(new Vector3[] { transform.position, endPos });
    }
}
