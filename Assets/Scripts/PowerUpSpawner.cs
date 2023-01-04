using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Spawn Boundaries")]
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    [Header("Power Ups")]
    [SerializeField] GameObject HealthPowerupPrefab;
    [SerializeField] float powerupLifetime = 5f;

    [SerializeField] bool spawnHealth = false;

    Vector2 spawnLocation;

    float randomLowerValue = 1;
    float randomUpperValue = 5;

    float playerMaxHealth;
    Health health;

    void Awake()
    {
        health = FindObjectOfType<Player>().GetComponentInParent<Health>();
    }

    void Start()
    {
        StartCoroutine(SpawnHealthPowerUp());
        playerMaxHealth = health.GetHealth();
        Debug.Log(playerMaxHealth);
    }

    void Update()
    {
        if(health.GetHealth() < 0.3 * playerMaxHealth)
        {
            randomUpperValue = 2;
            
        }
        else
        {
            randomUpperValue = 5;
        }
    }

    IEnumerator SpawnHealthPowerUp()
    {
        do
        {
            yield return new WaitForSecondsRealtime(2);

            if(Random.Range(randomLowerValue,randomUpperValue) == 1)
            {
                spawnLocation = new Vector2(Random.Range(minX,maxX), Random.Range(minY, maxY));
                Debug.Log(spawnLocation);
                GameObject powerup = Instantiate(HealthPowerupPrefab, spawnLocation, Quaternion.identity);

                Destroy(powerup, powerupLifetime);
            }
        }while(spawnHealth);
    }
}
