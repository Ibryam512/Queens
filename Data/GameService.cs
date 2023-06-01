namespace Devin.Data
{
    public class GameService
    {
        private readonly BoardService boardService;
        private readonly PlayerService playerService;
        private readonly MessageService messageService;

        public string[,] Board { get; set; }

        public GameService(BoardService boardService, PlayerService playerService, MessageService messageService)
        {
            this.boardService = boardService;
            this.playerService = playerService;
            this.messageService = messageService;
        }

        public void SetBoard(int n, int m)
        {
            Board = new string[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Board[i, j] = "-";
                }
            }
        }

        public void PlaceQueen(Player player, int x, int y)
        {
            if (Board[x, y] == "-")
            {
                Board[x, y] = player.Id.ToString();
                PlaceOnRow(x, y);
                PlaceOnColumn(x, y);
                PlaceOnDiagonals(x, y);
                playerService.ChangeStatus(player);
                boardService.ChangeColor(x, y, player.Color);
                boardService.Fill(Board);
                messageService.SetMessage("-");
                if (IsWinner())
                {
                    player.Status = Status.Winner;
                    player.Winnings++;
                    messageService.SetMessage($"Поздравления! {player.Nickname} печели!");
                    boardService.ShowAll();
                    return;
                }
                //В случай, че е избрана опцията за Single player
                if (playerService.GetPlayerToPlay().IsSinglePlayer)
                {
                    GenerateMove(ref x, ref y);
                    PlaceQueen(playerService.GetPlayerToPlay(), x, y);
                }
            }
            else
            {
                messageService.SetMessage("Не може да поставите царица там :(");
            }
            
        }

        public bool IsWinner() 
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] == "-") return false;
                }
            }
            return true;
        }

        public void GenerateMove(ref int x, ref int y)
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] == "-") 
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }
        }

        private void PlaceOnRow(int x, int y)
        {
            for (int row = 0; row < Board.GetLength(1); row++)
            {
                if (row == y) continue;
                Board[x, row] = "*";
            }
        }

        private void PlaceOnColumn(int x, int y)
        {
            for (int col = 0; col < Board.GetLength(0); col++)
            {
                if (col == x) continue;
                Board[col, y] = "*";
            }
        }

        private void PlaceOnDiagonals(int x, int y)
        {
            for (int i = x + 1, j = y + 1; i < Board.GetLength(0) && j < Board.GetLength(1); i++, j++)
            {
                Board[i, j] = "*";
            }

            for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
            {
                Board[i, j] = "*";
            }

            for (int i = x - 1, j = y + 1; i >= 0 && j < Board.GetLength(1); i--, j++)
            {
                Board[i, j] = "*";
            }

            for (int i = x + 1, j = y - 1; i < Board.GetLength(0) && j >= 0; i++, j--)
            {
                Board[i, j] = "*";
            }
        }
    }
}