using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace DrillV1
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            metroComboBox1.Items.Add("RUST #1");
            metroComboBox1.Items.Add("RUST #2");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == -1)
            {
                MetroFramework.MetroMessageBox.Show(this, "You must select a cheat to inject!", "", MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
            }

            if (metroComboBox1.SelectedIndex == 0)
            {
                string path = Settings.Pathy;
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                }
                WebClient wb = new WebClient();
                wb.Headers.Add("User-Agent", Settings.UserAgentString);
                wb.DownloadFile(Settings.RUST1, Settings.Save);

                var Form3 = new Form3();
                Form3.Closed += (s, args) => this.Close();
                this.Hide();
                Form3.Show();
            }

            if (metroComboBox1.SelectedIndex == 1)
            {
                string path = Settings.Pathy;
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                }
                WebClient wb = new WebClient();
                wb.Headers.Add("User-Agent", Settings.UserAgentString);
                wb.DownloadFile(Settings.RUST2, Settings.Save);

                var Form3 = new Form3();
                Form3.Closed += (s, args) => this.Close();
                this.Hide();
                Form3.Show();
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 0)
            {
                Process[] pname = Process.GetProcessesByName("rust");
                if (pname.Length == 0)
                    MetroFramework.MetroMessageBox.Show(this, "RUST Game Process Not Running", "", MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
            }

            if (metroComboBox1.SelectedIndex == 1)
            {
                Process[] pname = Process.GetProcessesByName("rust");
                if (pname.Length == 0)
                    MetroFramework.MetroMessageBox.Show(this, "RUST Game Process Not Running", "", MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
            }
        }
    }
}
