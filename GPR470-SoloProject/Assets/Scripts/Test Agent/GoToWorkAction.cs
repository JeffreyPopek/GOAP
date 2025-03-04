using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWorkAction : GoapAction
{
    public override bool PrePerform()
    {
        if (GoapWorld.Instance.GetEnergy() < 40)
            return false;
        
        return true;
    }
    
    public override bool PostPerform()
    {
        return true;
    }
}
