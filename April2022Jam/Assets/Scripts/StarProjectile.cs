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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        collectable.SetActive(true);
        rb.gravityScale = postBounceGravityScale;
        rb.drag = postBounceLinearDrag;
        rb.velocity = rb.velocity.normalized * postBounceSpeed + Vector2.up * upTrend;
        Destroy(this);
    }
}
