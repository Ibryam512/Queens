using Devin.Pages;
using System.Collections.Generic;

namespace Devin.Data
{
    public class BoardService
    {
        public List<List<Square>> squares { get; private set; }

        public void SetSquares(List<List<Square>> squares)
        {
            this.squares = squares;
        }

        public void RefreshSquares()
        {
            for (int i = 0; i < squares.Count; i++)
            {
                for (int j = 0; j < squares[i].Count; j++)
                {
                    ChangeColor(i, j, "white");
                }
            }
        }

        public void ChangeColor(int x, int y, string color)
        {
            squares[x][y].bgcolor = color;
            squares[x][y].StateChanged();
        }

        public void Fill(string[,] board)
        {
            for (int i = 0; i < squares.Count; i++)
            {
                for (int j = 0; j < squares[i].Count; j++)
                {
                    if (board[i, j] == "*")
                    {
                        ChangeColor(i, j, "red");                  
                    }
                }
            }
        }
        
        public void ShowAll()
        {
            for (int i = 0; i < squares.Count; i++)
            {
                for (int j = 0; j < squares[i].Count; j++)
                {
                    if (squares[i][j].bgcolor == "white")
                    {
                        ChangeColor(i, j, "red");                  
                    }
                }
            }
        }     
    }
}