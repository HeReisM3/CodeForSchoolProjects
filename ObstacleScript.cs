using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public GameObject drop;
    public int health = 100;
    public GameObject deathEffect;
    private Animator anim;
    private bool laserHit = false;

    private void Start() 
    {
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        if (laserHit)
            anim.SetBool("takeDamage", true);
        else
            anim.SetBool("takeDamage", false);
        
        laserHit = false;
    }

    public void TakeDamage (int damage)
    {
        health -= damage;
        laserHit = true;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        drop.SetActive(true);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
