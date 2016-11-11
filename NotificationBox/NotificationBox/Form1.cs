using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NotificationBox
{
    public partial class Form1 : Form
    {
        //These do a lot of stuff a have absolutely no idea what is
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        //Set path to the required program
        public static readonly string TimeXmlPath = Environment.CurrentDirectory + @"\Time.xml";

        public Form1()
        {
            ValidatePath(); //Make sure that the required file IS in the CurrentDirectory before any components are loaded

            InitializeComponent();

            button1.FlatAppearance.BorderColor = Color.Black; //Makes the exit button border Black

            String[] Values = LoadXml();
            label2.Text = Values[0]; //Put the set time from Time.xml into label2
            label1.Text = Values[1]; //Put the message from Time.xml into label1

            ClearXml(); //clear Time.xml nodes

            FadeOut(); //Make Form1 fade out slowly
        }

        public void ValidatePath()
        {
            if (!File.Exists(TimeXmlPath)) //Check if Time.xml exists
            {
                //Create a MessageBox to display an error
                DialogResult dialog = MessageBox.Show("The file: Time.xml, was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialog == DialogResult.OK)
                {
                    Environment.Exit(0); //Close program
                }
            }
        }


        private async void FadeOut()
        {
            while(Opacity > 0.0) //Run while the program is visible / while the opactiy is more than 0
            {
                if (ClientRectangle.Contains(Control.MousePosition)) //Check if the mouse is inside the Form1
                {
                    Opacity = 1; //Set Form1 Opacity to 100%
                    return; //End method
                }

                await Task.Delay(40); //Delay for 40 milliseconds
                Opacity -= 0.0001; //Take 0.01% from the Opacity of Form1
            }

            Environment.Exit(0); //Close program
        }

        public String[] LoadXml()
        {
            XmlDocument doc = new XmlDocument();

            if(File.Exists(TimeXmlPath)) //Makes sure that Time.xml exists
            {
                doc.Load(TimeXmlPath); //Load Time.xml
            }
            else
            {
                //Set paths to the required programs
                DialogResult dialog = MessageBox.Show("The file: Time.xml, was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialog == DialogResult.OK)
                {
                    Environment.Exit(0); //Close program
                }
            }

            //Put the set time and message into a String array
            String[] Value =
            {
                doc.SelectSingleNode("Main/Date").InnerText,
                doc.SelectSingleNode("Main/Message").InnerText
            };

            return Value; //Return the Value array with the Date and Message from Time.xml
        }

        public void ClearXml()
        {
            XmlDocument doc = new XmlDocument();

            if(File.Exists(TimeXmlPath)) //Make sure that Time.xml exist
            {
                doc.Load(TimeXmlPath);  //Load Time.xml
            }
            else
            {
                //Set paths to the required programs
                DialogResult dialog = MessageBox.Show("The file: Time.xml, was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialog == DialogResult.OK)
                {
                    Environment.Exit(0); //Close program
                }
            }

            doc.SelectSingleNode("Main/Date").InnerText = ""; //Clear the Date node from Time.xml
            doc.SelectSingleNode("Main/Message").InnerText = ""; //Clear the Message node from Time.xml

            doc.Save(TimeXmlPath); //Save changes to Time.xml

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS); //Set this program as the topmost program, ALWAYS
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); //Close program
        }

        //Allow the form to be dragged around.
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
            e.Graphics.DrawLine(pen, 519, 43, 1, 43);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.IndianRed;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Silver;
        }
    }
}