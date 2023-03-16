using Moq;
using Moq.Protected;
using NUnit.Framework;
using SchaebigeSchaetzungen.Model;
using System.Net;

namespace SchaebigeSchatzungen.Tests
{
    public class VideoTests
    {
        private Video _video { get; set; } = null!;

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
            Assert.That(result.Length, Is.EqualTo(length));
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
            Assert.That(result.Length, Is.EqualTo(expectedLength));
        }

        [Test]
        public void RandomVidID_ReturnsDifferentStrings()
        {
            // Arrange

            // Act
            string result1 = Video.randomVidID();
            string result2 = Video.randomVidID();

            // Assert
            Assert.That(result2, Is.Not.EqualTo(result1));
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


        [Test]
        public async Task GetDetailsAsync_ReturnsDetailsForValidVideoId()
        {
            // Arrange

            Video video = new Video();

            // Act
            await video.GetDetailsAsync(video.VideoID);

            // Assert
            Assert.NotNull(video.Views);
            Assert.NotNull(video.Comments);
            Assert.NotNull(video.Likes);

            Assert.True(string.IsNullOrEmpty(video.Language) || video.Language is string);
            Assert.True(video.Views >= 0);
            Assert.True(video.Comments >= 0);
            Assert.True(video.Likes >= 0);
        }
        [Test]
        public void Display_ReturnsHtmlWithIframe()
        {
            Video video = new Video();
            // Arrange
            string url = "testUrl";

            // Act
            string result = _video.Display(url);

            // Assert
            Assert.IsTrue(result.Contains("<iframe"));
        }

        [Test]
        public void Display_ReturnsHtmlWithExpectedWidthAndHeight()
        {
            // Arrange
            string url = "testUrl";

            // Act
            string result = _video.Display(url);

            // Assert
            Assert.IsTrue(result.Contains("width=\"770px\""));
            Assert.IsTrue(result.Contains("height=\"350px\""));
        }

        [Test]
        public void Display_ReturnsHtmlWithExpectedAutoplayAndLoopAttributes()
        {
            // Arrange
            string url = "testUrl";

            // Act
            string result = _video.Display(url);

            // Assert
            Assert.IsTrue(result.Contains("?autoplay=1&loop=1"));
        }

    }
}

