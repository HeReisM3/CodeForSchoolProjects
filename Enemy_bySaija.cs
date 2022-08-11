using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Enemy_bySaija : MonoBehaviour
{
    public int health;
    public float moveSpeed;
    public GameObject detectionPoint;
    public GameObject detectionPoint2;
    public GameObject detectionPoint3;
    public Animator animator;

    [SerializeField] 
    private float direction;
    public static float enemyDir;


    [SerializeField]
    private bool changeDir;

    [SerializeField]
    private LayerMask groundLayer; 

    [SerializeField]
    private LayerMask playerDetection;
    private float attackTimer = 0.5f;
    private bool playerDetected = false;
    public Rigidbody2D rb;
    public static float animMoveSpeed;
    public static int animHealth;
    public AudioSource dying;
    

    private void Start() 
    {
       rb = GetComponent<Rigidbody2D>(); 
       animHealth = health;
       animMoveSpeed = moveSpeed;
    }

    
    void Update()
    {
        dying.volume = VolumeScript.soundVolume;
        animHealth = health;
        animMoveSpeed = moveSpeed;
        enemyDir = direction;
        transform.Translate(moveSpeed * Time.deltaTime * direction, 0, 0);
        transform.localScale = new Vector3(direction, 1, 1);
        
        if (playerDetected)
        {
            moveSpeed = 0f;
            attackTimer -= Time.deltaTime;

            if (attackTimer < 0.05f)
            {
                moveSpeed = 10;
            }
        }
        else if (!playerDetected)
        {
            moveSpeed = 2;
        }

        if (health <= 0)
        {
            dying.Play();
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            moveSpeed = 2f;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void LateUpdate()
    {
        Debug.DrawRay(detectionPoint2.transform.position, Vector2.right * direction * 7f, Color.red);
        RaycastHit2D hit3 = Physics2D.Raycast(detectionPoint2.transform.position, Vector2.right * direction, 7f, playerDetection);
        if (hit3.collider != null)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
            attackTimer = 0.5f;
        }

        Debug.DrawRay(detectionPoint2.transform.position, Vector2.left * direction * 2f, Color.yellow);
        RaycastHit2D hit4 = Physics2D.Raycast(detectionPoint3.transform.position, Vector2.left * direction, 2f, playerDetection);

        
        Debug.DrawRay(detectionPoint.transform.position, Vector2.down, Color.green);
        // Raycast alaspäi
        RaycastHit2D hit = Physics2D.Raycast(detectionPoint.transform.position, Vector2.down, 1, groundLayer);
        // vaihtaa suuntaa jos ray ei osu groundiin
        if(hit.collider == null && !PlayerControllerScript.playerRespawning)
        {
            ChangeDirection();
        }

        Debug.DrawRay(detectionPoint.transform.position, Vector2.right * direction * 0.2f, Color.blue);
        // Raycast eteenpäin
        RaycastHit2D hit2 = Physics2D.Raycast(detectionPoint.transform.position, Vector2.right * direction, 0.2f, groundLayer);
        // Jos säde osuu Ground-layerin objektiin, vaihtaa suuntaa
        if (hit2.collider != null)
        {
            ChangeDirection();
        }

        if ((hit4.collider != null && health > 0) && (!PlayerControllerScript.playerRespawning))
        {
            ChangeDirection();
            attackTimer = 0.1f;

        }
    }

    void ChangeDirection()
    {
        //Debug.Log("Suunnanvaihto");
        direction *= -1; // Kerrotaan suunta -1:llä jolloin suunta tulee aina olemaan joko 1 tai -1
    }

    public void Die()
    {
        moveSpeed = 0;
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(gameObject, 4);
    }

    public void TakingDamage(int damage)
    {
        health -= damage;
        
    }
}