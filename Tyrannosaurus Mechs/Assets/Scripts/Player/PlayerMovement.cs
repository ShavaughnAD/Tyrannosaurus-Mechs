﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    Health playerHealth;
    public enum Ability
    {
        Shield, Speedy, Chomp
    }
    public Ability ability;
    public Rigidbody2D playerRB;
    public float moveSpeed = 5;
    public float idleSpeed = 1;

    public float coolDownTimer = 10;
    public float weaponDamage = 10;

    public float abilityActiveTime = 2;

    float defaultMoveSpeed;
    float cooldown;
    bool skillReady = true;

    //A bad way to check this but it works for now. Optimize later maybe
    bool shieldAbility = false;
    bool chompAbility = false;
    bool speedyAbility = false;

    public GameObject shield;
    public GameObject chomp;

    public string shipName;
    [TextArea]
    public string shipDescription;

    bool autoMove = false;

    #endregion

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<Health>();
    }

    void Start()
    {
        cooldown = coolDownTimer;
        autoMove = true;
        defaultMoveSpeed = moveSpeed;
        if(shield != null)
        {
            shield.SetActive(false);
        }
        if(chomp != null)
        {
            chomp.SetActive(false);
        }
    }

    public virtual void Update()
    {
        #region Movement Input

        if (autoMove)
        {
            playerRB.transform.Translate(Vector2.up *  idleSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            playerRB.transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            autoMove = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerRB.transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            autoMove = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRB.transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            autoMove = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRB.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            autoMove = false;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            autoMove = true;
        }


        #endregion

        #region Ability

        if (cooldown != coolDownTimer)
        {
            cooldown += 1 * Time.deltaTime;
            if(cooldown >= coolDownTimer)
            {
                cooldown = coolDownTimer;
                skillReady = true;
            }
        }

        if (skillReady)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AbilityUsage();
            }
        }

        #endregion

    }

    public void AbilityUsage()
    {
        skillReady = false;
        cooldown = 0;
        switch (ability)
        {
            case Ability.Shield:
                shieldAbility = true;
                shield.SetActive(true);
                playerHealth.immune = true;
                Invoke("StopAbility", abilityActiveTime);
                break;

            case Ability.Speedy:
                speedyAbility = true;
                moveSpeed += 3;
                Invoke("StopAbility", abilityActiveTime);
                break;

            case Ability.Chomp:
                chompAbility = true;
                chomp.SetActive(true);
                playerHealth.immune = true;
                Invoke("StopAbility", abilityActiveTime);
                break;

        }
    }

    void StopAbility()
    {
        if (shieldAbility)
        {
            if(shield != null)
            {
                shield.SetActive(false);
            }
            playerHealth.immune = false;
        }
        if (chompAbility)
        {
            if(chomp != null)
            {
                chomp.SetActive(false);
            }
            playerHealth.immune = false;
        }
        if (speedyAbility)
        {
            moveSpeed = defaultMoveSpeed;
        }
    }
}
