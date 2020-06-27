using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    Health playerHealth;
    public enum Ability
    {
        Shield, Speedy, Chomp, Blink
    }
    public Ability ability;
    public Rigidbody2D playerRB;
    public float moveSpeed = 5;
    float idleSpeed = 1;

    public float coolDownTimer = 10;
    public float weaponDamage = 10;

    public float abilityActiveTime = 2;

    float defaultMoveSpeed;
    float cooldown;
    public bool skillReady = true;

    bool shieldAbility = false;
    bool chompAbility = false;
    bool speedyAbility = false;

    public GameObject shield;
    public GameObject chomp;

    public AudioClip skillSoundEffect;
    [HideInInspector] public AudioSource auSource;

    public ParticleSystem muzzleFlash;

    public Animator chompAnim;

    public string shipName;
    [TextArea]
    public string shipDescription;

    public Image abilityIcon;

    bool autoMove = false;

    #endregion

    void Awake()
    {
        auSource = GetComponent<AudioSource>();
        if(auSource == null)
        {
            Debug.LogError("Audio Source was null, adding one to " + gameObject.name);
            gameObject.AddComponent<AudioSource>();
            auSource = GetComponentInChildren<AudioSource>();
        }
        auSource.clip = skillSoundEffect;
        playerRB = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<Health>();
        abilityIcon = GameObject.FindGameObjectWithTag("AbilityIcon").GetComponent<Image>();
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
            if(chompAnim == null)
            {
                chompAnim = GetComponentInChildren<Animator>();
            }
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

        if(abilityIcon != null)
        {
            abilityIcon.fillAmount = cooldown / coolDownTimer;
        }

        cooldown += 1 * Time.deltaTime;
        if (cooldown >= coolDownTimer)
        {
            cooldown = coolDownTimer;
            skillReady = true;
        }

        if (Input.GetKey(KeyCode.Space) && skillReady == true)
        {
            AbilityUsage();
        }

        #endregion

    }

    public void AbilityUsage()
    {
        switch (ability)
        {
            case Ability.Shield:
                shieldAbility = true;
                shield.SetActive(true);
                playerHealth.immune = true;
                Invoke("StopAbility", abilityActiveTime);
                skillReady = false;
                cooldown = 0;
                break;

            case Ability.Speedy:
                speedyAbility = true;
                moveSpeed += 3;
                Invoke("StopAbility", abilityActiveTime);
                skillReady = false;
                cooldown = 0;
                break;

            case Ability.Chomp:
                chompAbility = true;
                chomp.SetActive(true);
                playerHealth.immune = true;
                chompAnim.SetBool("Crunch", true);
                Invoke("StopAbility", abilityActiveTime);
                break;

            case Ability.Blink:

                break;

        }
        auSource.PlayOneShot(skillSoundEffect);
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
            skillReady = false;
            cooldown = 0;
            if (chomp != null)
            {
                chomp.SetActive(false);
            }
            playerHealth.immune = false;
        }
        if (speedyAbility)
        {
            moveSpeed = defaultMoveSpeed;
        }

        CancelInvoke();
    }
}
