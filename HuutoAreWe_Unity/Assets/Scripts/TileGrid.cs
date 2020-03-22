﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid : MonoBehaviour
{
    public GameObject DefaultTile;
    public float TileScale = 1;
    public int TileWidth = 20;
    public int TileHeight = 10;

    public List<EditorTile> TileGridList = new List<EditorTile>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int i = 0; i < TileWidth; i++)
        {
            for (int j = 0; j < TileHeight; j++)
            {
                GameObject go = GameObject.Instantiate(DefaultTile, this.transform);
                go.name = $"{i},{j}";
                go.transform.localPosition = new Vector2(i * TileScale, j * TileScale);
                go.transform.localScale = new Vector2(TileScale, TileScale);

                EditorTile editorTile = go.GetComponent<EditorTile>();
                editorTile.SetCoords(i, j);
                TileGridList.Add(editorTile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
