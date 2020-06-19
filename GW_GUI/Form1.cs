using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GW_GUI
{
    public partial class Form1 : Form
    {
        bool cleanExit = true;

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }

        public void DrawGrid()
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black, 1);
            Font f = new Font(FontFamily.GenericMonospace, 8);
            SolidBrush b = new SolidBrush(Color.Black);
            StringFormat df = new StringFormat();
            int numOfCells = 87;
            int cellHeight = 80;
            int cellWidth = 9;
            int rowCount = 2;
            for (int i = 0; i <= numOfCells; i++)
            {
                // Vertical
                g.DrawLine(p, i * cellWidth, 0, i * cellWidth, rowCount * cellHeight);
                // Text
                g.DrawString((i / 10).ToString(), f, b, i * cellWidth, 162, df);
                g.DrawString((i % 10).ToString(), f, b, i * cellWidth, 172, df);
            }
            // Horizontal
            g.DrawLine(p, 0, 0, numOfCells * cellWidth, 0);
            g.DrawLine(p, 0, cellHeight, numOfCells * cellWidth, cellHeight);
            g.DrawLine(p, 0, rowCount * cellHeight, numOfCells * cellWidth, rowCount * cellHeight);
        }

        public void DrawSector(byte track, byte side, byte mode)
        {
            Graphics g = panel1.CreateGraphics();
            SolidBrush b;
            switch (mode)
            {
                case 1:
                    b = new SolidBrush(Color.Gray);
                    break;
                case 2:
                    b = new SolidBrush(Color.Black);
                    break;
                case 3:
                    b = new SolidBrush(Color.Red);
                    break;
                default:
                    b = new SolidBrush(Color.White);
                    break;
            }
            int cellHeight = 80;
            int cellWidth = 9;

            Rectangle rect = new Rectangle(2 + (track * cellWidth), 2 + (side * cellHeight), 6, 77);
            g.FillRectangle(b, rect);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid();
        }

        public void RunCmdAsync(string cmd, string args)
        {
            //* Create your Process
            Process process = new Process();
            process.StartInfo.FileName = @"python.exe";
            process.StartInfo.Arguments = string.Format("-u \"{0}\" {1}", cmd, args);
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = false;
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            //process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.Exited += new EventHandler(ProcessExited);
            process.StartInfo.RedirectStandardInput = true;
            process.EnableRaisingEvents = true;
            process.Start();
            //string err = process.StandardError.ReadToEnd();
            process.BeginOutputReadLine();
            //process.BeginErrorReadLine();
        }

        public string RunCmdSync(string cmd, string args)
        {
            string result;
            //* Create your Process
            Process process = new Process();
            process.StartInfo.FileName = @"python.exe";
            process.StartInfo.Arguments = string.Format("-u \"{0}\" {1}", cmd, args);
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = false;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
            result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            //string err = process.StandardError.ReadToEnd();
            //process.BeginOutputReadLine();
            //process.BeginErrorReadLine();
            return result;
        }

        internal void ProcessExited(object sender, System.EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                EnableControls(true);
            });
            
            if (cleanExit) tsslStatus.Text = "Done.";
        }

        void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            byte track = 0, side = 0;
            string tracks, sides, errors;
            string output = Convert.ToString(outLine.Data);
            if (output != null && (output.Contains("Reading Track") || output.Contains("Writing Track") || output.Contains("Erasing Track")))
            {
                tracks = output.Substring(14, output.IndexOf('.') - 14);
                sides = output.Substring(output.IndexOf('.') + 1, 1);
                byte.TryParse(tracks, out track);
                byte.TryParse(sides, out side);
                tsslStatus.Text = output;
                DrawSector(track, side, 1);
            }
            if (output != null && output.Contains("Command Failed"))
            {
                errors = output.Substring(output.IndexOf("Command Failed"));
                tsslStatus.Text = errors;
                cleanExit = false;
                DrawSector(track, side, 3);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("gw"))
            {
                string output = RunCmdSync("gw", "reset");

                if (output != null && output.Contains("** Greaseweazle"))
                {
                    string hw = output.Substring(output.IndexOf("** ") + 3, output.IndexOf(',') - 3);
                    string sw = output.Substring(output.IndexOf(",") + 2);
                    this.Text += " | " + hw + " | " + sw;
                }
                else
                {
                    string error = output.Substring(0, output.IndexOf(':'));
                    string descr = output.Substring(output.IndexOf(':') + 3);
                    DialogResult dialog = MessageBox.Show(descr, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dialog == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                }
            }
            else
            {
                DialogResult dialog = MessageBox.Show("File 'gw' does not exist in the current path.", "File not found...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialog == DialogResult.OK)
                {
                    Application.Exit();
                }
            }

        }

        private void EnableControls(bool status)
        {
            btnRead.Enabled = status;
            btnWrite.Enabled = status;
            btnErase.Enabled = status;
            pnlSetup.Enabled = status;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            panel1.Refresh();
            DrawGrid();
            string strImageName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strImageName = saveFileDialog1.FileName;
                tsslStatus.Text = "Reading...";
                cleanExit = true;
                RunCmdAsync("gw", "read --scyl " + numStart.Value.ToString() + " --ecyl " + numEnd.Value.ToString() + (rbSingle.Checked ? " --single-sided" : "") + " \"" + strImageName + "\"");
            }
            else
            {
                EnableControls(true);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            panel1.Refresh();
            DrawGrid();
            string strImageName;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Are you sure do you want to OVERWRITE content of the floppy disk?", "Write Disk", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    strImageName = openFileDialog1.FileName;
                    tsslStatus.Text = "Writing...";
                    cleanExit = true;
                    RunCmdAsync("gw", "write --scyl " + numStart.Value.ToString() + " --ecyl " + numEnd.Value.ToString() + (rbSingle.Checked ? " --single-sided" : "") + " \"" + strImageName + "\"");
                }
                else
                {
                    EnableControls(true);
                }
            }
            else
            {
                EnableControls(true);
            }
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            panel1.Refresh();
            DrawGrid();
            if (MessageBox.Show("Are you sure do you want to ERASE content of the floppy disk?", "Erase Disk", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tsslStatus.Text = "Erasing...";
                cleanExit = true;
                RunCmdAsync("gw", "erase --scyl " + numStart.Value.ToString() + " --ecyl " + numEnd.Value.ToString() + (rbSingle.Checked ? " --single-sided" : ""));
            }
            else
            {
                EnableControls(true);
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            string info = RunCmdSync("gw", "info");
            MessageBox.Show(info, "HW Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rbSingle_CheckedChanged(object sender, EventArgs e)
        {
            rbSingle.ForeColor = System.Drawing.SystemColors.Control;
            rbDouble.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void btnDouble_CheckedChanged(object sender, EventArgs e)
        {
            rbDouble.ForeColor = System.Drawing.SystemColors.Control;
            rbSingle.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void rbDS80_CheckedChanged(object sender, EventArgs e)
        {
            rbDouble.Checked = true;
            numStart.Value = 0;
            numEnd.Value = 79;
        }

        private void rbSS80_CheckedChanged(object sender, EventArgs e)
        {
            rbSingle.Checked = true;
            numStart.Value = 0;
            numEnd.Value = 79;
        }

        private void rbDS82_CheckedChanged(object sender, EventArgs e)
        {
            rbDouble.Checked = true;
            numStart.Value = 0;
            numEnd.Value = 81;
        }

        private void rbSS82_CheckedChanged(object sender, EventArgs e)
        {
            rbSingle.Checked = true;
            numStart.Value = 0;
            numEnd.Value = 81;
        }
    }
}
