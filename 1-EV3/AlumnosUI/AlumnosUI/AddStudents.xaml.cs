using System.Windows;
using Model;
namespace AlumnosUI
{
    /// <summary>
    /// Lógica de interacción para AddStudents.xaml
    /// </summary>
    /// 

    public enum ErrorType
    {
        Student = 0,
        Name = -1,
        Age = -2,
        Description = -3,
        COUNT = -4
    }


    public partial class AddStudents : Window
    {

        public static string GetEnumDescription(long value)
        {
            if (value == 0) return "Student";
            if (value == -1) return "Name";
            if (value == -2) return "Age";
            if (value == -3) return "Description";
            return string.Empty;
        }

        public AddStudents()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number;
                
                if (!int.TryParse(boxAge.Text, out number))
                {
                    ErrorAddingStudent((int)ErrorType.Age);
                    return;
                }
                    
                Student student = new Student()
                {
                    Name = boxName.Text,
                    Age = number,
                    Description = boxDesc.Text,
                };

                long result = AppModel.Instance.Database.AddStudent(student);
                if (result <= 0)
                {
                    ErrorAddingStudent(result);
                    Console.WriteLine("No se pudo añadir");
                    
                }
                else
                {
                    Console.WriteLine("Añadiendo estudiante");
                    SuccessAddingStudent(result);
                }
                    


            }
            catch (Exception ex) 
            {
                Console.Error.WriteLine(ex.Message);
            }

        }

        private void SuccessAddingStudent(long value)
        {
            MessageBox.Show($"Success! The Student's ID is {value}");
        }

        private void ErrorAddingStudent(long value)
        {
            if (value <= (int)ErrorType.COUNT)
                MessageBox.Show("Error! Try again.");
            MessageBox.Show($"Error! {GetEnumDescription(value)} is not valid.");

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
