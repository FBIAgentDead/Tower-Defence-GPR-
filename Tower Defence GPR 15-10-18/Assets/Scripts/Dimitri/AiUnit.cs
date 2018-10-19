using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiUnit : MonoBehaviour {

    GameObject unit;
    private string name;
    int unitHealth { get { return unitHealth; } set { unitHealth = unitHealth; } }
    private int unitDamage;
    private float unitSpeed;
    private Vector2 spawnlocation;
    
    //constructor
    public AiUnit(string unitName,Vector2 spawn, int health, int damage, float speed = 1)
    {
        name = unitName;
        unitHealth = health;
        unitDamage = damage;
        unitSpeed = speed;
        spawnlocation = spawn;
        GetGameObject();
    }

    //gets the gameobject by tag with the given name
    private void GetGameObject()
    {
        unit = GameObject.FindGameObjectWithTag(name);
        Instantiate(unit, spawnlocation, Quaternion.identity);
    }

}
