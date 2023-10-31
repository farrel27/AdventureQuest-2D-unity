using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballShoot : MonoBehaviour
{
    PlayerControls controls;
    public Animator animator;

    public GameObject bullet;
    public Transform bulletHole;
    public string ShootSound;
    public float force = 200;
    public int playerDamage = 10;
    private bool canFire = true;
    private float fireDelay = 1f;
    private GameObject go;
    private Button fireButton;

    private void Start()
    {
        fireButton = GameObject.Find("ShootButton").GetComponent<Button>();
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Shoot.performed += ctx => Fire();
    }

    void Fire()
    {
        if (canFire)
        {
            animator.SetTrigger("shoot");
            AudioManager.instance.Play(ShootSound);
            
            go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);
            if (GetComponent<PlayerMovement>().isFacingRight)

                go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
            else
                go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);

            Destroy(go, 1.2f);
            StartCoroutine(StartFireDelay());
        }
        else
        {
            return;
        }
    }
    IEnumerator StartFireDelay()
    {
        fireButton.interactable = false;
        canFire = false;
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
        fireButton.interactable = true;
    }
}
