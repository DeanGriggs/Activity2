using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        public int Size { get; set; }

        public Cell[,] theGrid { get; set; }
        public Board(int s)
        {
            //initial borad size defined by s
            Size = s;

            //2d array of type cell
            theGrid = new Cell[Size, Size];

            //fill 2d with ne cells with coordinates
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, String ChessPiece)
        {
            //step 1 clear board
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].IsLegal = false;
                    theGrid[i, j].IsOccupied = false;
                }
            }

            //step 2 find and mark all leagal moves
            switch (ChessPiece)
            {
                case "Knight":

                    if (IsSafe(theGrid[currentCell.Row + 2, currentCell.Column + 1]))
            {
                theGrid[currentCell.Row + 2, currentCell.Column + 1].IsLegal = true;
            }
            if (IsSafe(theGrid[currentCell.Row + 1, currentCell.Column + 2]))
            {
                theGrid[currentCell.Row + 1, currentCell.Column + 2].IsLegal = true;
            }
            if (IsSafe(theGrid[currentCell.Row - 2, currentCell.Column + 1]))
            {
                theGrid[currentCell.Row - 2, currentCell.Column + 1].IsLegal = true;
            }
            if (IsSafe(theGrid[currentCell.Row - 1, currentCell.Column + 2]))
            {
                theGrid[currentCell.Row - 1, currentCell.Column + 2].IsLegal = true;
            }
            if (IsSafe(theGrid[currentCell.Row - 2, currentCell.Column - 1]))
            {
                theGrid[currentCell.Row - 2, currentCell.Column - 1].IsLegal = true;
            }
            if (IsSafe(theGrid[currentCell.Row - 1, currentCell.Column - 2]))
            {
                theGrid[currentCell.Row - 1, currentCell.Column - 2].IsLegal = true;
            }
            if (IsSafe(theGrid[currentCell.Row + 2, currentCell.Column - 1]))
            {
                theGrid[currentCell.Row + 2, currentCell.Column - 1].IsLegal = true;
            }
            if (IsSafe(theGrid[currentCell.Row + 1, currentCell.Column - 2]))
            {
                theGrid[currentCell.Row + 1, currentCell.Column - 2].IsLegal = true;
            }
            break;


                case "King":
                    if (IsSafe(theGrid[currentCell.Row + 1, currentCell.Column + 1]))
                        theGrid[currentCell.Row + 1, currentCell.Column + 1].IsLegal = true;

                    if (IsSafe(theGrid[currentCell.Row - 1, currentCell.Column + 1]))
                        theGrid[currentCell.Row - 1, currentCell.Column + 1].IsLegal = true;

                    if (IsSafe(theGrid[currentCell.Row, currentCell.Column + 1]))
                        theGrid[currentCell.Row, currentCell.Column + 1].IsLegal = true;

                    if (IsSafe(theGrid[currentCell.Row + 1, currentCell.Column - 1]))
                        theGrid[currentCell.Row + 1, currentCell.Column - 1].IsLegal = true;

                    if (IsSafe(theGrid[currentCell.Row + 1, currentCell.Column]))
                        theGrid[currentCell.Row + 1, currentCell.Column].IsLegal = true;

                    if (IsSafe(theGrid[currentCell.Row, currentCell.Column - 1]))
                        theGrid[currentCell.Row, currentCell.Column - 1].IsLegal = true;

                    if (IsSafe(theGrid[currentCell.Row - 1, currentCell.Column - 1]))
                        theGrid[currentCell.Row - 1, currentCell.Column - 1].IsLegal = true;

                    if (IsSafe(theGrid[currentCell.Row - 1, currentCell.Column]))
                        theGrid[currentCell.Row - 1, currentCell.Column].IsLegal = true;

                    break;

                case "Rook":
                    // Mark all cells in the same row
                    for (int col = 0; col < Size; col++)
                    {
                        if (col != currentCell.Column)
                        {
                            theGrid[currentCell.Row, col].IsLegal = true;
                        }
                    }

                    // Mark all cells in the same column
                    for (int row = 0; row < Size; row++)
                    {
                        if (row != currentCell.Row)
                        {
                            theGrid[row, currentCell.Column].IsLegal = true;
                        }
                    }

                    break;

                case "Bishop":
                    // Mark all cells in the diagonal line from top-left to bottom-right
                    for (int i = 1; i < Size; i++)
                    {
                        int row = currentCell.Row + i;
                        int col = currentCell.Column + i;
                        if (row >= Size || col >= Size) break;
                        theGrid[row, col].IsLegal = true;
                    }

                    for (int i = 1; i < Size; i++)
                    {
                        int row = currentCell.Row - i;
                        int col = currentCell.Column - i;
                        if (row < 0 || col < 0) break;
                        theGrid[row, col].IsLegal = true;
                    }

                    // Mark all cells in the diagonal line from top-right to bottom-left
                    for (int i = 1; i < Size; i++)
                    {
                        int row = currentCell.Row - i;
                        int col = currentCell.Column + i;
                        if (row < 0 || col >= Size) break;
                        theGrid[row, col].IsLegal = true;
                    }

                    for (int i = 1; i < Size; i++)
                    {
                        int row = currentCell.Row + i;
                        int col = currentCell.Column - i;
                        if (row >= Size || col < 0) break;
                        theGrid[row, col].IsLegal = true;
                    }


                    break;

                case "Queen":
                    //mMark all cells in the same row
                    for (int col = 0; col < Size; col++)
                    {
                        if (col != currentCell.Column)
                        {
                            theGrid[currentCell.Row, col].IsLegal = true;
                        }
                    }

                    // Mark all cells in the same column
                    for (int row = 0; row < Size; row++)
                    {
                        if (row != currentCell.Row)
                        {
                            theGrid[row, currentCell.Column].IsLegal = true;
                        }
                    }
                    // Mark all cells in the diagonal line from top-left to bottom-right
                    for (int i = 1; i < Size; i++)
                    {
                        int row = currentCell.Row + i;
                        int col = currentCell.Column + i;
                        if (row >= Size || col >= Size) break;
                        theGrid[row, col].IsLegal = true;
                    }

                    for (int i = 1; i < Size; i++)
                    {
                        int row = currentCell.Row - i;
                        int col = currentCell.Column - i;
                        if (row < 0 || col < 0) break;
                        theGrid[row, col].IsLegal = true;
                    }

                    // Mark all cells in the diagonal line from top-right to bottom-left
                    for (int i = 1; i < Size; i++)
                    {
                        int row = currentCell.Row - i;
                        int col = currentCell.Column + i;
                        if (row < 0 || col >= Size) break;
                        theGrid[row, col].IsLegal = true;
                    }

                    for (int i = 1; i < Size; i++)
                    {
                        int row = currentCell.Row + i;
                        int col = currentCell.Column - i;
                        if (row >= Size || col < 0) break;
                        theGrid[row, col].IsLegal = true;
                    }


                    break;

                case "Pawn":

                    break;
            }
            theGrid[currentCell.Row, currentCell.Column].IsOccupied = true;


            bool IsSafe(Cell c)
            {
                bool IsOccupied  = true;
                int Occupied = Convert.ToInt32(IsOccupied);

                if (Occupied >= 0 && Occupied < Size)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }

        
    }
    }
    

