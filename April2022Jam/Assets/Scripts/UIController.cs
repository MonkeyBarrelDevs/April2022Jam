using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    GameObject Stars1;
    GameObject Stars2;
    GameObject Stars3;    
    GameObject Stars4;
    GameObject Stars5; 
    StargunController stargun;
    // Start is called before the first frame update
    void Start()
    {
        Stars1 = GameObject.Find("1Star");
        Stars2 = GameObject.Find("2Star");
        Stars3 = GameObject.Find("3Star");
        Stars4 = GameObject.Find("4Star");
        Stars5 = GameObject.Find("5Star");
        stargun = FindObjectOfType<StargunController>();
    }

    // Update is called once per frame
    void Update()
    {
        int ammo = stargun.getAmmo();
        if(ammo == 0)
        {
            Stars1.SetActive(false);
            Stars2.SetActive(false);
            Stars3.SetActive(false);
            Stars4.SetActive(false);
            Stars5.SetActive(false);
        }
        else if(ammo == 1)
        {
            Stars1.SetActive(true);
            Stars2.SetActive(false);
            Stars3.SetActive(false);
            Stars4.SetActive(false);
            Stars5.SetActive(false);
        }
        else if(ammo == 2)
        {
            Stars1.SetActive(false);
            Stars2.SetActive(true);
            Stars3.SetActive(false);
            Stars4.SetActive(false);
            Stars5.SetActive(false);
        }
        else if(ammo == 3)
        {
            Stars1.SetActive(false);
            Stars2.SetActive(false);
            Stars3.SetActive(true);
            Stars4.SetActive(false);
            Stars5.SetActive(false);
        }
        else if(ammo == 4)
        {
            Stars1.SetActive(false);
            Stars2.SetActive(false);
            Stars3.SetActive(false);
            Stars4.SetActive(true);
            Stars5.SetActive(false);
        }
        else if(ammo >= 5)
        {
            Stars1.SetActive(false);
            Stars2.SetActive(false);
            Stars3.SetActive(false);
            Stars4.SetActive(false);
            Stars5.SetActive(true);
        }
    }
}
