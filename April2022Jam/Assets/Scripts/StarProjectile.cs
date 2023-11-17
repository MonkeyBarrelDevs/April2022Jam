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

    /// <summary>
    /// Handles changing the star gameobject from its prebounce to postbounce state.
    /// </summary>
    void OnCollisionEnter2D(Collision2D col)
    {
        // Trigger the SFX and VFX.
        string soundName = soundNames[UnityEngine.Random.Range(0, soundNames.Length)];
        manager.PlayOneShot(soundName);
        if (bounceEffect != null)
            Instantiate(bounceEffect, transform.position, Quaternion.identity);

        // Sets up the gameobject for postbounce.
        collectable.SetActive(true);
        rb.gravityScale = postBounceGravityScale;
        rb.drag = postBounceLinearDrag;
        rb.velocity = rb.velocity.normalized * postBounceSpeed + Vector2.up * upTrend;

        // This component has served its purpose and can be safely removed.
        Destroy(this);
    }
}
