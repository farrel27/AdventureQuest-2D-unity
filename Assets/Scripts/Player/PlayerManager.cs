using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool isStageClear;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    public GameObject stageClearScreen;

    public static Vector2 lastCheckPointPos = new Vector2(0, 2);
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;
    public CinemachineVirtualCamera VCam;
    public GameObject[] playerPrefabs;
    int characterIndex;

    private void Awake()
    {
        Time.timeScale = 0;
        characterIndex =  PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player =  Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        VCam.m_Follow = player.transform;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;
        isStageClear = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        coinsText.text = numberOfCoins.ToString() ;
        if (isGameOver)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
        if (isStageClear)
        {
            stageClearScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        lastCheckPointPos = new Vector2(0, 2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReplayLevelonCheckpoin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
    public void GoToMenu()
    {
        Timer.instance.resetTempTime();
        SceneManager.LoadScene(0);
    }
}
