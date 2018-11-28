using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    public int health;
    public string state;

    public void atakeDamage(int amount)
    {
        health -= amount;
       // Debug.Log("Player health: " + this.health);
        this.state = "aggro";
        //        healthbar.updateHealth(health, maxHealth);
    }

}
