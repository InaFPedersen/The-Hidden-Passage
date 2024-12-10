using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemies : MonoBehaviour
{
    //Variables
   
    [Header("Player")]
    private Transform player;
    public PlayerController damage;
   
    [Header("Enemies")]
    public EnemyType type;
    public float speed = 0.05f;
    public int index;
    private Transform target;

    [Header("Enemy Checkpoint List")]
    public List<Transform> checkpoints = new List<Transform>();

    //Function that moves the enemy
    public void MoveEnemy()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //Function that checks the distance between enemy and next target checkpoint
    public void CheckDistance()
    {
        if (Vector3.Distance(transform.position, checkpoints[index].transform.position)< 1)
        {
            NextWayPoint();
        }
    }

    //Function that finds the checkpoints for the enemy movement
    public void NextWayPoint()
    {
        if(index < checkpoints.Count - 1)
        {
            target = checkpoints[index + 1];
            index++;
        }
        else
        {
            index = 0;
            target = checkpoints[index];
        }
    }
   
    void Start()
    {
        index = 0;
        target = checkpoints[index];
        
    }


    void Update()
    {
        CheckDistance();
        MoveEnemy();
    }

    //Function that runs when player collide with the enemies collider
    public void OnCollisionEnter(Collision collision)
    {
        //ifsetninger som sjekker hvilken bane spilleren er i
        if (SceneManager.GetActiveScene().name == "Magical")
        {
            if(collision.gameObject.tag == "Player")
            {
                Vector3 force = collision.contacts[0].normal;
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                rb.AddForce((-force * 400) + (Vector3.up * 500));
                LoseHealth();
            }
        }
        else if (SceneManager.GetActiveScene().name == "Fortress")
        {
            if (collision.gameObject.tag == "Player")
            {
                Vector3 force = collision.contacts[0].normal;
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                rb.AddForce((-force * 200) + (Vector3.up * 200));
                LoseHealth();
            }
        }
        else if (SceneManager.GetActiveScene().name == "Haunted")
        {
            if (collision.gameObject.tag == "Player")
            {
                Vector3 force = collision.contacts[0].normal;
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                rb.AddForce((-force * 400) + (Vector3.up * 500));
                LoseHealth();
            }
        }
    }

    //Function for how much health you loose from what enemy
    public void LoseHealth()
    {
        switch (type)
        {
            case EnemyType.BrownMouse:
                damage.TakeDamage(6); 
                break;
            case EnemyType.GrayRat:
                damage.TakeDamage(8);
                break;
            case EnemyType.Zombie:
                damage.TakeDamage(7); 
                break;
            case EnemyType.PoisonMushroom:
                damage.TakeDamage(5);
                break;

        }
        
    }
    
}
//Collection of enemy types
public enum EnemyType
{
    BrownMouse,
    Zombie,
    GrayRat,
    PoisonMushroom,
    Ghost
}


