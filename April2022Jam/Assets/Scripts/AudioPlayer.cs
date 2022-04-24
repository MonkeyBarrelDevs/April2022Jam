using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] string play;
    [SerializeField] string stop;
    AudioManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
        if (play != "")
            manager.Play(play);
        if (stop != "")
            manager.Stop(stop);
    }
}
