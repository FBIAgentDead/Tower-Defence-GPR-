using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiUnit : MonoBehaviour {

    [SerializeField]
    GameObject unit;
    private string name;
    [SerializeField]
    private int unitHealth;
    [SerializeField]
    private int unitDamage;
    [SerializeField]
    private float unitSpeed;
    private Vector2 spawnlocation;
    [SerializeField]
    private Transform[] pathStrait;

    void Awake()
    {
        StartCoroutine("PathMovement");
    }


    public int getHealth { set { getHealth = value; } get { return unitHealth; } }
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
        //to be continued...
    }

    //gets the next tile for the waypoint system
    private int NextTile(int index, Transform[] lenght){
        if(index == lenght.Length)
        return index;
        else
        return (index+1);
    }

    //waypoint system moves from tile to tile pretty ez right?
    IEnumerator PathMovement(){
        for(int i = 0; i < pathStrait.Length; i++){
            float temp = 0;
            if(unit.transform.position != pathStrait[pathStrait.Length - 1].position){
                while(unit.transform.position != pathStrait[NextTile(i, pathStrait)].position){
                    unit.transform.position = Vector3.Lerp(unit.transform.position, pathStrait[NextTile(i, pathStrait)].position, temp);
                    temp += (unitSpeed/10);
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
    }

}
