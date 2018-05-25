using System;
using System.Collections.Generic;


public class Queen : Piece
{
    public Queen(Coordinate aPosition, string aColor, Board pBoard)
        : base(aPosition, aColor, pBoard, 'Q')
    {

    }

    public override void findPossibleMoves() //combines the moves of a rook and bishop, along files, ranks, and diagonals
    {
        PossibleMoves.Clear();
        Coordinate mPosition = new Coordinate(Position);
        string color;
        Action<int, int> checkDiagonal = (x, y) =>
        {
            for (; mPosition.changeDiagonal(x, y); )
            {
                color = board.CheckColor(mPosition);
                if (color == "none")
                {
                    
                    PossibleMoves.Add(mPosition);
                    mPosition = new Coordinate(mPosition);
                }

                else if (color != Color)
                {
                    // if (!IntoCheck(mPosition))
                    PossibleMoves.Add(mPosition);
                    break;
                }
                else
                    break;
            }
            mPosition = new Coordinate(Position);
        };
        Action<int> checkFile = (direction) =>
        {
            mPosition = new Coordinate(Position);
            for (; mPosition.changeFile(direction); )
            {
                color = board.CheckColor(mPosition);
                if (color == "none") //no piece, continue normally
                {
                    PossibleMoves.Add(mPosition);

                }
                else if (color != Color) //opposite piece, add its position and stop
                {
                    PossibleMoves.Add(mPosition);
                    break;
                }
                else //same color piece, don't add and stop
                    break;
                mPosition = new Coordinate(mPosition);
            }
            mPosition = new Coordinate(Position); //new coordinate object, resets position as well
        };
        Action<int> checkRank = (direction) =>
        {
            mPosition = new Coordinate(Position);
            for (; mPosition.changeRank(direction); )
            {
                color = board.CheckColor(mPosition);
                if (color == Color)
                    break;
                else if (color == "none")
                {
                    PossibleMoves.Add(mPosition);
                    mPosition = new Coordinate(mPosition);
                }
                else //opposite piece, add its position and stop
                { //bug occurs somewhere here, goes one position further than it should, or perhaps even past
                    PossibleMoves.Add(mPosition);
                    break;
                }
            }
            mPosition = new Coordinate(Position); //new coordinate object, resets position as well
        };

        checkFile(1); //check right
        checkFile(-1); //check left
        checkRank(1); //check up
        checkRank(-1); //check down
        
        checkDiagonal(1, 1); //up right
        checkDiagonal(1, -1); //up left
        checkDiagonal(-1, 1); //down right
        checkDiagonal(-1, -1); //down left
    }

    public Queen (Queen piece) //duplicator
        : base(piece)
    {

    }
}

