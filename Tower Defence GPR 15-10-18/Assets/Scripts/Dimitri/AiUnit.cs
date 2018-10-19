using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiUnit : MonoBehaviour {

    GameObject unit;
    private string name;
    int unitHealth { get { return unitHealth; } set { unitHealth = unitHealth; } }
    private int unitDamage;
    private float unitSpeed;
    
    //constructor
    public AiUnit(string unitName, int health, int damage, float speed = 1)
    {
        name = unitName;
        unitHealth = health;
        unitDamage = damage;
        unitSpeed = speed;
        GetGameObject();
    }

    //gets the gameobject by tag with the given name
    private void GetGameObject()
    {
        unit = GameObject.FindGameObjectWithTag(name);
    }

}
