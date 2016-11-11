using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Linq;

/*
TODO:
    - Make the program able to handle serveral set times, not just one. 
*/

namespace Notification_Program
{
    public partial class Form1 : Form
    {
        //Set paths to the required programs
        public static string CurrentDir = Environment.CurrentDirectory;
        public static readonly string TimeXmlPath = CurrentDir + @"\Time.xml";
        public static readonly string ServiceTestPath = CurrentDir + @"\Service Test.exe";

        public Form1()
        {
            ValidatePaths(); //Make sure that the required files are in the CurrentDirectory before any components are loaded

            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom; //Custom formating of the DateTimePicker
            dateTimePicker1.CustomFormat = "dd-MM-yyyy"; //Set format to days/months/year

            ExitButton.FlatAppearance.BorderColor = Color.Black; //Makes the exit button border Black

            if (File.Exists(TimeXmlPath)) //Make sure Time.xml exists
            {
                if (!Program.xmlhandler.XmlIsEmpty(TimeXmlPath)) //Checks if there is something in Time.xml
                {
                    DateTime CurrentTime = DateTime.Now; //get current time

                    DateTime EndTime = Program.xmlhandler.GetXML(TimeXmlPath); //Get the set time from Time.xml

                    if (CurrentTime < EndTime) //If the current time has not yet passed the set time
                    {
                        AddToListView(EndTime.ToString()); //add set time to listView
                    }
                }
            }
            else
            {
                Program.xmlhandler.CreateTimeXml(TimeXmlPath); //If Time.xml doesnt't exist, then make it
            }
        }

        public void ValidatePaths()
        {
            if (!File.Exists(TimeXmlPath)) //Make sure Time.xml exists
            {
                Program.xmlhandler.CreateTimeXml(TimeXmlPath); //If Time.xml doesnt't exist, then make it
            }

            else if (!File.Exists(ServiceTestPath)) //Check if Service Test.exe exists
            {
                //Create a MessageBox to display an error
                DialogResult dialog = MessageBox.Show("The file: Service Test.exe, was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialog == DialogResult.OK)
                {
                    Environment.Exit(0); //Close program
                }
            }

        }

        private void SetTimeButton_Click(object sender, EventArgs e)
        {
            if (!IsBoxEmpty()) //Make shure there is no empty textboxes 
            {
                String[] dateString = { dateTimePicker1.Text, HourTextBox.Text, MinutesTextBox.Text, SecondsTextBox.Text, MessageTextBox.Text }; //Put the content of the textboxes into a String array

                if(File.Exists(TimeXmlPath)) //Make sure Time.xml exists
                {
                    Program.xmlhandler.WriteToXML(dateString, TimeXmlPath); //Make changes to Time.xml
                }
                else
                {
                    Program.xmlhandler.CreateTimeXml(TimeXmlPath); //If Time.xml doesnt't exist, then make it
                }

                if(File.Exists(ServiceTestPath)) //Make sure Service Test.exe exists
                {
                    Process.Start(ServiceTestPath); //Start the Service application
                }
                else
                {
                    //Create a MessageBox to display an error
                    DialogResult dialog = MessageBox.Show("The file: Service Test.exe, was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dialog == DialogResult.OK)
                    {
                        Environment.Exit(0); //Close program
                    }
                }

                Clear(); //Clear Text Boxses

                AddToListView(string.Join(" ", dateString)); //Add the set date to listView
            }
        }

       
        public void AddToListView(String item)
        {
            listView1.Items.Add(item); //Add a date to the listview
        }

        public bool IsBoxEmpty()
        {
            //Check for epmty textboxes
            if(HourTextBox.Text.Equals("") || MinutesTextBox.Text.Equals("") || SecondsTextBox.Text.Equals(""))
            {
                if (HourTextBox.Text.Equals("") && MinutesTextBox.Text.Equals("") && SecondsTextBox.Text.Equals(""))
                {
                    MessageBox.Show("All the text boxes are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (HourTextBox.Text.Equals("") && MinutesTextBox.Text.Equals(""))
                {
                    MessageBox.Show("The Hours and Mintues text boxs are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(HourTextBox.Text.Equals("") && SecondsTextBox.Text.Equals(""))
                {
                    MessageBox.Show("The Hours and Seconds text boxs are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(MinutesTextBox.Text.Equals("") && SecondsTextBox.Text.Equals(""))
                {
                    MessageBox.Show("The Minutes and Seconds text boxs are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(HourTextBox.Text.Equals(""))
                {
                    MessageBox.Show("The Hours text box is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
                else if (MinutesTextBox.Text.Equals(""))
                {
                    MessageBox.Show("The Minutes text box is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(SecondsTextBox.Text.Equals(""))
                {
                    MessageBox.Show("The Seconds text box is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return true; //There is one or several empty boxes
            }

            return false; //There are no empty box(es)
        }

        //Clear all the text boxes when called
        public void Clear()
        {
            HourTextBox.Text = String.Empty;
            MinutesTextBox.Text = String.Empty;
            SecondsTextBox.Text = String.Empty;
            MessageTextBox.Text = String.Empty;
        }

        #region HourMinuteSecondPickers

        public static string OldValue1 = string.Empty, OldValue2 = string.Empty, OldValue3 = string.Empty;

        //Hours
        private void HourTextBox_TextChanged(object sender, EventArgs e)
        {
            if (HourTextBox.Text.Any(x => char.IsLetter(x)))
            {
                HourTextBox.Text = OldValue1;
            }

            try
            {
                if (Convert.ToInt32(HourTextBox.Text) > 24) //Make sure textBox1.Text is not more than 24
                {
                    HourTextBox.Text = "24"; //If it is more than 24 then we make it 24
                }
            }
            catch { }

            OldValue1 = HourTextBox.Text;
        }

        //Minutes
        private void MinutesTextBox_TextChanged(object sender, EventArgs e)
        {
            if (MinutesTextBox.Text.Any(x => char.IsLetter(x)))
            {
                MinutesTextBox.Text = OldValue2;
            }

            try
            {
                if (Convert.ToInt32(MinutesTextBox.Text) > 59) //Make sure textBox2.Text is not more than 59
                {
                    MinutesTextBox.Text = "59"; //If it is more than 59 then we make it 59
                }
            }
            catch { }

            OldValue2 = MinutesTextBox.Text;
        }

        //Seconds
        private void SecondsTextBox_TextChanged(object sender, EventArgs e)
        {

            if(SecondsTextBox.Text.Any(x => char.IsLetter(x)))
            {
                SecondsTextBox.Text = OldValue3;
            }

            try
            {
                if (Convert.ToInt32(SecondsTextBox.Text) > 59) //Make sure textBox3.Text is not more than 59
                {
                    SecondsTextBox.Text = "59"; //If it is more than 59 then we make it 59
                }
            }
            catch { }

            OldValue3 = SecondsTextBox.Text;
        }
        #endregion

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        //Makes the form draggable
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.White, ButtonBorderStyle.Solid); //Draw border on Form1

            //Draw white line on Form1
            Pen pen = new Pen(Color.White);
            e.Graphics.DrawLine(pen, Width, 43, 1 , 43);
        }
        
        //
        //A bunch of color changes according to certain mouse events
        //
        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.BackColor = Color.IndianRed;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.BackColor = Color.Red;
        }

        private void ExitButton_MouseDown(object sender, MouseEventArgs e)
        {
            ExitButton.BackColor = Color.Silver;
        }

        private void SetTimeButton_MouseEnter(object sender, EventArgs e)
        {
            SetTimeButton.BackColor = Color.DarkSeaGreen;
        }

        private void SetTimeButton_MouseLeave(object sender, EventArgs e)
        {
            SetTimeButton.BackColor = Color.LightGreen;
        }

        private void SetTimeButton_MouseDown(object sender, MouseEventArgs e)
        {
            SetTimeButton.BackColor = Color.Silver;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MinimizeButton_MouseEnter(object sender, EventArgs e)
        {
            MinimizeButton.BackColor = Color.LightGray;
        }

        private void MinimizeButton_MouseLeave(object sender, EventArgs e)
        {
            MinimizeButton.BackColor = Color.WhiteSmoke;
        }

        private void MinimizeButton_MouseDown(object sender, MouseEventArgs e)
        {
            MinimizeButton.BackColor = Color.Gray;
        }
    }
}
