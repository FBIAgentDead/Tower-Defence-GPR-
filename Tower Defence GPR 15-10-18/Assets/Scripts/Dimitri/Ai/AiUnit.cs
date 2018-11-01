using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiUnit : MonoBehaviour {

    GameObject unitPrefab;
    GameObject unit;
    private string name;
    private int unitHealth;
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


    public int getHealth { set { getHealth = value; } get { return unitHealth; } }

    //gets the gameobject by tag with the given name and instantiate on given spawn
    private void GetGameObject()
    {
        unitPrefab = GameObject.FindGameObjectWithTag(name);
        unit = Instantiate(unitPrefab, spawnlocation, Quaternion.identity);
    }
    public Vector2 position { get {return unit.transform.position; } }

    //AI movement with the algorithm A*
    private void APathfinding()
    {
        GridMaster grid = gameObject.AddComponent<GridMaster>();//list for all the tiles
        Dictionary<string,Tile> open = new Dictionary< string,Tile>();//list for all tiles that still have 2 be checked
        List<Tile> closed = new List<Tile>();//tiles that have been checked

        //this below is going to be looped to find the right path the lists stay filled

        //check if current tile is finish
        if(grid.mainGrid.GetTile(unit.transform.position).getTileType == TileTypes.EnemyBase){
            //when AIunit reached enemy base
        }
        else{
            closed.Add(grid.mainGrid.GetTile(unit.transform.position));
        }

        //gets all the parent Tiles not 8 but 4 cause you can't go diognal in the game
        if(grid.mainGrid.GetTile(unit.transform.position, 1).getTileType == TileTypes.Path)
            open.Add("rightNeighbour",grid.mainGrid.GetTile(unit.transform.position, 1));
        if (grid.mainGrid.GetTile(unit.transform.position, -1).getTileType == TileTypes.Path)
            open.Add("leftNeighbour",grid.mainGrid.GetTile(unit.transform.position, -1));
        if (grid.mainGrid.GetTile(unit.transform.position, 0, 1).getTileType == TileTypes.Path)
            open.Add("upNeighbour",grid.mainGrid.GetTile(unit.transform.position, 0, 1));
        if (grid.mainGrid.GetTile(unit.transform.position, 0, -1).getTileType == TileTypes.Path)
            open.Add("downNeighbour",grid.mainGrid.GetTile(unit.transform.position, 0, -1));

        //for each tile in open its going to check wich one has the best values and then move towards that one
        //to be continued...
    }

    
    //lerp from tile a to tile b with the use of unitSpeed giving in constructor
    private IEnumerator MoveTo(Tile b){
        float t = 0;
        while(t < 1){
            Debug.Log("moving");
            unit.transform.position = Vector2.Lerp(unit.transform.position, b.position, t);
            t += unitSpeed/10;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
