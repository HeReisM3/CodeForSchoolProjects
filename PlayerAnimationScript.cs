using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    private Animator anim;
    public bool jumpCheck1, jumpCheck2;
    public Transform jumpChecker1, jumpChecker2;
    public LayerMask jumpCheckLayer;
    [SerializeField] private AudioSource runSound;
    private bool isRunning;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate() 
    {
        jumpCheck1 = Physics2D.OverlapCircle(jumpChecker1.position, 0.45f, jumpCheckLayer);    
        jumpCheck2 = Physics2D.OverlapCircle(jumpChecker2.position, 0.45f, jumpCheckLayer);    
    }

    void Update()
    {
        runSound.volume = VolumeScript.soundVolume + 0.005f;

        if (PlayerControllerScript.playerTakeDmg == true)
            anim.SetTrigger("takeDamage");

        if (Input.GetButton("Fire1") && Time.timeScale != 0)
            anim.SetTrigger("shoot");
        
        if (jumpCheck1 == false || jumpCheck2 == false)
            anim.SetBool("isJumping", true);

        else if (jumpCheck1 == true || jumpCheck2 == true)
            anim.SetBool("isJumping", false);
        
        if (!ConsoleScript.talkingToConsole)
        {

            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && (jumpCheck1 == true || jumpCheck2 == true)) || (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && (jumpCheck1 == true || jumpCheck2 == true)))
            {
                anim.SetBool("isRunning", true);
                isRunning = true;
            }
            else
            {
                anim.SetBool("isRunning", false);
                isRunning = false;
            }

            if (isRunning)
            {
                if (!runSound.isPlaying)
                    runSound.Play();
            }
            else
                runSound.Stop();

            if (!jumpCheck1 && !jumpCheck2)
                runSound.Stop();
        }
        else if (ConsoleScript.talkingToConsole)
        {
            anim.SetBool("isRunning", false);
            runSound.Stop();
        }
    }
}