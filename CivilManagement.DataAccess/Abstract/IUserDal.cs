using CivilManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CivilManagement.DataAccess.Abstract
{
    public interface IUserDal
    {
        List<User> GetUser(string identityNumber, string phone);
    }
}
