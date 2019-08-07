using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// What types of object active / deactivate changes are available
public enum ActivateType
{
    activate,
    deactivate,
    toggle
}

// Reaction that activates or deactivates the object this script is placed on.
public class Reaction_Activate : Reaction
{
    // What type of activation to trigger
    public ActivateType type;

    // Activate or deactivate depending on the set type!
    public override void React()
    {
        switch (type)
        {
            case ActivateType.activate:
                gameObject.SetActive(true);
                break;
            case ActivateType.deactivate:
                gameObject.SetActive(false);
                break;
            case ActivateType.toggle:
                gameObject.SetActive(!gameObject.activeSelf); // Set my active to the opposite of my current active
                break;
        }
    }
}
