using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    private bool isTakingDamage = false;
    private int currentSceneIndex;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "LittleMonster" || collision.gameObject.tag == "Monster" || collision.gameObject.tag == "BossFireBall" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Boss2") && !isTakingDamage)
        {
            isTakingDamage = true;
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
                Timer.instance.setTempTime();
            }
            else
            {
                StartCoroutine(GetHurt());
            }
            if(collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Boss2"){
                AudioManager.instance.Play("EnemyAttack");
            }
        }
        if (collision.gameObject.tag == "StageClear")
        {
            PlayerManager.isStageClear = true;
            PlayerManager.lastCheckPointPos = new Vector2(0, 2);
            AudioManager.instance.Play("StageClear");
            gameObject.SetActive(false);
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            LevelManager.instance.MarkLevelAsCompleted(currentSceneIndex);
            Timer.instance.onLevelCompleted(currentSceneIndex);
            
            isTakingDamage = false;
            GetComponent<Animator>().SetLayerWeight(1, 0);
            Physics2D.IgnoreLayerCollision(6,8, false);
        }
        if (collision.gameObject.tag == "BossFireBall")
        {
            AudioManager.instance.Play("EnemyDamage");
            Destroy(collision.gameObject);
        }
    }
    IEnumerator GetHurt(){ 
        Physics2D.IgnoreLayerCollision(6,8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6,8, false);
        isTakingDamage = false;
    }
}
