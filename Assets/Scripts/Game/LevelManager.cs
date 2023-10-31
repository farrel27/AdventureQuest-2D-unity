using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public bool[] levelCompletionStatus;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayerPrefs.SetInt("level0", 1);
    }

    // Add methods to update the completion status of each level
    public void MarkLevelAsCompleted(int levelIndex)
    {
        PlayerPrefs.SetInt("level" + levelIndex, 1);
    }

    public bool IsLevelCompleted(int levelIndex)
    {
        return PlayerPrefs.GetInt("level" + levelIndex) == 1? true : false;
    }
}

