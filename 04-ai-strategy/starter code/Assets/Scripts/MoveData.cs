/* Program name: 04-ai-strategy
   Project file name: MoveData.cs
   Author: Marco Koen
   Date: 20/06/2022
   Language: C#
   Platform: Windows
   Purpose: Holds the move data?
   Description: 
   Known Bugs:
   Additional Features:
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveData
{
    public TileData firstPosition = null;
    public TileData secondPosition = null;
    public ChessPiece pieceMoved = null;
    public ChessPiece pieceKilled = null;
    public int score = int.MinValue;
}
