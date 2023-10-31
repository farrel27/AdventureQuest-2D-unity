using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public int attackDamage = 20;
	public int enragedAttackDamage = 40;
	private GameObject Target;
	private bool isAttacked = false;
	private void Start()
	{
		Target = GameObject.FindGameObjectWithTag("Player");
	}

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	public void Attack()
	{
		AudioManager.instance.Play("Sword");
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null && !isAttacked)
		{
			isAttacked = true;
			HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
				Timer.instance.setTempTime();
                AudioManager.instance.Play("GameOver");
                Target.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
		}
	}

	IEnumerator GetHurt(){ 
        Physics2D.IgnoreLayerCollision(6,8);
        Target.GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        Target.GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6,8, false);
		isAttacked = false;
    }

	public void EnragedAttack()
	{
		AudioManager.instance.Play("Sword");
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			//colInfo.GetComponent<PlayerHealth>().TakeDamage(enragedAttackDamage);
			HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
				Timer.instance.setTempTime();
                AudioManager.instance.Play("GameOver");
                Target.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
