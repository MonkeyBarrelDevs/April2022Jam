using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : MonoBehaviour
{
    private AudioManager manager; 
    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("MainAudioManager").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (manager != null)
                manager.PlayOneShot("StarPickup");
            col.gameObject.GetComponent<StargunController>().increaseAmmo();
            Destroy(this.gameObject);
        }
    }
}