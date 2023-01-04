using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [Header("Spawn Boundaries")]
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    [Header("Power Ups")]
    [SerializeField] GameObject HealthPowerupPrefab;

    [SerializeField] bool spawnHealth = false;
    Vector2 spawnLocation;

    void Start()
    {
        StartCoroutine(SpawnHealthPowerUp());
    }

    IEnumerator SpawnHealthPowerUp()
    {
        do
        {
            yield return new WaitForSecondsRealtime(5);

            if(Random.Range(1,10) == 1)
            {
                spawnLocation = new Vector2(Random.Range(minX,maxX), Random.Range(minY, maxY));
                GameObject powerup = Instantiate(HealthPowerupPrefab, spawnLocation, Quaternion.identity);

                Destroy(powerup, 2);
            }
        }while(spawnHealth);
    }
}
