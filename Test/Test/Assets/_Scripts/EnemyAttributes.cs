﻿using UnityEngine;
using System.Collections;

public class EnemyAttributes : MonoBehaviour
{
    public float enemyHealth = 150;
    public GameObject drop;

    private Color color;
    private float maxHealth;
    private float percLeft;

    // This script just changes the color of the enemy as it's health is diminished, will change later or use to update a health bar.

	// Use this for initialization
	void Start ()
    {
        maxHealth = enemyHealth;
        color = gameObject.GetComponent<MeshRenderer>().material.color;

        //print("R: " + color.r + " G: " + color.g + " B: " + color.b + " A: " + color.a + " t: " + (enemyHealth / maxHealth) + " Max: " + maxHealth + " Cur: " + enemyHealth);

        percLeft = enemyHealth / maxHealth;

        color = new Color(1 - percLeft, 1 - percLeft, color.b, color.a);

        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
	
    void OnCollisionEnter(Collision collision)
    {
        
    }

    public void IncreaseHealth(double newHealth)
    {
        maxHealth = (float)newHealth;
        enemyHealth = (float)newHealth;
    }

	// Update is called once per frame
	void Update ()
    {
        //print(enemyHealth);percLeft = enemyHealth / maxHealth;
        percLeft = enemyHealth / maxHealth;

        color = new Color(1 - percLeft, 1 - percLeft, color.b, color.a);

        //print("R: " + color.r + " G: " + color.g + " B: " + color.b + " A: " + color.a + " t: " + (enemyHealth/maxHealth) + " Max: " + maxHealth + " Cur: " + enemyHealth);

        gameObject.GetComponent<MeshRenderer>().material.color = color;

        // Enemy is dead.
        if (enemyHealth <= 0)
        {
            if(drop != null)
            {
                drop.transform.position = transform.position;
                GameObject newDrop = Instantiate(drop, transform.position, transform.rotation) as GameObject;
                newDrop.tag = "Pickup";
                newDrop.transform.position = transform.position;
                newDrop.GetComponent<Weapon>().SetPickup(true);

            }
            Destroy(gameObject);
        }
	}
}
