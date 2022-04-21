 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxhealth = 100;
    public float health;
    private float hitTimer = 0.15f;
    public bool isHit = false;
    public Rigidbody2D myRigidbody;
    Movement moveScript;
    Fighting fightingScript;
    private float damage;
    public bool isDummy;
    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<Movement>();
        fightingScript = GetComponent<Fighting>();
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
       //Tee kuoleminen
    }

    public void TakeDamage(float damage)
    {
        if(!isHit)
        {
            if(fightingScript.blockCheck)
            {
                health -= damage/2;
            }
            else
            {
                health -= damage;
                StartCoroutine(Knockback());
            }
            Debug.Log("Health: " + health);
        }
    }

    IEnumerator Knockback()
    {
        //Käskyt välittömästi
        isHit = true;
        myRigidbody.velocity = new Vector2(moveScript.facing * -2.5f, 2.5f);
        //laskuri
        yield return new WaitForSeconds(hitTimer);
        //Ajastimen jälkeen tapahtuvat käskyt
        isHit = false;
    }
}
