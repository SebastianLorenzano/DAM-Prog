namespace _1._2_exercise3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "The Second Button Has been Pressed";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "The First Button Has been Pressed";
        }
    }
}