using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;

    public float speed = 1.0f;

    private float startTime;

    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void Update()
    {
        float disCovered = (Time.time - startTime) * speed;

        float fractionOfJourney = disCovered / journeyLength;

        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
    }
}
