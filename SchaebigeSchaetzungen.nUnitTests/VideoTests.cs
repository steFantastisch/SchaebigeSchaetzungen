using NUnit.Framework;

namespace SchaebigeSchaetzungen.nUnitTests

{
    
    public class VideoTests
    {

        private Video _video;
        [SetUp]
        public void Setup()
        {
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
        public void Video_GetDetailsAsync_ReturnsCorrectDetails()
        {
            // Arrange
            string videoId = "VIDEO_ID";
            Video video = new Video();

            // Act
            video.GetDetailsAsync(videoId).Wait();

            // Assert
            Assert.AreEqual(1234, video.Views);
            Assert.AreEqual(567, video.Likes);
            Assert.AreEqual(89, video.Comments);
            Assert.AreEqual("en", video.Language);
            Assert.IsFalse(video.German);
        }
    }
}
