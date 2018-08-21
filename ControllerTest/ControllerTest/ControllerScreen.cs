using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SlimDX.DirectInput;
using System.Runtime.InteropServices;
using System.Timers;

/// <summary>
/// https://www.youtube.com/watch?v=rtnLGfAj7W0
/// </summary>

namespace ControllerTest
{
    
    public partial class ControllerScreen : Form
    {
        public ControllerScreen()
        {
            InitializeComponent();
            GetSticks();
            Sticks = GetSticks();
            ControllerTimer.Enabled = true;
            ControllerTimer.Interval = 100;
        }
        
        DirectInput Input = new DirectInput();
        SlimDX.DirectInput.Joystick stick;
        Joystick[] Sticks;
        bool MouseClicked = false;
        bool[] buttons;

        int xValue = 0;
        int yValue = 0;
        int zValue = 0;

        int xRotValue = 0;
        int yRotValue = 0;
        int zRotValue = 0;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void mouse_event(uint flag, uint _x, uint _y, uint btn, uint exInfo);
        private const int MOUSEEVENT_LEFTDOWN = 0x02;
        private const int MOUSEEVENT_LEFTUP = 0x04;

        public Joystick[] GetSticks()
        {
            List<SlimDX.DirectInput.Joystick> sticks = new List<SlimDX.DirectInput.Joystick>();
            foreach (DeviceInstance device in Input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                try
                {
                    stick = new SlimDX.DirectInput.Joystick(Input, device.InstanceGuid);
                    stick.Acquire();
                    foreach (DeviceObjectInstance deviceObject in stick.GetObjects())
                    {
                        if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                        {
                            stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 100);
                        }
                    }
                    sticks.Add(stick);
                }
                catch (DirectInputException)
                {

                }
            }
            return sticks.ToArray();
        }

        void stickHandle(Joystick stick, int id)
        {
            JoystickState state = new JoystickState();
            state = stick.GetCurrentState();

            xValue = state.X;
            yValue = state.Y;
            zValue = state.Z;

            xRotValue = state.RotationX;
            yRotValue = state.RotationY;
            zRotValue = state.RotationZ;

            bool[] buttons = state.GetButtons(); 

            if (id == 0)
            {
                if (buttons[0])
                {
                    if (MouseClicked = false)
                    {
                        mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                        MouseClicked = true;
                    }
                }
                else
                {
                    if (MouseClicked == true)
                    {
                        mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
                        MouseClicked = false;
                    }
                }
                checkBox1.Text = buttons[0] + "";
                checkBox2.Text = buttons[1] + "";
                checkBox3.Text = buttons[2] + "";
                checkBox4.Text = buttons[3] + "";
                checkBox5.Text = buttons[4] + "";
                checkBox6.Text = buttons[5] + "";
            }
        }

        public void MouseMove(int posx, int posy)
        {
            Cursor.Position = new Point(Cursor.Position.X + posx, Cursor.Position.Y + posy);
            Cursor.Clip = new Rectangle(this.Location, this.Size);
        }

        private void ControllerTimer_Tick(object sender, EventArgs e)
        {
            for (int a = 0; a < Sticks.Length; a++)
            {
                stickHandle(Sticks[a], a);
                RightTriggerBar.Value = (yRotValue + 100) / 2;
                LeftTriggerBar.Value = (xRotValue + 100) / 2;
            }
        }
        private void ControllerScreen_Load(object sender, EventArgs e)
        {
            Joystick[] joystick = GetSticks();
        }
    }
}
    