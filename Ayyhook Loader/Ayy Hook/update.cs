// uses the the System namespace
using System;
// uses the System.Windows.Forms namespace
using System.Windows.Forms;
// uses the System.Net namespace
using System.Net;
// uses the System.Threading namespace
using System.Threading;

namespace DrillV1
{
    public partial class update : MetroFramework.Forms.MetroForm
    {
        public update()
        {
            InitializeComponent();
        }

        string versioncheck = new WebClient().DownloadString(Settings.Check);
        string location = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

        private void update_Load(object sender, EventArgs e)
        {
            metroLabel1.Text = "Loading.";
            Thread.Sleep(100);
            metroLabel1.Text = "Loading..";
            Thread.Sleep(100);
            metroLabel1.Text = "Loading...";
            Thread.Sleep(100);
            metroLabel1.Text = "Loading.";
            Thread.Sleep(100);
            metroLabel1.Text = "Loading..";
            Thread.Sleep(100);
            metroLabel1.Text = "Loading...";
            Thread.Sleep(100);
            metroLabel1.Text = "Checking for update";

            if (versioncheck != Settings.version.ToString())
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            metroLabel1.Text = "Update found!";
            Thread.Sleep(100);
            metroLabel1.Text = "Downloading";
            WebClient webClient = new WebClient();
            webClient.DownloadFile(Settings.Update, location);
            metroLabel1.Text = "Done!";
            Application.Exit();
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            metroLabel1.Text = "No update found :)";
            Thread.Sleep(1000);
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
            this.Hide();
            timer2.Stop();
        }
    }
}
