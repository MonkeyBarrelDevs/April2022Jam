using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    PlayerMovement player;
    LevelLoader loader;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        loader = FindObjectOfType<LevelLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.Die();
            loader.DelayLoadLevelWithName(loader.getSceneName(), player.getDeathDuration());
        }
    }
}
