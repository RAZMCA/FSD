using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.DataLayer.Models;

namespace TwitterClone.BusinessLayer
{
    public class TweetBL
    {
        public List<Tweet> GetTweets(string userId)
        {
            List<Tweet> tweets = new List<Tweet>();
            using (TwitterCloneEntities db = new TwitterCloneEntities())
            {
                tweets = (from t in db.Tweets                                
                                 where t.UserId == userId
                                 select t
                                ).OrderBy(x => x.CreatedDate).ToList();              
                                
            }
            return tweets;
        }

        public void SaveTweet(Tweet tweet)
        {
            using (TwitterCloneEntities db = new TwitterCloneEntities())
            {
                if (tweet.TweetId == 0)
                {
                    db.Tweets.Add(tweet);
                }
                else
                {
                    Tweet t;
                    t = GetTweetById(tweet.TweetId);
                }
                db.SaveChanges();
            }
        }

        public Tweet GetTweetById(int tweetId)
        {
            Tweet tweet = new Tweet();
            using (TwitterCloneEntities db = new TwitterCloneEntities())
            {
                tweet = (from t in db.Tweets
                          where t.TweetId == tweetId
                          select t).SingleOrDefault();

            }
            return tweet;
        }
    }
}
