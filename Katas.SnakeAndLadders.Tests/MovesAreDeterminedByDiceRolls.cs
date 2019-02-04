using FakeItEasy;
using FluentAssertions;
using Xbehave;

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
                    player = new Player(1, "Player 1", dice);
                    int totalSquares = 100;
                    gameEngine = new GameEngine(totalSquares);
                    gameEngine.AddPlayer(player);
                    gameEngine.Start();
                });

            "When the player rolls a die"
                .x(() =>
                {
                    diceRollResult = player.RollDice();
                });

            "Then the result should be between 1-6 inclusive"
             .x(() =>
             {
                 diceRollResult.Should().BeInRange(1, 6);
             });

        }


        [Scenario]
        public void WhenPlayerRolls4_ThenTokenShouldMove4Spaces(GameEngine gameEngine, Player player,
            IDice dice, int diceRollResult, int positionBeforeMove)
        {
            "Given the player rolls a 4"
                .x(() =>
                {
                    dice = A.Fake<IDice>();
                    A.CallTo(() => dice.Roll()).Returns(4);
                    player = new Player(1, "Player 1", dice);
                    int totalSquares = 100;
                    gameEngine = new GameEngine(totalSquares);
                    gameEngine.AddPlayer(player);
                    gameEngine.Start();
                });

            "When they move their token"
                .x(() =>
                {
                    positionBeforeMove = gameEngine.CurrentSquareForPlayer(player);
                    gameEngine.MovePlayer(player, player.RollDice());
                });
            "Then the token should move 4 space"
                .x(() =>
                {
                    int positionAfterMove = gameEngine.CurrentSquareForPlayer(player);
                    int result = positionAfterMove - positionBeforeMove;
                    result.Should().Be(4);
                });
        }

    }
}
