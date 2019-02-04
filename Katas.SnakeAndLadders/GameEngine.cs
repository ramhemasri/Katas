using System.Collections.Generic;

namespace Katas.SnakeAndLadders
{
    public class GameEngine
    {
        private readonly int totalSquares;
        private readonly IList<Player> players;
        private readonly IDictionary<Player, int> squares;
        public Player Winner;

        public GameEngine(int totalSquares)
        {
            this.totalSquares = totalSquares;
            players = new List<Player>();
            squares = new Dictionary<Player, int>();
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void Start()
        {
            foreach (Player player in players)
            {
                squares.Add(player, 1);
            }
        }

        public int CurrentSquareForPlayer(Player player)
        {
            return squares[player];
        }

        public void MovePlayer(Player player, int spaces)
        {
            if (CurrentSquareForPlayer(player) + spaces > totalSquares)
            {
                return;
            }

            squares[player] = CurrentSquareForPlayer(player) + spaces;
            if (squares[player] == totalSquares)
            {
                Winner = player;
            }
        }
    }
}
