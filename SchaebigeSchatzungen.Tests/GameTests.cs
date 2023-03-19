using Moq;
using Moq.Protected;
using NUnit.Framework;
using SchaebigeSchaetzungen.Model;
using System.Net;

namespace SchaebigeSchatzungen.Tests
{
    public class GameTests
    {
        [Test]
        public void CalculateMultiplayerPoints_ReturnsCorrectScores()
        {
            // Arrange
            int player1Guess = 1000;
            int player2Guess = 2000;
            int actualViews = 1500;

            // Act
            int[] result = Game.CalculateMultiplayerPoints(player1Guess, player2Guess, actualViews);

            // Assert
            Assert.AreEqual(67, result[0]);
            Assert.AreEqual(75, result[1]);
        }

        [Test]
        public void CalculateMultiplayerPoints_BothPlayersExact_ReturnsMaxScores()
        {
            // Arrange
            int player1Guess = 1500;
            int player2Guess = 1500;
            int actualViews = 1500;

            // Act
            int[] result = Game.CalculateMultiplayerPoints(player1Guess, player2Guess, actualViews);

            // Assert
            Assert.AreEqual(100, result[0]);
            Assert.AreEqual(100, result[1]);
        }

        [Test]
        public void SingleplayerPts_ReturnsCorrectScore()
        {
            // Arrange
            int playerGuess = 1000;
            int actualViews = 1500;

            // Act
            string result = Game.SingleplayerPts(playerGuess, actualViews);

            // Assert
            Assert.AreEqual("67", result);
        }

        [Test]
        public void SingleplayerPts_ExactGuess_ReturnsMaxScore()
        {
            // Arrange
            int playerGuess = 1500;
            int actualViews = 1500;

            // Act
            string result = Game.SingleplayerPts(playerGuess, actualViews);

            // Assert
            Assert.AreEqual("100", result);
        }
    }

}

