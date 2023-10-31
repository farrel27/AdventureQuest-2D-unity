using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    PlayerControls controls;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public string Sound;
    public int playerDamage = 10;
    private GameObject go;
    private bool canFire = true;
    private float fireDelay = 1f;
    private Button fireButton;

    private void Awake()
    {
        fireButton = GameObject.Find("ShootButton").GetComponent<Button>();
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Shoot.performed += ctx => Fire();
    }

    void Fire()
    {
        if (!canFire)
        {
            return; // Exit the method if it's not allowed to fire yet
        }
        animator.SetTrigger("shoot");
        AudioManager.instance.Play(Sound);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies){
            if (enemy.tag == "Monster")
            {
                enemy.GetComponent<Blu>().TakeDamage(playerDamage);
            }
            if (enemy.tag == "LittleMonster")
            {
                enemy.GetComponent<Yillo>().TakeDamage(playerDamage);
            }
            if (enemy.tag == "Boss")
            {
                enemy.GetComponent<BossHealth>().TakeDamage(playerDamage);
            }
            if (enemy.tag == "Boss2")
            {
                enemy.GetComponent<Boss2Health>().TakeDamage(playerDamage);
            }
        }
        StartCoroutine(StartFireDelay());
    }
    void OnDrawGizmosSelected(){
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
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
