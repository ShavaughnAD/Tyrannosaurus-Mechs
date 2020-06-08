using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Health playerHealth;
    public Rigidbody2D playerRB;
    public float moveSpeed = 5;
    public float idleSpeed = 1;

    public float coolDownTimer = 10;
    public float weaponDamage = 10;

    float cooldown;
    bool skillReady = true;
    public GameObject shield;

    public string shipName;
    [TextArea]
    public string shipDescription;

    bool autoMove = false;

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<Health>();
    }

    void Start()
    {
        cooldown = coolDownTimer;
        autoMove = true;
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

        if(cooldown != coolDownTimer)
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
                Ability();
            }
        }

    }

    public void Ability()
    {
        skillReady = false;
        shield.SetActive(true);
        playerHealth.immune = true;
        cooldown = 0;
    }
}
