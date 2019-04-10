using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models;

namespace Teams.BL.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();
        UserModel GetById(Guid Id);
        UserModel Create(UserModel model);
        void Update(UserModel model);
        void Delete(Guid Id);
    }
}
