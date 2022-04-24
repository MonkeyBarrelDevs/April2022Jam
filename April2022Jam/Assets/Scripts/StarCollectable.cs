using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<StargunController>().increaseAmmo();
            Destroy(transform.parent.gameObject);
        }
    }
}