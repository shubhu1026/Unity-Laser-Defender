using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    [SerializeField] int healthAmount;
    
    Health health;
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            health = other.GetComponent<Health>();

            health.HealthPowerUpPickup(healthAmount);

            Destroy(gameObject);
        }
    }
}
