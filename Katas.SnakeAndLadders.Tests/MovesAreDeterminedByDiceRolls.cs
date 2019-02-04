using Xbehave;
using FluentAssertions;

namespace Katas.SnakeAndLadders.Tests
{
    /// As a player
    /// I want to move my token based on the roll of a die
    /// So that there is an element of chance in the game
    public class MovesAreDeterminedByDiceRolls
    {        
        [Scenario]
        public void PlayerRollsDie_ShouldBeInRangeOf1And6(GameEngine gameEngine, Player player, IDice dice, int diceRollResult)
        {
           
            "Given the game is started"
                .x(() =>
                {
                    dice = new Dice();
                    player = new Player(1, "Player 1",dice);
                    int totalSquares = 100;
                    gameEngine = new GameEngine(totalSquares);
                    gameEngine.AddPlayer(player);
                    gameEngine.Start();
                });

            "When the player rolls a die"
                .x(() => {
                    diceRollResult = player.RollDice();
                });

            "Then the result should be between 1-6 inclusive"
             .x(() =>
             {
                 diceRollResult.Should().BeInRange(1, 6);
             });

        }

    }
}
