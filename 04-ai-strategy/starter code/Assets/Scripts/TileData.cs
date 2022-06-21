/* Program name: 04-ai-strategy
   Project file name: TileData.cs
   Author: Marco Koen
   Date: 20/06/2022
   Language: C#
   Platform: Windows
   Purpose: Holds the TileData
   Description: 
   Known Bugs:
   Additional Features:
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData
{
    private Vector2 position = Vector2.zero;
    public Vector2 Position
    {
        get{ return position; }
    }

    private ChessPiece currentPiece = null;
    public ChessPiece CurrentPiece
    {
        get{ return currentPiece; }
        set{ currentPiece = value; }
    }

    public TileData(int x, int y)
    {
        position.x = x;
        position.y = y;

        if (y == 0 || y == 1 || y == 6 || y == 7)        
            currentPiece = GameObject.Find("[" + x.ToString() + "," + y.ToString() + "]").GetComponent<ChessPiece>();        
    }

    public void SwapFakePieces(ChessPiece newPiece)
    {
        currentPiece = newPiece;
    }
}
