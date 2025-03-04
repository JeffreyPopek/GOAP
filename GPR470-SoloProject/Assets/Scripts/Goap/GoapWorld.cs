using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GoapWorld
{
    private static WorldStates _world;

    private static Queue<GameObject> buyers;
    private static Queue<GameObject> seats;

    public static int energyLevel;
    public static int foodLevel;
    public static int happinessLevel;


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

        energyLevel = 100;
        foodLevel = 100;
        happinessLevel = 100;
    }

    private GoapWorld() { }
    
    public static GoapWorld Instance { get; } = new GoapWorld();

    public WorldStates GetWorld() { return _world; }

    public void LoseEnergy(int amount)
    {
        energyLevel -= amount;
        
        if(energyLevel <= 0)
            Debug.Log("NO ENERGY");
    }
    
    public void GainEnergy(int amount)
    {
        energyLevel += amount;

        if (energyLevel > 100)
        {
            energyLevel = 100;
            Debug.Log("MAX ENERGY");
        }
    }

    public int GetEnergy() { return energyLevel; }
    
    public void LoseFood(int amount)
    {
        foodLevel -= amount;
        
        if(foodLevel <= 0)
            Debug.Log("IM HUNGER");
    }
    
    public void GainFood(int amount)
    {
        foodLevel += amount;
        
        if (foodLevel > 100)
        {
            foodLevel = 100;
            Debug.Log("MAX HUNGER");
        }
    }
    
    public int GetFood() { return foodLevel; }

    public void LoseHappiness(int amount)
    {
        happinessLevel -= amount;
        
        if(happinessLevel <= 0)
            Debug.Log("IM SAD :(");
    }
    
    public void GainHappiness(int amount)
    {
        happinessLevel += amount;
        
        if (happinessLevel > 100)
        {
            happinessLevel = 100;
            Debug.Log("MAX HAPPY :)");
        }
    }
    
    public int GetHappiness() { return happinessLevel; }


    #region old

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

    #endregion

   


}
