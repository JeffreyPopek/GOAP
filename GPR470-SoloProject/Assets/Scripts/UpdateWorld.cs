using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateWorld : MonoBehaviour
{
    public TextMeshProUGUI states;

    private void LateUpdate()
    {
        Dictionary<string, int> worldStates = GoapWorld.Instance.GetWorld().GetStates();

        states.text = "";

        foreach (var s in worldStates)
            states.text += s.Key + ", " + s.Value + "\n";

    }
}
