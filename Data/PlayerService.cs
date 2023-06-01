using Devin.Pages;
using System.Collections.Generic;
using System.Linq;

namespace Devin.Data
{
    public class PlayerService
    {
        private PlayerStatus playerStatus;

        public List<Player> Players { get; private set; }

        public void SetPlayerStatus(PlayerStatus playerStatus)
        {
            this.playerStatus = playerStatus;
        }

        public void AddPlayers(Player playerOne, Player playerTwo)
        {
            Players = new List<Player>();
            Players.Add(playerOne);
            Players.Add(playerTwo);
        }

        public Player GetPlayerToPlay() => Players.SingleOrDefault(x => x.Status == Status.Placing);

        public void ChangeStatus(Player player)
        {
            player.Status = Status.Waiting;
            if (player.Id == 2) Players[0].Status = Status.Placing;
            else Players[1].Status = Status.Placing;
            playerStatus.StateChanged();
        }

        public void RefreshStatus()
        {
            Players[0].Status = Status.Placing;
            Players[1].Status = Status.Waiting;
        }       

    }
}