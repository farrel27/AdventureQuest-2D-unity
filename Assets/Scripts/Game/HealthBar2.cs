using UnityEngine;
using UnityEngine.UI;

public class HealthBar2 : MonoBehaviour
{
    private Boss2Health bossHealth;
    public Slider slider;

    private void Start()
    {
        if (gameObject.activeSelf)
        {
            GameObject boss = GameObject.FindGameObjectWithTag("Boss2");
            bossHealth = boss.GetComponent<Boss2Health>();
            slider.maxValue = bossHealth.health;
        }
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            slider.value = bossHealth.health;
        }
    }
}
