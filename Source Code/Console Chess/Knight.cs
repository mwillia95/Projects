using System;
using System.Collections.Generic;


class Knight : Piece
{
    public Knight(Coordinate aPosition, string aColor, Board aBoard) : base(aPosition, aColor, aBoard, 'N')
    {
    }

    public override void findPossibleMoves() //can move in L shapes, can also move over pieces
    {
        PossibleMoves.Clear();
        Coordinate mPosition = new Coordinate(Position);
        if (mPosition.changeDiagonal(2, 1))
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);

        mPosition = new Coordinate(Position);
        if (mPosition.changeDiagonal(1, 2))
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);

        mPosition = new Coordinate(Position);
        if (mPosition.changeDiagonal(-2, 1))
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);

        mPosition = new Coordinate(Position);
        if (mPosition.changeDiagonal(-1, 2))
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);

        mPosition = new Coordinate(Position);
        if (mPosition.changeDiagonal(2, -1))
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);

        mPosition = new Coordinate(Position);
        if (mPosition.changeDiagonal(1, -2))
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);

        mPosition = new Coordinate(Position);
        if (mPosition.changeDiagonal(-2, -1))
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);

        mPosition = new Coordinate(Position);
        if (mPosition.changeDiagonal(-1, -2))
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);
    }

    public Knight(Knight piece) //duplicator
        : base(piece)
    {

    }
}

