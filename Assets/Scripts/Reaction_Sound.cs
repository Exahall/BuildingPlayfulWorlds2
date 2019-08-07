using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reaction that plays a sound
public class Reaction_Sound : Reaction
{
    // Sound to play
    public AudioClip audioClip;

    // Call Unity's own AudioSource system to play a one-time sound at the position of this object.
    public override void React()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }
}
