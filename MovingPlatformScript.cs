using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
//using UnityEditorInternal;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float speed = 2;
    public int startingPoint;
    public Transform[] points;
    private int i;
    //Platform liikkuu kahden määritellyn pisteen välillä säädetyllä nopeudella. Pisteet on sisällytetty arrayhin.
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
            {
                i++;
                if (i == points.Length)
                    i = 0;
            }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    //Pelaaja-hahmosta tulee platformin child-objekti platformille hypättäessä, jotta se liikkuu platformin mukana.

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (transform.position.y < collision.transform.position.y - 2f)
        {
            collision.transform.SetParent(transform);
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision) 
    {
        collision.transform.SetParent(null);
    }
}
