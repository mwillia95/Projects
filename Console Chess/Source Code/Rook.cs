using System;
using System.Collections.Generic;


class Rook : Piece
{

    public Rook(Coordinate aPosition, string aColor, Board aBoard) : base(aPosition, aColor, aBoard, 'R')
    {
    }

    public override void findPossibleMoves() //can move along file or rank, as long as it is not blocked
    {
        PossibleMoves.Clear();
        Coordinate pTmp = new Coordinate(Position);
        string color;
        Action<int> checkFile = (direction) =>
        {
            pTmp = new Coordinate(Position);
            for (; pTmp.changeFile(direction); )
            {
                color = board.CheckColor(pTmp);
                if (color == "none") //no piece, continue normally
                {
                    PossibleMoves.Add(pTmp);

                }
                else if (color != Color) //opposite piece, add its position and stop
                {
                    PossibleMoves.Add(pTmp);
                    break;
                }
                else //same color piece, don't add and stop
                    break;
                pTmp = new Coordinate(pTmp);
            }
            pTmp = new Coordinate(Position); //new coordinate object, resets position as well
        };
        Action<int> checkRank = (direction) =>
        {
            pTmp = new Coordinate(Position);
            for (; pTmp.changeRank(direction);)
            {
                color = board.CheckColor(pTmp);
                if (color == Color)
                    break;
                else if (color == "none")
                {
                    PossibleMoves.Add(pTmp);
                    pTmp = new Coordinate(pTmp);
                }
                else //opposite piece, add its position and stop
                { //bug occurs somewhere here, goes one position further than it should, or perhaps even past
                    PossibleMoves.Add(pTmp);
                    Console.WriteLine("Ocuured attempting position " + pTmp);
                    break;
                }
            }
            pTmp = new Coordinate(Position); //new coordinate object, resets position as well
        };

        checkFile(1); //check right
        checkFile(-1); //check left
        checkRank(1); //check up
        checkRank(-1); //check down
    }

    public Rook(Rook piece) //duplicator
        : base(piece)
    {

    }
}

