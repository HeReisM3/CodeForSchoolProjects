using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesScript : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.5f, 205f), Mathf.Clamp(transform.position.y, -10f, 100f), transform.position.z);
        //näitä ^ arvoja muuttamalla voi suurentaa tai pienentää pelaajan aluetta
    }
}
