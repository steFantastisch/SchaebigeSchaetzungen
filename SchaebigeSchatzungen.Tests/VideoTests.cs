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
        public async Task GetDetailsAsync_ReturnsCorrectDetails()
        {
            // Arrange
            var videoId = "testVideoId";
            var sampleResponse = @"{
            ""items"": [{
            ""snippet"": {
                ""publishedAt"": ""2021-01-01T00:00:00Z"",
                ""title"": ""Test Video"",
                ""description"": ""This is a test video."",
                ""defaultAudioLanguage"": ""de""},
            ""statistics"": {
                ""viewCount"": 1000,
                ""likeCount"": 500,
                ""commentCount"": 200
            },
            ""contentDetails"": {
                ""duration"": ""PT1M30S""
            }}], ""pageInfo"": {
                ""totalResults"": 1,
                ""resultsPerPage"": 1}}";

            var httpClientMock = new Mock<HttpClientHandler>();
            httpClientMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(sampleResponse),
                })
                .Verifiable();

            var httpClient = new HttpClient(httpClientMock.Object);
            var video = new Video();
            // Act
            await video.GetDetailsAsync(videoId, httpClient);

            // Assert
            Assert.That(video.Views, Is.EqualTo(1000));
            Assert.That(video.Likes, Is.EqualTo(500));
            Assert.That(video.Comments, Is.EqualTo(200));
            Assert.That(video.Language, Is.EqualTo("de"));
            Assert.That(video.German, Is.True);

            httpClientMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Test]
        public async Task GetDetailsAsync_ReturnsDetailsForValidVideoId()
        {
            // Arrange

            // Act
            await _video.GetDetailsAsync(_video.VideoID);

            // Assert
            Assert.NotNull(_video.Views);
            Assert.NotNull(_video.Comments);
            Assert.NotNull(_video.Likes);

            Assert.True(string.IsNullOrEmpty(_video.Language) || _video.Language is string);
            Assert.True(_video.Views >= 0);
            Assert.True(_video.Comments >= 0);
            Assert.True(_video.Likes >= 0);
        }

        [Test]
        public void Display_ReturnsHtmlWithExpectedParams()
        {

            // Act
            string result = _video.Dispstr;

            // Assert
            Assert.IsTrue(result.Contains("width=\"770px\""));
            Assert.IsTrue(result.Contains("height=\"350px\""));
            Assert.IsTrue(result.Contains("?autoplay=1&loop=1"));
            Assert.IsTrue(result.Contains("<iframe"));
        }



    }
}

