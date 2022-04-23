using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : MonoBehaviour
{
    StargunController stargun;
    void Start()
    {
        stargun = FindObjectOfType<StargunController>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            stargun.increaseAmmo();
            Destroy(transform.parent.gameObject);
        }
    }
}