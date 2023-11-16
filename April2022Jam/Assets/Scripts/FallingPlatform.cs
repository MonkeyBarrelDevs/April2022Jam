using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float detectDistance = 100f;

    bool dropped = false;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, detectDistance, LayerMask.GetMask("Player"));
        if(hit)
        {
            Debug.Log("Hit");
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            if (!dropped) 
            {
                dropped = true;
                rb.velocity += Vector2.down * .0001f;
            }
        }
    }
}
