using UnityEngine;

public class Bullet : MonoBehaviour
{	
    private FireballShoot fireballShoot;
    private GameObject Player;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if(Player == null)
            Destroy(gameObject);
        else
            fireballShoot = Player.GetComponent<FireballShoot>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Monster")
        {
            collision.GetComponent<Blu>().TakeDamage(fireballShoot.playerDamage);
            Destroy(gameObject);
        }
        if (collision.tag == "LittleMonster")
        {
            collision.GetComponent<Yillo>().TakeDamage(fireballShoot.playerDamage);
            Destroy(gameObject);
        }
        if (collision.tag == "Boss")
        {
            collision.GetComponent<BossHealth>().TakeDamage(fireballShoot.playerDamage);
            Destroy(gameObject);
        }
        if (collision.tag == "Boss2")
        {
            collision.GetComponent<Boss2Health>().TakeDamage(fireballShoot.playerDamage);
            Destroy(gameObject);
        }
    }
}
