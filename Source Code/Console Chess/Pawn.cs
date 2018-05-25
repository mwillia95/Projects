using System;
using System.Collections.Generic;


public class Pawn : Piece
{
    public Pawn(Coordinate aPosition, string aColor, Board aBoard) : base(aPosition, aColor, aBoard, 'P')
    {
    }

    public override void findPossibleMoves() //move forward one, direction dependent on color. can also capture diagonally
    {
        PossibleMoves.Clear();
        int direction = 0;
        if (Color == "white")
            direction = 1;
        else if (Color == "black")
            direction = -1;
        Coordinate mPosition = new Coordinate(Position); //creates a duplicate of pawn's position
        mPosition.changeRank(direction); //to check one in front of the pawn

        string front = board.CheckColor(mPosition);
        if (front == "none") //has opposite colored piece or no piece
        {
            PossibleMoves.Add(mPosition);
            if (hasMoved == false) //can move two spaces up if it has not yet moved and there is no piece already in front of it
            {
                mPosition = new Coordinate(mPosition);
                mPosition.changeRank(direction);
                if (board.CheckColor(mPosition) == "none")
                    PossibleMoves.Add(mPosition);
            }
        }
        mPosition = new Coordinate(Position);


        mPosition.changeRank(direction);
        if (mPosition.changeFile(1)) //checks in front and to the right of the pawn
            if (isOppositeColor(mPosition)) //must have an opposite colored piece
            {
                PossibleMoves.Add(mPosition);
            }

        mPosition = new Coordinate(Position);
        mPosition.changeRank(direction);
        if (mPosition.changeFile(-1)) //checks in front and to the left of the pawn
            if (isOppositeColor(mPosition))
            {
                PossibleMoves.Add(mPosition);
            }
    }


    public void Promote(string pType) //promotes the pawn to a new piece at the same position it was already at
    {
        //Change the pawn to a new type of piece
        if (pType == "N")
            board.PlacePiece(new Knight(Position, Color, board), Position);
        else if (pType == "B")
            board.PlacePiece(new Bishop(Position, Color, board), Position);
        else if (pType == "R")
            board.PlacePiece(new Rook(Position, Color, board), Position);
        else if (pType == "Q")
            board.PlacePiece(new Queen(Position, Color, board), Position);
        else
            throw new Exception("Invalid piece, use N, B, R, or Q.");
        return;
    }

    public Pawn(Pawn piece) //duplicator
        : base(piece)
    {

    }
}
