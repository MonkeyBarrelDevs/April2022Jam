using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Animator anim;

    LevelLoader loader;

    // Start is called before the first frame update
    void Start()
    {
        loader = FindObjectOfType<LevelLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetTrigger("OpenDoor");
            loader.LoadNextLevel();
        }
    }
}
