/* Program name: Maze Generation
   Project file name: Node.cs
   Author: Marco Koen
   Date: 14/06/2022
   Language: C#
   Platform: Windows
   Purpose: A utility class of node
   Description: Creates nodes and sets their x and y + other settings. Allows us to create our paths.
   Known Bugs:
   Additional Features:
*/
public class Node
{
    public int x;
    public int y;

    public int gCost;
    public int hCost;
    public int fCost;

    public Node cameFromNode;

    public bool isWalkable;

    public Node(int x, int y, bool isWalkable)
    {
        this.x = x;
        this.y = y;
        hCost = 0;
        this.isWalkable = isWalkable;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }
}