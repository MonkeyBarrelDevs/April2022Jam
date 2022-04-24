using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioPlayer : MonoBehaviour
{
    [SerializeField] string play;
    [SerializeField] string stop;
    void Start()
    {
        FindObjectOfType<AudioManager>().Play(play);
        if(stop != "")
            FindObjectOfType<AudioManager>().Stop(stop);
    }
}
