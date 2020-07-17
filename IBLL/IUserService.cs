using Model;
using System;
using System.Collections.Generic;

namespace IBLL
{
    public interface  IUserService
    {
        User FindUser(int id);
        IEnumerable<User> UserAll();
    }
}
