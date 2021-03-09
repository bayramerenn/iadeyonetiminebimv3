using CivilManagement.DataAccess.Abstract;
using CivilManagement.DataAccess.Concrete.EntityFramework.Context;
using CivilManagement.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CivilManagement.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : IUserDal
    {
        public List<User> GetUser(string identityNumber, string phone)
        {


            using (var context = new CivilContext())
            {
                var user = context.Set<User>().FromSqlRaw($"EXEC cvl_StoreManager @identityNum='{identityNumber}',@phone='{phone}'").ToList();

                return user;
            }
        }

    }
}