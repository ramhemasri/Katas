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

        [Scenario]
        public void AfterGameStart_WhenTokenMove3Spaces_ThenTokenShouldBeOnSquare4(GameEngine gameEngine, Player player)
        {
            "Given the token is on square 1"
               .x(() =>
               {
                   player = new Player(1, "Player 1");
                   int totalSquares = 100;
                   gameEngine = new GameEngine(totalSquares);
                   gameEngine.AddPlayer(player);
                   gameEngine.Start();
               });

            "When the token is moved 3 spaces"
                .x(() =>
                {
                    int spaces = 3;
                    gameEngine.MovePlayer(player, spaces);
                });

            "Then the token is on square 4"
                .x(() =>
                {
                    gameEngine.CurrentSquareForPlayer(player).Should().Be(4);
                });
        }

        [Scenario]
        public void AfterGameStart_WhenTokenMoves3And4Spaces_ThenTokenShouldBeOnSquare8(GameEngine gameEngine, Player player)
        {
            "Given the token is on square 1"
                   .x(() =>
                   {
                       player = new Player(1, "Player 1");
                       int totalSquares = 100;
                       gameEngine = new GameEngine(totalSquares);
                       gameEngine.AddPlayer(player);
                       gameEngine.Start();
                   });

            "When the token is moved 3 spaces"
                .x(() =>
                {
                    int spaces = 3;
                    gameEngine.MovePlayer(player, spaces);
                });

            "And then it is moved 4 spaces"
                .x(() =>
                {
                    int spaces = 4;
                    gameEngine.MovePlayer(player, spaces);
                });

            "Then the token is on square 8"
                .x(() =>
                {
                    gameEngine.CurrentSquareForPlayer(player).Should().Be(8);
                });
        }
    }
}
