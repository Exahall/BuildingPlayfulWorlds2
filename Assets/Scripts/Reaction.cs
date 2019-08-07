using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for all reactions. Contains no functionality itself, but other scripts can extend upon the 'React' method.
public class Reaction : MonoBehaviour
{

    // This is called when a reaction needs to do -something-
    public virtual void React()
    {

    }

}
