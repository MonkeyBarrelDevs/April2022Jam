using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
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
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.Die();
            loader.DelayLoadLevelWithName(loader.getSceneName(), player.getDeathDuration());
        }
    }
}
