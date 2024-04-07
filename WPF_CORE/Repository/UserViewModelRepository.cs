using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CORE.Models;

namespace WPF_CORE.Repository
{
    public class UserViewModelRepository
    {
        private readonly UseCase.Core core;

        public UserViewModelRepository()
        {
            core = new UseCase.Core();
        }

        public List<User> GetUsers()
        {
            return core.GetUsers();
        }

        public void EditUser(int id, string firstName, string lastName, int age, int points)
        {
            core.EditUser(id, firstName, lastName, age, points);
        }

        public void RemoveUser(int id)
        {
            core.RemoveUser(id);
        }

        public void AddUser(string firstName, string lastName, int age, int points)
        {
            core.AddUser(firstName, lastName, age, points);
        }
    }
}
