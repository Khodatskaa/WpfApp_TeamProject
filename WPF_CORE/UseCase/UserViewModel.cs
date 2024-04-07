using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CORE.Models;

namespace WPF_CORE.UseCase
{
    public class UserViewModel
    {
        private readonly Core core;

        public ObservableCollection<User> Users { get; set; }    // ObservableCollection is used to update the UI automatically

        public UserViewModel()
        {
            core = new Core();
            Users = new ObservableCollection<User>(core.GetUsers());
        }

        public void RefreshData()
        {
            Users.Clear();
            List<User> users = core.GetUsers();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        public void EditUser(int id, string firstName, string lastName, int age, int points)
        {
            core.EditUser(id, firstName, lastName, age, points);
            RefreshData();
        }

        public void RemoveUser(int id)
        {
            core.RemoveUser(id);
            RefreshData();
        }

        public void AddUser(string firstName, string lastName, int age, int points)
        {
            core.AddUser(firstName, lastName, age, points);
            RefreshData();
        }

        public void SortByPoints()
        {
            List<User> sortedUsers = Users.OrderByDescending(u => u.Points).ToList();    // (u => u.Points) - is used to sort by Points
            Users.Clear();
            foreach (var user in sortedUsers)
            {
                Users.Add(user);
            }
        }

        public void SortByAge()
        {
            List<User> sortedUsers = Users.OrderBy(u => u.Age).ToList();                  // (u => u.Age) - is used to sort by Age
            Users.Clear();
            foreach (var user in sortedUsers)
            {
                Users.Add(user);
            }
        }

        public void SortByName()
        {
            List<User> sortedUsers = Users.OrderBy(u => u.FirstName).ToList();           // (u => u.FirstName) - is used to sort by FirstName
            Users.Clear();
            foreach (var user in sortedUsers)
            {
                Users.Add(user);
            }
        }
    }

    internal class Core
    {
        public List<User> GetUsers()
        {
            return new List<User>
        {
            new User { Id = 1, FirstName = "John", LastName = "Doe", Age = 25, Points = 100 },
            new User { Id = 2, FirstName = "Jane", LastName = "Doe", Age = 30, Points = 200 },
            new User { Id = 3, FirstName = "Alice", LastName = "Smith", Age = 35, Points = 300 },
            new User { Id = 4, FirstName = "Bob", LastName = "Smith", Age = 40, Points = 400 }
        };
        }

        public void EditUser(int id, string firstName, string lastName, int age, int points) { }

        public void RemoveUser(int id) { }

        public void AddUser(string firstName, string lastName, int age, int points) { }
    }
}
