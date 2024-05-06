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
        private bool _editButtonPressed = false;
        private Student _SavedStudent {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
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


        private void TransformTextBlockToTextBox(TextBlock textBlock)
        {
            if (textBlock == null)
                return;

            // Create a new TextBox
            TextBox textBox = new TextBox();
            textBox.Text = textBlock.Text;
            textBox.HorizontalAlignment = textBlock.HorizontalAlignment;
            textBox.VerticalAlignment = textBlock.VerticalAlignment;
            textBox.Margin = textBlock.Margin;

            // Replace TextBlock with TextBox in the parent container
            if (textBlock.Parent is Panel parentPanel)
            {
                int index = parentPanel.Children.IndexOf(textBlock);
                parentPanel.Children.RemoveAt(index);
                parentPanel.Children.Insert(index, textBox);
            }
        }

        private void TransformTextBoxToTextBlock(TextBox textBox)
        {
            if (textBox == null)
                return;

            // Create a new TextBlock
            TextBlock textBlock = new TextBlock();
            textBlock.Text = textBox.Text;
            textBlock.HorizontalAlignment = textBox.HorizontalAlignment;
            textBlock.VerticalAlignment = textBox.VerticalAlignment;
            textBlock.Margin = textBox.Margin;

            // Replace TextBox with TextBlock in the parent container
            if (textBox.Parent is Panel parentPanel)
            {
                int index = parentPanel.Children.IndexOf(textBox);
                parentPanel.Children.RemoveAt(index);
                parentPanel.Children.Insert(index, textBlock);
            }
        }

        private void ToggleTextBlockTextBox(object sender)
        {
            if (sender is TextBlock block)
            {
                TransformTextBlockToTextBox(block);
            }
            else if (sender is TextBox box)
            {
                TransformTextBoxToTextBlock(box);
            }
        }

        private void ToggleBoxes()
        {
            if (boxName.Parent is Panel parentPanel)
            {
                int indexName = parentPanel.Children.IndexOf(boxName);
                ToggleTextBlockTextBox(parentPanel.Children[indexName]);
                int indexAge = parentPanel.Children.IndexOf(boxAge);
                ToggleTextBlockTextBox(parentPanel.Children[indexAge]);
                int indexDesc = parentPanel.Children.IndexOf(boxDesc);
                ToggleTextBlockTextBox(parentPanel.Children[indexDesc]);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!_editButtonPressed)
            {
                ToggleBoxes();
                buttonCheck.Visibility = Visibility.Visible;

                _SavedStudent = new Student() { Name = boxName.Text, Age = boxAge.Text, Description = boxDesc.Text };
            }
                
        }

        private void buttonCheck_Click(object sender, RoutedEventArgs e)
        {

        }
    }


 }
