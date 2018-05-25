using System;
using System.Collections.Generic;

class King : Piece
{
    public King(Coordinate aPosition, string aColor, Board aBoard, char aType = 'K')
        : base(aPosition, aColor, aBoard, aType)
    {
    }

    public override void findPossibleMoves() //king can move in any direction by one square
    {
        PossibleMoves.Clear();
        //check up
        Coordinate mPosition = new Coordinate(Position);
        if (mPosition.changeRank(1))
        {
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);
        }
        //check down
        mPosition = new Coordinate(Position);
        if (mPosition.changeRank(-1))
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);
        //check right
        mPosition = new Coordinate(Position);
        if (mPosition.changeFile(1))
        {

            if (board.CheckColor(mPosition) == "none")
                PossibleMoves.Add(mPosition);
        }

        //check left
        mPosition = new Coordinate(Position);
        if (mPosition.changeFile(-1))
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);
        //check up right
        mPosition = new Coordinate(Position);
        if (mPosition.changeDiagonal(1, 1))
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);
        //check up left
        mPosition = new Coordinate(Position);
        if (mPosition.changeDiagonal(1, -1))
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);
        //check down right
        mPosition = new Coordinate(Position);
        if (mPosition.changeDiagonal(-1, 1))
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);
        //check down left
        mPosition = new Coordinate(Position);
        if (mPosition.changeDiagonal(-1, -1))
            if (!isSameColor(mPosition))
                PossibleMoves.Add(mPosition);
    }

    public bool canCastleKingside() //returns true if king can castle Kingside (from E file to G file)
    {
        //check for castling kingside
        Piece rook = new Piece();
        Coordinate pTmp = new Coordinate(Position);
        pTmp.changeFile(3);
        rook = board.board[pTmp.Rank, pTmp.File];
        if (rook == null) //there is no piece where rook should be
            return false;
        if (!(rook is Rook)) //the piece there is not a rook
            return false;
        if (rook.hasMoved == true) //the rook there has already moved
            return false;
        //figure out if the squares between the rook and king are empty MOVE TO POSSIBLE/LEGAL MOVES
        pTmp.changeFile(-1);
        if (board.isTherePiece(pTmp) == true) //if there is a piece on G file
            return false;
        if (IntoCheck(pTmp)) //if being on the G file would cause check
            return false;
        pTmp.changeFile(-1);
        if (board.isTherePiece(pTmp) == true) //if there is a piece on F file
            return false;
        if (IntoCheck(pTmp)) //if being on F file would cause check
            return false;
        if (board.inCheck(Color)) //if the king is already in check
            return false;
        //if all of these are false and it has reached here, castling kingside is legal
        return true;
    }

    public bool canCastleQueenside() //returns true if the king can castle queenside (from E file to C file)
    {
        Piece rook = new Piece();
        Coordinate pTmp = new Coordinate(Position);
        pTmp.changeFile(-4); //moves from E file to A file
        rook = board.board[pTmp.Rank, pTmp.File];
        if (rook == null) //there is no piece where rook should be
            return false;
        if (!(rook is Rook)) //the piece there is not a rook
            return false;
        if (rook.hasMoved == true) //the rook there has already moved
            return false;
        //figure out if the squares between the rook and king are empty MOVE TO POSSIBLE/LEGAL MOVES
        pTmp.changeFile(1);
        if (board.isTherePiece(pTmp) == true) //if there is a piece on B file
            return false;

        pTmp.changeFile(1);
        if (board.isTherePiece(pTmp) == true) //if there is a piece on C file
            return false;
        if (IntoCheck(pTmp)) //if being on C file would cause check
            return false;
        pTmp.changeFile(1);
        if (board.isTherePiece(pTmp) == true) //if there is a piece on the D file
            return false;
        if (IntoCheck(pTmp)) //if being on the D file would cause check
            return false;
        if (board.inCheck(Color)) //if the king is already in check
            return false;
        //if all of these are false and it has reached here, castling kingside is legal
        pTmp.changeFile(-1); //moves pTmp from D file to C file
        LegalMoves.Add(pTmp);

        return true;
    }

    public King() //blank constructor
    {

    }

    public King(King piece) //duplicator
        :base(piece)
    {
       
    }
}
//Cannot use IntoCheck in PossibleMoves because it would cause recursive definition
//Cannot call findPossibleMoves on the opposite color because of recursive definition for the kings. White king finding if it could castle would require
//the black king finding out if it could castle which would require the white king finding out if it could castle.
//How do I find if placing the king in castling would cause check? Consider only looking for castle in LegalMoves definition?
//Possible because the ability to castle does not effect if it puts the other king in check
