using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerManager.lastCheckPointPos = transform.position;
            GetComponent<SpriteRenderer>().color = Color.white;
            AudioManager.instance.Play("Checkpoint");
            if (!TryGetComponent<CircleCollider2D>(out CircleCollider2D collider)) return;
            collider.enabled = false;
        }
    }
}
