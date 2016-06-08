using UnityEngine;
using System.Collections;

public class HexGridGenerator : MonoBehaviour {
    
    //Array of tile types
    public Transform[] hexTiles;

    //The sizeXsize 
    public int x = 5;
    public int y = 5;

    //Basically this will get set based on the size of the tile
    //1/2 of its size and will spawn the radius above the last row
    //that way they are evenly spaced
    public float radius = 1.0f;

    //are we calculating the distance from the center? Yes for tight packed hex's,
    //no for overlapping hex's
    public bool useAsInnerCircleRadius = true;

    private float offsetX, offsetY;

    void Start()
    {
        radius = hexTiles[0].transform.localScale.x * 0.5f;

        //Used to calculate the grid distance
        float unitLength = (useAsInnerCircleRadius) ? (radius / (Mathf.Sqrt(3) / 2)) : radius;

        offsetX = unitLength * Mathf.Sqrt(3);
        offsetY = unitLength * 1.5f;
        
        //Creation of tiles
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                //Set its position
                Vector2 hexpos = HexOffset(i, j);
                Vector3 pos = new Vector3(hexpos.x, 0, hexpos.y);
                //Create the random tile
                var newTile = Instantiate(hexTiles[Random.Range(0, hexTiles.Length)], pos, Quaternion.identity);
                newTile.name = i.ToString() + " " + j.ToString();
            }
        }
    }

    Vector2 HexOffset(int x, int y)
    {
        Vector2 position = Vector2.zero;

        //basically we check if its an even or odd number
        //Then we generate the rows so that they fit
        //Where the odd ones are slightly higher spawned
        if (y % 2 == 0)
        {
            position.x = x * offsetX;
            position.y = y * offsetY;
        }
        else
        {
            position.x = (x + 0.5f) * offsetX;
            position.y = y * offsetY;
        }

        return position;
    }
}

/*  
    --------------------
    SAME TYPE GENERATION
    --------------------
    Instantiate(hexTile, pos, Quaternion.identity);

    -----------------
    RANDOM GENERATION
    -----------------
    public Transform [] spawnThis;

    ....

    Instantiate( spawnThis[ Random.Range(0,spawnThis.length) ], ..., ... );


    ---------------------
    CONTROLLED GENERATION 
    ---------------------
    public Transform [] tile; // Water, Ground, Tree tiles

    public int W, G, T; //Assign the index of the tiles in the tile[] to here;

    private int [][] formation = 
    {
    { W, W, W, W, W, W, W },
    { W, G, G, G, G, G, W },
    { W, G, T, T, T, G, W },
    { W, G, G, G, G, G, W },
    { W, W, W, W, W, W, W },
    }

    ....

    for( int i = 0; i < formation.length; i++ ) {
    for( int j = 0; j < formation[i].length; j++ ) {
    Vector2 hexpos = HexOffset( i, j );
    Vector3 pos = new Vector3( hexpos.x, hexpos.y, 0 );
    Instantiate(tile[ formation[i][j] ], pos, Quaternion.identity );
    }
    }
*/
