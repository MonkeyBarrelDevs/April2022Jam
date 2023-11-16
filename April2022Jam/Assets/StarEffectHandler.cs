using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEffectHandler : MonoBehaviour
{
    [SerializeField] Animator effectAnim;
    // Start is called before the first frame update
    void Start()
    {
        effectAnim.SetTrigger("Start");
    }

    public void End() 
    {
        Destroy(this.gameObject);
    }
}
