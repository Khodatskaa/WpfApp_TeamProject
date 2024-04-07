using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CORE.Models
{
    public class Core
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Points { get; set; }

        public Core()
        {
            FirstName = "";
            LastName = "";
        }

        public Core(int id, string firstName, string lastName, int age, int points)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Points = points;
        }

        public delegate void CoreEventHandler(object sender, CoreEventArgs e);
        public event CoreEventHandler CoreEvent;

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public string GetFirstName()
        {
            return FirstName;
        }

        public void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }

        public int GetAge()
        {
            return Age;
        }

        public void SetAge(int age)
        {
            Age = age;
        }

        public int GetPoints()
        {
            return Points;
        }

        public void SetPoints(int points)
        {
            Points = points;
        }

        public void RaiseCoreEvent(string message)
        {
            CoreEvent?.Invoke(this, new CoreEventArgs(message));
        }
    }

    public class CoreEventArgs : EventArgs
    {
        public string Message { get; }

        public CoreEventArgs(string message)
        {
            Message = message;
        }
    }
}