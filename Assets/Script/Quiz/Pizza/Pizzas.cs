using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pizza", menuName ="Gravic/Pizza")]
public class Pizzas : ScriptableObject
{
    public string Prompt;
    public GameObject Pizza;
    public int PizzaWeNeed;
    public int MaxPizzaOnPrefab;

    public virtual int RandomPizzaWeNeed()
    {
        return (Random.Range(1, MaxPizzaOnPrefab));
    }
}
