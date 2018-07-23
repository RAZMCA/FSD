using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.DataLayer;
using TwitterClone.DataLayer.Models;

namespace TwitterClone.BusinessLayer
{
    public class UserBL
    {
        public void AddUser(Person item)
        {
            using (TwitterCloneEntities db = new TwitterCloneEntities())
            {
                db.People.Add(item);
                db.SaveChanges();
            }
        }
        public Person Validate(string uname,string pwd)
        {
            using (TwitterCloneEntities db = new TwitterCloneEntities())
            {
                Person obj = db.People.FirstOrDefault(i => i.UserId == uname && i.Password == pwd);
                return obj;
            }
        }
        public Person SearchUser(string uname)
        {
            using (TwitterCloneEntities db = new TwitterCloneEntities())
            {
                Person obj = db.People.FirstOrDefault(i => i.UserId.Contains(uname));
                return obj;
            }
        }

        public Person GetUserDetails(string userId)
        {
            using (TwitterCloneEntities db = new TwitterCloneEntities())
            {
                Person obj = db.People.FirstOrDefault(i => i.UserId == userId);
                return obj;
            }
        }
        public void UpdateUser(Person item)
        {
            using (TwitterCloneEntities db = new TwitterCloneEntities())
            {
                var user = db.People.Where(x => x.UserId == item.UserId).FirstOrDefault();
                if(user != null)
                {
                    user.FullName = item.FullName;
                    user.Email = item.Email;
                    db.Entry(user).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                
            }
        }
    }
}
