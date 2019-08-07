using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

// State Machine which handles which page the diary is currently at!
public class DiaryStateMachine : MonoBehaviour
{
    // The singleton reference
    protected static DiaryStateMachine _instance;
    // The getter for the singleton. If the reference has not been set yet, find it first!
    public static DiaryStateMachine instance
    {
        get
        {
            if (_instance == null) _instance = GameObject.FindObjectOfType<DiaryStateMachine>();
            return _instance;
        }
    }

    // The current diary page that is active.
    public DiaryPage currentPage;
    // List of objects that are activated and deactivated as pages are opened. Index of object must match index of current diary page setting!
    public List<GameObject> pageObjects;

    // Delay timer to prevent closing the diary right when it is opened!
    private float inputDelayTimer;
    // Reactions to trigger on close, given by what triggers the diary
    private List<Reaction> triggerOnClose;

    public FirstPersonController player;

    // Awaken and close the diary if it was open in the editor
    private void Awake()
    {
        ClosePage();
    }

    // Opens the given page and starts the input delay timer. This deactivates all pages, while it activates the page that matches the enum index.
    public void OpenPage(DiaryPage newPage, List<Reaction> triggerOnClose)
    {
        inputDelayTimer = 0.1f;
        currentPage = newPage;
        this.triggerOnClose = triggerOnClose;

        int index = (int)newPage - 1;
        for (int i = 0; i < pageObjects.Count; i++)
        {
            pageObjects[i].SetActive(i == index);
        }

        player.enabled = newPage == DiaryPage.none;
    }

    // Closes any page that is open
    public void ClosePage()
    {
        if (triggerOnClose != null)
        {
            for (int i =0; i < triggerOnClose.Count; i++)
            {
                triggerOnClose[i].React();
            }
        }

        OpenPage(DiaryPage.none, null);
    }

    // Count down the input delay timer, and if it's completed, allow mouse clicks to close the page.
    private void Update()
    {
        if (inputDelayTimer > 0)
        {
            inputDelayTimer -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && currentPage != DiaryPage.none && inputDelayTimer <= 0)
        {
            ClosePage();
        }
    }
}
