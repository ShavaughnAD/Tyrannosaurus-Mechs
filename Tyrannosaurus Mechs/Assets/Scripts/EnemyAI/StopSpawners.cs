using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSpawners : MonoBehaviour
{
    public GameObject spawner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(spawner);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
