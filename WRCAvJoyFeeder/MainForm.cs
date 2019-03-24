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


    public MainForm()
    {
      InitializeComponent();
    }


    // Handler function for window size change events
    private void MainForm_Resize(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized)
      {
        this.Hide();  // Hide taskbar icon
        trayIcon.Visible = true;  // Show system tray icon
        
        // TODO only show balloon for the first time
        
        trayIcon.ShowBalloonTip(1000);  // Show the balloon tip when minimized
      }
    }


    // Handler function for system tray
    private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.Show();  // Show taskbar icon
      this.WindowState = FormWindowState.Normal;  // Restore window state (Unminimize)
      trayIcon.Visible = false;  // Hide the system tray icon
    }


    // Connect button handler function
    private void serialConnect_Click(object sender, EventArgs e)
    {
      if (serialConnect.Text == "Start")
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
          timer1.Enabled = true;
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }

        if (serialPort1.IsOpen)
        {  // WHEN SERIAL PORT IS CONNECTED
          list_SerialPorts.Enabled = false;  // Disable serial port selector
          serialBaud.Enabled = false;  // Disable baud rate input box

          // Create the joystick object and position structure
          axis_e_x.Text = ujoyStick.GetVJDAxisExist(uJoyId, HID_USAGES.HID_USAGE_X).ToString();
          axis_e_y.Text = ujoyStick.GetVJDAxisExist(uJoyId, HID_USAGES.HID_USAGE_Y).ToString();
          axis_e_rx.Text = ujoyStick.GetVJDAxisExist(uJoyId, HID_USAGES.HID_USAGE_RX).ToString();
          axis_e_ry.Text = ujoyStick.GetVJDAxisExist(uJoyId, HID_USAGES.HID_USAGE_RY).ToString();
          axis_e_rz.Text = ujoyStick.GetVJDAxisExist(uJoyId, HID_USAGES.HID_USAGE_RZ).ToString();
          axis_e_s1.Text = ujoyStick.GetVJDAxisExist(uJoyId, HID_USAGES.HID_USAGE_SL0).ToString();
          axis_e_s2.Text = ujoyStick.GetVJDAxisExist(uJoyId, HID_USAGES.HID_USAGE_SL1).ToString();
          button_e.Text = ujoyStick.GetVJDButtonNumber(uJoyId).ToString();
          cpov_e.Text = ujoyStick.GetVJDContPovNumber(uJoyId).ToString();
          dpov_e.Text = ujoyStick.GetVJDDiscPovNumber(uJoyId).ToString();

          ujoyStick.GetVJDAxisMax(uJoyId, HID_USAGES.HID_USAGE_X, ref joyMax);
          ujoyStick.GetVJDAxisMin(uJoyId, HID_USAGES.HID_USAGE_X, ref joyMin);
          //MessageBox.Show("Min:" + joyMin.ToString() + ", Max:" + joyMax.ToString(),"Connected");

          // Acquire the target
          if ((vjoy_status.Text == VjdStat.VJD_STAT_OWN.ToString()) || ((vjoy_status.Text == VjdStat.VJD_STAT_FREE.ToString()) && (!ujoyStick.AcquireVJD(uJoyId))))
          {
            vjoy_status.Text = "Failed to acquire vJoy device";
            Console.WriteLine(vjoy_status.Text);
            return;
          }
          else
          {
            vjoy_status.Text = "Acquired: vJoy device";
            Console.WriteLine(vjoy_status.Text);
          }


          ujoyStick.ResetVJD(uJoyId);  // Reset joystick states
          serialConnect.Text = "Stop";  // Change button text on connection
          timer1.Enabled = false;  // Disable the timer for updating available com ports
          list_SerialPorts.Enabled = false;  // Disable serial port chooser
          serialBaud.Enabled = false;  // Disable baud rate input box
        }
      }
      else
      {  // WHEN SERIAL PORT IS DISCONNECTED
        serialConnect.Enabled = true;
        serialPort1.Close();

        if (serialPort1.IsOpen == false)
        {
          timer1.Enabled = false;
          serialConnect.Enabled = true;
          list_SerialPorts.Enabled = true;
          serialBaud.Enabled = true;
          serialConnect.Text = "Start";
        }
        else { MessageBox.Show("Error disconnecting"); }
        // TODO set vjoy_status instead MessageBox
      }
    }


    private void MainForm_Load(object sender, EventArgs e)
    {
      // Initialize vJoy
      ujoyStick = new vJoy();

      // Get the driver attributes (Vendor ID, Product ID, Version Number)
      if (!ujoyStick.vJoyEnabled())
      {
        vjoy_status.Text = "vJoy driver not enabled";
        Application.Exit();
        //Console.WriteLine(vjoy_status.Text);
      }

      vjoy_status.Text = ujoyStick.GetVJDStatus(uJoyId).ToString();
      //vjoy_vendor.Text = ujoyStick.GetvJoyManufacturerString();
      //vjoy_product.Text = ujoyStick.GetvJoyProductString();
      //vjoy_version.Text = ujoyStick.GetvJoySerialNumberString();

      // Check driver and library dll version
      UInt32 DllVer = 0, DrvVer = 0;
      bool match = ujoyStick.DriverMatch(ref DllVer, ref DrvVer);

      if (match)
      {
        vjoy_dllver.Text = DllVer.ToString();
        vjoy_drvver.Text = DrvVer.ToString();
        //Console.WriteLine("DLL: " + vjoy_dllver.Text);
        //Console.WriteLine("DRV: " + vjoy_drvver.Text);
      }
      else
      {
        vjoy_status.Text = "DLL MISMATCH";
        //Console.WriteLine(vjoy_status.Text);
      }

      comRefresh();
      fillListView(new string[] { "Throttle", "Rudder", "Aileron", "Elevator", "Gear", "Aux 1" }, new int[] { 0, 0, 0, 0, 0, 0 });
    }


    private delegate void SetTextDeleg(string text);


    void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      try
      {
        if (serialPort1.IsOpen)
        {

          string data = serialPort1.ReadLine();

          // Invokes the delegate on the UI thread, and sends the data that was received to the invoked method.

          // ---- The "si_DataReceived" method will be executed on the UI thread which allows populating of the textbox.

          this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
        }
      }
      catch (Exception ex) { MessageBox.Show(ex.Message); }
    }


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


    //private long LMAP(long inMin, long inMax, long outMin, long outMax, long input)
    //{
    //    if (input > inMax || input < inMin)
    //        return -1;

    //    if (outMax == 1 && outMin == 0)
    //    {
    //        long d = inMin + ((inMax - inMin) / 2);
    //        if (input > d)
    //            return 1;
    //        else
    //            return 0;
    //    }

    //    return (input - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    //}


    private void si_DataReceived(string data)
    {
      string serialDataPre = data.Trim();
      textBox1.Text = serialDataPre;

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
              label1.Text = line.ToString();
              ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_X);
              break;
            case 1:
              label2.Text = line.ToString();
              ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_RX);
              ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_RZ);
              ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_SL0);
              ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_SL1);
              ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_Z);
              break;
            case 2:
              label3.Text = line.ToString();
              ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_RX);
              break;
            case 3:
              label4.Text = line.ToString();
              ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_RY);
              break;
            case 4:
              label5.Text = line.ToString();
              int k = MAP(1100, 1900, 0, 1, line);
              ujoyStick.SetBtn(Convert.ToBoolean(k), uJoyId, 0);
              break;
            case 5:
              label6.Text = line.ToString();
              int l = MAP(1100, 1900, 0, 1, line);
              ujoyStick.SetBtn(Convert.ToBoolean(l), uJoyId, 1);
              break;
          }

          //if (c == 0)
          //{
          //    //lineJoyY1.Top = MAP(1100, 1900, il, ih, line);
          //    label1.Text = line.ToString();
          //    ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_X);
          //}
          //if (c == 1)
          //{
          //    //lineJoyX1.Left = MAP(1100, 1900, il, ih, line);
          //    label2.Text = line.ToString();
          //    //Console.WriteLine("1: " + MAP(1100, 1900, (int)joyMin, (int)joyMax, line).ToString());
          //    ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_RX);
          //    ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_RZ);
          //    ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_SL0);
          //    ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_SL1);
          //    ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_Z);
          //}
          //if (c == 2)
          //{
          //    //lineJoyY2.Top = MAP(1100, 1900, il, ih, line);
          //    label3.Text = line.ToString();

          //    ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_RX);
          //}
          //if (c == 3)
          //{
          //    //lineJoyX2.Left = MAP(1100, 1900, il, ih, line);
          //    label4.Text = line.ToString();
          //    ujoyStick.SetAxis(MAP(1100, 1900, (int)joyMin, (int)joyMax, line), uJoyId, HID_USAGES.HID_USAGE_RY);
          //}
          //if (c == 4)
          //{
          //    label5.Text = line.ToString();
          //    int l = MAP(1100, 1900, 0, 1, line);
          //    //if (l == 1)
          //    //    lightGear1.Image = Properties.Resources.buttonOpen;
          //    //else
          //    //    lightGear1.Image = Properties.Resources.buttonClosed;
          //    ujoyStick.SetBtn(Convert.ToBoolean(l), uJoyId, 0);
          //}
          //if (c == 5)
          //{
          //    label6.Text = line.ToString();
          //    int l = MAP(1100, 1900, 0, 1, line);
          //    //if (l == 1)
          //    //    lightAux1.Image = Properties.Resources.buttonOpen;
          //    //else
          //    //    lightAux1.Image = Properties.Resources.buttonClosed;
          //    ujoyStick.SetBtn(Convert.ToBoolean(l), uJoyId, 1);
          //}

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
        timer1.Interval = 1000;
        list_SerialPorts.Items.Add("No ports!");
        list_SerialPorts.SelectedIndex = 0;
        //serialBaud.Text = "";
        list_SerialPorts.Enabled = false;
        serialBaud.Enabled = false;
        serialConnect.Enabled = false;
      }
      else
      {
        timer1.Interval = 5000;
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


    // ???
    public void fillListView(string[] names, int[] inverse = null)
    {
      listView1.Items.Clear();
      int c = 0;

      foreach (string item in names)
      {
        ListViewItem i = new ListViewItem(new string[] { "", item, "nul", "nul", "nul" });
        if (inverse[c] == 1)
          i.Checked = true;
        listView1.Items.Add(i);
        c++;
      }
    }


    // Timer-1 handler function
    private void timer1_Tick(object sender, EventArgs e)
    {
      //Console.WriteLine("Timer1: Tick! Check for com port change");
      comRefresh();
    }


    //private void openGamePad_Click(object sender, EventArgs e)
    //{
    //    System.Diagnostics.Process.Start("rundll32.exe", "shell32.dll,Control_RunDLL joy.cpl");
    //}


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
  }
}
