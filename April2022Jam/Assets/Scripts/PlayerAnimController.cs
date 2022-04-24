using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] Transform playerModel;
    [SerializeField] Transform gunModel;
    [SerializeField] Animator playerAnim;
    [SerializeField] Animator gunAnim;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float yTolerance = .01f;
    [SerializeField] float xTolerance = .01f;

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isDead)
        {
            #region Player
            if (rb.velocity.x > xTolerance)
                playerModel.localScale = new Vector3(1, 1, 1);
            if (rb.velocity.x < -xTolerance)
                playerModel.localScale = new Vector3(-1, 1, 1);

            playerAnim.SetFloat("Y", rb.velocity.y);
            if (Mathf.Abs(rb.velocity.y) > yTolerance)
                playerAnim.SetFloat("X", 0);
            else
                playerAnim.SetFloat("X", Mathf.Abs(rb.velocity.x));
            #endregion

            #region Gun
            float gunRotation = gunModel.rotation.eulerAngles.z;
            if (gunRotation < 90 || gunRotation > 270)
                gunModel.localScale = new Vector3(1, 1, 1);
            if (gunRotation > 90 && gunRotation < 270)
                gunModel.localScale = new Vector3(1, -1, 1);
            #endregion
        }
    }

    public void Die()
    {
        playerModel.localScale = Vector3.one;
        gunModel.gameObject.SetActive(false);
        playerAnim.SetTrigger("Die");
    }

    public void Fire() 
    {
        gunAnim.SetTrigger("Fire");
    }
}
