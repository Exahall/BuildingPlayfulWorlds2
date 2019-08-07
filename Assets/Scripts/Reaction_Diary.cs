using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reaction that opens a specific diary page.
public class Reaction_Diary : Reaction
{
    // Diary page to open
    public DiaryPage activatePage;

    // Reactions to fire when page closes
    public List<Reaction> onPageClose;

    // Call the DiaryStateMachine singleton to open the page.
    public override void React()
    {
        DiaryStateMachine.instance.OpenPage(activatePage, onPageClose);
    }
}
