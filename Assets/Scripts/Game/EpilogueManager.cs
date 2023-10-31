using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpilogueManager : MonoBehaviour
{
    public static EpilogueManager instance;

    public GameObject[] images;
    public GameObject EpilogueUI;
    private bool _fadein;
    private bool _fadeout;
    [SerializeField]
    private CanvasGroup canvasGroup;
    int index;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        canvasGroup.alpha = 0;
        index = 0;
    }
        

    void Update()
    {
        if(index == 0)
        {
            images[0].gameObject.SetActive(true);
        }
        if (_fadein)
        {
            if(canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    _fadein = false;
                }
            }
        }
        if (_fadeout)
        {
            if(canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= Time.deltaTime;
                if (canvasGroup.alpha == 0)
                {
                    _fadeout = false;
                    EpilogueUI.SetActive(false);
                }
            }
        }
    }

    public void Next()
    {
    index += 1;

    if(index > images.Length - 1 )
    {
        index = images.Length - 1;
        FadeOut();
    }

        for(int i = 0 ; i < images.Length - 1 ; i++)
        {
        images[i].gameObject.SetActive(false);
        images[index].gameObject.SetActive(true);
        }
    }
    public void FadeIn()
    {
        _fadein = true;
    }
    public void FadeOut()
    {
        _fadeout = true;
    }
    public void activateObject()
    {
        EpilogueUI.SetActive(true);
        FadeIn();
    }
}