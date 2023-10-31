using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private BossHealth bossHealth;
    public Slider slider;

    private void Start()
    {
        if (gameObject.activeSelf)
        {
            GameObject boss = GameObject.FindGameObjectWithTag("Boss");
            bossHealth = boss.GetComponent<BossHealth>();
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
