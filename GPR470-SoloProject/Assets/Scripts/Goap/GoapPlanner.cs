using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Net.Mail;
using Unity.VisualScripting;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Node
{
    public Node parent;
    public float cost;
    public Dictionary<string, int> state;
    public GoapAction action;

    public Node(Node parent, float cost, Dictionary<string, int> allStates, GoapAction action)
    {
        this.parent = parent;
        this.cost = cost;
        state = new Dictionary<string, int>(allStates);
        this.action = action;
    }
}

public class GoapPlanner
{
    public Queue<GoapAction> Plan(List<GoapAction> actions, Dictionary<string, int> goal, WorldStates states)
    {
        List<GoapAction> usableActions = new List<GoapAction>();

        foreach (var act in actions)
        {
            if (act.IsAchievable())
                usableActions.Add(act);
        }

        List<Node> leaves = new List<Node>();
        Node start = new Node(null, 0, GoapWorld.Instance.GetWorld().GetStates(), null);

        bool success = BuildGraph(start, leaves, usableActions, goal);

        if (!success)
        {
            Debug.Log("NO PLAN");
            return null;
        }

        Node cheapest = null;

        foreach (var leaf in leaves)
        {
            if (cheapest == null)
                cheapest = leaf;
            else
            {
                if (leaf.cost < cheapest.cost)
                    cheapest = leaf;
            }
        }

        List<GoapAction> result = new List<GoapAction>();
        Node n = cheapest;
        
        while(n != null)
        {
            if(n.action != null)
                result.Insert(0, n.action);

            n = n.parent;
        }

        Queue<GoapAction> queue = new Queue<GoapAction>();

        // move from list to queue
        foreach (var act in result)
            queue.Enqueue(act);

        // debug
        Debug.Log("The plan is: ");
        foreach (var act in queue)
            Debug.Log($"Q: {act.actionName}");

        return queue;
    }


    private bool BuildGraph(Node parent, List<Node> leaves, List<GoapAction> usableActions, Dictionary<string, int> goal)
    {
        bool foundPath = false;

        foreach (var action in usableActions)
        {
            if (action.IsAchievableGiven(parent.state))
            {
                Dictionary<string, int> currentState = new Dictionary<string, int>(parent.state);
                foreach (var effect in action.effectsDictionary)
                {
                    if(!currentState.ContainsKey(effect.Key))
                        currentState.Add(effect.Key, effect.Value);
                }

                Node node = new Node(parent, parent.cost + action.cost, currentState, action);

                if (GoalAchieved(goal, currentState))
                {
                    leaves.Add(node);
                    foundPath = true;
                }
                else
                {
                    List<GoapAction> subset = ActionSubset(usableActions, action);
                    bool found = BuildGraph(node, leaves, subset, goal);

                    if (found)
                        foundPath = true;
                }
            }
        }

        return foundPath;
    }

    private bool GoalAchieved(Dictionary<string, int> goal, Dictionary<string, int> state)
    {
        foreach (var g in goal)
        {
            if (!state.ContainsKey(g.Key))
                return false;
        }
        
        return true;
    }

    private List<GoapAction> ActionSubset(List<GoapAction> actions, GoapAction removeMe)
    {
        // removes the removeMe var from the usable actions list
        List<GoapAction> subset = new List<GoapAction>();

        foreach (var action in actions)
        {
            if (!action.Equals(removeMe))
                subset.Add(action);
        }

        return subset;
    }
}
