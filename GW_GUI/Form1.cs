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
        static byte maxTrack = 87;
        static byte maxSide = 2;
        static int cellHeight = 80;
        static int cellWidth = 9;
        static char mode;

        bool cleanExit = true;
        byte[,] trackMap = new byte[maxTrack, maxSide];

        Process gwProcess;

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
            
            for (int i = 0; i <= maxTrack; i++)
            {
                // Vertical
                g.DrawLine(p, i * cellWidth, 0, i * cellWidth, maxSide * cellHeight);
                // Text
                g.DrawString((i / 10).ToString(), f, b, i * cellWidth, 162, df);
                g.DrawString((i % 10).ToString(), f, b, i * cellWidth, 172, df);
            }
            // Horizontal
            g.DrawLine(p, 0, 0, maxTrack * cellWidth, 0);
            g.DrawLine(p, 0, cellHeight, maxTrack * cellWidth, cellHeight);
            g.DrawLine(p, 0, maxSide * cellHeight, maxTrack * cellWidth, maxSide * cellHeight);
            
            // Redraw Track Map
            for (byte track = 0; track < Form1.maxTrack; track++)
                for (byte side = 0; side < Form1.maxSide; side++)
                {
                    DrawSector(track, side, trackMap[track, side]);
                }
        }

        public void DrawSector(byte track, byte side, byte mode, bool updateMap = false)
        {
            Graphics g = panel1.CreateGraphics();
            SolidBrush b;

            if (updateMap) trackMap[track, side] = mode;

            switch (mode)
            {
                case 1: // Read OK
                    b = new SolidBrush(Color.Gray);
                    break;
                case 2: // Write OK
                    b = new SolidBrush(Color.Black);
                    break;
                case 3: // Error
                    b = new SolidBrush(Color.Red);
                    break;
                default: // Empty
                    b = new SolidBrush(Color.White);
                    break;
            }
            
            Rectangle rect = new Rectangle(2 + (track * cellWidth), 2 + (side * cellHeight), 6, 77);
            g.FillRectangle(b, rect);
        }

        public void ClearGrid()
        {
            for (byte sector=0; sector<maxTrack; sector++)
                for (byte side=0; side<maxSide; side++)
                {
                    trackMap[sector, side] = 0;
                }
            DrawGrid();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid();
        }

        public Process RunCmdAsync(string cmd, string args)
        {
            // Create Process
            Process process = new Process();
            process.StartInfo.FileName = @"python.exe";
            process.StartInfo.Arguments = string.Format("-u \"{0}\" {1}", cmd, args);
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = false;
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.Exited += new EventHandler(ProcessExited);
            process.StartInfo.RedirectStandardInput = true;
            process.EnableRaisingEvents = true;
            process.Start();
            process.BeginOutputReadLine();
            return process;
        }

        public string RunCmdSync(string cmd, string args)
        {
            string result;
            // Create Process
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
            string tracks, sides;
            string output = Convert.ToString(outLine.Data);
            tsslStatus.Text = output;
            if (output != null)
            {
                if (output.Contains("Reading"))
                    mode = 'R';
                else if (output.Contains("Writing"))
                    mode = 'W';
                else if (output.Contains("Erasing"))
                    mode = 'E';
                else if (output.Contains("T"))
                {
                    tsslStatus.Text = output;
                    tracks = output.Substring(1, output.IndexOf('.') - 1);
                    sides = output.Substring(output.IndexOf('.') + 1, 1);
                    byte.TryParse(tracks, out track);
                    byte.TryParse(sides, out side);
                    if (output.Contains("Command Failed"))
                    {
                        cleanExit = false;
                        DrawSector(track, side, 3, true);
                    }
                    else if (mode == 'R')
                    {
                        DrawSector(track, side, 1, true);
                    }
                    else if (mode == 'W' || mode == 'E')
                    {
                        DrawSector(track, side, 2, true);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("gw"))
            {
                string output = RunCmdSync("gw", "info");

                if (output != null && output.Contains("Greaseweazle"))
                {
                    string hw = output.Substring(output.IndexOf("Model: ") + 10, 2);
                    string sw = output.Substring(output.IndexOf("Firmware: ") + 10, 5);
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
            btnInfo.Enabled = status;
            pnlSetup.Enabled = status;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            panel1.Refresh();
            ClearGrid();
            string strImageName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strImageName = saveFileDialog1.FileName;
                tsslStatus.Text = "Reading...";
                cleanExit = true;
                gwProcess = RunCmdAsync("gw", "read --revs " + numPasses.Value.ToString() + " --scyl " + numStart.Value.ToString() + " --ecyl " + numEnd.Value.ToString() + (rbSingle.Checked ? " --single-sided" : "") + " --rate " + (rbDD.Checked ? "250" : "500")  + " \"" + strImageName + "\"");
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
            ClearGrid();
            string strImageName;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Are you sure do you want to OVERWRITE content of the floppy disk?", "Write Disk", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    strImageName = openFileDialog1.FileName;
                    tsslStatus.Text = "Writing...";
                    cleanExit = true;
                    gwProcess = RunCmdAsync("gw", "write --scyl " + numStart.Value.ToString() + " --ecyl " + numEnd.Value.ToString() + (rbSingle.Checked ? " --single-sided" : "") + " \"" + strImageName + "\"");
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
            ClearGrid();
            if (MessageBox.Show("Are you sure do you want to ERASE content of the floppy disk?", "Erase Disk", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tsslStatus.Text = "Erasing...";
                cleanExit = true;
                gwProcess = RunCmdAsync("gw", "erase --scyl " + numStart.Value.ToString() + " --ecyl " + numEnd.Value.ToString() + (rbSingle.Checked ? " --single-sided" : ""));
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
            if (gwProcess!=null)
            {
                gwProcess.Close();
            }
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

        private void rbDD_CheckedChanged(object sender, EventArgs e)
        {
            rbDD.ForeColor = System.Drawing.SystemColors.Control;
            rbHD.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void rbHD_CheckedChanged(object sender, EventArgs e)
        {
            rbHD.ForeColor = System.Drawing.SystemColors.Control;
            rbDD.ForeColor = System.Drawing.SystemColors.ControlText;
        }
    }
}
