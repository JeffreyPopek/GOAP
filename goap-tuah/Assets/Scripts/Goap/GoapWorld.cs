using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GoapWorld
{
    private static readonly GoapWorld instance = new GoapWorld();

    private static WorldStates _world;

    private static Queue<GameObject> buyers;
    private static Queue<GameObject> seats;

    static GoapWorld()
    {
        _world = new WorldStates();

        buyers = new Queue<GameObject>();
        seats = new Queue<GameObject>();

        GameObject[] seatArr = GameObject.FindGameObjectsWithTag("Seat");

        foreach (var s in seatArr)
            seats.Enqueue(s);

        if(seatArr.Length > 0)
            _world.ModifyState("FreeSeat", seatArr.Length);
    }

    private GoapWorld()
    {
        
    }

    public void AddBuyer(GameObject go)
    {
        buyers.Enqueue(go);
    }

    public GameObject RemoveBuyer()
    {
        if (buyers.Count == 0)
            return null;

        return buyers.Dequeue();
    }
    
    public void AddSeat(GameObject go)
    {
        seats.Enqueue(go);
    }

    public GameObject RemoveSeat()
    {
        if (seats.Count == 0)
            return null;

        return seats.Dequeue();
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
