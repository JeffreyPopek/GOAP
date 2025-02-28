using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant_GetBuyer : GoapAction
{
    public override bool PrePerform()
    {
        target = GoapWorld.Instance.RemoveBuyer();

        if (target == null)
            return false;
        
        return true;
    }
    
    public override bool PostPerform()
    {
        return true;
    }
}