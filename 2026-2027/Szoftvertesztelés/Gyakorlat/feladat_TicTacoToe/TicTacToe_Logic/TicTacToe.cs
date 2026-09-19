using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace TicTacToe_Lib;

public class TicTacToe
{
    private int[,] gameMap;
    public int actualPlayer;

    public TicTacToe()
    {
        gameMap = new int[3,3];
        actualPlayer = 1;
    }

    public bool isEmpty(int x, int y)
    {
        return gameMap[x, y] == 0;
    }

    public bool Place(int x,int y)
    {
        if (GameWon()) throw new Exception("megnyert játék");
        if (NoMoreMoves()) throw new Exception("nincs több lépés");

        if (isEmpty(x, y))
        // && !GameWon() && !NoMoreMoves()
        {
            gameMap[x, y] = actualPlayer;
            if (actualPlayer == 1) actualPlayer++;
            else actualPlayer = 1;
            return true;
        }
        return false;
    }

    public bool NoMoreMoves()
    {
        foreach(int field in gameMap)
        {
            if (field == 0) return false; // we found an empty space, so we return false (meaning it is not true, that there are no more moves
        }
        return true;
    }

    public bool GameWon()
    {
        for (int i = 0; i < 3; i++)
        {
            // check horizontal and vertical
            if ((gameMap[0, i]> 0 && gameMap[0, i] == gameMap[1, i] && gameMap[0, i] == gameMap[2, i]) ||
                // the field is not empty and all field in the row are the same
               (gameMap[i, 0] > 0 && gameMap[i, 0] == gameMap[i, 1] && gameMap[i, 0] == gameMap[i, 0]))
            {   // the field is not empty and all field in the column are the same
                return true;
            }
        }

        // check diagonals
            if ((gameMap[0, 0]> 0 && gameMap[0, 0] == gameMap[1, 1] && gameMap[0, 0] == gameMap[2, 2]) ||  
               (gameMap[0, 2] > 0 && gameMap[0, 2] == gameMap[1, 1] && gameMap[0, 2] == gameMap[2, 0]))
            {   // the field is not empty and all field in the diagonal are the same
                return true;
            }
        return false;
    }
}
