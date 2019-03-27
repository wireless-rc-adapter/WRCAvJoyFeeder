namespace WRCAvJoyFeeder
{
  partial class MainForm
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.serialConnect = new System.Windows.Forms.Button();
      this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
      this.serialBaud = new System.Windows.Forms.MaskedTextBox();
      this.vjoy_status = new System.Windows.Forms.Label();
      this.list_SerialPorts = new System.Windows.Forms.ComboBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.listView1 = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.closeButton = new System.Windows.Forms.Button();
      this.Ch1Label = new System.Windows.Forms.Label();
      this.Ch2Label = new System.Windows.Forms.Label();
      this.Ch3Label = new System.Windows.Forms.Label();
      this.Ch4Label = new System.Windows.Forms.Label();
      this.Ch5Label = new System.Windows.Forms.Label();
      this.Ch6Label = new System.Windows.Forms.Label();
      this.minButton = new System.Windows.Forms.Button();
      this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.calBtn = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.groupBox1.SuspendLayout();
      this.trayMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // serialConnect
      // 
      this.serialConnect.BackColor = System.Drawing.Color.MidnightBlue;
      this.serialConnect.Cursor = System.Windows.Forms.Cursors.Hand;
      this.serialConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.serialConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.serialConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.serialConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.serialConnect.ForeColor = System.Drawing.Color.White;
      this.serialConnect.Location = new System.Drawing.Point(181, 139);
      this.serialConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.serialConnect.Name = "serialConnect";
      this.serialConnect.Size = new System.Drawing.Size(168, 46);
      this.serialConnect.TabIndex = 52;
      this.serialConnect.Text = "Connect";
      this.serialConnect.UseVisualStyleBackColor = false;
      this.serialConnect.Click += new System.EventHandler(this.serialConnect_Click);
      this.serialConnect.MouseEnter += new System.EventHandler(this.serialConnect_MouseEnter);
      this.serialConnect.MouseLeave += new System.EventHandler(this.serialConnect_MouseLeave);
      // 
      // serialPort1
      // 
      this.serialPort1.PortName = "COM3";
      this.serialPort1.ReadBufferSize = 18;
      this.serialPort1.ReceivedBytesThreshold = 17;
      this.serialPort1.WriteBufferSize = 18;
      // 
      // serialBaud
      // 
      this.serialBaud.BackColor = System.Drawing.Color.DarkOrange;
      this.serialBaud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.serialBaud.ForeColor = System.Drawing.Color.MidnightBlue;
      this.serialBaud.Location = new System.Drawing.Point(36, 66);
      this.serialBaud.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.serialBaud.Mask = "00000 bps";
      this.serialBaud.Name = "serialBaud";
      this.serialBaud.PromptChar = '.';
      this.serialBaud.Size = new System.Drawing.Size(96, 35);
      this.serialBaud.TabIndex = 57;
      this.serialBaud.Text = "9600";
      this.serialBaud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // vjoy_status
      // 
      this.vjoy_status.AutoSize = true;
      this.vjoy_status.Location = new System.Drawing.Point(420, 9);
      this.vjoy_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.vjoy_status.Name = "vjoy_status";
      this.vjoy_status.Size = new System.Drawing.Size(76, 20);
      this.vjoy_status.TabIndex = 83;
      this.vjoy_status.Text = "Unknown";
      // 
      // list_SerialPorts
      // 
      this.list_SerialPorts.BackColor = System.Drawing.Color.DarkOrange;
      this.list_SerialPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.list_SerialPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.list_SerialPorts.ForeColor = System.Drawing.Color.MidnightBlue;
      this.list_SerialPorts.FormattingEnabled = true;
      this.list_SerialPorts.Location = new System.Drawing.Point(19, 24);
      this.list_SerialPorts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.list_SerialPorts.Name = "list_SerialPorts";
      this.list_SerialPorts.Size = new System.Drawing.Size(132, 37);
      this.list_SerialPorts.TabIndex = 109;
      this.list_SerialPorts.Text = "Please Wait...";
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.Color.Transparent;
      this.groupBox1.Controls.Add(this.serialBaud);
      this.groupBox1.Controls.Add(this.list_SerialPorts);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox1.ForeColor = System.Drawing.SystemColors.Window;
      this.groupBox1.Location = new System.Drawing.Point(181, 21);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox1.Size = new System.Drawing.Size(168, 103);
      this.groupBox1.TabIndex = 123;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Settings";
      // 
      // listView1
      // 
      this.listView1.BackColor = System.Drawing.SystemColors.Control;
      this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.listView1.CheckBoxes = true;
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
      this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
      this.listView1.FullRowSelect = true;
      this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.listView1.Location = new System.Drawing.Point(436, 44);
      this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.listView1.MultiSelect = false;
      this.listView1.Name = "listView1";
      this.listView1.Scrollable = false;
      this.listView1.Size = new System.Drawing.Size(42, 40);
      this.listView1.TabIndex = 142;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Inv";
      this.columnHeader1.Width = 0;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "RC Name";
      this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.columnHeader2.Width = 120;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Value";
      this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.columnHeader3.Width = 75;
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Min";
      this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.columnHeader4.Width = 0;
      // 
      // columnHeader5
      // 
      this.columnHeader5.Text = "Max";
      this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.columnHeader5.Width = 0;
      // 
      // timer
      // 
      this.timer.Enabled = true;
      this.timer.Interval = 1000;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // closeButton
      // 
      this.closeButton.BackColor = System.Drawing.Color.DarkOrange;
      this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
      this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
      this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.closeButton.Font = new System.Drawing.Font("Marlett", 7F);
      this.closeButton.ForeColor = System.Drawing.Color.MidnightBlue;
      this.closeButton.Location = new System.Drawing.Point(362, 13);
      this.closeButton.Name = "closeButton";
      this.closeButton.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
      this.closeButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.closeButton.Size = new System.Drawing.Size(18, 18);
      this.closeButton.TabIndex = 126;
      this.closeButton.Text = "r";
      this.closeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip(this.closeButton, "Exit\r\n");
      this.closeButton.UseVisualStyleBackColor = false;
      this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
      // 
      // Ch1Label
      // 
      this.Ch1Label.BackColor = System.Drawing.Color.Transparent;
      this.Ch1Label.Enabled = false;
      this.Ch1Label.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Ch1Label.ForeColor = System.Drawing.Color.White;
      this.Ch1Label.Location = new System.Drawing.Point(105, 20);
      this.Ch1Label.Name = "Ch1Label";
      this.Ch1Label.Size = new System.Drawing.Size(64, 29);
      this.Ch1Label.TabIndex = 127;
      this.Ch1Label.Text = "CH 1";
      this.Ch1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip(this.Ch1Label, "Channel 1");
      // 
      // Ch2Label
      // 
      this.Ch2Label.BackColor = System.Drawing.Color.Transparent;
      this.Ch2Label.Enabled = false;
      this.Ch2Label.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Ch2Label.ForeColor = System.Drawing.Color.White;
      this.Ch2Label.Location = new System.Drawing.Point(107, 44);
      this.Ch2Label.Name = "Ch2Label";
      this.Ch2Label.Size = new System.Drawing.Size(64, 29);
      this.Ch2Label.TabIndex = 128;
      this.Ch2Label.Text = "CH 2";
      this.Ch2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip(this.Ch2Label, "Channel 2");
      // 
      // Ch3Label
      // 
      this.Ch3Label.BackColor = System.Drawing.Color.Transparent;
      this.Ch3Label.Enabled = false;
      this.Ch3Label.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Ch3Label.ForeColor = System.Drawing.Color.White;
      this.Ch3Label.Location = new System.Drawing.Point(107, 68);
      this.Ch3Label.Name = "Ch3Label";
      this.Ch3Label.Size = new System.Drawing.Size(64, 29);
      this.Ch3Label.TabIndex = 129;
      this.Ch3Label.Text = "CH 3";
      this.Ch3Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip(this.Ch3Label, "Channel 3");
      // 
      // Ch4Label
      // 
      this.Ch4Label.BackColor = System.Drawing.Color.Transparent;
      this.Ch4Label.Enabled = false;
      this.Ch4Label.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Ch4Label.ForeColor = System.Drawing.Color.White;
      this.Ch4Label.Location = new System.Drawing.Point(106, 92);
      this.Ch4Label.Name = "Ch4Label";
      this.Ch4Label.Size = new System.Drawing.Size(64, 29);
      this.Ch4Label.TabIndex = 130;
      this.Ch4Label.Text = "CH 4";
      this.Ch4Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip(this.Ch4Label, "Channel 4");
      // 
      // Ch5Label
      // 
      this.Ch5Label.BackColor = System.Drawing.Color.Transparent;
      this.Ch5Label.Enabled = false;
      this.Ch5Label.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Ch5Label.ForeColor = System.Drawing.Color.White;
      this.Ch5Label.Location = new System.Drawing.Point(107, 115);
      this.Ch5Label.Name = "Ch5Label";
      this.Ch5Label.Size = new System.Drawing.Size(64, 29);
      this.Ch5Label.TabIndex = 131;
      this.Ch5Label.Text = "CH 5";
      this.Ch5Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip(this.Ch5Label, "Channel 5");
      // 
      // Ch6Label
      // 
      this.Ch6Label.BackColor = System.Drawing.Color.Transparent;
      this.Ch6Label.Enabled = false;
      this.Ch6Label.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Ch6Label.ForeColor = System.Drawing.Color.White;
      this.Ch6Label.Location = new System.Drawing.Point(107, 139);
      this.Ch6Label.Name = "Ch6Label";
      this.Ch6Label.Size = new System.Drawing.Size(64, 29);
      this.Ch6Label.TabIndex = 132;
      this.Ch6Label.Text = "CH 6";
      this.Ch6Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.toolTip1.SetToolTip(this.Ch6Label, "Channel 6");
      // 
      // minButton
      // 
      this.minButton.BackColor = System.Drawing.Color.DarkOrange;
      this.minButton.Cursor = System.Windows.Forms.Cursors.Hand;
      this.minButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
      this.minButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.minButton.Font = new System.Drawing.Font("Marlett", 7F, System.Drawing.FontStyle.Bold);
      this.minButton.ForeColor = System.Drawing.Color.MidnightBlue;
      this.minButton.Location = new System.Drawing.Point(362, 42);
      this.minButton.Name = "minButton";
      this.minButton.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.minButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.minButton.Size = new System.Drawing.Size(18, 18);
      this.minButton.TabIndex = 133;
      this.minButton.Text = "0";
      this.minButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip(this.minButton, "Minimize");
      this.minButton.UseVisualStyleBackColor = false;
      this.minButton.Click += new System.EventHandler(this.minButton_Click);
      // 
      // trayIcon
      // 
      this.trayIcon.ContextMenuStrip = this.trayMenu;
      this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
      this.trayIcon.Text = "Wireless RC Adapter";
      this.trayIcon.Visible = true;
      this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
      // 
      // trayMenu
      // 
      this.trayMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
      this.trayMenu.Name = "trayMenu";
      this.trayMenu.Size = new System.Drawing.Size(199, 67);
      this.trayMenu.Text = "Wireless RC Adapter";
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
      this.toolStripMenuItem1.ShowShortcutKeys = false;
      this.toolStripMenuItem1.Size = new System.Drawing.Size(198, 30);
      this.toolStripMenuItem1.Text = "Exit";
      this.toolStripMenuItem1.ToolTipText = "Exits the application.";
      this.toolStripMenuItem1.Click += new System.EventHandler(this.closeButton_Click);
      // 
      // calBtn
      // 
      this.calBtn.BackColor = System.Drawing.Color.Transparent;
      this.calBtn.Cursor = System.Windows.Forms.Cursors.Hand;
      this.calBtn.Enabled = false;
      this.calBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.calBtn.FlatAppearance.BorderSize = 0;
      this.calBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
      this.calBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
      this.calBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.calBtn.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.calBtn.ForeColor = System.Drawing.Color.Navy;
      this.calBtn.Location = new System.Drawing.Point(106, 161);
      this.calBtn.Name = "calBtn";
      this.calBtn.Size = new System.Drawing.Size(64, 29);
      this.calBtn.TabIndex = 134;
      this.calBtn.TabStop = false;
      this.calBtn.Text = "CALIBR";
      this.toolTip1.SetToolTip(this.calBtn, "Open Windows Joystick Settings\r\n(eg. to calibrate device on os)");
      this.calBtn.UseVisualStyleBackColor = false;
      this.calBtn.Click += new System.EventHandler(this.calBtn_Click);
      this.calBtn.MouseEnter += new System.EventHandler(this.calBtn_MouseEnter);
      this.calBtn.MouseLeave += new System.EventHandler(this.calBtn_MouseLeave);
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.DarkOrange;
      this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
      this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.Font = new System.Drawing.Font("Marlett", 7F);
      this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
      this.button1.Location = new System.Drawing.Point(362, 72);
      this.button1.Name = "button1";
      this.button1.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
      this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.button1.Size = new System.Drawing.Size(18, 18);
      this.button1.TabIndex = 143;
      this.button1.Text = "s";
      this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.toolTip1.SetToolTip(this.button1, "Help");
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.helpBtn_Click);
      // 
      // MainForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.Lime;
      this.BackgroundImage = global::WRCAvJoyFeeder.Properties.Resources.background;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ClientSize = new System.Drawing.Size(384, 209);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.vjoy_status);
      this.Controls.Add(this.listView1);
      this.Controls.Add(this.calBtn);
      this.Controls.Add(this.minButton);
      this.Controls.Add(this.Ch6Label);
      this.Controls.Add(this.Ch5Label);
      this.Controls.Add(this.Ch4Label);
      this.Controls.Add(this.Ch3Label);
      this.Controls.Add(this.Ch2Label);
      this.Controls.Add(this.Ch1Label);
      this.Controls.Add(this.closeButton);
      this.Controls.Add(this.serialConnect);
      this.Controls.Add(this.groupBox1);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(384, 209);
      this.MinimumSize = new System.Drawing.Size(384, 209);
      this.Name = "MainForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Wireless RC Adapter";
      this.TransparencyKey = System.Drawing.Color.Lime;
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.Resize += new System.EventHandler(this.MainForm_Resize);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.trayMenu.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    internal System.Windows.Forms.Button serialConnect;
    private System.IO.Ports.SerialPort serialPort1;
    private System.Windows.Forms.Label vjoy_status;
    private System.Windows.Forms.ComboBox list_SerialPorts;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ColumnHeader columnHeader4;
    private System.Windows.Forms.ColumnHeader columnHeader5;
    private System.Windows.Forms.Timer timer;
    //internal System.Windows.Forms.Button openGamePad;
    private System.Windows.Forms.MaskedTextBox serialBaud;
    private System.Windows.Forms.Button closeButton;
    private System.Windows.Forms.Label Ch1Label;
    private System.Windows.Forms.Label Ch2Label;
    private System.Windows.Forms.Label Ch3Label;
    private System.Windows.Forms.Label Ch4Label;
    private System.Windows.Forms.Label Ch5Label;
    private System.Windows.Forms.Label Ch6Label;
    private System.Windows.Forms.Button minButton;
    private System.Windows.Forms.NotifyIcon trayIcon;
    private System.Windows.Forms.Button calBtn;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ContextMenuStrip trayMenu;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}