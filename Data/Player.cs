namespace Devin.Data
{
    public class Player
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Color { get; set; }
        public int Winnings { get; set; }
        public Status Status;
        public bool IsSinglePlayer { get; set; }

        public Player(int id, string nickname, string color)
        {
            this.Id = id;
            this.Nickname = nickname;
            this.Color = color;
        }
    }
}