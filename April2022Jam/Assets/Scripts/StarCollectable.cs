using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : MonoBehaviour
{
    [SerializeField] GameObject collectEffect;
    private AudioManager manager; 
    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("MainAudioManager").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (collectEffect != null)
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            if (manager != null)
                manager.PlayOneShot("StarPickup");
            col.gameObject.GetComponent<StargunController>().increaseAmmo();
            Destroy(this.gameObject);
        }
    }
}