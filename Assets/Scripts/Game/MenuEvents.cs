using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;
    private void Start()
    {
        Time.timeScale = 1;
        mixer.GetFloat("volume",out value);
        volumeSlider.value = value;
    }
    public void SetVolume()
    {
        if (volumeSlider.value == volumeSlider.minValue)
			mixer.SetFloat("volume", -80);
        else
            mixer.SetFloat("volume", volumeSlider.value);
    }

    public void LoadLevel(int index)
    {
        PlayerManager.lastCheckPointPos = new Vector2(0, 2);
        SceneManager.LoadScene(index);
    }
}
