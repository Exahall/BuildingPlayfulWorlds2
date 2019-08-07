using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reaction that opens a new additive scene.
public class Reaction_Scene : Reaction
{
    // Scene name that will be additively loaded.
    public string sceneName;

    // Whether to include a shake and fade transition during loading of scene
    public bool fadeAndShakeTransition;

    // Call the SceneController singleton to load the scene.
    public override void React()
    {
        SceneController.instance.LoadScene(sceneName, fadeAndShakeTransition);
    }
}
