using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Button button1;
    public Button button2;

    void Start()
    {
        // Check the initial state of button2
        if (button2.gameObject.activeInHierarchy == true)
        {
            // If button2 is active, disable button1
            button1.interactable = false;
        }
    }
    void Update()
{
    // Check the state of button2 continuously
    if (button2.gameObject.activeInHierarchy == true && button1.interactable)
    {
        // If button2 is active and button1 is still interactable, disable button1
        button1.interactable = false;
    }
    else if (!button2.gameObject.activeInHierarchy == true && !button1.interactable)
    {
        // If button2 is inactive and button1 is disabled, enable button1
        button1.interactable = true;
    }
}
}
