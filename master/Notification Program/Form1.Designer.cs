namespace Notification_Program
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SetTimeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SecondsTextBox = new System.Windows.Forms.TextBox();
            this.MinutesTextBox = new System.Windows.Forms.TextBox();
            this.HourTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MessageTextBox = new System.Windows.Forms.RichTextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.Black;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(291, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // SetTimeButton
            // 
            this.SetTimeButton.BackColor = System.Drawing.Color.LightGreen;
            this.SetTimeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetTimeButton.ForeColor = System.Drawing.Color.Black;
            this.SetTimeButton.Location = new System.Drawing.Point(12, 395);
            this.SetTimeButton.Name = "SetTimeButton";
            this.SetTimeButton.Size = new System.Drawing.Size(303, 23);
            this.SetTimeButton.TabIndex = 5;
            this.SetTimeButton.Text = "Set time";
            this.SetTimeButton.UseVisualStyleBackColor = false;
            this.SetTimeButton.Click += new System.EventHandler(this.SetTimeButton_Click);
            this.SetTimeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetTimeButton_MouseDown);
            this.SetTimeButton.MouseEnter += new System.EventHandler(this.SetTimeButton_MouseEnter);
            this.SetTimeButton.MouseLeave += new System.EventHandler(this.SetTimeButton_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SecondsTextBox);
            this.groupBox1.Controls.Add(this.MinutesTextBox);
            this.groupBox1.Controls.Add(this.HourTextBox);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 120);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pick a time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "         Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "       Seconds";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(105, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "        Minutes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "         Hours";
            // 
            // SecondsTextBox
            // 
            this.SecondsTextBox.BackColor = System.Drawing.Color.White;
            this.SecondsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SecondsTextBox.Location = new System.Drawing.Point(204, 87);
            this.SecondsTextBox.MaxLength = 2;
            this.SecondsTextBox.Name = "SecondsTextBox";
            this.SecondsTextBox.Size = new System.Drawing.Size(93, 20);
            this.SecondsTextBox.TabIndex = 3;
            this.SecondsTextBox.TextChanged += new System.EventHandler(this.SecondsTextBox_TextChanged);
            // 
            // MinutesTextBox
            // 
            this.MinutesTextBox.BackColor = System.Drawing.Color.White;
            this.MinutesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MinutesTextBox.Location = new System.Drawing.Point(105, 87);
            this.MinutesTextBox.MaxLength = 2;
            this.MinutesTextBox.Name = "MinutesTextBox";
            this.MinutesTextBox.Size = new System.Drawing.Size(93, 20);
            this.MinutesTextBox.TabIndex = 1;
            this.MinutesTextBox.TextChanged += new System.EventHandler(this.MinutesTextBox_TextChanged);
            // 
            // HourTextBox
            // 
            this.HourTextBox.BackColor = System.Drawing.Color.White;
            this.HourTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HourTextBox.Location = new System.Drawing.Point(6, 87);
            this.HourTextBox.MaxLength = 2;
            this.HourTextBox.Name = "HourTextBox";
            this.HourTextBox.Size = new System.Drawing.Size(93, 20);
            this.HourTextBox.TabIndex = 0;
            this.HourTextBox.TextChanged += new System.EventHandler(this.HourTextBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.MessageTextBox);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 207);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message";
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.BackColor = System.Drawing.Color.White;
            this.MessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessageTextBox.Location = new System.Drawing.Point(6, 19);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(291, 182);
            this.MessageTextBox.TabIndex = 4;
            this.MessageTextBox.Text = "";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Location = new System.Drawing.Point(327, 55);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(182, 363);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Red;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(459, 11);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(50, 23);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ExitButton_MouseDown);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Notification Program";
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeButton.ForeColor = System.Drawing.Color.Black;
            this.MinimizeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MinimizeButton.Location = new System.Drawing.Point(430, 11);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(23, 23);
            this.MinimizeButton.TabIndex = 9;
            this.MinimizeButton.Text = "—";
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            this.MinimizeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MinimizeButton_MouseDown);
            this.MinimizeButton.MouseEnter += new System.EventHandler(this.MinimizeButton_MouseEnter);
            this.MinimizeButton.MouseLeave += new System.EventHandler(this.MinimizeButton_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(521, 445);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SetTimeButton);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button SetTimeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SecondsTextBox;
        private System.Windows.Forms.TextBox MinutesTextBox;
        private System.Windows.Forms.TextBox HourTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.RichTextBox MessageTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button MinimizeButton;
    }
}

