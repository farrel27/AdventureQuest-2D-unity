using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{
    void OnCollissonEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    
}
