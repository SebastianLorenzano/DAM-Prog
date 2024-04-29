using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model;
namespace AlumnosUI
{
    /// <summary>
    /// Lógica de interacción para AddStudents.xaml
    /// </summary>
    public partial class AddStudents : Window
    {
        public AddStudents()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student student = new Student()
                {
                    Name = boxName.Text,
                    Age = Convert.ToInt32(boxAge.Text),
                    Description = boxDesc.Text,
                };

                long result = AppModel.Instance.Database.AddStudent(student);
                if (result == 1)
                    ErrorAddingStudent();
            }
            catch (Exception ex) 
            {
                Console.Error.WriteLine(ex.Message);
            }

        }

        private void ErrorAddingStudent()
        {
            throw new NotImplementedException();
        }
    }
}
