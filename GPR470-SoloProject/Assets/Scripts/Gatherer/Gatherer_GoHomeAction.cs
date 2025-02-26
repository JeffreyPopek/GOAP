using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Gatherer_GoHomeAction : GoapAction
{
    public override bool PrePerform()
    {
        return true;
    }
    
    public override bool PostPerform()
    {
        return true;
    }
}
