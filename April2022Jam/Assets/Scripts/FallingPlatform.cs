using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float detectDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, Vector2.down, detectDistance, LayerMask.GetMask("Player"));
        if(hit)
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
