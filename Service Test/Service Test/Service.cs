using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using System.Xml;
using Service_Test.Properties;
using System.Media;
using Microsoft.Win32;
using System.IO;

/*
Todo:
    
*/

namespace TimeService
{
    public partial class Service : ServiceBase
    {
        //Set paths to the required programs
        public static string CurrentDir = Environment.CurrentDirectory;
        public static readonly string TimeXmlPath = CurrentDir + @"\Time.xml";
        public static readonly string ServiceTestPath = CurrentDir + @"\Service Test.exe";
        public static readonly string NotificationBoxPath = CurrentDir + @"\NotificationBox.exe";

        public static RegistryKey rk;

        public Service()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        public void PlayWavFile()
        {
            SoundPlayer player = new SoundPlayer(Resources.Sound1); //Load Sound1 in to SoundPlayer
            player.PlaySync(); //Plays file
        }

        public bool IsXmlEmpty()
        {
            XmlDocument doc = new XmlDocument();

            if(File.Exists(TimeXmlPath)) //make sure Time.xml exists
            {
                doc.Load(TimeXmlPath); //Loads the Time.xml file into doc
            }
            else
            {
                throw new Exception("The file " + "Time.xml" + " was not found");
            }

            if (doc.SelectSingleNode("Main/Date").InnerText.Equals("")) //If time.xml is empty then return true
            {
                return true;
            }

            return false; //If time.xml is not empty then return false
        }

        protected override void OnStart(string[] args)
        {
            rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true); //Make a regestry key

            if (!IsXmlEmpty()) //If Time.xml is not empty, which means there is a set time
            {
                rk.SetValue("MyService", ServiceTestPath); //Add MyService to the Registry so that Service test.exe starts on login

                XmlDocument doc = new XmlDocument();

                doc.Load(TimeXmlPath); //Loads the Time.xml file into doc

                String Times = doc.SelectSingleNode("Main/Date").InnerText; //Puts the times in to an array

                DateTime EndTime = Convert.ToDateTime(Times); //Put the set time into an DateTime variable

                //Make a timer that takes the set time and current time, and finds the remaining time in milliseconds
                double time = (EndTime - DateTime.Now).TotalMilliseconds;
                System.Timers.Timer timer = new System.Timers.Timer(time > 0 ? time : 1);
                timer.Elapsed += Timer_Done;
                timer.Enabled = true;
                timer.AutoReset = false;
                
            }

            else if(IsXmlEmpty()) //If there is no set time, then we delete the service regestry key and close the program
            {
                rk.DeleteValue("MyService", false); //Delete MyService from the registry so that Server Test.exe doesn't start on login
                 
                Environment.Exit(0); //Close program
            }
        }

        //This method is called when the tier is done
        private void Timer_Done(object sender, System.Timers.ElapsedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(TimeXmlPath); //Loads the Time.xml file into doc

            Process.Start(NotificationBoxPath);

            PlayWavFile(); //Play sound

            rk.DeleteValue("MyService", false); //Delete regestry key

            Environment.Exit(0); //Close program
        }

        protected override void OnStop()
        {
            //Nothing happens
        }
    }
}