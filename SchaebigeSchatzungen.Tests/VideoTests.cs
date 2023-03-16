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
    }
}