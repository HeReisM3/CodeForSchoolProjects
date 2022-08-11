using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAnimations : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy_bySaija.animMoveSpeed < 2 && Enemy_bySaija.animHealth > 0)
            anim.SetBool("idle", true);
        else
            anim.SetBool("idle", false);
        
        if (Enemy_bySaija.animMoveSpeed == 2 && Enemy_bySaija.animHealth > 0)
            anim.SetBool("walk", true);
        else
            anim.SetBool("walk", false);
        
        if (Enemy_bySaija.animMoveSpeed > 2)
            anim.SetBool("attack", true);
        else
            anim.SetBool("attack", false);

        if (Enemy_bySaija.animHealth <= 0)
        {
            anim.SetBool("death", true);
            anim.SetBool("idle", false);
        }
        
    }
}
