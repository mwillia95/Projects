using System;
using System.Collections.Generic;

//The base class that chess pieces inherit from
//Includes methods and attritubes shared across all pieces
public class Piece : IEquatable<Piece>
{
    public char Type;
    public Coordinate Position;
    public string Color;
    public List<Coordinate> LegalMoves = new List<Coordinate>();
    public List<Coordinate> PossibleMoves = new List<Coordinate>();
    public bool hasMoved;
    public Board board;
    public Piece(Coordinate aPosition, string aColor, Board aBoard, char aType = 'P', bool aHasMoved = false)
    {
        Type = aType;
        Position = aPosition;
        board = aBoard;
        if (aColor.ToLower() == "white")
            Color = "white";
        else if (aColor.ToLower() == "black")
            Color = "black";
        else
            throw new Exception("Invalid color was input for piece. Use black or white.");
        hasMoved = aHasMoved;
    }
    public Piece() //only use blank to avoid null calls
    {

    }

    public bool isSameColor(Coordinate position) //returns true if this pieces color matches the color at position
    {
        if (board.CheckColor(position) == Color)
            return true;
        return false;
    }

    public bool isOppositeColor(Coordinate position) //returns true if there IS a piece but a different color
    {
        if (board.CheckColor(position) != Color && board.CheckColor(position) != "none")
            return true;
        return false;
    }

    public void findLegalMoves() //pick a possible move, perform it. calculate opposite colors possible moves and see if same color king's position is in opposite color's possible moves
    {
        LegalMoves.Clear();
        foreach (Coordinate position in PossibleMoves)
        {
            if (!IntoCheck(position))
                LegalMoves.Add(position);
        }
    }

    public virtual void findPossibleMoves() //consider range of piece, if there is a same color piece, and stopping when running into another piece
    {

    }
    public bool IntoCheck(Coordinate newPosition) //check to see if moving the piece puts itself in check. moves pieces back regardless of result
    { //extend into check to include capturing the other teams king
        Coordinate oldPosition = new Coordinate(Position); //copy old position
        Piece mPiece; //save the pointer to the piece of the square being moved to
        bool check = false; //default case
        mPiece = board.board[newPosition.Rank, newPosition.File];
        //board.getPiece(newPosition, out mPiece); //saves what piece is on the square we are moving to (null if no piece is there)
        board.PlacePiece(this, newPosition); //place the piece to its new position (the position it was at is now null)
        //by placing 'this' over the opposite colored piece, the opposite piece is no longer on the board so its legal moves are not checked
        if(board.inCheck(Color) == true) //moving the piece put itself in check
            check = true; //king would be put into check
        if (mPiece != null) //to avoid overwriting where it just came from
        {
            board.board[newPosition.Rank, newPosition.File] = mPiece; //reassigns the pieces back
            board.board[oldPosition.Rank, oldPosition.File] = this;
            Position = oldPosition;
        }
        else
            board.PlacePiece(this, oldPosition); //place the piece back to its position
        return check;
    }
    public void findAllMoves() //finds Possible and Legal moves (NOT USED)
    {
        findPossibleMoves();
        findLegalMoves();
    }

    public void DisplayPossible() //debug method, displays possible moves (check not considered)
    {
        foreach (Coordinate p in PossibleMoves)
        {
            Console.Write(p);
            Console.Write(" ");
        }
    }

    public void DisplayLegal() //debug method, displays legal moves (cannot move into check)
    {
        foreach (Coordinate p in LegalMoves)
        {
            Console.Write(p);
            Console.Write(" ");
        }
    }

    public override string ToString() //returns the Type of the piece (i.e 'P' for Pawn)
    {
        return Type.ToString();
    }

    public void Display() //Displays information of the piece to the console (Debug)
    {
        if (Position == null) //display was called on a null piece
        {
            Console.WriteLine("No piece at this position");
            return;
        }
        Console.WriteLine(Type.ToString() + " @ " + Position);
        Console.WriteLine("Displaying possible moves before check:");
        DisplayPossible();
        Console.WriteLine();
        Console.WriteLine("Displaying legal moves only:");
        DisplayLegal();
    }

    public bool Equals(Piece p) //Position is unique identifier, at most only one piece should ever be on any square
    {
        if (p.Position == Position)
            return true;
        return false;
    }
    
    public Piece(Piece p) //Dupicator constructor, especially for copying pieces from one board to another while avoiding pointer issues
    {
        if (p == null)
            return;

        LegalMoves.AddRange(p.LegalMoves);
        PossibleMoves.AddRange(p.PossibleMoves);
        Type = p.Type;
        Color = p.Color;
        board = p.board;
        Position = new Coordinate(p.Position);
        hasMoved = p.hasMoved;
    }
}