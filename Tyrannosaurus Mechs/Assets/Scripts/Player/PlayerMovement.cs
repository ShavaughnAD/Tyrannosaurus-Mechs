using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public float moveSpeed = 5;

    bool autoMove = false;

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        autoMove = true;
    }

    void Update()
    {
        if (autoMove)
        {
            playerRB.transform.Translate(Vector2.up * .5f * Time.deltaTime);
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
    }
}
