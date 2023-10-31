using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2Health : MonoBehaviour
{

	public int health = 500;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	private int currentSceneIndex;

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
		PlayerManager.isStageClear = true;
		AudioManager.instance.Play("StageClear");
		EpilogueManager.instance.activateObject();
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		LevelManager.instance.MarkLevelAsCompleted(currentSceneIndex);
		Timer.instance.onLevelCompleted(currentSceneIndex);
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
