using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GoapWorld
{
    private static readonly GoapWorld instance = new GoapWorld();

    private static WorldStates _world;

    static GoapWorld()
    {
        _world = new WorldStates();
    }

    private GoapWorld()
    {
        
    }

    public static GoapWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return _world;
    }
}
