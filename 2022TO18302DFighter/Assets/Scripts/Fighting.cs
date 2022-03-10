using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    public float punchDamage = 2f;
    public float kickDamage = 3f;
    public bool blockCheck = false;
    public Transform punchCheck;
    public Transform kickCheck;
    public float range = 1.7f;
    public LayerMask enemyLayer;
    public float cooldown = 0.25f;

    private float cooldownTimer;
    private bool attacking = false;
    private bool hit = false;
    private int chooser;
    Health healthScript;
    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack(Transform check, float damage)
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(check.position,range,enemyLayer);
        if(enemyHit != null)
        {
            foreach(Collider2D enemy in enemyHit)
            {
                if(enemy.gameObject != this.gameObject){
                    enemy.GetComponent<Health>().TakeDamage(damage);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(punchCheck.position,range);
        Gizmos.DrawWireSphere(kickCheck.position,range);
        
    }
}
