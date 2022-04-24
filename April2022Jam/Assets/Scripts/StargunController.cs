using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StargunController : MonoBehaviour
{
    [SerializeField] int ammo;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float recoilForce = 1f;
    [SerializeField] Rigidbody2D rb;
    private Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(ammo > 0)
            {
                Instantiate(prefab, firePoint.position, firePoint.rotation);
                rb.AddForce(-mousePosition * recoilForce, ForceMode2D.Impulse);
                ammo--;
            }
    }

    public void increaseAmmo()
    {
        ammo++;
    }

    public int getAmmo()
    {
        return ammo;
    }
}