using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarProjectile : MonoBehaviour
{ 
    Rigidbody2D rb;
    [SerializeField] GameObject collectable;
    [SerializeField] float speed = 20f;
    [SerializeField] float postBounceGravityScale = 1f;
    [SerializeField] float postBounceLinearDrag = 2f;
    [SerializeField] float postBounceSpeed = 10f;
    [SerializeField] float upTrend = 1f;
    [SerializeField] GameObject bounceEffect;
    private string[] soundNames;
    private AudioManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("MainAudioManager").GetComponent<AudioManager>();
        soundNames = new string[3];
        soundNames[0] = "Rebound1";
        soundNames[1] = "Rebound2";
        soundNames[2] = "Rebound3";
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string soundName = soundNames[UnityEngine.Random.Range(0, soundNames.Length)];
        manager.PlayOneShot(soundName);
        if (bounceEffect != null)
            Instantiate(bounceEffect, transform.position, Quaternion.identity);
        collectable.SetActive(true);
        rb.gravityScale = postBounceGravityScale;
        rb.drag = postBounceLinearDrag;
        rb.velocity = rb.velocity.normalized * postBounceSpeed + Vector2.up * upTrend;
        Destroy(this);
    }
}
