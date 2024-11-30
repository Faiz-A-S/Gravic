using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaManager : MonoBehaviour
{
    public Pizzas Pizzas;
    public Text TextSoal;
    public string PromptString1;
    public string PromptString2;
    public PlateOnTop _onPlate;
    private int _onPlatePizza;
    private int _pizzaWeNeed;

    void Start()
    {
        GeneratePizza();
    }

    void GeneratePizza()
    {
        _pizzaWeNeed = Pizzas.PizzaWeNeed = Pizzas.RandomPizzaWeNeed();
        TextSoal.text = PromptString1 + " " + Pizzas.PizzaWeNeed + "/" + Pizzas.MaxPizzaOnPrefab + " " + PromptString2;
    }

    private void Update()
    {
        _onPlatePizza = _onPlate.GetOnPiring();
    }
    public void Siap()
    {
        if (_onPlatePizza.Equals(_pizzaWeNeed))
        {
            Debug.Log("SIAP");
            Fungus.Flowchart.BroadcastFungusMessage("PizzaBenar");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Belum SIAP");
            Fungus.Flowchart.BroadcastFungusMessage("PizzaSalah");
            Destroy(gameObject);
        }
    }
    
    public void Tampil()
    {
        Instantiate(gameObject);
    }
}
