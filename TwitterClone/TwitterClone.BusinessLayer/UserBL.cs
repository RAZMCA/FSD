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
            using (TwitterCloneEntities1 db = new TwitterCloneEntities1())
            {
                db.People.Add(item);
                db.SaveChanges();
            }
        }
        public Person Validate(string uname,string pwd)
        {
            using (TwitterCloneEntities1 db = new TwitterCloneEntities1())
            {
                Person obj = db.People.FirstOrDefault(i => i.UserId == uname && i.Password == pwd);
                return obj;
            }
        }
    }
}
