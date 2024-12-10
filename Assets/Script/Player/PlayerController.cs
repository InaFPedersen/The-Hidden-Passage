using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Variables:

    [Header("Player")]
    private Rigidbody rigidBody;
    private Quaternion newRotation;

    [Header("PlayerMovement")]
    public Vector3 newPosition;
    public float speed;             // Represent how fast the player moves. Adjust inside the Inspector
    private bool jump = false;
    public float rotateSpeed = 30.0f;
    public float jumpHeight = 500f;
    public Transform mainCharacter;
    public float sprintSpeed = 0.1f;
    [Header("PlayerLight")]
    public Light playerLight;

    [Header("PlayerLife")]
    public int maxHealth = 100; 
    public int currentHealth;
    public HealthBar healthBar;

    [Header("PlayerXP")]
    public int startXP = 0; 
    public int currentXP;
    public ExpBar xpBar;


    // Start is called before the first frame update
    public void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        rigidBody = GetComponent<Rigidbody>();

        // Setting stats for player's health bar 
        currentHealth = maxHealth; // sette inn i if for sjekk dersom liv skal følge scenene
        healthBar.SetMaxHealth(maxHealth);

        // Start setting for player's xp
        currentXP = startXP;
        xpBar.SetStartXP(startXP);
    }

    // Update is called once per frame
    void Update()
    {
       PlayerMovement();


        // Player Light
        // activating extra light to function as a flashlight for the player if playerLight is not active
        if (Input.GetKeyDown(KeyCode.F) && playerLight.enabled == false)
        {
            playerLight.enabled = true;
            // checking if light is active, then deactivate the light inside the player if active
        }
        else if (Input.GetKeyDown(KeyCode.F) && playerLight.enabled == true)
        {
            playerLight.enabled = false;
        }

    }

    private void FixedUpdate()
    {
        if (jump)
        {
            rigidBody.AddForce(transform.up * jumpHeight);
            jump = false;
        }
    }
    
    //Player controlls and keykodes
    public void PlayerMovement()
    {
        

        newRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            newPosition -= transform.right * speed;
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPosition += transform.right * speed;
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            newPosition += transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPosition -= transform.forward * speed;
        }

        //Move jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        //Sprint
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            newPosition += transform.forward * sprintSpeed;
        }

        newPosition.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
    }

    // Function to change players health and displayed health in health bar when taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene((int)Scenes.GameOver);
        }
    }

    //Function to gain health from potions
    public void GainHealth(int healing)
    {
        currentHealth += healing;
        healthBar.SetHealth(currentHealth);

        if (currentHealth >= 100)
        {
            healthBar.SetHealth(maxHealth); 
        }
    }

    //Function to collect experience points into the exp bar
    public void GetExperiencePoints(int experience)
    {
        currentXP += experience;
        xpBar.SetXP(currentXP); 
    }

    //Collection of scenes
    public enum Scenes
    {
        MainMenu,
        Lobby,
        Fortress,
        Magical,
        Haunted,
        GameOver,
        Victory
    }
}
