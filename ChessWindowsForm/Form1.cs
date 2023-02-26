using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessWindowsForm
{
    public partial class Form1 : Form
    {

        static Board myBoard = new Board(8);

        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];
        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }

        private void populateGrid()
        {
            int buttonSize = panel1.Width / myBoard.Size;
            panel1.Height = panel1.Width;

            for(int i = 0; i < myBoard.Size; i++) 
            {
                for(int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();

                    btnGrid[i, j].Height = buttonSize;
                    btnGrid[i, j].Width = buttonSize;

                    btnGrid[i, j].Click += Grid_Button_Click;

                    panel1.Controls.Add(btnGrid[i, j]);
                    
                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    btnGrid[i, j].Text = i + "|" + j;
                    btnGrid[i, j].Tag = new Point(i,j);
                }
            }
        }
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            string piece = (string)comboBox1.SelectedItem;
            // Do something with the selected item

        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            string piece = (string)comboBox1.SelectedItem;

            // get row and col number of button clicked
            Button clickedButton = (Button)sender;
            Point Location = (Point)clickedButton.Tag;

            int x = Location.X;
            int y = Location.Y;

            Cell currentCell = myBoard.theGrid[x, y];


            //determine legal moves
            myBoard.MarkNextLegalMoves(currentCell, piece);

            //update text on button
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].Text = "";
                    if (myBoard.theGrid[i,j].IsLegal == true)
                    {
                        btnGrid[i, j].Text = "Legal";
                    }
                    else if (myBoard.theGrid[i, j].IsOccupied == true)
                    {
                        btnGrid[i, j].Text = piece;
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
