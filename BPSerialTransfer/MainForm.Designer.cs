/*
 * Created by SharpDevelop.
 * User: Asus
 * Date: 2020. 11. 28.
 * Time: 10:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BPSerialTransfer
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox comName;
		private System.Windows.Forms.Button downloadButton;
		private System.Windows.Forms.RichTextBox consoleBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown baudRate;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label statusLED;
		private System.Windows.Forms.Label outputSign;
		private System.Windows.Forms.TextBox filePathBrowser;
		private System.Windows.Forms.Label rxLED;
		private System.Windows.Forms.Label txLED;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.FolderBrowserDialog saveFileDialog;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.label1 = new System.Windows.Forms.Label();
			this.comName = new System.Windows.Forms.TextBox();
			this.downloadButton = new System.Windows.Forms.Button();
			this.consoleBox = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.baudRate = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.statusLED = new System.Windows.Forms.Label();
			this.outputSign = new System.Windows.Forms.Label();
			this.filePathBrowser = new System.Windows.Forms.TextBox();
			this.rxLED = new System.Windows.Forms.Label();
			this.txLED = new System.Windows.Forms.Label();
			this.browseButton = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.baudRate)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 81);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(149, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "COMMUNICATION PORT:";
			// 
			// comName
			// 
			this.comName.Location = new System.Drawing.Point(146, 78);
			this.comName.Name = "comName";
			this.comName.Size = new System.Drawing.Size(152, 20);
			this.comName.TabIndex = 1;
			// 
			// downloadButton
			// 
			this.downloadButton.Location = new System.Drawing.Point(227, 163);
			this.downloadButton.Name = "downloadButton";
			this.downloadButton.Size = new System.Drawing.Size(75, 23);
			this.downloadButton.TabIndex = 2;
			this.downloadButton.Text = "Pair";
			this.downloadButton.UseVisualStyleBackColor = true;
			this.downloadButton.Click += new System.EventHandler(this.startDownload);
			// 
			// consoleBox
			// 
			this.consoleBox.BackColor = System.Drawing.SystemColors.WindowText;
			this.consoleBox.ForeColor = System.Drawing.Color.Lime;
			this.consoleBox.Location = new System.Drawing.Point(12, 192);
			this.consoleBox.Name = "consoleBox";
			this.consoleBox.Size = new System.Drawing.Size(286, 232);
			this.consoleBox.TabIndex = 3;
			this.consoleBox.Text = "";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(13, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(289, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "BPSandal";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label3.Location = new System.Drawing.Point(12, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(286, 28);
			this.label3.TabIndex = 5;
			this.label3.Text = "Serial port data transfer application for BPSandal by Levente Vendéghegyi (2020 F" +
	"rancis Studios)";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.SystemColors.Control;
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label4.Location = new System.Drawing.Point(202, 427);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Francis Studios";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(13, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "BITRATE:";
			// 
			// baudRate
			// 
			this.baudRate.Location = new System.Drawing.Point(76, 102);
			this.baudRate.Maximum = new decimal(new int[] {
			1316134911,
			2328,
			0,
			0});
			this.baudRate.Name = "baudRate";
			this.baudRate.Size = new System.Drawing.Size(176, 20);
			this.baudRate.TabIndex = 9;
			this.baudRate.Value = new decimal(new int[] {
			9600,
			0,
			0,
			0});
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label6.Location = new System.Drawing.Point(258, 99);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(57, 23);
			this.label6.TabIndex = 10;
			this.label6.Text = "BAUD";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(13, 163);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 23);
			this.label7.TabIndex = 11;
			this.label7.Text = "STATUS:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// statusLED
			// 
			this.statusLED.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.statusLED.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.statusLED.ForeColor = System.Drawing.Color.Red;
			this.statusLED.Location = new System.Drawing.Point(82, 163);
			this.statusLED.Name = "statusLED";
			this.statusLED.Size = new System.Drawing.Size(137, 23);
			this.statusLED.TabIndex = 12;
			this.statusLED.Text = "OFFLINE";
			this.statusLED.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// outputSign
			// 
			this.outputSign.Location = new System.Drawing.Point(13, 131);
			this.outputSign.Name = "outputSign";
			this.outputSign.Size = new System.Drawing.Size(100, 23);
			this.outputSign.TabIndex = 13;
			this.outputSign.Text = "OUTPUT:";
			// 
			// filePathBrowser
			// 
			this.filePathBrowser.Location = new System.Drawing.Point(76, 129);
			this.filePathBrowser.Name = "filePathBrowser";
			this.filePathBrowser.Size = new System.Drawing.Size(104, 20);
			this.filePathBrowser.TabIndex = 14;
			// 
			// rxLED
			// 
			this.rxLED.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.rxLED.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.rxLED.Location = new System.Drawing.Point(258, 133);
			this.rxLED.Name = "rxLED";
			this.rxLED.Size = new System.Drawing.Size(22, 17);
			this.rxLED.TabIndex = 15;
			this.rxLED.Text = "RX";
			// 
			// txLED
			// 
			this.txLED.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.txLED.Location = new System.Drawing.Point(280, 133);
			this.txLED.Name = "txLED";
			this.txLED.Size = new System.Drawing.Size(22, 17);
			this.txLED.TabIndex = 16;
			this.txLED.Text = "TX";
			// 
			// browseButton
			// 
			this.browseButton.Location = new System.Drawing.Point(187, 129);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(65, 23);
			this.browseButton.TabIndex = 17;
			this.browseButton.Text = "Browse";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseFile);
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(314, 459);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.txLED);
			this.Controls.Add(this.rxLED);
			this.Controls.Add(this.filePathBrowser);
			this.Controls.Add(this.outputSign);
			this.Controls.Add(this.statusLED);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.baudRate);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.consoleBox);
			this.Controls.Add(this.downloadButton);
			this.Controls.Add(this.comName);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(330, 498);
			this.MinimumSize = new System.Drawing.Size(330, 498);
			this.Name = "MainForm";
			this.Text = "BPSerialTransfer v3.0";
			((System.ComponentModel.ISupportInitialize)(this.baudRate)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
