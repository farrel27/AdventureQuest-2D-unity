using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public GameObject SpawnPoint;
    public GameObject HealthBar;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthBar.SetActive(true);
            Instantiate(objectToInstantiate, SpawnPoint.transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
