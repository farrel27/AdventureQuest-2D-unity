using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        // Check the completion status of the previous level
        bool isPreviousLevelCompleted = LevelManager.instance.IsLevelCompleted(levelIndex - 1);

        // Disable or enable the button based on the previous level's completion status
        button.interactable = isPreviousLevelCompleted;
    }
}

