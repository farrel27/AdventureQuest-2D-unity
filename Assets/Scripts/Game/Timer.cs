using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    private float currentTime = 0;
    private float bestTime;
    private float currentbestTime;
    private bool timeisRunnig;
    private float[] bestTimes;
    public TMP_Text timerText;
    public TMP_Text NewRecordText;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        timeisRunnig = true;
        bestTimes = new float[5];
        for (int i = 1; i < 4; i++)
        {
            bestTimes[i] = PlayerPrefs.GetFloat("bestTime" + i );
        }
        currentTime = PlayerPrefs.GetFloat("Level" + SceneManager.GetActiveScene().buildIndex + "Time");
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeisRunnig)
        {
            currentTime += Time.deltaTime;
            DisplayTime(currentTime);
        }
    }
    void DisplayTime ( float timeToDisplay)
    {
        timeToDisplay +=1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void onLevelCompleted(int levelIndex)
    {
        timeisRunnig = false;

        if (currentTime < bestTimes[levelIndex] && bestTimes[levelIndex] != 0)
        {
            bestTimes[levelIndex] = currentTime;
            PlayerPrefs.SetFloat("bestTime" + levelIndex, bestTimes[levelIndex]);
            NewRecordText.gameObject.SetActive(true);
        }
        if ( bestTimes[levelIndex] == 0)
        {
            bestTimes[levelIndex] = currentTime;
            PlayerPrefs.SetFloat("bestTime" + levelIndex, bestTimes[levelIndex]);
            NewRecordText.gameObject.SetActive(true);
        }
        PlayerPrefs.SetFloat("Level" + levelIndex + "Time", 0);
        Debug.Log("Level" + levelIndex + "Time");
    }
    public void setTempTime()
    {
        PlayerPrefs.SetFloat("Level" + SceneManager.GetActiveScene().buildIndex + "Time", currentTime);
    }
    public void resetTempTime()
    {
        PlayerPrefs.SetFloat("Level" + SceneManager.GetActiveScene().buildIndex + "Time", 0);
    }
}
