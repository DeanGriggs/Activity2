using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsoleApp
{
    class Program
    {

        static Board myBoard = new Board(8);

        

        

        static void Main(string[] args)
        {
            


        //show empty board
            printBoard(myBoard);

            //ask for coordinates for piece
            Cell currentCell = setCurrectCell();
            string SetPiece = UserSetPiece();
            currentCell.IsOccupied= true;

            //calculate all legal moves
            myBoard.MarkNextLegalMoves(currentCell, SetPiece);

            //print board with "x"=piece, "."=empty spaces, "+"=legal moves
            printBoard(myBoard);

            //wait for another enter key before ending the program
            Console.ReadLine();
        }

        private static void printBoard(Board myBoard)
        {
            //pring the chess board to the cosole x=piece .=empty spaces +=legal moves

            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Cell c = myBoard.theGrid[i, j];

                    if (c.IsOccupied == true)
                    {
                        Console.Write("&");
                    }
                    else if (c.IsLegal == true)
                    {
                        Console.Write("+");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                    Console.Write("|");
                }
                Console.WriteLine("");
                Console.WriteLine("================");
            }

        }


        static Cell setCurrectCell()
        {
            //get x and y cooridinate from the user and return cell location
            Console.WriteLine("Enter row number");
            int Row = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("enter column number");
            int Col = int.Parse(Console.ReadLine()) - 1;

            myBoard.theGrid[Row, Col].IsOccupied = true;
            return myBoard.theGrid[Row, Col];
        }
        private static string UserSetPiece()
        {
            Console.WriteLine("Enter piece type 1=King, 2=Queen, 3=Bishop, 4=Rook, 5=Knight");
            int piece = int.Parse(Console.ReadLine());

            if (piece == 1)
            {
                Console.WriteLine("You Chose King");
                return "King";
            }
            else if (piece == 2)
                return "Queen";
            else if (piece == 3)
                return "Bishop";
            else if (piece == 4)
                return "Rook";
            else if (piece == 5)
                return "Knight";
            else
                return "Knight";
        }

    }
}

