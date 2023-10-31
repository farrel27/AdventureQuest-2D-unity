using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 500;

	public GameObject deathEffect;
	public GameObject Boss2Prefab;

	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Vector3 spawnPosition = transform.position;
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
		
		GameObject HealthBar2 = GameObject.Find("Boss2Spwaner");
		if (HealthBar2 != null){
			HealthBar2.GetComponent<Boss2Spawner>().spawnBoss2();
		}
		Instantiate(Boss2Prefab, spawnPosition, Quaternion.identity);
	}

}
