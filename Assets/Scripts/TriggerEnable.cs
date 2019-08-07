using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When it is activated or enabled, or disabled, it triggers reactions!
public class TriggerEnable : MonoBehaviour
{
    // Reactions triggered when this object is activated.
    public List<Reaction> reactionsOnEnable;

    // Reactions triggered when this object is deactivated.
    public List<Reaction> reactionsOnDisable;

    // Called when the object is activated! Trigger reactions!
    private void OnEnable()
    {
        for (int i = 0; i < reactionsOnEnable.Count; i++)
        {
            reactionsOnEnable[i].React();
        }   
    }

    // Called when the object is deactivated! Trigger reactions!
    private void OnDisable()
    {
        for (int i = 0; i < reactionsOnDisable.Count; i++)
        {
            reactionsOnDisable[i].React();
        }
    }

}
