using FakeItEasy;
using FluentAssertions;
using Xbehave;

namespace Katas.SnakeAndLadders.Tests
{
    /// As a player
    /// I want to be able to win the game
    /// So that I can gloat to everyone around
    public class PlayerCanWintheGame
    {
        [Scenario]
        public void WhenTokenMovesToSquare100_ThenPlayerWinsGame(GameEngine gameEngine, Player player,
            IDice dice, int diceRollResult, int positionBeforeMove)
        {
            "Given the token is on square 97"
               .x(() =>
               {
                   player = new Player(1, "Player 1", dice);
                   int totalSquares = 100;
                   gameEngine = new GameEngine(totalSquares);
                   gameEngine.AddPlayer(player);
                   gameEngine.Start();
                   gameEngine.MovePlayer(player,96);
               });

            "When the token is moved 3 spaces"
                .x(() =>
                {
                    gameEngine.MovePlayer(player, 3);
                });

            "Then the token is on square 100"
             .x(() =>
             {
                 gameEngine.CurrentSquareForPlayer(player).Should().Be(100);
             });

            "And the player has won the game"
                .x(() =>
                {
                    gameEngine.Winner.Should().Be(player);
                });
        }

        [Scenario]
        public void WhenTokenMoves4StepsFrom97_ThenTokenIsOn97(GameEngine gameEngine, Player player,
            IDice dice, int diceRollResult, int positionBeforeMove)
        {
            "Given the token is on square 97"
               .x(() =>
               {
                   player = new Player(1, "Player 1", dice);
                   int totalSquares = 100;
                   gameEngine = new GameEngine(totalSquares);
                   gameEngine.AddPlayer(player);
                   gameEngine.Start();
                   gameEngine.MovePlayer(player, 96);
               });

            "When the token is moved 4 spaces"
                .x(() =>
                {
                    gameEngine.MovePlayer(player, 4);
                });

            "Then the token is on square 97"
             .x(() =>
             {
                 gameEngine.CurrentSquareForPlayer(player).Should().Be(97);
             });

            "And the player has not won the game"
                .x(() =>
                {
                    gameEngine.Winner.Should().Be(null);
                });
        }
    }
}
