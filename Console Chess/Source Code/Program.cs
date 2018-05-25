using System;
using System.Collections.Generic;


//Figure out how to update the chess board without rewriting the entire board.
class Program
{
    static void Main(string[] args)
    {
        Intro();
        while (true) //always within this loop until an environment exit
        {
            Board ChessBoard;
            Console.WriteLine("Would you like to customize setup? (Y/N)");
            string input = Console.ReadLine();

            if (input.ToLower() == "y")
                ChessBoard = new Board(false); //customized setup
            else
                ChessBoard = new Board();

            List<Piece[,]> SavedBoards = new List<Piece[,]>(); //this list is to allow the user to move back and forth to saved board states
            SavedBoards.Add(ChessBoard.Copy(ChessBoard.board)); //add a copy of this board (standard start) as the first board of the list
            while (true) //loops through moves until checkmate/draw/restart
            {
                ChessBoard.Display();

                try
                {
                    ChessBoard.Turn("white", SavedBoards);
                }
                catch (Exception e) //this should only have to catch checkmate or stalemate or a user-started restart
                { //can also catch outstanding errors that should not occur
                    ChessBoard.Display();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to restart game");
                    Console.ReadKey();
                    break;
                }
                ChessBoard.Display();

                try
                {
                    ChessBoard.Turn("black", SavedBoards);
                }
                catch (Exception e)
                {
                    ChessBoard.Display();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to restart game");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
    public static void Intro()
    {
        Console.WriteLine("Welcome to the Chess Console Application.");
        Console.WriteLine("This application can functionally take input to represent a game of chess.");
        Console.WriteLine("Formatting is required for the input:");
        Console.WriteLine("1: Start with the type of the piece for the first letter as a capital letter. \n(i.e. B for bishop, N for Knight, K for king)");
        Console.WriteLine("If the piece is a pawn, do not include the type.");
        Console.WriteLine("2: Specify the square for the piece to travel to: one letter for the file and a number for the rank. (i.e. e4)");
        Console.WriteLine("The file (a-h) should be lowercase. The rank should between 1 to 8");
        Console.WriteLine("Example: Pawn (e4) Knight (Nf3)");
        Console.WriteLine();
        Console.WriteLine("Special Conditions:");
        Console.WriteLine("If two pieces of the same type are able to travel to the square you want one piece to go:");
        Console.WriteLine("Include a file specification after the type letter if they are not on the same file (Nbd2, ed5)");
        Console.WriteLine("Include a rank specification after the type letter if they are on the same file (R8b2)");
        Console.WriteLine();
        Console.WriteLine("In order to castle Kingside, type: 0-0. To castle Queenside, type: 0-0-0");
        Console.WriteLine("If you wish to go back a move, type: back");
        Console.WriteLine("To move back forward, type: forward");
        Console.WriteLine("If you go back and make a move from a previous position, all moves backtracked from will be\n deleted.");
        Console.WriteLine("Type restart if you wish to restart the game.");
        Console.WriteLine("Type exit if you wish to exit the application.");
        Console.WriteLine("Press Enter to continue to the game...");
        Console.ReadLine();
    }
}
