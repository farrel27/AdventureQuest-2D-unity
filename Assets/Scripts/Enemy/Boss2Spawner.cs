using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Spawner : MonoBehaviour
{
    public GameObject HealthBar2;
    public GameObject HealthBar;
    public void spawnBoss2(){
        HealthBar2.SetActive(true);
        HealthBar.SetActive(false);
    }
}
