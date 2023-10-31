using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BestClearTime : MonoBehaviour
{
    public TMP_Text Level1Text;
    public TMP_Text Level2Text;
    public TMP_Text Level3Text;
    private float[] bestTimes;
    private string[] bestTimesText;
    
    // Start is called before the first frame update
    void Start()
    {
        bestTimes = new float[5];
        bestTimesText = new string[5];
        for (int i = 1; i < 4; i++)
        {
            bestTimes[i] = PlayerPrefs.GetFloat("bestTime" + i );
            float minutes = Mathf.FloorToInt(bestTimes[i] / 60);
            float seconds = Mathf.FloorToInt(bestTimes[i] % 60);

            // Return the formatted string
            bestTimesText [i] = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        
        Level1Text.text = "Level 1 : " + bestTimesText[1];
        Level2Text.text = "Level 2 : " + bestTimesText[2];
        Level3Text.text = "Level 3 : " + bestTimesText[3];
    }

}
