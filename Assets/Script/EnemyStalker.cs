using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStalker : MonoBehaviour
{
    //Variables
    [Header("Direction")]
    private Vector3 angle;
    private Vector3 targetDirection;

    [Header("Player")]
    private Transform player;

    [Header("Enemies")]
    public EnemyType type;
    public float speed = 0.2f;

    public void Initialize(Transform p, float s)
    {
        angle.x = Random.Range(0.1f, 100f);
        angle.y = Random.Range(0.1f, 100f);
        angle.z = Random.Range(0.1f, 100f);
        
        player = p;
        speed = s;
        
        targetDirection = (player.position - transform.position).normalized;
    }

    void Update()
    {
        transform.Rotate(angle * Time.deltaTime);
        transform.position += targetDirection * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, player.position) > 50)
        {
            Destroy(this.gameObject);
        }
    }

    // Runs in the first frame the player enter collider that isTrigger (takes 5 damage)
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(5);
        }
    }

     //Function that takes 1 damage every frame the player stay inside a ghost
    public void OnTriggerStay(Collider other)
    {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(1);
     }
}