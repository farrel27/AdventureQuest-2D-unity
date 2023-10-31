using UnityEngine;
using UnityEngine.UI;

public class Yillo : MonoBehaviour
{
    Transform target;
    public Transform borderCheck;
    public Transform borderCheck2;
    public int enemyHP = 100;
    public Animator animator;
    public Slider enemyHealthBar;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"));
        rb = GetComponent<Rigidbody2D>();
        enemyHealthBar.value = enemyHP;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.x > transform.position.x)
            transform.localScale = new Vector2(1f, 1f);
        else
            transform.localScale = new Vector2(-1f, 1f);

    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        enemyHealthBar.value = enemyHP;
        if (enemyHP > 0)
        {
            animator.SetTrigger("Damage");
        }
        else
        {
            Destroy(gameObject);
            GetComponent<BoxCollider2D>().enabled = false;
            this.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isAttacking", true);
            AudioManager.instance.Play("EnemyAttack");
        }
        if (collision.gameObject.CompareTag("Jumper"))
        {
            // Calculate the jumping direction
            Vector2 jumpingDirection = (transform.position - collision.transform.position).normalized;

            // Modify the jumping direction by adjusting the individual components
            jumpingDirection.x *= -5f;
            jumpingDirection.y *= 20;

            // Apply jumping force
            rb.AddForce(jumpingDirection, ForceMode2D.Impulse);
        }
    }
}
