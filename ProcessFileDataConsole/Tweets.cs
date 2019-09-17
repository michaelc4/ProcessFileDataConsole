using System;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Models;

namespace ProcessFileDataConsole
{
    public class Tweets
    {
        public IEnumerable<ITweet> BuscarTweets(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret, string paramBusca)
        {
            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            RateLimit.RateLimitTrackerMode = RateLimitTrackerMode.TrackAndAwait;
            var searchParameter = Search.CreateTweetSearchParameter(paramBusca);
            searchParameter.SearchType = SearchResultType.Recent;
            searchParameter.MaximumNumberOfResults = 100000;
            searchParameter.Since = new DateTime(2019, 1, 1);
            return Search.SearchTweets(searchParameter).ToList();
        }
    }
}
