using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string SetPiece { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsLegal { get; set; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
            IsOccupied = false;
        }

        public void SetOccupied(bool isOccupied)
        {
            IsOccupied = isOccupied;
        }

        public bool GetOccupied()
        {
            return IsOccupied;
        }

        public static implicit operator Cell(int v)
        {
            throw new NotImplementedException();
        }
    }
}
