namespace Katas.SnakeAndLadders
{
    public class Player
    {
        private readonly int id;
        private readonly string name;
        private readonly IDice dice;

        public Player(int id, string name, IDice dice)
        {
            this.id = id;
            this.name = name;
            this.dice = dice;
        }

        public int RollDice()
        {
            return dice.Roll();
        }
    }
}
