using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_TeamProject
{
    public partial class MainWindow : Window
    {
        private Core core;

        public MainWindow()
        {
            InitializeComponent();
            core = new Core();

            RefreshData();
        }

        private void RefreshData()
        {
            peopleListView.Items.Clear();

            List<Person> people = core.GetPeople();

            foreach (var person in people)
            {
                var item = new ListViewItem();
                item.Content = person;
                peopleListView.Items.Add(item);
            }
        }

        private void EditPersonButton_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = (Person)peopleListView.SelectedItem;
            if (selectedPerson == null)
            {
                MessageBox.Show("Будь ласка, виберіть користувача для редагування.");
                return;
            }

            EditPersonWindow editWindow = new EditPersonWindow(selectedPerson);
            if (editWindow.ShowDialog() == true)
            {
                core.EditPerson(selectedPerson.Id, editWindow.Name, editWindow.Surname, editWindow.Age, editWindow.Grades);

                RefreshData();
            }
        }

        private void RemovePersonButton_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = (Person)peopleListView.SelectedItem;
            if (selectedPerson == null)
            {
                MessageBox.Show("Будь ласка, виберіть користувача для видалення.");
                return;
            }

            core.RemovePerson(selectedPerson.Id);

            RefreshData();
        }

        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {
            EditPersonWindow editWindow = new EditPersonWindow();
            if (editWindow.ShowDialog() == true)
            {
                core.AddPerson(editWindow.Name, editWindow.Surname, editWindow.Age, editWindow.Grades);

                RefreshData();
            }
        }

        private void SortByGradesButton_Click(object sender, RoutedEventArgs e)
        {
            List<Person> sortedPeople = core.GetPeople().OrderByDescending(p => p.Grades.Average()).ToList();

            peopleListView.Items.Clear();
            foreach (var person in sortedPeople)
            {
                var item = new ListViewItem();
                item.Content = person;
                peopleListView.Items.Add(item);
            }
        }

        private void SortByAgeButton_Click(object sender, RoutedEventArgs e)
        {
            List<Person> sortedPeople = core.GetPeople().OrderBy(p => p.Age).ToList();

            peopleListView.Items.Clear();
            foreach (var person in sortedPeople)
            {
                var item = new ListViewItem();
                item.Content = person;
                peopleListView.Items.Add(item);
            }
        }

        private void SortByNameButton_Click(object sender, RoutedEventArgs e)
        {
            List<Person> sortedPeople = core.GetPeople().OrderBy(p => p.Name).ToList();

            peopleListView.Items.Clear();
            foreach (var person in sortedPeople)
            {
                var item = new ListViewItem();
                item.Content = person;
                peopleListView.Items.Add(item);
            }
        }
    }
}