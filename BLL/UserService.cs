using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class UserService : IUserService
    {
        #region DataInit
        private List<User> _UserList = new List<User>()
        {
            new User ()
            {
                id =1,
                Name ="1name",
                Password ="1password"
            },
            new User ()
            {
                id =2,
                Name ="2name",
                Password ="2password" 
            },
            new User ()
            {
                id =3,
                Name ="3name",
                Password ="3password"
            },
            new User ()
            {
                id =4,
                Name ="4name",
                Password ="4password"
            }
        };
        #endregion
        public User FindUser(int id)
        {
            return this._UserList.Find(r => r.id == id);
        }

        public IEnumerable<User> UserAll()
        {
            return this._UserList;
        }


    }
}
