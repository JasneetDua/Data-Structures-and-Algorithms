using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameState
    {
        private readonly GameCell[,] board = new GameCell[3, 3];

        public GameState()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.board[i, j] = GameCell.Empty;
                }
            }
        }

        public GameState(GameState origin)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.board[i, j] = origin.board[i, j];
                }
            }
        }

        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    hash = hash * 3 + (int)this.board[i, j];
                }
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public GameState MakeMove(int row, int col, GameCell player)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                return null;
            }

            if (this.board[row, col] != GameCell.Empty)
            {
                return null;
            }

            var newState = new GameState(this);
            newState.board[row, col] = player;
            return newState;
        }

        public bool IsWinning(GameCell player)
        {
            var diag1Winning = true;
            var diag2Winning = true;

            for (int i = 0; i < 3; i++)
            {
                var rowWinning = true;
                var colWinning = true;

                if (this.board[i, i] != player)
                {
                    diag1Winning = false;
                }

                if (this.board[i, 2 - i] != player)
                {
                    diag2Winning = false;
                }

                for (int j = 0; j < 3; j++)
                {
                    if (this.board[i, j] != player)
                    {
                        rowWinning = false;
                    }
                    if (this.board[j, i] != player)
                    {
                        colWinning = false;
                    }
                }

                if (rowWinning || colWinning)
                {
                    return true;
                }
            }

            return diag1Winning || diag2Winning;
        }

        public override string ToString()
        {
            return $@"{GetSymbol(this.board[0, 0])}{GetSymbol(this.board[0, 1])}{GetSymbol(this.board[0, 2])}
{GetSymbol(this.board[1, 0])}{GetSymbol(this.board[1, 1])}{GetSymbol(this.board[1, 2])}
{GetSymbol(this.board[2, 0])}{GetSymbol(this.board[2, 1])}{GetSymbol(this.board[2, 2])}
";
        }

        private static char GetSymbol(GameCell cell)
        {
            if (cell == GameCell.Empty)
            {
                return '.';
            }
            if(cell == GameCell.Player1)
            {
                return 'X';
            }
            return 'O';
        }
    }
}
