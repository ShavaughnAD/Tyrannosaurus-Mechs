using UnityEngine;

public class DamageFloaterHandler : MonoBehaviour
{
    public float destroyTime = 1;
    public Vector3 floatingTextOffset = new Vector3(0, 0.5f, 0);

    void Start()
    {
        transform.localPosition += floatingTextOffset;
    }
}