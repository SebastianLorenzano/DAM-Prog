using Model;
using System.Windows;
using System.Windows.Controls;

namespace AlumnosUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _index = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddStudents newPage = new AddStudents();
            newPage.ShowDialog();
        }

        private void ButtonAdd_Copiar1_Click(object sender, RoutedEventArgs e)
        {
            var db = AppModel.Instance.Database;
            int studentCount = db.StudentCount;
            if (studentCount == 0)
                return;
            if (++_index >= studentCount)
                _index = 0;
            ChangeStudent(db.GetStudentAt(_index));
        }


        private void ButtonAdd_Copiar_Click(object sender, RoutedEventArgs e)
        {
            var db = AppModel.Instance.Database;
            int studentCount = db.StudentCount;
            if (studentCount == 0)
                return;
            if (--_index <= -1)
                _index = studentCount - 1;
            ChangeStudent(db.GetStudentAt(_index));

        }


        private void ChangeStudent(Student student)
        {
            if (Student.IsValid(student) <= 0)
                return;
            boxName.Text = student.Name;
            boxAge.Text = student.Age.ToString();
            boxDesc.Text = student.Description;
            boxId.Text = student.Id.ToString();
            blockId.Text = (_index + 1).ToString();
        }
    }
}