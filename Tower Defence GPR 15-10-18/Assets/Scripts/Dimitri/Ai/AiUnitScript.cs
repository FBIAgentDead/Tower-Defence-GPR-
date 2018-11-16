using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Directions {Left, Right, Up, Down}
public class AiUnitScript : MonoBehaviour {

    [SerializeField]
    GameObject unit;
    [SerializeField]
    private int unitHealth;
    [SerializeField]
    private int unitDamage;
    [SerializeField]
    private float unitSpeed;
    public Directions[] path;
    [SerializeField]
    GridMaster tiles;
    void Awake()
    {
        tiles = GameObject.Find("Grid").GetComponent<GridMaster>();
        StartCoroutine("PathMovement");
    }


    public int getHealth { get { return unitHealth; } set { unitHealth = value; } }
    public Vector2 position { get {return unit.transform.position; } }

    // //AI movement with the algorithm A*
    // private void APathfinding()
    // {
    //     GridMaster grid = gameObject.AddComponent<GridMaster>();//list for all the tiles
    //     Tile[,] open = grid.mainGrid.tiles;//list for all tiles that still have 2 be checked
    //     Tile[,] closed = new Tile[Mathf.RoundToInt(grid.mainGrid.tileSizeY),Mathf.RoundToInt(grid.mainGrid.tileSizeX)];//tiles that have been checked
        
    //     for(int i = 0; i < grid.mainGrid.tiles.Length; i++){

    //     }

    //     //this below is going to be looped to find the right path the lists stay filled

    //     //check if current tile is finish
    //     if(grid.mainGrid.GetTile(unit.transform.position).getTileType == TileTypes.EnemyBase){
    //         //when AIunit reached enemy base
    //     }
    //     else{
            
    //     }

    //     //to be continued...
    // }

    void Update()
    {
        // if(tiles.mainGrid.tiles[0,0].getObjects != null){
        //     Debug.Log(tiles.mainGrid.tiles[0,0].getObjects[0].transform.position);
        // }
    }
    
    //using a enum to move left up down right
    IEnumerator PathMovement()
    {
        for (int i = 0; i < path.Length; i++)
        {
            Tile moveTo = tiles.mainGrid.GetTile(unit.transform.position);
            while(moveTo.getTileType == TileTypes.Path || moveTo.getTileType == TileTypes.EnemySpawn){
                float temp = 0;
                if(path[i] == Directions.Left){
                    moveTo = tiles.mainGrid.GetTile(unit.transform.position, -1);
                }
                else if (path[i] == Directions.Right)
                {
                    moveTo = tiles.mainGrid.GetTile(unit.transform.position, 1);
                }
                else if (path[i] == Directions.Up)
                {
                    moveTo = tiles.mainGrid.GetTile(unit.transform.position, 0, -1);
                }
                else
                {
                    moveTo = tiles.mainGrid.GetTile(unit.transform.position, 0, 1);
                }
                if(moveTo.getTileType == TileTypes.Path){
                    while(unit.transform.position != moveTo.position){
                        unit.transform.position = Vector3.Lerp(unit.transform.position, moveTo.position, temp);
                        temp += (unitSpeed / 10);
                        yield return new WaitForSeconds(0.1f);
                    }
                }
            }
        }
    }

}
