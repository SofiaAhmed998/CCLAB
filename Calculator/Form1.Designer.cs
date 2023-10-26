namespace calculator
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            Display = new TextBox();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            button17 = new Button();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            button21 = new Button();
            button22 = new Button();
            button23 = new Button();
            button24 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(16, 98);
            button1.Name = "button1";
            button1.Size = new Size(75, 43);
            button1.TabIndex = 1;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Number_Pressed;
            // 
            // button2
            // 
            button2.Location = new Point(97, 98);
            button2.Name = "button2";
            button2.Size = new Size(75, 43);
            button2.TabIndex = 2;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Number_Pressed;
            // 
            // button3
            // 
            button3.Location = new Point(178, 98);
            button3.Name = "button3";
            button3.Size = new Size(75, 43);
            button3.TabIndex = 3;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Number_Pressed;
            // 
            // button4
            // 
            button4.Location = new Point(178, 46);
            button4.Name = "button4";
            button4.Size = new Size(75, 43);
            button4.TabIndex = 4;
            button4.Text = "+";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Operator_Pressed;
            // 
            // button5
            // 
            button5.BackColor = Color.Silver;
            button5.Location = new Point(94, 245);
            button5.Margin = new Padding(0);
            button5.Name = "button5";
            button5.Size = new Size(240, 43);
            button5.TabIndex = 5;
            button5.Text = "=";
            button5.UseVisualStyleBackColor = false;
            button5.Click += Operator_Pressed;
            // 
            // Display
            // 
            Display.Location = new Point(16, 17);
            Display.Name = "Display";
            Display.Size = new Size(399, 23);
            Display.TabIndex = 6;
            // 
            // button6
            // 
            button6.Location = new Point(178, 147);
            button6.Name = "button6";
            button6.Size = new Size(75, 43);
            button6.TabIndex = 9;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Number_Pressed;
            // 
            // button7
            // 
            button7.Location = new Point(97, 147);
            button7.Name = "button7";
            button7.Size = new Size(75, 43);
            button7.TabIndex = 8;
            button7.Text = "5";
            button7.UseVisualStyleBackColor = true;
            button7.Click += Number_Pressed;
            // 
            // button8
            // 
            button8.Location = new Point(16, 147);
            button8.Name = "button8";
            button8.Size = new Size(75, 43);
            button8.TabIndex = 7;
            button8.Text = "4";
            button8.UseVisualStyleBackColor = true;
            button8.Click += Number_Pressed;
            // 
            // button10
            // 
            button10.Location = new Point(97, 46);
            button10.Name = "button10";
            button10.Size = new Size(75, 43);
            button10.TabIndex = 11;
            button10.Text = "CE";
            button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Location = new Point(16, 46);
            button11.Name = "button11";
            button11.Size = new Size(75, 43);
            button11.TabIndex = 10;
            button11.Text = "C";
            button11.UseVisualStyleBackColor = true;
            button11.Click += Operator_Pressed;
            // 
            // button12
            // 
            button12.Location = new Point(178, 196);
            button12.Name = "button12";
            button12.Size = new Size(75, 43);
            button12.TabIndex = 15;
            button12.Text = "9";
            button12.UseVisualStyleBackColor = true;
            button12.Click += Number_Pressed;
            // 
            // button13
            // 
            button13.Location = new Point(97, 196);
            button13.Name = "button13";
            button13.Size = new Size(75, 43);
            button13.TabIndex = 14;
            button13.Text = "8";
            button13.UseVisualStyleBackColor = true;
            button13.Click += Number_Pressed;
            // 
            // button14
            // 
            button14.Location = new Point(16, 196);
            button14.Name = "button14";
            button14.Size = new Size(75, 43);
            button14.TabIndex = 13;
            button14.Text = "7";
            button14.UseVisualStyleBackColor = true;
            button14.Click += Number_Pressed;
            // 
            // button15
            // 
            button15.Location = new Point(259, 196);
            button15.Name = "button15";
            button15.Size = new Size(75, 43);
            button15.TabIndex = 18;
            button15.Text = "÷";
            button15.UseVisualStyleBackColor = true;
            button15.Click += Operator_Pressed;
            // 
            // button16
            // 
            button16.Location = new Point(259, 147);
            button16.Name = "button16";
            button16.Size = new Size(75, 43);
            button16.TabIndex = 17;
            button16.Text = "-";
            button16.UseVisualStyleBackColor = true;
            button16.Click += Operator_Pressed;
            // 
            // button17
            // 
            button17.Location = new Point(259, 98);
            button17.Name = "button17";
            button17.Size = new Size(75, 43);
            button17.TabIndex = 16;
            button17.Text = "×";
            button17.UseVisualStyleBackColor = true;
            button17.Click += Operator_Pressed;
            // 
            // button18
            // 
            button18.Location = new Point(16, 245);
            button18.Name = "button18";
            button18.Size = new Size(75, 43);
            button18.TabIndex = 19;
            button18.Text = "0";
            button18.UseVisualStyleBackColor = true;
            button18.Click += Number_Pressed;
            // 
            // button19
            // 
            button19.Location = new Point(340, 46);
            button19.Name = "button19";
            button19.Size = new Size(75, 43);
            button19.TabIndex = 20;
            button19.Text = "Sin";
            button19.UseVisualStyleBackColor = true;
            button19.Click += Trigonomatric_function;
            // 
            // button20
            // 
            button20.Location = new Point(340, 196);
            button20.Name = "button20";
            button20.Size = new Size(75, 43);
            button20.TabIndex = 21;
            button20.Text = "Cot";
            button20.UseVisualStyleBackColor = true;
            button20.Click += Trigonomatric_function;
            // 
            // button21
            // 
            button21.Location = new Point(340, 147);
            button21.Name = "button21";
            button21.Size = new Size(75, 43);
            button21.TabIndex = 22;
            button21.Text = "Tan";
            button21.UseVisualStyleBackColor = true;
            button21.Click += Trigonomatric_function;
            // 
            // button22
            // 
            button22.Location = new Point(340, 98);
            button22.Name = "button22";
            button22.Size = new Size(75, 43);
            button22.TabIndex = 23;
            button22.Text = "Cos";
            button22.UseVisualStyleBackColor = true;
            button22.Click += Trigonomatric_function;
            // 
            // button23
            // 
            button23.Location = new Point(340, 245);
            button23.Name = "button23";
            button23.Size = new Size(75, 43);
            button23.TabIndex = 24;
            button23.Text = "Cosec";
            button23.UseVisualStyleBackColor = true;
            button23.Click += Trigonomatric_function;
            // 
            // button24
            // 
            button24.Location = new Point(259, 46);
            button24.Name = "button24";
            button24.Size = new Size(75, 43);
            button24.TabIndex = 25;
            button24.Text = "Sec";
            button24.UseVisualStyleBackColor = true;
            button24.Click += Trigonomatric_function;
            // 
            // Form1
            // 
            AccessibleRole = AccessibleRole.Sound;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(434, 301);
            Controls.Add(button24);
            Controls.Add(button23);
            Controls.Add(button22);
            Controls.Add(button21);
            Controls.Add(button20);
            Controls.Add(button19);
            Controls.Add(button18);
            Controls.Add(button15);
            Controls.Add(button16);
            Controls.Add(button17);
            Controls.Add(button12);
            Controls.Add(button13);
            Controls.Add(button14);
            Controls.Add(button10);
            Controls.Add(button11);
            Controls.Add(button6);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(Display);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            ForeColor = Color.Black;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private TextBox Display;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
        private Button button20;
        private Button button21;
        private Button button22;
        private Button button23;
        private Button button24;
    }
}