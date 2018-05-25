using System;
using System.Collections.Generic;


class Bishop : Piece
{
    public Bishop(Coordinate aPosition, string aColor, Board aBoard) : base(aPosition, aColor, aBoard, 'B')
    {
    }

    public override void findPossibleMoves() //bishop can move along any diagonal as long as it is not blocked
    {
        PossibleMoves.Clear();
        Coordinate mPosition = new Coordinate(Position);
        string color;
        Action<int, int> checkDiagonal = (x, y) =>
        {
            for (; mPosition.changeDiagonal(x, y);)
            {
                color = board.CheckColor(mPosition);
                if (color == "none")
                {
                    //if (!IntoCheck(mPosition))
                    PossibleMoves.Add(mPosition);
                    mPosition = new Coordinate(mPosition);

                }

                else if (color != Color)
                {
                    //if (!IntoCheck(mPosition))
                    PossibleMoves.Add(mPosition);
                    break;
                }
                else
                    break;
            }
            mPosition = new Coordinate(Position);
        };
        checkDiagonal(1, 1); //up right
        checkDiagonal(1, -1); //up left
        checkDiagonal(-1, 1); //down right
        checkDiagonal(-1, -1); //down left
    }

    public Bishop(Bishop piece) //duplicator
        : base(piece)
    {

    }
}

