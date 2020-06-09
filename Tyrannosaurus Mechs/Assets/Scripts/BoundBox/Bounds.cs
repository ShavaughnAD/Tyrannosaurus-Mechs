using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
  void Update()
  {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp(pos.x,.02f,.98f);
            pos.y = Mathf.Clamp(pos.y, .02f,.96f);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
  }
}