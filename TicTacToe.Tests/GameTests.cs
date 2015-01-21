using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TicTacToe.TicTacToe;
using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void GameShouldStartWithOToken()
        {
            var game = new Game();
            Assert.That(game.CurrentPlayerToken, Is.EqualTo(Token.O));
        }

        [Test]
        public void GameShouldStartWithNullResult()
        {
            var game = new Game();
            Assert.That(game.Result, Is.Null);
        }

        [Test]
        public void WhenAllCellsAreFilledAndNoWinnerGameShouldHaveDrawResult()
        {
            var game = new Game();

            game.Play(BoardPosition.A1); //O
            game.Play(BoardPosition.A2); //X
            game.Play(BoardPosition.A3); //O
            game.Play(BoardPosition.B2); //X
            game.Play(BoardPosition.B1); //O
            game.Play(BoardPosition.C1); //X
            game.Play(BoardPosition.B3); //O
            game.Play(BoardPosition.C3); //X
            game.Play(BoardPosition.C2); //O

            Assert.That(game.Result, Is.EqualTo(GameResult.Draw));
        }

        [Test]
        public void WhenSomeCellsAreFilledAndNoWinnerGameShouldHaveNullResult()
        {
            var game = new Game();

            game.Play(BoardPosition.A1); //O
            game.Play(BoardPosition.A2); //X
            game.Play(BoardPosition.A3); //O
            
            Assert.That(game.Result, Is.Null);
        }

        [Test]
        public void WhenXWinsGameShouldHaveXWinResult()
        {
            var game = new Game();

            game.Play(BoardPosition.A1); //O
            game.Play(BoardPosition.A2); //X
            game.Play(BoardPosition.A3); //O
            game.Play(BoardPosition.B2); //X
            game.Play(BoardPosition.B1); //O
            game.Play(BoardPosition.C2); //X

            Assert.That(game.Result, Is.EqualTo(GameResult.X_Win));
        }

        [Test]
        public void WhenOWinsGameShouldHaveOWinResult()
        {
            var game = new Game();
            game.Play(BoardPosition.A1); //O
            game.Play(BoardPosition.A2); //X
            game.Play(BoardPosition.B1); //O
            game.Play(BoardPosition.B2); //X
            game.Play(BoardPosition.C1); //O
            
            Assert.That(game.Result, Is.EqualTo(GameResult.O_Win));
        }

        [Test]
        public void GameShouldExposeReadonlyBoard()
        {
            var game = new Game();
            Assert.That(game.Board, Is.Not.Null);
        }

        [Test]
        public void GameShouldSwapCurrentPlayerAfterEachPlay()
        {
            var game = new Game();

            game.Play(BoardPosition.A1);

            Assert.That(game.CurrentPlayerToken, Is.EqualTo(Token.X));
        }

        [Test]
        public void GameShouldAddTokenToBoardWhenPlaying()
        {
            var game = new Game();

            Assert.That(game.CurrentPlayerToken, Is.EqualTo(Token.O), "Token not initialised to O");
            game.Play(BoardPosition.A1);

            Assert.That(game.CurrentPlayerToken, Is.EqualTo(Token.X));
            Assert.That(game.Board.GetTokenAt(BoardPosition.A1), Is.EqualTo(Token.O));
        }

        [Test]
        public void GameShouldAddXTokenToBoardWhenPlayingSecondRound()
        {
            var game = new Game();

            game.Play(BoardPosition.A1);
            
            Assert.That(game.CurrentPlayerToken, Is.EqualTo(Token.X), "TokenSwitching not working");
            game.Play(BoardPosition.A2);

            Assert.That(game.Board.GetTokenAt(BoardPosition.A2), Is.EqualTo(Token.X));
        }

        [Test]
        public void PlayShouldReturnFalseWhenPlayerAttemptsToPlayInAnOccupiedPosition()
        {
            var game = new Game();

            var ans1 = game.Play(BoardPosition.A1); //token should be X
            var ans2 = game.Play(BoardPosition.A1); //token doesn not change here

            Assert.That(ans1, Is.True);
            Assert.That(ans2, Is.False);
        }

        [Test]
        public void GameShouldNotSwapPlayerWhenPlayerAttemptsToPlayInAnOccupiedPosition()
        {
            var game = new Game();

            game.Play(BoardPosition.A1); //token should be X
            
            Assert.That(game.CurrentPlayerToken, Is.EqualTo(Token.X));
            
            game.Play(BoardPosition.A1); //token doesn not change here

            Assert.That(game.CurrentPlayerToken, Is.EqualTo(Token.X));
        }
    }
}
