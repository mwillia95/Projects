Program.cs:
Contains the main method. Uses board class to display a chess board through the console
and gets the user input to make moves.

Board.cs:
Class containing various methods revolving around the chess board, such as displaying the board,
storing piece positions, and the Turn method. Also contains definitions for Checkmate, Stalemate,
and draws.

Piece.cs:
Parent class that all other pieces inherit from. "Possible moves" are defined as moves that a piece 
can make within its definition of range (i.e. bishop can move diagonally) without consideration of if
the piece leaves the side in check afterwards. "Legal moves" are possible moves that do not leave the side
in check.

All other classes inherit from the Piece class and give their own definitions of "possible moves." King.cs
also contains methods to check if castling kingside or queenside is legal.