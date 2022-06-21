/* Program name: 04-ai-strategy
   Project file name: BoardManager.cs
   Author: Marco Koen
   Date: 20/06/2022
   Language: C#
   Platform: Windows
   Purpose: Manages and sets up the chess board
   Description: 
   Known Bugs:
   Additional Features:
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private static BoardManager instance;
    public static BoardManager Instance
    {
        get{ return instance; }
    }
    private void Awake()
    {
        if (instance == null)        
            instance = this;        
        else if (instance != this)        
            Destroy(this);    
    }  

    private TileData[,] board = new TileData[8, 8];

    public void SetupBoard()
    {
        for (int y = 0; y < 8; y++)        
            for (int x = 0; x < 8; x++)            
                board[x, y] = new TileData(x, y);                    
    }

    public TileData GetTileFromBoard(Vector2 tile)
    {
        return board[(int)tile.x, (int)tile.y];
    }
}
