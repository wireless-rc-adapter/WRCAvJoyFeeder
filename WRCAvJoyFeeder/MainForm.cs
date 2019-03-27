using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using vJoyInterfaceWrap;

namespace WRCAvJoyFeeder
{
  public partial class MainForm : Form
  {
    // Declare a virtual-joystick (vJoy) with id 1
    static public vJoy ujoyStick;
    static public vJoy.JoystickState iReport;
    static public uint uJoyId = 1;
    public long joyMin = 0;
    public long joyMax = 1;

    // Window first time minimized flag
    static public bool first_min = false;


    public MainForm()
    {
      InitializeComponent();
    }


    // Handler function for window size change events
    private void MainForm_Resize(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized && !first_min)
      {
        // Show the balloon tip when minimized for the first time
        trayIcon.ShowBalloonTip(1000, "Wireless RC Adapter", "Minimized to the system tray, double click the icon to open it again.", ToolTipIcon.Info);
        first_min = true;
      }
    }


    // Mouse-click handler function for system tray icon
    private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized)
      {  // Restore window state when minimized
        this.WindowState = FormWindowState.Normal;
      }
      else
      {  // Minimize the window when it is not
        this.WindowState = FormWindowState.Minimized;
      }
    }


    // Button handler function for Connect button
    private void serialConnect_Click(object sender, EventArgs e)
    {
      if (serialConnect.Text == "Connect")
      {
        serialPort1.BaudRate = int.Parse(serialBaud.Text.Replace(" bps", ""));  // Add ' bps' to baud rate value
        serialPort1.PortName = list_SerialPorts.SelectedItem.ToString();
        serialPort1.NewLine = "\n";  // Define the transmission delimiter
        serialPort1.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);

        // Make sure the port is closed before trying to open
        if (serialPort1.IsOpen)
        {
          serialPort1.Close();
        }

        // Try to open the serial port
        try
        {
          serialPort1.Open();
          timer.Enabled = true;
        }
        catch (Exception ex) {
          MessageBox.Show(ex.Message);
        }

        if (serialPort1.IsOpen)
        {  // WHEN SERIAL PORT IS CONNECTED
          list_SerialPorts.Enabled = false;  // Disable serial port selector
          serialBaud.Enabled = false;  // Disable baud rate input box

          // Create the joystick object and position structure
          //axis_e_x.Text = ujoyStick.GetVJDAxisExist(uJoyId, HID_USAGES.HID_USAGE_X).ToString();
          //axis_e_y.Text = ujoyStick.GetVJDAxisExist(uJoyId, HID_USAGES.HID_USAGE_Y).ToString();
          //axis_e_z.Text = ujoyStick.GetVJDAxisExist(uJoyId, HID_USAGES.HID_USAGE_Z).ToString();
          //axis_e_rz.Text = ujoyStick.GetVJDAxisExist(uJoyId, HID_USAGES.HID_USAGE_RZ).ToString();
          //axis_e_ry.Text = ujoyStick.GetVJDAxisExist(uJoyId, HID_USAGES.HID_USAGE_RY).ToString();
          //axis_e_s1.Text = ujoyStick.GetVJDAxisExist(uJoyId, HID_USAGES.HID_USAGE_SL0).ToString();
          //button_e.Text = ujoyStick.GetVJDButtonNumber(uJoyId).ToString();
          //cpov_e.Text = ujoyStick.GetVJDContPovNumber(uJoyId).ToString();
          //dpov_e.Text = ujoyStick.GetVJDDiscPovNumber(uJoyId).ToString();

          ujoyStick.GetVJDAxisMax(uJoyId, HID_USAGES.HID_USAGE_X, ref joyMax);
          ujoyStick.GetVJDAxisMin(uJoyId, HID_USAGES.HID_USAGE_X, ref joyMin);

          // Acquire the target
          if ((vjoy_status.Text == VjdStat.VJD_STAT_OWN.ToString()) || ((vjoy_status.Text == VjdStat.VJD_STAT_FREE.ToString()) && (!ujoyStick.AcquireVJD(uJoyId))))
          {
            vjoy_status.Text = "Failed to acquire vJoy device";
            trayIcon.ShowBalloonTip(3000, "Wireless RC Adapter", "Error: Failed to acquire vJoy device! Make sure there is nothing using it.", ToolTipIcon.Error);
            Console.WriteLine("Error: Failed to acquire vJoy device!");
            return;
          }
          else
          {
            vjoy_status.Text = "Acquired: vJoy device";
            trayIcon.ShowBalloonTip(1000, "Wireless RC Adapter", "Connected", ToolTipIcon.Info);
            Console.WriteLine("Debug: Succesfully connected.");
            calBtn.Enabled = true;
            channelLabels_Enable(true);
          }


          ujoyStick.ResetVJD(uJoyId);  // Reset joystick states
          serialConnect.Text = "Disconnect";  // Change button text on connection
          timer.Enabled = false;  // Disable the timer for updating available com ports
          list_SerialPorts.Enabled = false;  // Disable serial port chooser
          serialBaud.Enabled = false;  // Disable baud rate input box
        }
      }
      else
      {  // WHEN SERIAL PORT IS DISCONNECTED
        serialConnect.Enabled = true;
        calBtn.Enabled = false;
        channelLabels_Enable(false);
        serialPort1.Close();
        trayIcon.ShowBalloonTip(1000, "Wireless RC Adapter", "Disconnected", ToolTipIcon.Info);
        Console.WriteLine("Debug: Adapter disconnected.");

        if (serialPort1.IsOpen == false)
        {
          timer.Enabled = false;
          serialConnect.Enabled = true;
          list_SerialPorts.Enabled = true;
          serialBaud.Enabled = true;
          serialConnect.Text = "Connect";
        }
        else {
          // TODO set vjoy_status instead MessageBox
          //MessageBox.Show("Error disconnecting");
          trayIcon.ShowBalloonTip(3000, "Wireless RC Adapter", "Error: Can not open serial port! Make sure there is nothing using it.", ToolTipIcon.Error);
        }
      }
    }

    private void serialConnect_MouseEnter(object sender, EventArgs e)
    {
      serialConnect.ForeColor = Color.Navy;
    }

    private void serialConnect_MouseLeave(object sender, EventArgs e)
    {
      serialConnect.ForeColor = Color.White;

    }

    private void channelLabels_Enable(Boolean state)
    {
      Ch1Label.Enabled = state;
      Ch2Label.Enabled = state;
      Ch3Label.Enabled = state;
      Ch4Label.Enabled = state;
      Ch5Label.Enabled = state;
      Ch6Label.Enabled = state;
    }


    private void MainForm_Load(object sender, EventArgs e)
    {
      // Initialize vJoy
      ujoyStick = new vJoy();

      // Get the driver attributes (Vendor ID, Product ID, Version Number)
      if (!ujoyStick.vJoyEnabled())
      {
        //vjoy_status.Text = "vJoy driver not enabled";
        trayIcon.ShowBalloonTip(3000, "Wireless RC Adapter", "Error: vJoy driver not enabled, exiting! Please enable and re-launch application.", ToolTipIcon.Error);
        Console.WriteLine("Error: vJoy driver not enabled!");
        Application.Exit();
      }

      vjoy_status.Text = ujoyStick.GetVJDStatus(uJoyId).ToString();

      // Check driver and library dll version
      UInt32 DllVer = 0, DrvVer = 0;
      bool match = ujoyStick.DriverMatch(ref DllVer, ref DrvVer);

      if (match)
      {
        String vjoy_dllver = DllVer.ToString();
        String vjoy_drvver = DrvVer.ToString();
        Console.WriteLine("Debug: DLL(v" + vjoy_dllver + "), DRV(v" + vjoy_drvver + ")");
      }
      else
      {
        vjoy_status.Text = "DLL MISMATCH";
        trayIcon.ShowBalloonTip(3000, "Wireless RC Adapter", "Error: Dll version mismatc!. Please install latest vJoy driver.", ToolTipIcon.Error);
        Console.WriteLine("Error: Dll version mismatch! Please install latest vJoy driver.");
      }

      comRefresh();
      fillListView(new string[] { "CH1", "CH2", "CH3", "CH4", "CH5", "CH6" }, new int[] { 0, 0, 0, 0, 0, 0 });
    }


    private delegate void SetTextDeleg(string text);


    void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      try
      {
        if (serialPort1.IsOpen)
        {
          // Invokes the delegate on the UI thread, and sends the data that was received to the invoked method.
          // ---- The "si_DataReceived" method will be executed on the UI thread which allows populating of the textbox.
          string data = serialPort1.ReadLine();
          this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
        }
      }
      catch (Exception ex) {
        MessageBox.Show(ex.Message);
        Console.WriteLine(ex.Message);
      }
    }


    // Function to remap input values to output range
    private int MAP(int inMin, int inMax, int outMin, int outMax, int input)
    {
      if (input > inMax || input < inMin)
        return -1;

      if (outMax == 1 && outMin == 0)
      {
        int d = inMin + ((inMax - inMin) / 2);
        if (input > d)
          return 1;
        else
          return 0;
      }

      return (input - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }


    private void si_DataReceived(string data)
    {
      string serialDataPre = data.Trim();
      //textBox1.Text = serialDataPre;

      int[] serialData = Array.ConvertAll(serialDataPre.Split(','), int.Parse);

      if (serialData.Length == 6)
      {
        int c = 0;
        //int il = 0;
        //int ih = 101;

        foreach (int line in serialData)
        {
          listView1.Items[c].SubItems[2].Text = line.ToString();

          //if (listView1.Items[c].Checked == true)
          //{
          //    il = 101;
          //    ih = 0;
          //}

          switch (c)
          {
            case 0:
              Ch1Label.Text = line.ToString();
              ujoyStick.SetAxis(MAP(1000, 2000, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_X);
              break;
            case 1:
              Ch2Label.Text = line.ToString();
              ujoyStick.SetAxis(MAP(1000, 2000, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_Y);
              break;
            case 2:
              Ch3Label.Text = line.ToString();
              ujoyStick.SetAxis(MAP(1000, 2000, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_Z);
              break;
            case 3:
              Ch4Label.Text = line.ToString();
              ujoyStick.SetAxis(MAP(1000, 2000, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_RZ);
              break;
            case 4:
              Ch5Label.Text = line.ToString();
              ujoyStick.SetAxis(MAP(1000, 2000, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_RY);
              break;
            case 5:
              Ch6Label.Text = line.ToString();
              int l = MAP(1000, 2000, 0, 1, line);
              ujoyStick.SetBtn(Convert.ToBoolean(l), uJoyId, 0);
              break;
          }

          c++;
        }
      }
    }


    //public static int ConvertRange(int originalStart, int originalEnd, int newStart, int newEnd, int value)
    //{
    //    double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
    //    return (int)(newStart + ((value - originalStart) * scale));
    //}


    public void comRefresh()
    {
      string text = "";

      if (list_SerialPorts.Items.Count > 1)
      {
        int item = list_SerialPorts.SelectedIndex;
        text = list_SerialPorts.Items[item].ToString();
      }

      string[] ports = SerialPort.GetPortNames();
      list_SerialPorts.Items.Clear();

      if (ports.Length == 0)
      {
        timer.Interval = 1000;
        list_SerialPorts.Items.Add("No ports!");
        list_SerialPorts.SelectedIndex = 0;
        Console.WriteLine("Warning: No serial ports found!");
        //serialBaud.Text = "";
        list_SerialPorts.Enabled = false;
        serialBaud.Enabled = false;
        serialConnect.Enabled = false;
      }
      else
      {
        timer.Interval = 5000;
        list_SerialPorts.Items.Add("Choose port...");
        list_SerialPorts.Items.AddRange(ports);
        list_SerialPorts.SelectedIndex = 0;

        if (list_SerialPorts.Items.Contains(text))  // ???
          list_SerialPorts.SelectedIndex = list_SerialPorts.Items.IndexOf(text);

        if (serialBaud.TextLength == 0)
        {
          serialBaud.Text = "9600";
        }

        list_SerialPorts.Enabled = true;
        serialBaud.Enabled = true;
        serialConnect.Enabled = true;
      }
    }


    public void fillListView(string[] names, int[] inverse = null)
    {
      listView1.Items.Clear();
      int c = 0;

      foreach (string item in names)
      {
        ListViewItem i = new ListViewItem(new string[] { "", item, "nul", "nul", "nul" });
        
        if (inverse[c] == 1)
        {
          i.Checked = true;
        }

        listView1.Items.Add(i);

        c++;
      }
    }


    // Timer handler function
    private void timer_Tick(object sender, EventArgs e)
    {
      Console.WriteLine("Debug: Timer-Tick! Checking for com port changes.");
      comRefresh();
    }


    private void calBtn_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start("rundll32.exe", "shell32.dll,Control_RunDLL joy.cpl");
    }


    // Close button handler function
    private void closeButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    // Minimize button handler function
    private void minButton_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    // Make window draggable to move
    protected override void WndProc(ref Message m)
    {/* Constants in Windows API
        0x84 = WM_NCHITTEST - Mouse Capture Test
        0x1 = HTCLIENT - Application Client Area
        0x2 = HTCAPTION - Application Title Bar

        This function intercepts all the commands sent to the application. 
        It checks to see of the message is a mouse click in the application. 
        It passes the action to the base action by default. It reassigns 
        the action to the title bar if it occured in the client area
        to allow the drag and move behavior. */

      switch (m.Msg)
      {
        case 0x84:
          base.WndProc(ref m);
          if ((int)m.Result == 0x1)
            m.Result = (IntPtr)0x2;
          return;
      }

      base.WndProc(ref m);
    }


    // Hide window from ALT+TAB selector
    //protected override CreateParams CreateParams
    //{
    //  get
    //  {
    //    CreateParams pm = base.CreateParams;
    //    pm.ExStyle |= 0x80;
    //    return pm;
    //  }
    //}

    private void calBtn_MouseEnter(object sender, EventArgs e)
    {
      calBtn.ForeColor = Color.White;
    }

    private void calBtn_MouseLeave(object sender, EventArgs e)
    {
      calBtn.ForeColor = Color.Navy;

    }

    private void helpBtn_Click(object sender, EventArgs e)
    {
      System.Diagnostics.Process.Start("http://github.com/wireless-rc-adapter/wireless-rc-adapter/wiki");
    }
  }
}
