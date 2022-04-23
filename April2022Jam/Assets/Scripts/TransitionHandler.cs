using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionHandler : MonoBehaviour
{
    [SerializeField] Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        LevelLoader.TransitionEvent += StartTransition;
    }

    void StartTransition() 
    {
        transition.SetTrigger("Start");
    }

    private void OnDisable()
    {
        LevelLoader.TransitionEvent -= StartTransition;
    }
}
