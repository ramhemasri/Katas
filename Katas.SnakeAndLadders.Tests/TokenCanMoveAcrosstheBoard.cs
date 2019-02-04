using FluentAssertions;
using Xbehave;

namespace Katas.SnakeAndLadders.Tests
{
    ///As a player
    ///I want to be able to move my token
    ///So that I can get closer to the goal
    public class TokenCanMoveAcrosstheBoard
    {
        [Scenario]
        public void TokenShouldBeOnSquare1(GameEngine gameEngine, Player player)
        {
            "Given the game is started"
                .x(() =>
                {
                    player = new Player(1, "Player 1");
                    int totalSquares = 100;
                    gameEngine = new GameEngine(totalSquares);
                    gameEngine.AddPlayer(player);
                    gameEngine.Start();
                });

            "When the token is placed on the board"
                .x(() => { });

            "Then the token is on square 1"
             .x(() =>
             {
                 gameEngine.CurrentSquareForPlayer(player).Should().Be(1);
             });

        }


    }
}
