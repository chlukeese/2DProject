using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float Runspeed = 6f;
    private Rigidbody2D rb;
    private bool facingRight;
    private Collider2D cc;
    public Collider2D[] collider; //Ground check
    bool isKicking = false;
    private int currentHealth;
    private int totalHealth;
    private GameObject player;
    // Start is called before the first frame update
    public PlayerMovement()
    {
        totalHealth = 10;
        currentHealth = totalHealth;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        totalHealth = 10; //Sets total health
        currentHealth = totalHealth;
        cc = GetComponent<CapsuleCollider2D>(); //Gets local capsule collider on Player
        facingRight = true; // sets players starting rotation
        rb = GetComponent<Rigidbody2D>(); //Gets local Rigidbody 2D on player
    }
    void Update()
    {
        Buttons();
        if (GameObject.FindGameObjectWithTag("Heart") == null)
        {
            Application.LoadLevel(Application.loadedLevel);
            Destroy(player);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); // values -1 - 1 for x-axis movement
        HandleMovement(horizontal);
        
       
    }
    public void loseHealth()
    {
        currentHealth--;
        if (currentHealth == 0)
        {
            Destroy(player);
        }
    }
    private void Buttons()
    {
        if (Input.GetButtonDown("Fire1")) // Checks for left mouse button
        {
            isKicking = true;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && cc.GetContacts(collider) != 0) // Checks for Space button and Ground Check
        {
            Jump();
        }
    }
    private void HandleMovement(float horizontal)
    {
            
            rb.velocity = new Vector2(horizontal * Runspeed, rb.velocity.y); // sets x-axis movement
             Flip(horizontal);

    }
    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) // Checks for x-axis movement input
        {
            facingRight = !facingRight;

            if (facingRight)
            {
                transform.localRotation = new Quaternion(0f, 0f, 0f,1f); // sets Player facing right
            }
            else
            {
                transform.localRotation = new Quaternion(0f, 180f, 0f,1f); // sets Player facing left
                
            }
        }
    }
    private void Jump()
    {
        
        rb.AddForce(new Vector2(1f,1000f)); // adds 1000f force to current player force
    }
}
