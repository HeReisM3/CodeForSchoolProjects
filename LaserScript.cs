using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float speed = 15f;
    public int damage = 40;
    public Rigidbody2D rb;
    //private Vector2 moveDirection;
    private SpriteRenderer _renderer;
    public float lifeTime = 2;

    //Laserin prefabissa kiinni oleva koodi, joka kuljettaa sitä annetulla nopeudella ammuttuun suuntaan. Flippaa prefabin tarvittaessa.

    void Start()
    {
        
        _renderer = GetComponent<SpriteRenderer>();

        if (PlayerControllerScript.dir < 0f)
            _renderer.flipX = true;

        if (PlayerControllerScript.dir > 0)
            rb.velocity = transform.right * speed;
        else if (PlayerControllerScript.dir < 0)
            rb.velocity = -transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        ObstacleScript obstacle = hitInfo.GetComponent<ObstacleScript>();
        if (obstacle != null)
            obstacle.TakeDamage(damage);

        Enemy_bySaija enemy = hitInfo.GetComponent<Enemy_bySaija>();
        if (enemy != null)
            enemy.TakingDamage(damage);

        Debug.Log("hit");
        Destroy(gameObject);
    }

    //Prefab tuhoutuu tietyn ajan kuluttua vaikkei osuisi mihinkään.
    private void Update() 
    {
        
        lifeTime -= Time.deltaTime;
        
        if ( lifeTime < 0 )
        {
            Destroy(gameObject);
        }
    }
}
