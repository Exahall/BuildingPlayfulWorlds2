using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Any object that contains this script, and of which the layer is set to Interactable, can be clicked on.
// It will then trigger any amount of reactions
public class Interactable : MonoBehaviour
{
    // Name to show in HUD when looking at this object
    public string interactionName;

    // All reactions to trigger upon clicking on this
    public List<Reaction> reactions;

    // This interactable is clicked! Trigger all reactions!
    public void Interact()
    {
        for (int i =0; i < reactions.Count; i++)
        {
            reactions[i].React();
        }
    }

}
