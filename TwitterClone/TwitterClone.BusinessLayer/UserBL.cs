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
    }
}
