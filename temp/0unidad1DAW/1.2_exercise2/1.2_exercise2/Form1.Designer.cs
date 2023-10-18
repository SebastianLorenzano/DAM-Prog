namespace _1._2_exercise2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(214, 102);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(346, 27);
            textBox1.TabIndex = 0;
            textBox1.Text = "Write Here";
            // 
            // button1
            // 
            button1.Location = new Point(214, 220);
            button1.Name = "button1";
            button1.Size = new Size(346, 29);
            button1.TabIndex = 1;
            button1.Text = "Show the content of the TextBox";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(214, 281);
            button2.Name = "button2";
            button2.Size = new Size(341, 29);
            button2.TabIndex = 2;
            button2.Text = "Change the colour of the Background";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(214, 342);
            button3.Name = "button3";
            button3.Size = new Size(341, 29);
            button3.TabIndex = 3;
            button3.Text = "Change the colour of the TextBox's text";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(262, 36);
            label1.Name = "label1";
            label1.Size = new Size(156, 25);
            label1.TabIndex = 4;
            label1.Text = "My First Program";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
    }
}