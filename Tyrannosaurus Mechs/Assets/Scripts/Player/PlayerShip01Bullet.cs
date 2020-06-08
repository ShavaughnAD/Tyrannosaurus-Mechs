﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip01Bullet : PlayerMovement
{
    float speed;

    void Start()
    {
        speed = 8f;
    }

    
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }
}
