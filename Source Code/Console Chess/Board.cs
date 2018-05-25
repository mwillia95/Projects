using System;
using System.Collections.Generic;


public class Board
{
    public Piece[,] board = new Piece[8, 8];
    private int mPosition = 0; //points to which position in SavedBoards the board should point to
    public Board(bool standard = true)
    {
        Initialize(standard);
    }

    public Piece[,] Copy(Piece[,] pBoard) //returns a copy of the current board
    {
        Piece[,] newBoard = new Piece[8, 8];
        foreach (Piece p in pBoard)
        {
            if (p != null)
                if (p.Type == 'P')
                {
                    Pawn Tmp = (Pawn)p;
                    Pawn pTmp = new Pawn(Tmp);
                    newBoard[pTmp.Position.Rank, pTmp.Position.File] = pTmp;
                }
                else if (p.Type == 'N')
                {
                    Knight Tmp = (Knight)p;
                    Knight pTmp = new Knight(Tmp);
                    newBoard[pTmp.Position.Rank, pTmp.Position.File] = pTmp;
                }
                else if (p.Type == 'B')
                {
                    Bishop Tmp = (Bishop)p;
                    Bishop pTmp = new Bishop(Tmp);
                    newBoard[pTmp.Position.Rank, pTmp.Position.File] = pTmp;
                }
                else if (p.Type == 'Q')
                {
                    Queen Tmp = (Queen)p;
                    Queen pTmp = new Queen(Tmp);
                    newBoard[pTmp.Position.Rank, pTmp.Position.File] = pTmp;
                }
                else if (p.Type == 'R')
                {
                    Rook Tmp = (Rook)p;
                    Rook pTmp = new Rook(Tmp);
                    newBoard[pTmp.Position.Rank, pTmp.Position.File] = pTmp;
                }
                else if (p.Type == 'K')
                {
                    King Tmp = (King)p;
                    King pTmp = new King(Tmp);
                    newBoard[pTmp.Position.Rank, pTmp.Position.File] = pTmp;
                }
        }
        return newBoard;
    }

    public void Initialize(bool standard) //false would indicate a nonstandard setup
    {
        PlaceAllPieces(); //place the pieces and then determine if the user wants to change them
        if (!standard)
        {
            Initialize();
            return;
        }
        //standard initialization on the board
        PlaceAllPieces();
        AllPossible("white");
        AllLegal("white");
        mPosition = 0;
    }

    private void Initialize() //custom board setup
    {
        Console.WriteLine("Choose how you want to customize pieces:");
        Console.WriteLine("Type the square you want the piece placed (i.e. e8 or a1)");
        Console.WriteLine("Type the piece notation of the piece you want to place (N, B, R, Q, K, P");
        Console.WriteLine("If you wish to change the color piece, change to \"white\" or \"black\" before placing");
        Console.WriteLine("To reset position to standard setup, type: standard");
        Console.WriteLine("To clear all pieces to a blank setup, type: clear");
        Console.WriteLine("When finished setting up board, type: done");
        string color = "white"; //default color
        Coordinate square = new Coordinate(0, 0); //default pos
        int postBoardPos = 0; //represents where the cursor should go to be just after the board
        while (true)
        {
            string input;
            Display();
            postBoardPos = Console.CursorTop;
            Console.WriteLine("Current piece color: {0}", color);
            Console.WriteLine("Current square selected: {0}", square);
            square = new Coordinate(square); //to avoid reference issues
            Console.WriteLine();
            Console.Write("Type out a square, piece, or color to customize board setup: ");
            input = Console.ReadLine();
            //determine what the user input
            if (input.Length == 1 && (isPieceNotation(input[0]) || input == "P")) //user wants to place a color piece at square
            { //must only be one character and a piece notation
                PlacePiece(color, input[0], square);
                continue;
            }
            if (input.Length == 2 && isFile(input[0]) && isRank(input[1])) //user wants to select a square to target
            { //must only be two characters and be in the format file/rank (e4, a1, etc.)
                square.File = Coordinate.FileToInt(input[0]);
                square.Rank = Coordinate.RankToInt(input[1]);
                continue;
            }
            if (input.ToLower() == "white" || input.ToLower() == "black") //user wants to select a color for pieces
            {//can only be black or white
                color = input.ToLower();
                continue;
            }
            if (input.ToLower() == "standard") //user wants to set board to standard setup
            {
                board = new Piece[8, 8]; //clears the board by creating a new one
                PlaceAllPieces();
            }
            if (input.ToLower() == "clear") //user wants to clear all pieces from the board
            {
                board = new Piece[8, 8];
            }
            if (input.ToLower() == "done")
                return;
        }
    }

    public void PlacePiece(string color, char type, Coordinate position) //this method figures out what type needs to be created
    {
        if (type == 'P')
        {
            PlacePiece(new Pawn(position, color, this), position);
        }
        if (type == 'B')
        {
            PlacePiece(new Bishop(position, color, this), position);
        } if (type == 'N')
        {
            PlacePiece(new Knight(position, color, this), position);
        } if (type == 'R')
        {
            PlacePiece(new Rook(position, color, this), position);
        } if (type == 'Q')
        {
            PlacePiece(new Queen(position, color, this), position);
        } if (type == 'K')
        {
            PlacePiece(new King(position, color, this), position);
        }
    }
    public void Display() //find a way to systematically display the board
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.BackgroundColor = ConsoleColor.Black; ;
        Console.WriteLine("\t   ----------------------------------------------------------------");
        for (int x = 7; x >= 0; x--) //x goes down
        {
            Console.Write("\t  |");
            for (int z = 7; z >= 0; z--) //z goes across
            {
                ChooseColor(x, z);
                Console.Write("       ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("|");
            }
            Console.WriteLine();
            Console.Write("\t" + (x + 1) + " |"); //displays the rank
            for (int y = 0; y <= 7; y++) //similar to z but this loop deals with the piece notation
            {
                ChooseColor(x, y + 1);
                Console.Write("   ");
                if (board[x, y] != null)
                {
                    if (board[x, y].Color == "white")
                        Console.ForegroundColor = ConsoleColor.White;
                    else
                        Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(board[x, y]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("   ");
                }
                else
                    Console.Write("    ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("|");
                Console.BackgroundColor = ConsoleColor.DarkGray;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.Write("\t  |");
            for (int z = 7; z >= 0; z--)
            {
                ChooseColor(x, z);
                
                Console.Write("       ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("|");
            }
            Console.WriteLine();
            Console.WriteLine("\t   ----------------------------------------------------------------");

        }
        Console.Write("\t      ");
        for (int x = 0; x <= 7; x++)
            Console.Write(Coordinate.IntToFile(x) + "       "); //displays the file
        Console.WriteLine();

    }

    public void ChooseColor(int row, int col) //chooses what color the square the should be
    {
        if (row % 2 == 0 && col % 2 == 0)
            Console.BackgroundColor = ConsoleColor.Gray;
        else if (row % 2 == 1 && col % 2 == 1)
            Console.BackgroundColor = ConsoleColor.Gray;
        else
            Console.BackgroundColor = ConsoleColor.DarkGray;
    }

    public void PostBoardPos() //sets the cursor the line after the board
    {
        Console.SetCursorPosition(0, 34);
    }

    public void ClearPostBoard() //clear everything just after the board (i.e. error messages / explanation)
    {
        int currentLineCursor = 34;
        for (int x = 0; x < 6; x++) //clears 5 lines below the board
        {

            Console.SetCursorPosition(0, currentLineCursor);
            Console.WriteLine(new string(' ', Console.WindowWidth));
            currentLineCursor += 1;
        }
        PostBoardPos();
    }


    public void Turn(string color, List<Piece[,]> SavedBoards) //take an input in chess notation, perform it if legal, determine if opposite color is in checkmate or stalemate
    {

        Piece target = new Piece(); //outermost block so it can be reached later for promotion attempts
        bool repeat = false;
        do //while repeat == true
        { //method of leaving the loop is either break or return
            if (repeat == true)
                ClearPostBoard(); //remove error messages
            Console.WriteLine(color + " to move...");
            Console.WriteLine("Input Move in Chess Notation: (Xx#) or (x#) if pawn; (Xxx#) or (xx#) if specification needed");
            //if two of the same type of piece can move to one square, specification is needed
            //if they are on differing files, specify file after specifying piece type
            //if they are on the same file, specify rank after specifying piece type
            string input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine("No input given.");
                repeat = true;
                Console.ReadKey();
                continue;
            }
            if (input.ToLower() == "exit")
            {
                while (true)
                {
                    ClearPostBoard();
                    string Input;
                    Console.WriteLine("Are you sure you want to exit the application? (Y/N)");
                    Input = Console.ReadLine();
                    if (Input.ToLower() == "y")
                        Environment.Exit(0);
                    if (Input.ToLower() == "n")
                    {
                        repeat = true;
                        break;
                    }
                }
                continue;
            }
            if (input.ToLower() == "restart")
            {
                while (true) //will loop until the user inputs proper y or n
                {
                    ClearPostBoard();
                    string Input;
                    Console.WriteLine("Are you sure you want to restart this chess game? (Y/N)");
                    Input = Console.ReadLine();
                    if (Input.ToLower() == "y")
                        throw new Exception("User has restarted game...");
                    if (Input.ToLower() == "n")
                    {
                        repeat = true;
                        break;
                    }
                }
                continue;
            }
            if (input.ToLower() == "back") //user wants to move back one move
            {
                if (SavedBoards.Count == 1 || mPosition == 0) //there is only one saved board, should mean no move has been made yet
                {
                    Console.WriteLine("Cannot move back a move any further, already at beginning position");
                    repeat = true;
                    Console.ReadKey();
                    continue;
                }
                mPosition--;
                board = Copy(SavedBoards[mPosition]);
                return;
            }
            else if (input.ToLower() == "forward") //the condition is that if the user moves back, they can move forward as long as they do not make a move
            { //if the user goes back and makes a move, all moves in front of that position should be removed
                if (mPosition == SavedBoards.Count - 1)
                {
                    Console.WriteLine("No position to move forward to.");
                    Console.ReadKey();
                    repeat = true;
                    continue;
                }
                mPosition++;
                board = Copy(SavedBoards[mPosition]);
                return;
            }
            if (input.Length > 5) //lager than possible chess notation input
            {
                repeat = true;
                Console.WriteLine("Invalid Notation: Larger than highest possible length of characters.");
                Console.ReadKey();
                continue; //break back to the beginning
            }
            if (input == "0-0") //user wants to castle kingside (from E file to G file)
            {
                King king = new King();
                foreach (Piece p in board)
                {
                    if (p is King && p.Color == color)
                        king = (King)p;
                }
                if (king.canCastleKingside() == false)
                {
                    Console.WriteLine("Invalid Notation: King cannot castle Kingside");
                    Console.ReadKey();
                    repeat = true;
                    continue;
                }
                //won't reach here unless the king can castle kingside
                Coordinate pTmp = new Coordinate(king.Position);
                Piece rook = board[pTmp.Rank, pTmp.File + 3];
                pTmp.changeFile(2); //pTmp to G file (where king goes)
                PlacePiece(king, pTmp);
                pTmp = new Coordinate(pTmp);
                pTmp.changeFile(-1); //pTmp to F file (where rook goes)
                PlacePiece(rook, pTmp);
                king.hasMoved = true;
                rook.hasMoved = true;
                break;
            }

            if (input == "0-0-0")
            {
                King king = new King();
                foreach (Piece p in board)
                {
                    if (p is King && p.Color == color)
                        king = (King)p;
                }
                if (king.canCastleQueenside() == false)
                {
                    Console.WriteLine("Invalid Notation: King cannot castle Queenside");
                    Console.ReadKey();
                    repeat = true;
                    continue;
                }
                //won't reach here unless the king can castle queenside
                Coordinate pTmp = new Coordinate(king.Position);
                Piece rook = board[pTmp.Rank, pTmp.File - 4]; //to A file
                pTmp.changeFile(-2); //pTmp to C file (where king goes)
                PlacePiece(king, pTmp);
                pTmp = new Coordinate(pTmp);
                pTmp.changeFile(1); //pTmp to D file (where rook goes)
                PlacePiece(rook, pTmp);
                king.hasMoved = true;
                rook.hasMoved = true;
                break;
            }
            bool invalid = false;
            foreach (char value in input) //make sure all characters in input are part of the format
            {
                if ((isRank(value) || isFile(value) || isPieceNotation(value)) == false)
                {
                    Console.WriteLine("Invalid Notation: Make sure to follow the correct format");
                    Console.ReadKey();
                    repeat = true;
                    invalid = true;
                }
            }
            if (invalid) //invalid characters are used in the input
                continue;
            if (!isRank(input[input.Length - 1])) //the very last char should ALWAYS be rank
            {
                Console.WriteLine("Invalid Notation: Last character should always be the rank of the target square (4 of e4)");
                Console.ReadKey();
                repeat = true;
                continue;
            }
            if (!isFile(input[input.Length - 2])) //second to last char should ALWAYS be file
            {
                Console.WriteLine("Invalid Notation: Second to last character should always be file of the target square (e of e4)");
                Console.ReadKey();
                repeat = true;
                continue;
            }
            char toRank = input[input.Length - 1]; //returns the last char in input
            char toFile = input[input.Length - 2]; //return second to last char in input
            Coordinate position = new Coordinate(Coordinate.RankToInt(toRank), Coordinate.FileToInt(toFile)); //this coordinate is the square wanting to be moved to
            //determine what kind of piece the notation is targetting
            char type = 'P'; //default case, will change if not targetting a pawn
            if (isPieceNotation(input[0])) //if not targetting a pawn
            {
                type = input[0];
            }
            else if (!isFile(input[0]))
            {
                Console.WriteLine("Invalid Notation: Make sure the Piece notation is capital (i.e Nf3 or Bb4) or start with File for pawns (i.e e4 or g6)");
                Console.ReadKey();
                repeat = true;
                continue;
            }
            else if (input[0] == 'b' && input[1] == 'b') //rare case where user might input something like bb5 instead of Bb5.
            {
                Console.WriteLine("Invalid Notation: Make sure Piece notation is capital (i.e Nf3 or Bb5)");
                Console.ReadKey();
                repeat = true;
                continue;
            }
            //determine if specification is required before checking
            List<Piece> potentialPieces = new List<Piece>();
            foreach (Piece piece in board)
            {
                if (piece != null)
                    if (piece.Type == type && piece.Color == color && piece.LegalMoves.Contains(position)) // if its the piece type specified by notation and has a legal move to the square
                        potentialPieces.Add(piece); //this piece can move to the square
            }
            if (potentialPieces.Count == 0) //no piece of given type and color has this legal move
            {
                Console.WriteLine("Invalid Notation: No targetted " + color + " type can move to this square.", color, position);
                repeat = true;
                Console.ReadKey();
                continue;
            }
            else if (potentialPieces.Count == 1) //we found the only possible piece, make sure this is what the user asked for
            {
                if (type == 'P')
                {
                    if ((!isFile(input[0]) && input[0] != Coordinate.IntToFile(position.File)) ||
                        (!isRank(input[1]) && Coordinate.RankToInt(input[1]) != (position.Rank))) //checks formatting
                    {
                        Console.WriteLine("Invalid Notation: Make sure to follow the correct format.");
                        repeat = true;
                        Console.ReadKey();
                        continue;
                    }
                }
                else if (!(isPieceNotation(input[0]) && input[0] == type) || //is not piece notation or not the same piece
                    !(isFile(input[1]) && input[1] == Coordinate.IntToFile(position.File)) || //is not a file or not the same file
                    !(isRank(input[2]) && Coordinate.RankToInt(input[2]) == position.Rank)) //is not a rank or not the same rank
                {
                    Console.WriteLine("Invalid Notation: Make sure to follow the correct format.");
                    repeat = true;
                    Console.ReadKey();
                    continue;
                }
                PlacePiece(potentialPieces[0], position); //this piece has the position as a legal move, so perform it
                potentialPieces[0].hasMoved = true;
                target = potentialPieces[0];
                break; //break from the loop, continue to check for checkmate & stalemate
            }
            else //there is more than one potential piece, specification will be checked
            {//first, determine what should be specified computationally
                //then, check if the user input matches what should be specified

                bool specifyFile = false;
                int fromRank = -1; //0-based index of rank/file for piece being targetted
                int fromFile = -1;
                List<Piece> SpecialCondition = new List<Piece>(); //pieces that share a file with one piece and a rank with another that can all potentially move to the position
                if (type == 'P') //target is a pawn
                {
                    specifyFile = true; //always only need to specify file at most for pawns
                    fromFile = Coordinate.FileToInt(input[0]);
                }
                else if (MatchingFiles(potentialPieces) == false) //if no two pieces share the same file, usually the case
                {
                    specifyFile = true; //file can be used to determine which piece is targetted
                }
                else //at least two pieces that can move to position and share the same file, so at least rank must be specified (usually always only need rank at most)
                {
                    List<List<Piece>> sameFile = new List<List<Piece>>(); //determine the pairs/groups of pieces that share a file
                    int pos = 0; //position of sameRank[pos]
                    foreach (Piece p1 in potentialPieces) //adds lists of pieces to the list sameFile
                    {
                        List<Piece> tmp = new List<Piece>();
                        tmp.Add(p1);
                        sameFile.Add(tmp); //each piece starts its own list
                        foreach (Piece p2 in potentialPieces) //compare every other piece to it
                        {
                            if (p1 != p2 && p1.Position.File == p2.Position.File) //not the same thing and have same file
                            {
                                sameFile[pos].Add(p2);
                            }
                        }
                        pos++;
                    }
                    //determine if any of the pieces that shares a file also shares a rank with another piece
                    foreach (List<Piece> tmp in sameFile)
                    {
                        if (tmp.Count > 1) //tmp[0] shares a file with something
                        {
                            foreach (Piece p2 in potentialPieces)
                                if (p2 != tmp[0] && tmp[0].Position.Rank == p2.Position.Rank) //tmp[0] also shares a rank with something else
                                {
                                    SpecialCondition.Add(tmp[0]); //this piece must have file and rank specified to move to this position
                                    break;
                                }
                        }

                    }
                } //end rank specification check section
                if (input.Length == 5)
                {
                    if (SpecialCondition.Count == 0)
                    {
                        Console.WriteLine("Invalid Notation: This type of notation is not required");
                        Console.ReadKey();
                        repeat = true;
                        continue;
                    }
                    //the user is attempting to target a special condition
                    //find out which special condition is being targetted
                    //throw if no piece matches the notation
                    //move the piece to target position
                    //break from dowhile loop
                    throw new Exception("This code is currently not yet developed to handle special conditions of notation");
                }
                else if (specifyFile == true) //only file is required to specify which piece
                {
                    target = new Piece();
                    if (type == 'P')
                    {
                        if (!isFile(input[0]))
                        {
                            Console.WriteLine("Invalid Notation: File specification expected but not used to reach position {0}", position);
                            Console.ReadKey();
                            repeat = true;
                            continue;
                        }
                        fromFile = Coordinate.FileToInt(input[0]);
                    }
                    else
                    {
                        if (!isFile(input[1]))
                        {
                            Console.WriteLine("Invalid Notation: File specification expected but not used to reach position {0}", position);
                            Console.ReadKey();
                            repeat = true;
                            continue;

                        }
                        fromFile = Coordinate.FileToInt(input[1]);
                    }
                    foreach (Piece p in potentialPieces)
                        if (p.Position.File == fromFile)
                        {
                            target = p;
                            break;
                        }
                    if (target.Position == null)
                    {
                        Console.WriteLine("Invalid Notation: File specified, but no piece matched to position {0}", position);
                        Console.ReadKey();
                        repeat = true;
                        continue;
                    }
                    //verify the user correctly input the notation (Example: Nfd2 instead of Nfcd2 or Nf3d2)
                    if (input.Length == 5)
                    {
                        Console.WriteLine("Invalid Notation: Make sure format is correct, do not over-specify.");
                        Console.ReadKey();
                        repeat = true;
                        continue;
                    }
                    PlacePiece(target, position);
                    target.hasMoved = true;
                    break;
                }
                else //rank should be specified
                {
                    target = new Piece();
                    if (!isRank(input[1]))
                    {
                        Console.WriteLine("Invalid Notation: Rank specification expected but not used to reach position {0}", position);
                        Console.ReadKey();
                        repeat = true;
                        continue;
                    }
                    fromRank = Coordinate.RankToInt(input[1]); //stores the char as an int
                    foreach (Piece p in potentialPieces)
                        if (p.Position.Rank == fromRank) //int = char
                        {
                            target = p;
                            break;
                        }
                    if (target.Position == null) //means that it never found a piece 
                    {
                        Console.WriteLine("Invalid Notation: Rank specified, but no piece matched to position {0}", position);
                        Console.ReadKey();
                        repeat = true;
                        continue;
                    }
                    PlacePiece(target, position);
                    target.hasMoved = true;
                    break;
                }
                //otherwise specification will be in position 1
                //file must be specified iff no 2 potential pieces have the same file
                //if 2 or more pieces have the same rank, but no 2 have the same file, specify only rank
                //if 2 or more pieces have the same rank, and among those a piece also has the same rank, specify both file and rank
                //if both are to be specified, follow the order file/rank
            } //end specification check section
            //check to see if a pawn needs to be promoted
        } while (repeat == true);
        Pawn pawn; //check to see if a pawn needs to be promoted
        repeat = false;
        do
        {
            if (target.Type == 'P')
            {
                if (repeat == true)
                    Display();
                pawn = (Pawn)target;
                if ((target.Color == "white" && target.Position.Rank == 7) || (target.Color == "black" && target.Position.Rank == 0))
                {
                    Console.WriteLine("Choose pawn promotion (Press N, B, R, Q): ");
                    string promote = Console.ReadLine().ToString();
                    if (!(promote == "B" || promote == "N" || promote == "R" || promote == "Q"))
                    {
                        Console.WriteLine("\nInvalid Piece: Use B, N, R, or Q (with caps)");
                        repeat = true;
                        Console.ReadKey();
                        continue;
                    }
                    pawn.Promote(promote); //method asks the user what piece they want to promote to
                    break;
                }
            }
        } while (repeat == true);
        if (mPosition > SavedBoards.Count)
        {
            throw new Exception("Error: position is pointing somewhere higher than SavedBoards");
        }
        if (mPosition < SavedBoards.Count - 1) //Removes boards that would be in front of mPosition
        {
            while ( mPosition < SavedBoards.Count - 1 )
            {
                SavedBoards.RemoveAt(SavedBoards.Count - 1);
            }
        }
        if (Draw() == true)
        {
            throw new Exception("Draw by insufficient material for checkmate");
        }
        AllMoves(OppositeColor(color));
        if (!canMove(OppositeColor(color))) //no legal moves for the other color, must be either stalemate or checkmate
        {
            if (CheckMate(OppositeColor(color)) == true)
            {
                string message = color + " wins by checkmate!";
                throw new Exception(message);
            }
            else if (Stalemate(OppositeColor(color)) == true)
            {
                throw new Exception("Game Over: Stalemate");
            }
        }
        mPosition++;
        SavedBoards.Add(Copy(board)); //adds a copy of the board to the end of the list

    }

    public string OppositeColor(string color)
    {
        if (color == "white")
            return "black";
        if (color == "black")
            return "white";
        return "none";
    } //take a color and output the opposite

    public bool MatchingFiles(List<Piece> potentials)
    {
        foreach (Piece p1 in potentials)
            foreach (Piece p2 in potentials)
                if (p1 != p2 && p1.Position.File == p2.Position.File)
                    return true;
        return false;
    } //find if any two pieces have a matching file
    public bool MatchingRanks(List<Piece> potentials)
    {
        foreach (Piece p1 in potentials)
            foreach (Piece p2 in potentials)
                if (p1.Position.Rank == p2.Position.Rank)
                    return true;
        return false;
    } //find if any two pieces have a matching rank (NOT USED)

    public static bool isRank(char x)
    {
        if (x == '1' || x == '2' || x == '3' || x == '4' || x == '5' || x == '6' || x == '7' || x == '8')
            return true;
        return false;
    } //takes a char and determines if that char matches Chess Notation of a rank
    public static bool isFile(char x) //takes a char and determines if that char matches Chess Notation of a file
    {
        if (x == 'a' || x == 'b' || x == 'c' || x == 'd' || x == 'e' || x == 'f' || x == 'g' || x == 'h')
            return true;
        else
            return false;
    }

    public void AllPossible(string color = "both") //find possible moves for a specific color, or both if not specified
    {
        foreach (Piece p in board)
            if (p != null)
            {
                if (color == "both") //all pieces
                    p.findPossibleMoves();
                else if (p.Color == color) //pick a color
                    p.findPossibleMoves();
            }
    }

    public void AllLegal(string color = "both") //find all legal moves of a specific color, or both colors if not specified
    {
        foreach (Piece p in board)
            if (p != null)
            {
                if (color == "both")
                    p.findLegalMoves();
                else if (p.Color == color)
                    p.findLegalMoves();
            }
    }

    public void AllMoves(string color = "both") //find all possible & legal moves
    {
        AllPossible(color);
        AllLegal(color);
    }

    public void PlacePiece(Piece piece, Coordinate p) //takes a piece off its square and places it onto a new square, removing opposite if present
    {
        bool replace = false;
        if (piece.Position == p)
        {
            replace = true;
        }
        board[p.Rank, p.File] = piece;
        if (!replace) //if not a replacement
            board[piece.Position.Rank, piece.Position.File] = null;
        piece.Position = p;
    }

    public string CheckColor(Coordinate position) //returns "black", "white", or "none" (null)
    {
        if (board[position.Rank, position.File] != null)
            return board[position.Rank, position.File].Color;
        else return "none";
    }

    public bool isTherePiece(Coordinate position) //returns true if board has a piece at the position
    {
        if (board[position.Rank, position.File] != null)
            return true;
        else
            return false;
    } //whether or not there is a piece at position

    public bool getPiece(Coordinate p, out Piece piece) //retrieves a piece from a coordinate (NOT USED)
    {
        if (CheckColor(p) == "none")
        {
            piece = null;
            return false;
        }
        piece = board[p.Rank, p.File];
        return true;
    }

    public bool inCheck(string color) //check opposite color to see if any piece attacks the king
    {
        AllPossible(OppositeColor(color));
        Piece king = new Piece();
        foreach (Piece mPiece in board)
            if (mPiece is King && mPiece.Color == color)
                king = mPiece;

        foreach (Piece p in board)
            if (p != null)
                if (p.Color != color && p.PossibleMoves.Contains(king.Position))
                    return true;

        return false;
    }

    public bool CheckMate(string color) //returns true if the color passed in is in checkmate
    {
        if (inCheck(color) == true && canMove(color) == false) //if in check and has no legal moves (no way to get out of check) then it is checkmate
            return true;
        return false;
    }

    public bool Stalemate(string color) //returns true if stalemate has occured
    {
        if (!canMove(color) && !inCheck(color)) //no legal moves and not in check
            return true;
        //determine if there are only kings left
        return false;
    }

    public bool Draw() //returns true if there is insufficient material, resulting in a draw
    { //note that if any pawns, rooks, or queens are left at all, it cannot be a draw by insufficient material (automatic)
        int whiteKing = 0;
        int whiteKnight = 0;
        int whiteBishop = 0;
        int blackKing = 0;
        int blackKnight = 0;
        int blackBishop = 0;
        List<Piece> WhiteBishops = new List<Piece>();
        List<Piece> BlackBishops = new List<Piece>();
        foreach (Piece p in board) //collect all significant pieces that contribute to a draw
        {
            if (p == null)
                continue;
            if (p is King)
                if (p.Color == "white")
                    whiteKing++;
                else
                    blackKing++;
            else if (p is Knight)
                if (p.Color == "white")
                    whiteKnight++;
                else
                    blackKnight++;
            else if (p is Bishop)
                if (p.Color == "white")
                {
                    whiteBishop++;
                    WhiteBishops.Add(p);
                }
                else
                {
                    blackBishop++;
                    BlackBishops.Add(p);
                }
            else //its a Pawn, Queen, or Rook; do not throw a draw
                return false;
        }
        if (whiteKnight == 0 && whiteBishop == 0 && blackKnight == 0 && blackBishop == 0) //both sides only have a king
            return true;
        if (whiteKnight == 0 && whiteBishop == 0 && blackKnight == 1 && blackBishop == 0) //black has only a knight
            return true;
        if (whiteKnight == 1 && whiteBishop == 0 && blackKnight == 0 && blackBishop == 0) //white has only a knight
            return true;
        if (whiteKnight == 0 && whiteBishop == 0 && blackKnight == 0 && blackBishop == 1) //black has only a bishop
            return true;
        if (whiteKnight == 0 && whiteBishop == 1 && blackKnight == 0 && blackBishop == 0) //white has only a bishop
            return true;
        if (whiteKnight == 0 && whiteBishop > 0 && blackKnight == 0 && blackBishop > 0) //only kings and bishops remain
        { //check if all bishops are on the same color square
            string color = "none";
            color = WhiteBishops[0].Position.ColorSquare(); //the first bishops color will be compared against all others
            foreach (Piece bishop in WhiteBishops) //if only one white bishop, it will just compare against itself
                if (bishop.Position.ColorSquare() != color)
                    return false; //there are two bishops and they are on opposite colors, checkmate is possible
            foreach (Piece bishop in BlackBishops)
                if (bishop.Position.ColorSquare() != color)
                    return false; //there is a bishop that is on the opposite color square of the white bishop, checkmate (although not forced) is possible
            return true; //all bishops are on the same square (most always just one bishop on each side)
        }
        return false; //no draw by insufficient material criteria have been met
    }
    public bool canMove(string color) //returns true if the color has any legal moves available
    {
        foreach (Piece mPiece in board)
            if (mPiece != null)
                if (mPiece.Color == color)
                    if (mPiece.LegalMoves.Count > 0) //check each piece to see if it has any legal move
                        return true; //some piece has a legal move
        return false; //no piece has a legal move, either in checkmate or stalemate
    }

    public static bool isPieceNotation(char X) //returns true if the char matches the Chess Notation for pieces
    {
        if (X == 'N' || X == 'B' || X == 'R' || X == 'Q' || X == 'K')
            return true;
        else
            return false;
    }


    public void PlaceAllPieces() //sets all pieces for a standard setup of the board
    {
        for (int x = 0; x <= 7; x++) //add white pawns to the board
            board[1, x] = new Pawn(new Coordinate(1, x), "white", this);
        for (int x = 0; x <= 7; x++) //add black pawns to the board
            board[6, x] = new Pawn(new Coordinate(6, x), "black", this);
        board[0, 0] = new Rook(new Coordinate(0, 0), "white", this);
        board[0, 7] = new Rook(new Coordinate(0, 7), "white", this);
        board[7, 0] = new Rook(new Coordinate(7, 0), "black", this);
        board[7, 7] = new Rook(new Coordinate(7, 7), "black", this);
        board[0, 1] = new Knight(new Coordinate(0, 1), "white", this);
        board[0, 6] = new Knight(new Coordinate(0, 6), "white", this);
        board[7, 1] = new Knight(new Coordinate(7, 1), "black", this);
        board[7, 6] = new Knight(new Coordinate(7, 6), "black", this);
        board[0, 2] = new Bishop(new Coordinate(0, 2), "white", this);
        board[0, 5] = new Bishop(new Coordinate(0, 5), "white", this);
        board[7, 2] = new Bishop(new Coordinate(7, 2), "black", this);
        board[7, 5] = new Bishop(new Coordinate(7, 5), "black", this);
        board[0, 3] = new Queen(new Coordinate(0, 3), "white", this);
        board[7, 3] = new Queen(new Coordinate(7, 3), "black", this);
        board[0, 4] = new King(new Coordinate(0, 4), "white", this);
        board[7, 4] = new King(new Coordinate(7, 4), "black", this);
    }

}
public class Coordinate : IEquatable<Coordinate>
{
    //Use Coordinate.File, Coordinate.Rank
    public int File { get; set; } //(A -> H) => (0 -> 7) 
    public int Rank { get; set; } //(1 -> 8) => (0 -> 7)
    public void setCoordinate(char file, int rank) //takes Chess Notation to set the coordinates file and rank as 0-indexed
    {
        int row = -1;
        int column = -1;
        if (file == 'a' || file == 'A')
            row = 0;
        else if (file == 'b' || file == 'B')
            row = 1;
        else if (file == 'c' || file == 'C')
            row = 2;
        else if (file == 'd' || file == 'D')
            row = 3;
        else if (file == 'e' || file == 'E')
            row = 4;
        else if (file == 'f' || file == 'F')
            row = 5;
        else if (file == 'g' || file == 'G')
            row = 6;
        else if (file == 'h' || file == 'H')
            row = 7;
        else
            throw new Exception("Invalid File");
        if (rank > 8)
            throw new Exception("Invalid Rank");
        column = rank - 1;
        int[] position = { row, column };
        File = row;
        Rank = column;
    }

    public bool changeRank(int distance) //move up or down (+ or -) in rank. returns false if doing so would fall off the board
    {
        if (Rank + distance <= 7 && Rank + distance >= 0) //if this change does not move the position out of bounds
        {
            Rank += distance;
            return true;
        }
        return false;
    }

    public bool changeFile(int distance) //move right or left (+ or -) in file. returns false if doing so would fall off the board
    {
        if (File + distance <= 7 && File + distance >= 0)
        {
            File += distance;
            return true;
        }
        return false;
    }

    public bool changeDiagonal(int file, int rank) //move in a diagonal direction according to input. false if would fall off the board
    {
        int newFile = File + file;
        int newRank = Rank + rank;
        if (newFile <= 7 && newFile >= 0 && newRank <= 7 && newRank >= 0)
        {
            File = newFile;
            Rank = newRank;
            return true;
        }
        return false;
    }

    public Coordinate(char file, int rank) //used when input is standard chess notation
    {
        setCoordinate(file, rank);
    }//not certain if this creates a coordinate properly, likely unneccessary now

    public Coordinate(int file, int rank) //used when input is already 0-indexed
    {
        File = rank;
        Rank = file;
    }

    public Coordinate(Coordinate copy) //creates a duplicate copy
    {
        File = copy.File;
        Rank = copy.Rank;
    }

    public bool Equals(Coordinate position) //allows Coordinates to be compared on equality
    {
        
        if (this == null && position == null)
            return true;
        if (this != null && position == null)
            return false;
        if (position.File == File && position.Rank == Rank)
            return true;
        else
            return false;
    }

    public static char IntToFile(int file) //takes 0-indexed file and returns a char Chess Notation file
    {
        if (file == 0)
            return 'a';
        if (file == 1)
            return 'b';
        if (file == 2)
            return 'c';
        if (file == 3)
            return 'd';
        if (file == 4)
            return 'e';
        if (file == 5)
            return 'f';
        if (file == 6)
            return 'g';
        if (file == 7)
            return 'h';
        throw new Exception("Invalid 0-indexed file, use 0-7");
    }

    public static int FileToInt(char file) //takes Ches Notation file and returns 0-indexed file
    {
        int row = 0;
        if (file == 'a' || file == 'A')
            row = 0;
        else if (file == 'b' || file == 'B')
            row = 1;
        else if (file == 'c' || file == 'C')
            row = 2;
        else if (file == 'd' || file == 'D')
            row = 3;
        else if (file == 'e' || file == 'E')
            row = 4;
        else if (file == 'f' || file == 'F')
            row = 5;
        else if (file == 'g' || file == 'G')
            row = 6;
        else if (file == 'h' || file == 'H')
            row = 7;
        else
            throw new Exception("Invalid File, use A-H");
        return row;
    }

    public static int RankToInt(char x) //takes Chess Notation rank and returns 0-indxed rank
    {
        if (x == '1')
            return 0;
        if (x == '2')
            return 1;
        if (x == '3')
            return 2;
        if (x == '4')
            return 3;
        if (x == '5')
            return 4;
        if (x == '6')
            return 5;
        if (x == '7')
            return 6;
        if (x == '8')
            return 7;
        throw new Exception("Method should pass in rank from 1-8, and then return 0-based index rank from 0-7");
    }

    public string ColorSquare()
    {
        if (Rank % 2 == 0 && File % 2 == 0)
            return "black";
        if (Rank % 2 == 1 && File % 2 == 1)
            return "black";
        return "white";
    }

    public override string ToString() //outputs as [file, rank] (i.e [e,4])
    {
        return "[" + IntToFile(File) + "," + (Rank + 1) + "]";
    }
}
