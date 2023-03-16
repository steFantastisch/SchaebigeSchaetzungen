using NUnit.Framework;
using SchaebigeSchaetzungen.Model;

namespace SchaebigeSchatzungen.Tests
{
    public class VideoTests
    {
        private Video _video { get; set; }=null!;

        [SetUp]
        public void Setup()
        {
            _video = new Video();  
        }


        [Test]
        public void RandomString_ReturnsStringWithCorrectLength()
        {
            // Arrange
            int length = 10;

            // Act
            string result = Video.RandomString(length);

            // Assert
            Assert.AreEqual(length, result.Length);
        }

        [Test]
        public void RandomString_ReturnsStringWithOnlyValidCharacters()
        {
            // Arrange
            int length = 10;
            string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            // Act
            string result = Video.RandomString(length);

            // Assert
            foreach (char c in result)
            {
                Assert.IsTrue(validChars.Contains(c));
            }
        }

        [Test]
        public void RandomVidID_ReturnsStringWith11Characters()
        {
            // Arrange
            int expectedLength = 11;

            // Act
            string result = Video.randomVidID();

            // Assert
            Assert.AreEqual(expectedLength, result.Length);
        }

        [Test]
        public void RandomVidID_ReturnsDifferentStrings()
        {
            // Arrange

            // Act
            string result1 = Video.randomVidID();
            string result2 = Video.randomVidID();

            // Assert
            Assert.AreNotEqual(result1, result2);
        }

        [Test]
        public void RandomVidID_ReturnsStringWithValidCharacters()
        {
            // Arrange
            string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";
            List<char> validCharsList = validChars.ToCharArray().ToList();

            // Act
            string result = Video.randomVidID();

            // Assert
            foreach (char c in result)
            {
                Assert.Contains(c, validCharsList);
            }
        }
    }
}
