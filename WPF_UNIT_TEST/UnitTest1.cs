using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_TeamProject.Tests
{
    [TestClass]
    public class MainWindowTests
    {
        [TestMethod]
        public void Test_RefreshData()
        {
            // Arrange
            var mainWindow = new MainWindow();

            // Act
            mainWindow.RefreshData();

            // Assert
            Assert.IsNotNull(mainWindow.peopleListView.Items);
            Assert.IsTrue(mainWindow.peopleListView.Items.Count > 0);
        }

        [TestMethod]
        public void Test_EditPersonButton_Click_NullSelectedPerson()
        {
            // Arrange
            var mainWindow = new MainWindow();
            mainWindow.peopleListView.SelectedItem = null;

            // Act
            mainWindow.EditPersonButton_Click(null, null);

            // Assert
            MessageBoxAssert.PoppedUp("Будь ласка, виберіть користувача для редагування.");
        }

        [TestMethod]
        public void Test_RemovePersonButton_Click_NullSelectedPerson()
        {
            // Arrange
            var mainWindow = new MainWindow();
            mainWindow.peopleListView.SelectedItem = null;

            // Act
            mainWindow.RemovePersonButton_Click(null, null);

            // Assert
            MessageBoxAssert.PoppedUp("Будь ласка, виберіть користувача для видалення.");
        }

        [TestMethod]
        public void Test_SortByGradesButton_Click()
        {
            // Arrange
            var mainWindow = new MainWindow();

            // Act
            mainWindow.SortByGradesButton_Click(null, null);

            // Assert
            var sortedPeople = mainWindow.core.GetPeople().OrderByDescending(p => p.Grades.Average()).ToList();
            CollectionAssert.AreEqual(sortedPeople, mainWindow.peopleListView.Items.Cast<Person>().ToList());
        }

        [TestMethod]
        public void Test_SortByAgeButton_Click()
        {
            // Arrange
            var mainWindow = new MainWindow();

            // Act
            mainWindow.SortByAgeButton_Click(null, null);

            // Assert
            var sortedPeople = mainWindow.core.GetPeople().OrderBy(p => p.Age).ToList();
            CollectionAssert.AreEqual(sortedPeople, mainWindow.peopleListView.Items.Cast<Person>().ToList());
        }

        [TestMethod]
        public void Test_SortByNameButton_Click()
        {
            // Arrange
            var mainWindow = new MainWindow();

            // Act
            mainWindow.SortByNameButton_Click(null, null);

            // Assert
            var sortedPeople = mainWindow.core.GetPeople().OrderBy(p => p.Name).ToList();
            CollectionAssert.AreEqual(sortedPeople, mainWindow.peopleListView.Items.Cast<Person>().ToList());
        }
    }

    public static class MessageBoxAssert
    {
        public static void PoppedUp(string expectedMessage)
        {
            var messageBox = MessageBox.Show(expectedMessage, "", MessageBoxButton.OK);
            Assert.AreEqual(MessageBoxResult.OK, messageBox);
        }
    }
}