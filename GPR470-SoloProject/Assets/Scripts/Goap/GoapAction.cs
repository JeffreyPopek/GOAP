using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public abstract class GoapAction : MonoBehaviour
{
    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target;
    public string targetTag;
    public float duration = 0f;
    public WorldState[] preconditionsWorldState; // from inspector then move into dictionary
    public WorldState[] effectsWorldState;  // from inspector then move into dictionary
    public NavMeshAgent agent;

    public Dictionary<string, int> preconditionsDictionary;
    public Dictionary<string, int> effectsDictionary;

    public WorldStates agentBeliefs;

    public bool running;

    public GoapAction()
    {
        preconditionsDictionary = new Dictionary<string, int>();
        effectsDictionary = new Dictionary<string, int>();
    }

    public void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();

        if (preconditionsWorldState != null)
        {
            foreach (var w in preconditionsWorldState)
                preconditionsDictionary.Add(w.key, w.value);
        }
        
        if (effectsWorldState != null)
        {
            foreach (var w in effectsWorldState)
                effectsDictionary.Add(w.key, w.value);
        }
    }

    public bool IsAchievable()
    {
        return true;
    }

    public bool IsAchievableGiven(Dictionary<string, int> conditions)
    {
        foreach (var pair in preconditionsDictionary)
        {
            if (!conditions.ContainsKey(pair.Key))
                return false;
        }
        return true;
    }
    
    public abstract bool PrePerform();
    public abstract bool PostPerform();
}
