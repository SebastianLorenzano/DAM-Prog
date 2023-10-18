namespace _0._1_example
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
            yes_button = new Button();
            no_button = new Button();
            continue_label = new Label();
            textbox1 = new TextBox();
            SuspendLayout();
            // 
            // yes_button
            // 
            yes_button.ForeColor = SystemColors.ActiveCaptionText;
            yes_button.Location = new Point(242, 292);
            yes_button.Name = "yes_button";
            yes_button.Size = new Size(94, 29);
            yes_button.TabIndex = 0;
            yes_button.Text = "YES";
            yes_button.UseVisualStyleBackColor = true;
            yes_button.Click += button1_Click;
            // 
            // no_button
            // 
            no_button.Location = new Point(434, 292);
            no_button.Name = "no_button";
            no_button.Size = new Size(94, 29);
            no_button.TabIndex = 1;
            no_button.Text = "NO";
            no_button.UseVisualStyleBackColor = true;
            no_button.Click += button2_Click;
            // 
            // continue_label
            // 
            continue_label.AutoSize = true;
            continue_label.BackColor = Color.Red;
            continue_label.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            continue_label.Location = new Point(193, 155);
            continue_label.Name = "continue_label";
            continue_label.Size = new Size(362, 35);
            continue_label.TabIndex = 2;
            continue_label.Text = "DO YOU WANT TO CONTINUE?";
            continue_label.Click += label1_Click;
            // 
            // textbox1
            // 
            textbox1.Location = new Point(310, 91);
            textbox1.Name = "textbox1";
            textbox1.Size = new Size(125, 27);
            textbox1.TabIndex = 3;
            textbox1.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            BackgroundImage = Properties.Resources._324519_832x600;
            ClientSize = new Size(782, 453);
            Controls.Add(textbox1);
            Controls.Add(continue_label);
            Controls.Add(no_button);
            Controls.Add(yes_button);
            Name = "Form1";
            Text = "My First C# Program";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button yes_button;
        private Button no_button;
        private Label continue_label;
        private TextBox textbox1;
    }
}