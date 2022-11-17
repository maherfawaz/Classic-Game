using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;  // We need this to make Tiles & Tilemaps work

public class BuildTilemapFromData : MonoBehaviour {
    static public Tile[] VISUAL_TILES;

    [NaughtyAttributes.Button("Fill Tilemap from Text")]
    void FillTileMap() {
        MapInfo.LoadMap( mapDataText.text );
        LoadTiles();
        ShowTiles();
    }

    [Header( "Inscribed" )]
    public string resourcesFolderHoldingTiles = "Tiles_Visual";
    public TextAsset mapDataText;
    public Tilemap tilemapToFill;

    private TileBase[] visualTileBaseArray;

    //void Awake() {
    //    LoadTiles();
    //}

    //void Start() {
    //    ShowTiles();                                                         // a
    //}

    /// <summary>
    /// Load all the Tiles from the Resources/Tiles_Visual folder into an array.
    /// </summary>
    void LoadTiles() {
        int num;

        // Load all of the Sprites from DelverTiles
        Tile[] tempTiles = Resources.LoadAll<Tile>( resourcesFolderHoldingTiles );        // a

        // The order of the Tiles is not guaranteed, so arrange them by number
        VISUAL_TILES = new Tile[tempTiles.Length];
        for ( int i = 0; i < tempTiles.Length; i++ ) {
            string[] bits = tempTiles[i].name.Split( '_' );                  // b
            if ( int.TryParse( bits[1], out num ) ) {                        // c
                VISUAL_TILES[num] = tempTiles[i];
            } else {
                Debug.LogError( "Failed to parse num of: " + tempTiles[i].name );// d
            }
        }
        Debug.Log( "Parsed " + VISUAL_TILES.Length + " tiles into TILES_VISUAL." );
    }

    /// <summary>
    /// Uses GetMapTiles() to generate an array of TileBases with the right tile
    ///  in each position on the map. Then set them as a block on visualMap.
    /// </summary>
    void ShowTiles() {
        visualTileBaseArray = GetMapTiles();                                 // b
        tilemapToFill.SetTilesBlock( MapInfo.GET_MAP_BOUNDS(), visualTileBaseArray );
    }

    /// <summary>
    /// Use MapInfo.MAP to create a TileBase[] array holding the tiles to fill
    ///  the visualMap Tilemap.
    /// </summary>
    /// <returns>The TileBases for visualMap</returns>
    public TileBase[] GetMapTiles() {
        int tileNum;
        Tile tile;
        TileBase[] mapTiles = new TileBase[MapInfo.W * MapInfo.H];
        for ( int y = 0; y < MapInfo.H; y++ ) {
            for ( int x = 0; x < MapInfo.W; x++ ) {
                tileNum = MapInfo.MAP[x, y];                               // c
                tile = VISUAL_TILES[tileNum];                              // d
                mapTiles[y * MapInfo.W + x] = tile;                        // e
            }
        }
        return mapTiles;
    }

}