using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarProjectile : MonoBehaviour
{ 
    Rigidbody2D rb;
    Collider2D starCollider;
    [SerializeField] GameObject collectable;
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        starCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        collectable.SetActive(true);
        rb.gravityScale = 1;
        Destroy(this);
    }
}
