using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "StarProjectile")
        {
            Destroy(this.gameObject);
        }
    }
}
