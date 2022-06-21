/* Program name: 04-ai-strategy
   Project file name: MoveHeuristic.cs
   Author: Marco Koen
   Date: 20/06/2022
   Language: C#
   Platform: Windows
   Purpose: Manages the chess weights.
   Description: 
   Known Bugs:
   Additional Features:
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHeuristic
{
    public int GetPieceWeight(ChessPiece.PieceType type)
    {
        switch (type)
        {
            case ChessPiece.PieceType.PAWN:
                return 10;            
            case ChessPiece.PieceType.KNIGHT:
                return 30;
            case ChessPiece.PieceType.BISHOP:
                return 30;
            case ChessPiece.PieceType.ROOK:
                return 50;
            case ChessPiece.PieceType.QUEEN:
                return 90;
            case ChessPiece.PieceType.KING:
                return 10000;
            default:
                return -1;
        }
    }
}
