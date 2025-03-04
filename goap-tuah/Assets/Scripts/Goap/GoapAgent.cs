using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SubGoal
{
    public Dictionary<string, int> subGoals;
    public bool remove; // determine if you want to remove the goal after its achieved

    public SubGoal(string s, int i, bool r)
    {
        subGoals = new Dictionary<string, int>();
        subGoals.Add(s, i);
        remove = r;
    }
    
}
public class GoapAgent : MonoBehaviour
{
    // goap stuff
    public List<GoapAction> actions = new List<GoapAction>();
    public Dictionary<SubGoal, int> goals = new Dictionary<SubGoal, int>();
    
    public GoapAction currentAction;
    
    private GoapPlanner _planner;
    private Queue<GoapAction> _actionQueue;
    private SubGoal _currentGoal;

    public void Start()
    {
        GoapAction[] acts = GetComponents<GoapAction>();
        
        foreach (var act in acts)
            actions.Add(act);
    }


    private bool _invoked;
    
    
    void OnMouseDown()
    {
        AgentViewer.instance.target = gameObject;
    }

    private void CompleteAction()
    {
        currentAction.running = false;
        currentAction.PostPerform();
        _invoked = false;
    }
    
    private void LateUpdate()
    {
        if (currentAction != null && currentAction.running)
        {
            float distanceToTarget = Vector3.Distance(currentAction.target.transform.position, transform.position);
            if (currentAction.agent.hasPath && distanceToTarget < 2f) // TODO: Change distance threshold
            {
                if (!_invoked)
                {
                    // complete action in X seconds where X is the action duration. Only call this once
                    Invoke("CompleteAction", currentAction.duration);
                    _invoked = true;
                }
            }

            return;
        }
        

        
        if (_planner == null || _actionQueue == null)
        {
            _planner = new GoapPlanner();

            var sortedGoals = from entry in goals orderby entry.Value descending select entry;

            foreach (var sg in sortedGoals)
            {
                _actionQueue = _planner.Plan(actions, sg.Key.subGoals, null);
                if (_actionQueue != null)
                {
                    _currentGoal = sg.Key;
                    break;
                }
            }
        }

        // called when done with plan
        if (_actionQueue != null && _actionQueue.Count == 0)
        {
            if (_currentGoal.remove)
                goals.Remove(_currentGoal);
            
            // planner is set to null and will make a new plan next update
            _planner = null;
        }
        
        if(_actionQueue != null && _actionQueue.Count > 0)
        {
            currentAction = _actionQueue.Dequeue();
            if (currentAction.PrePerform())
            {
                if (currentAction.target == null && currentAction.targetTag != "")
                    currentAction.target = GameObject.FindWithTag(currentAction.targetTag);

                // Set destination of agent
                if (currentAction.target != null)
                {
                    currentAction.running = true;
                    currentAction.agent.SetDestination(currentAction.target.transform.position);
                }
            }
            else
            {
                // forces agent to get new plan
                _actionQueue = null;
            }
        }
    }
}
