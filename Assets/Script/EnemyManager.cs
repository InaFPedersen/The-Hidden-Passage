using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    //Variables

    //Referensing player
    [Header("Player")]
    public Transform player;

    [Header("Enemies")]
    public bool ghostThreat = false;
    public List<EnemyStalker> enemyStalkerList;
    public bool isSpawning = true;
    [Range(0, 100)]
    public float spawnChance = 1f;
    public EnemyType type;

    [Header("Distance")]
    public float maxDistance;
    public float minDistance;

    [Header("SpawnChance")]
    public float elapsed = 0f;
    public float duration = 2f;

    [Header("EnemiesStats")]
    public float speed = 0.5f;
    public int damage;


    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Haunted")
        {
            if (isSpawning)
            {
                if (elapsed > duration)
                {
                    int roll = UnityEngine.Random.Range(0, 100);
                    if (roll <= spawnChance)
                    {
                        Vector3 spawnPos = new Vector3(UnityEngine.Random.value - 0.5f, 0, UnityEngine.Random.value - 0.5f).normalized
                                                                            * UnityEngine.Random.Range(minDistance, maxDistance);
                        spawnPos += player.position;

                        EnemyStalker enemyStalker = Instantiate(enemyStalkerList[UnityEngine.Random.Range(0, enemyStalkerList.Count - 1)], spawnPos, Quaternion.identity);
                        enemyStalker.Initialize(player, UnityEngine.Random.Range(2f, 5f));//her stilles speeden
                        elapsed = 0f;
                    }
                }
                elapsed += Time.deltaTime;
            }
        }
    }
 
    //Function that enables enemy type for enemyStalker script
    public void EnableEnemyType(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Ghost:
                ghostThreat = true;
                StartCoroutine(EnemyTimer(value => ghostThreat = value));
                break;
        }
    }

    //functions that make the enable enemy type last for 10 seconds
    public IEnumerator EnemyTimer(Action<bool> b)
    {
        yield return new WaitForSeconds(10);
        b(false);
    }
    //Collection of enemy type
    public enum EnemyType
    {
        Ghost
    }
}

