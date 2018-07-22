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
        public void GetTweets(string userId)
        {
            using (TwitterCloneEntities1 db = new TwitterCloneEntities1())
            {
                //var tweetList = from tweet in db.Tweets
                //                join follow in db.foll  .Where(x => t1.ProjectID == x.ProjectID && x.Completed == true)
                //                                .DefaultIfEmpty()
                //                select new { t1.ProjectName, t2.TaskName }
            }
        }
    }
}
