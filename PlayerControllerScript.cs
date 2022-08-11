using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControllerScript : MonoBehaviour
{
    public PlayerStats stats;
    public Image filler;
    public float counter;
    public float maxCounter;
    [HideInInspector] public Rigidbody2D rb;
    private Vector2 moveDirection;
    public static float dir = 1f;
    public Transform groundCheck1, groundCheck2;//näihin raahataan GrounCheck -objektit Unityssa, ja näiden positionit syötetään FixedUpdatessa parametreina OverlapCircle -funktioon
    [SerializeField] private LayerMask jumpableGround;//Unityssa valitaan tähän layer, jolta tsekataan ollaanko grounded - meillä se on layer Unityssa nimeltä Ground
    public GameObject laserDirection;
    public float lowJumpMultiplier = 2;
    public float fallMultiplier = 2.5f;
    [SerializeField] private AudioSource pickupEnergy;
    [SerializeField] private AudioSource energyBar;
    private Vector3 respawnPoint;
    private bool attackedbyEnemy = false;
    public float slideTimer = 0.3f;
    public int lifeCounter = 3;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public static bool playerRespawning = false;
    public static bool playerTakeDmg = false;
    
    private void Start()
    {
        Application.targetFrameRate = 100;
        rb = GetComponent<Rigidbody2D>();
        dir = 1f;//tämä on startissa siitä syystä, ettei tasoa uudelleen ladattaessa tulisi ampumiseen suuntaongelmia. Älä poista.
        respawnPoint = transform.position;
    }

    private void FixedUpdate() 
    {
        Vector2 force = new Vector2(moveDirection.x * stats.moveSpeed - rb.velocity.x, 0f);
        rb.AddForce(force, ForceMode2D.Impulse);
        stats.isGrounded1 = Physics2D.OverlapCircle(groundCheck1.position, 0.1f, jumpableGround);//OverlapCircle luo ympyrän, jotta voidaan tsekkaa koskettaako se maahan vai ei
        stats.isGrounded2 = Physics2D.OverlapCircle(groundCheck2.position, 0.1f, jumpableGround);//parametreina GroundCheckien positionit, ympyrän säteen pituus ja layerMask
        //säteen pituutta voi tästä muokata ja testailla mikä olisi paras
    }

    private void Update()
    {

        if (ConsoleScript.talkingToConsole)
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        if (!ConsoleScript.talkingToConsole)
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        playerTakeDmg = false;
        pickupEnergy.volume = VolumeScript.soundVolume;
        energyBar.volume = VolumeScript.soundVolume + 0.035f;

        if (counter > maxCounter && Input.GetAxis("Horizontal") != 0)
            stats.energy -= 1;
        //energia laskee joka maxCounterilla määritellyn ajan yhellä pointilla vain liikkeessä. Inspectorista voi muuttaa maxCounterin arvoa.

        if (Input.GetButtonDown("Fire1") && PauseMenuScript.gameIsPaused == false)
        {
            stats.energy -= 5f;//ampuessa energia laskee 10 pojoo
        }

        Vector3 pos = Camera.main.WorldToScreenPoint(laserDirection.transform.position);
        Vector3 direc = Input.mousePosition - pos; //suuntavektori laserin lähtöpaikasta kohti hiiren sijaintia
        float angle = Mathf.Atan2(direc.y * transform.localScale.x, direc.x * transform.localScale.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -60, 60);
        laserDirection.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetAxis("Horizontal") > 0f)
            dir = 1f;
        else if (Input.GetAxis("Horizontal") < 0f)
            dir = -1f;


        moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0f); //tämä hoiti automaattisesti painetaanko vasenta vai oikeaa
        HandleFlipping();
        if (Input.GetButtonDown("Jump") && stats.isGrounded1 || Input.GetButtonDown("Jump") && stats.isGrounded2)
            HandleJumping();//jos painetaan jump-buttonia JA isGrounded1 on true TAI painetaan jump JA isGrounded2 on true.. niin vain silloin voidaan kutsua hyppy-funktiota.
        
        //tuunataan hyppyä tunnilla tehtyjen juttujen avulla
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier -1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier -1) * Time.deltaTime;
        }

        //energiabar
        if (counter > maxCounter)
        {
            stats.previousEnergy = stats.energy;
            counter = 0;
        }
        else
            counter += Time.deltaTime;

        filler.fillAmount = Mathf.Lerp(stats.previousEnergy / stats.maxEnergy, stats.energy / stats.maxEnergy, counter / maxCounter);

        //elämät
        if (lifeCounter == 3)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }

        if (lifeCounter < 3)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(false);
        }

        if (lifeCounter < 2)
        {
            life1.SetActive(true);
            life2.SetActive(false);
        }

        if (lifeCounter < 1)
            life1.SetActive(false);

        if (stats.energy <= 0 && lifeCounter != 0)
        {
            playerRespawning = true;
            PlayerDeath();
            StartCoroutine("WaitTimeRespawn");
            lifeCounter = lifeCounter - 1;
            stats.energy = 200f;
        }
        else if
            (stats.energy <= 0 && lifeCounter == 0)
            {
                RestartLevel();
            }
            
        //mobihyökkäystä
        if (attackedbyEnemy)//silloin kun mobi chargee pelaajaan niin pelaajan box collider menee hetkeks pois (vältetään colliderien friction joka oli ongelmana)
        {
            //GetComponent<BoxCollider2D>().enabled = false;
            slideTimer -= Time.deltaTime;
            transform.Translate(stats.moveSpeed * 3 * Time.deltaTime * Enemy_bySaija.enemyDir, 0.05f, 0);//pelaaja liikkuu mobin chargeemaan suuntaan
        }

        //if (slideTimer < 0.2f)
            //GetComponent<BoxCollider2D>().enabled = true;

        if (slideTimer < 0.1f)//jos slidetimer on <0.1f pelaajan liike loppuu
        {
            slideTimer = 0.3f;
            transform.Translate(stats.moveSpeed / 3 * Time.deltaTime * Enemy_bySaija.enemyDir, -0.05f, 0);
            attackedbyEnemy = false;
        }
    }


    private void HandleFlipping()
    {
        if (!ConsoleScript.talkingToConsole)
        {
            if (moveDirection.x == 0f)
                return;

            transform.localScale = new Vector3(Mathf.Sign(moveDirection.x), 1f, 1f);
        }
    }


    private void HandleJumping()
    {
       if (stats.isGrounded1 == false && stats.isGrounded2 == false) return;
        Debug.Log("Force " + stats.jumpForce);
        rb.AddForce(Vector2.up * stats.jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Acid") && stats.energy != 0 && lifeCounter != 0)
        {
            if (!playerTakeDmg)
            {
                playerTakeDmg = true;
            }

            lifeCounter = lifeCounter - 1;
            //stats.energy = 200f;
            PlayerDeath();
            StartCoroutine("WaitTimeRespawn");
        }
        else if (collision.gameObject.CompareTag("Acid") && stats.energy != 0 && lifeCounter == 0)
        {
            RestartLevel();
        }

        if (collision.gameObject.CompareTag("Enemy") && stats.energy != 0)
        {
            playerTakeDmg = true;
            Debug.Log("vihu osu");
            stats.energy -= 80;
            attackedbyEnemy = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Energy"))
        {
            pickupEnergy.Play();
            energyBar.Play();
            stats.previousEnergy = filler.fillAmount * stats.maxEnergy;
            counter = 0;
            stats.energy += 100f;
            if (stats.energy > 200)
            {
                if (lifeCounter == 3)
                    stats.energy = 200f;
                else if (lifeCounter != 3)
                {
                    stats.energy = stats.energy - 200f;
                    lifeCounter++;
                }
            }
        }
        else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
            //stats.respawnEnergy = stats.energy;
        }
    }

    IEnumerator WaitTimeRespawn()
    {
        yield return new WaitForSecondsRealtime(1);
        //stats.energy = 200f;
        RespawnCheckpoint();
    }

    // IEnumerator WaitTimeDeath()
    // {
    //     yield return new WaitForSecondsRealtime(1);
    //     RestartLevel();
    // }

    public void PlayerDeath()
    {
        Debug.Log("Respawnaat");
        GetComponent<BoxCollider2D>().enabled = false;
        stats.moveSpeed = 0;
        //stats.energy = 0;
        //Destroy(gameObject, 3);
    }

    private void RespawnCheckpoint()
    {
        stats.moveSpeed = 7f;
        stats.energy = 200f;
        GetComponent<BoxCollider2D>().enabled = true;
        transform.position = respawnPoint;
        playerTakeDmg = false;
        playerRespawning = false;
        //stats.energy = stats.respawnEnergy;
    }

    private void RestartLevel()
    {
        playerTakeDmg = false;
        SceneManager.LoadScene("Death");;
    }
}
