using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Displays the name of the interactable the player is looking at.
public class InteractableHUD : MonoBehaviour
{
    // The text to update with interactable name
    private Text interaction;

    // Awaken, get the text this object contains
    private void Awake()
    {
        interaction = gameObject.GetComponent<Text>();
    }

    // Every frame, set the text to the name of the currently looked at interactable. Or just reset if no such thing is looked at.
    private void Update()
    {
        if (InputRaycaster.instance.currentFocus != null)
        {
            interaction.text = InputRaycaster.instance.currentFocus.interactionName;
        }
        else
        {
            interaction.text = "";
        }
    }

}
