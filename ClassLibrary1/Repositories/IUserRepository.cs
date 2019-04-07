using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models;

namespace Teams.BL.Repositories
{
    interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int Id);
        UserModel Create(UserModel model);
        void Update(UserModel model);
        void Delete(Guid id);
    }
}
