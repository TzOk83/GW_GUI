namespace GW_GUI
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
            this.btnRead = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pnlSetup = new System.Windows.Forms.Panel();
            this.pnlPresets = new System.Windows.Forms.Panel();
            this.rbSS82 = new System.Windows.Forms.RadioButton();
            this.rbDS82 = new System.Windows.Forms.RadioButton();
            this.rbSS80 = new System.Windows.Forms.RadioButton();
            this.rbDS80 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDiskConfig = new System.Windows.Forms.Panel();
            this.rbDouble = new System.Windows.Forms.RadioButton();
            this.rbSingle = new System.Windows.Forms.RadioButton();
            this.numEnd = new System.Windows.Forms.NumericUpDown();
            this.numStart = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnErase = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnInfo = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.pnlSetup.SuspendLayout();
            this.pnlPresets.SuspendLayout();
            this.pnlDiskConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRead.Location = new System.Drawing.Point(12, 202);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(130, 40);
            this.btnRead.TabIndex = 1;
            this.btnRead.Text = "&Read Disk";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(12, 248);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(379, 165);
            this.tbLog.TabIndex = 2;
            this.tbLog.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 184);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(811, 22);
            this.statusStrip1.TabIndex = 6;
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(42, 17);
            this.tsslStatus.Text = "Ready.";
            // 
            // btnWrite
            // 
            this.btnWrite.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWrite.Location = new System.Drawing.Point(148, 202);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(130, 40);
            this.btnWrite.TabIndex = 7;
            this.btnWrite.Text = "&Write Disk";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnQuit.Location = new System.Drawing.Point(666, 202);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(130, 40);
            this.btnQuit.TabIndex = 8;
            this.btnQuit.Text = "&Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "scp";
            this.saveFileDialog1.Filter = "SCP Images|*.scp|IPF Images|*.ipf|HFE Images|*.hfe|All files|*.*";
            this.saveFileDialog1.Title = "Save Disk Image As...";
            // 
            // pnlSetup
            // 
            this.pnlSetup.Controls.Add(this.pnlPresets);
            this.pnlSetup.Controls.Add(this.pnlDiskConfig);
            this.pnlSetup.Location = new System.Drawing.Point(397, 248);
            this.pnlSetup.Name = "pnlSetup";
            this.pnlSetup.Size = new System.Drawing.Size(399, 165);
            this.pnlSetup.TabIndex = 9;
            // 
            // pnlPresets
            // 
            this.pnlPresets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPresets.Controls.Add(this.rbSS82);
            this.pnlPresets.Controls.Add(this.rbDS82);
            this.pnlPresets.Controls.Add(this.rbSS80);
            this.pnlPresets.Controls.Add(this.rbDS80);
            this.pnlPresets.Controls.Add(this.label2);
            this.pnlPresets.Location = new System.Drawing.Point(261, 3);
            this.pnlPresets.Name = "pnlPresets";
            this.pnlPresets.Size = new System.Drawing.Size(135, 159);
            this.pnlPresets.TabIndex = 1;
            // 
            // rbSS82
            // 
            this.rbSS82.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbSS82.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbSS82.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbSS82.Location = new System.Drawing.Point(16, 120);
            this.rbSS82.Name = "rbSS82";
            this.rbSS82.Size = new System.Drawing.Size(100, 23);
            this.rbSS82.TabIndex = 4;
            this.rbSS82.TabStop = true;
            this.rbSS82.Text = "> SS | 82";
            this.rbSS82.UseVisualStyleBackColor = true;
            this.rbSS82.CheckedChanged += new System.EventHandler(this.rbSS82_CheckedChanged);
            // 
            // rbDS82
            // 
            this.rbDS82.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDS82.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbDS82.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbDS82.Location = new System.Drawing.Point(16, 91);
            this.rbDS82.Name = "rbDS82";
            this.rbDS82.Size = new System.Drawing.Size(100, 23);
            this.rbDS82.TabIndex = 3;
            this.rbDS82.TabStop = true;
            this.rbDS82.Text = "> DS | 82";
            this.rbDS82.UseVisualStyleBackColor = true;
            this.rbDS82.CheckedChanged += new System.EventHandler(this.rbDS82_CheckedChanged);
            // 
            // rbSS80
            // 
            this.rbSS80.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbSS80.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbSS80.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbSS80.Location = new System.Drawing.Point(16, 62);
            this.rbSS80.Name = "rbSS80";
            this.rbSS80.Size = new System.Drawing.Size(100, 23);
            this.rbSS80.TabIndex = 2;
            this.rbSS80.TabStop = true;
            this.rbSS80.Text = "> SS | 80";
            this.rbSS80.UseVisualStyleBackColor = true;
            this.rbSS80.CheckedChanged += new System.EventHandler(this.rbSS80_CheckedChanged);
            // 
            // rbDS80
            // 
            this.rbDS80.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDS80.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbDS80.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbDS80.Location = new System.Drawing.Point(16, 33);
            this.rbDS80.Name = "rbDS80";
            this.rbDS80.Size = new System.Drawing.Size(100, 23);
            this.rbDS80.TabIndex = 1;
            this.rbDS80.TabStop = true;
            this.rbDS80.Text = "> DS | 80";
            this.rbDS80.UseVisualStyleBackColor = true;
            this.rbDS80.CheckedChanged += new System.EventHandler(this.rbDS80_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Presets";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDiskConfig
            // 
            this.pnlDiskConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDiskConfig.Controls.Add(this.rbDouble);
            this.pnlDiskConfig.Controls.Add(this.rbSingle);
            this.pnlDiskConfig.Controls.Add(this.numEnd);
            this.pnlDiskConfig.Controls.Add(this.numStart);
            this.pnlDiskConfig.Controls.Add(this.label5);
            this.pnlDiskConfig.Controls.Add(this.label4);
            this.pnlDiskConfig.Controls.Add(this.label3);
            this.pnlDiskConfig.Controls.Add(this.label1);
            this.pnlDiskConfig.Location = new System.Drawing.Point(3, 3);
            this.pnlDiskConfig.Name = "pnlDiskConfig";
            this.pnlDiskConfig.Size = new System.Drawing.Size(252, 159);
            this.pnlDiskConfig.TabIndex = 0;
            // 
            // rbDouble
            // 
            this.rbDouble.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDouble.Checked = true;
            this.rbDouble.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlText;
            this.rbDouble.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbDouble.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbDouble.ForeColor = System.Drawing.SystemColors.Control;
            this.rbDouble.Location = new System.Drawing.Point(170, 35);
            this.rbDouble.Name = "rbDouble";
            this.rbDouble.Size = new System.Drawing.Size(50, 23);
            this.rbDouble.TabIndex = 9;
            this.rbDouble.TabStop = true;
            this.rbDouble.Text = "2";
            this.rbDouble.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbDouble.UseVisualStyleBackColor = true;
            this.rbDouble.CheckedChanged += new System.EventHandler(this.btnDouble_CheckedChanged);
            // 
            // rbSingle
            // 
            this.rbSingle.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbSingle.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlText;
            this.rbSingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbSingle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbSingle.Location = new System.Drawing.Point(110, 35);
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.Size = new System.Drawing.Size(50, 23);
            this.rbSingle.TabIndex = 8;
            this.rbSingle.Text = "1";
            this.rbSingle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbSingle.UseVisualStyleBackColor = true;
            this.rbSingle.CheckedChanged += new System.EventHandler(this.rbSingle_CheckedChanged);
            // 
            // numEnd
            // 
            this.numEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEnd.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numEnd.Location = new System.Drawing.Point(110, 85);
            this.numEnd.Name = "numEnd";
            this.numEnd.Size = new System.Drawing.Size(110, 23);
            this.numEnd.TabIndex = 7;
            this.numEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numEnd.Value = new decimal(new int[] {
            79,
            0,
            0,
            0});
            // 
            // numStart
            // 
            this.numStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numStart.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numStart.Location = new System.Drawing.Point(110, 60);
            this.numStart.Name = "numStart";
            this.numStart.Size = new System.Drawing.Size(110, 23);
            this.numStart.TabIndex = 6;
            this.numStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(4, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "End at";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(4, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Start at";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(4, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Sides";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disk Configuration";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnErase
            // 
            this.btnErase.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnErase.Location = new System.Drawing.Point(284, 202);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(130, 40);
            this.btnErase.TabIndex = 10;
            this.btnErase.Text = "&Erase Disk";
            this.btnErase.UseVisualStyleBackColor = true;
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "scp";
            this.openFileDialog1.Filter = "SCP Images|*.scp|IPF Images|*.ipf|HFE Images|*.hfe|All files|*.*";
            this.openFileDialog1.Title = "Open Disk Image...";
            // 
            // btnInfo
            // 
            this.btnInfo.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnInfo.Location = new System.Drawing.Point(530, 202);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(130, 40);
            this.btnInfo.TabIndex = 11;
            this.btnInfo.Text = "&HW Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnRead;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 450);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnErase);
            this.Controls.Add(this.pnlSetup);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnRead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Greaseweazle GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlSetup.ResumeLayout(false);
            this.pnlPresets.ResumeLayout(false);
            this.pnlDiskConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel pnlSetup;
        private System.Windows.Forms.Panel pnlPresets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlDiskConfig;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbDouble;
        private System.Windows.Forms.RadioButton rbSingle;
        private System.Windows.Forms.NumericUpDown numEnd;
        private System.Windows.Forms.NumericUpDown numStart;
        private System.Windows.Forms.RadioButton rbSS82;
        private System.Windows.Forms.RadioButton rbDS82;
        private System.Windows.Forms.RadioButton rbSS80;
        private System.Windows.Forms.RadioButton rbDS80;
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnInfo;
    }
}

