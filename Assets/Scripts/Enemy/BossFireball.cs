using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireball : MonoBehaviour
{
    public int attackDamage = 20;
	public int enragedAttackDamage = 40;
	public GameObject fireBall;
	public Transform fireBallHole;
	public float force = 5f;
	private GameObject Target;
	private GameObject go;
	private bool canFire = true;
	private float fireDelay = 1.5f;
	private Animator animator;
	private void Start()
	{
		animator = GetComponent<Animator>();
		animator.SetBool("canAttack", true);
		Target = GameObject.FindGameObjectWithTag("Player");
	}

	public void Attack()
	{
		if (canFire)
		{
			AudioManager.instance.Play("Fireball");
			go = Instantiate(fireBall, fireBallHole.position, fireBall.transform.rotation);
			FireballMovement fireballMovement = go.GetComponent<FireballMovement>();

			Collider2D targetCollider = Target.GetComponent<Collider2D>();
			Vector2 targetPoint = targetCollider.ClosestPoint(fireBallHole.position);
			Vector2 direction = (targetPoint - (Vector2)fireBallHole.position).normalized;
			fireballMovement.Move(direction, force);
			StartCoroutine(StartFireDelay());
		}
		else
		{
			return;
		}
	}

	public void EnragedAttack()
	{
		if (canFire)
		{
			AudioManager.instance.Play("Fireball");
			go = Instantiate(fireBall, fireBallHole.position, fireBall.transform.rotation);
			FireballMovement fireballMovement = go.GetComponent<FireballMovement>();

			Collider2D targetCollider = Target.GetComponent<Collider2D>();
			Vector2 targetPoint = targetCollider.ClosestPoint(fireBallHole.position);
			Vector2 direction = (targetPoint - (Vector2)fireBallHole.position).normalized;
			fireballMovement.Move(direction, force*2);
			StartCoroutine(StartFireDelay());
		}
		else
		{
			return;
		}
	}
	IEnumerator StartFireDelay()
    {
        canFire = false;
		animator.SetBool("canAttack", canFire);
        yield return new WaitForSeconds(fireDelay / 2);
        canFire = true;
		animator.SetBool("canAttack", canFire);
    }
}
