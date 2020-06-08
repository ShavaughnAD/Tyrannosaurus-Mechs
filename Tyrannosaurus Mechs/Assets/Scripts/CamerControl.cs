using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerControl : MonoBehaviour
{

    public Transform target;

    public Transform Bkgd1;
    public Transform Bkgd2;
    private float size;
    // Start is called before the first frame update
    void Start()
    {
        size = Bkgd1.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //camera
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);

        //background
        if(transform.position.y >= Bkgd2.position.y)
        {
            Bkgd1.position = new Vector3(Bkgd1.position.x, Bkgd2.position.y+size, Bkgd1.position.z);
            SwitchBkgd();
        }
    }

    private void SwitchBkgd()
    {
        Transform temp = Bkgd1;

        Bkgd1 = Bkgd2;
        Bkgd2 = temp;
    }
}
