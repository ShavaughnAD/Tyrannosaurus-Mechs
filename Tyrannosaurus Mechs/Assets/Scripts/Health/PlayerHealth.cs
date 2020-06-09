﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public Text healthText;
    public Vector3 respawnPoint;

    public override void Awake()
    {
        base.Awake();
        onHurt.BindToEvent(Hurt);
        onDeath.BindToEvent(Death);
    }

    void Update()
    {
        //healthText.text = currentHealth.ToString("0");
    }

    void Start()
    {
        GameRestart();
    }

    void GameRestart()
    {
        respawnPoint = transform.position;
    }
    public void SetRespawnPoint(Transform transform)
    {
        respawnPoint = transform.position;
    }

    void Hurt(float param)
    {
        GameManager.gameManager.GameOver();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Enemy")
        {
            GameManager.gameManager.GameOver();
        }
    }

    void Death(float param)
    {
        //Respawn();
    }

    //void Respawn()
    //{
    //    transform.position = respawnPoint;
    //    currentHealth = maxHealth;
    //}
}
