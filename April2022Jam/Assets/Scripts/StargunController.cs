using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StargunController : MonoBehaviour
{
    [SerializeField] int ammo;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float yMomentumModifier = 1f;
    [SerializeField] float xMomentumModifier = 1f;
    [SerializeField] float yRecoilModifier = 1f;
    [SerializeField] float xRecoilModifier = 1f;
    [SerializeField] Rigidbody2D rb;
    private Vector2 mousePosition;
    private string[] soundNames;
    PlayerAnimController animController;

    private void Awake()
    {
        animController = GetComponent<PlayerAnimController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        soundNames = new string[3];
        soundNames[0] = "Cannon1";
        soundNames[1] = "Cannon2";
        soundNames[2] = "Cannon3";
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (ammo > 0)
        {
            string soundName = soundNames[UnityEngine.Random.Range(0, soundNames.Length)];
            GetComponent<AudioManager>().PlayOneShot(soundName);
            animController.Fire();
            Instantiate(prefab, firePoint.position, firePoint.rotation);
            Vector2 position2D = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Vector2 gunVector = (position2D - mousePosition).normalized;
            rb.velocity = new Vector2(rb.velocity.x * xMomentumModifier + gunVector.x * xRecoilModifier, rb.velocity.y * yMomentumModifier + gunVector.y * yRecoilModifier);
            //rb.AddForce((gameObject.transform.position-mousePosition).normalized * recoilForce, ForceMode2D.Impulse);
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