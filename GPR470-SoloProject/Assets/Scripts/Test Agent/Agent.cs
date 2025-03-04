using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : GoapAgent
{
    private readonly float _interval = 1.5f;
    private float _timer;

    public void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("haveEnergy", 1, false);
        goals.Add(s1, 3);
        
        SubGoal s2 = new SubGoal("haveFood", 1, false);
        goals.Add(s2, 2);
        
        SubGoal s3 = new SubGoal("beHappy", 1, false);
        goals.Add(s3, 1);
    }

    public void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _interval)
        {
            _timer = 0;
            
            GoapWorld.Instance.LoseEnergy(1);
            GoapWorld.Instance.LoseFood(1);
            GoapWorld.Instance.LoseHappiness(1);
        }
    }
}
