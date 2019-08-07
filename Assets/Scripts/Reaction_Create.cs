using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reaction that creates an instance of a prefab when triggered.
public class Reaction_Create : Reaction
{
    // Prefab to create instances of
    public GameObject prefab;

    // When triggered, create an instance!
    public override void React()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }

}
