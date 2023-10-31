using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    private float speed;

    public void Move(Vector2 direction, float force)
    {
        speed = force;
        transform.up = direction;
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }
    }
}
