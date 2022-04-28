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
    public bool isAlive{get; private set;}
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<Movement>();
        fightingScript = GetComponent<Fighting>();
        animator = GetComponent<Animator>();
        health = maxhealth;
        isAlive = true;
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
       if(isAlive == true)
       {
            animator.SetTrigger("Die");
            isAlive = false;
       }
    }

    public void TakeDamage(float damage)
    {

        if(isAlive == false)
        {
            return;
        }

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
