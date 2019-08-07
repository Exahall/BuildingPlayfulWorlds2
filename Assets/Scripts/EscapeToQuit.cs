using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

// If you hit Escape, quit game!
public class EscapeToQuit : MonoBehaviour
{
    // Object to open when you hit ESC
    public GameObject quitConfirm;

    public Button confirmButton;
    public Button cancelButton;

    public FirstPersonController player;

    // On awake, disable quit confirm if it is active
    private void Awake()
    {
        quitConfirm.SetActive(false);
        confirmButton.onClick.AddListener(ConfirmQuit);
        cancelButton.onClick.AddListener(CancelQuit);
    }

    // Check if it quits, then open quit confirm
    private void Update()
    {
        if (player.enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            quitConfirm.SetActive(true);
            player.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Called when you confirm quitting
    public void ConfirmQuit()
    {
        Application.Quit();
    }

    // Called when you cancel quitting
    public void CancelQuit()
    {
        quitConfirm.SetActive(false);
        player.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
