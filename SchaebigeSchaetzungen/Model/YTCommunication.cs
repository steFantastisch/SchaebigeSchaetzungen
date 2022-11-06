﻿using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Model
{
    public class YTCommunication
    {
        YouTubeService youTubeService = new YouTubeService();

        public YTCommunication(string keyPath, string accountEmail)
        {
            var certificate = new X509Certificate2(keyPath,
                "notasecret", X509KeyStorageFlags.Exportable);

            var credentials = new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(accountEmail)
                {
                    Scopes = new[]
                        {YouTubeService.Scope.YoutubeReadonly}
                }.FromCertificate(certificate));

            youTubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials
            });
        }

        public SearchResource.ListRequest GetData()
        {
            var searchListRequest = youTubeService.Search.List("snippet");
            searchListRequest.MaxResults = 1;
            searchListRequest.Type = "video";
            searchListRequest.Execute();

            return searchListRequest;
        }
    }
}
