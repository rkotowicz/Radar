namespace RadarApp
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.graphicsPanel1 = new System.Windows.Forms.Panel();
            this.txbRadarLog = new System.Windows.Forms.TextBox();
            this.btnRunPause = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // graphicsPanel1
            // 
            this.graphicsPanel1.BackColor = System.Drawing.Color.Black;
            this.graphicsPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.graphicsPanel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.graphicsPanel1.ForeColor = System.Drawing.Color.White;
            this.graphicsPanel1.Location = new System.Drawing.Point(0, 0);
            this.graphicsPanel1.Name = "graphicsPanel1";
            this.graphicsPanel1.Size = new System.Drawing.Size(1125, 700);
            this.graphicsPanel1.TabIndex = 0;
            // 
            // txbRadarLog
            // 
            this.txbRadarLog.CausesValidation = false;
            this.txbRadarLog.Location = new System.Drawing.Point(1131, 44);
            this.txbRadarLog.Multiline = true;
            this.txbRadarLog.Name = "txbRadarLog";
            this.txbRadarLog.ReadOnly = true;
            this.txbRadarLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbRadarLog.Size = new System.Drawing.Size(284, 656);
            this.txbRadarLog.TabIndex = 1;
            // 
            // btnRunPause
            // 
            this.btnRunPause.CausesValidation = false;
            this.btnRunPause.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRunPause.Location = new System.Drawing.Point(1131, 0);
            this.btnRunPause.Name = "btnRunPause";
            this.btnRunPause.Size = new System.Drawing.Size(284, 38);
            this.btnRunPause.TabIndex = 0;
            this.btnRunPause.Text = "&PAUSE";
            this.btnRunPause.UseVisualStyleBackColor = true;
            this.btnRunPause.Click += new System.EventHandler(this.btnRunPause_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 700);
            this.Controls.Add(this.btnRunPause);
            this.Controls.Add(this.txbRadarLog);
            this.Controls.Add(this.graphicsPanel1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Panel graphicsPanel1;
        public TextBox txbRadarLog;
        public Button btnRunPause;
    }
}