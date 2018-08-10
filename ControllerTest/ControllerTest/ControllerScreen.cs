using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SlimDX.DirectInput;

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
            timer1.Enabled = true;
        }
        DirectInput Input = new DirectInput();
        SlimDX.DirectInput.Joystick stick;
        Joystick[] Sticks;
        bool MouseClicked = false;

        int xValue = 0;
        int yValue = 0;
        int zValue = 0;

        [DllImport("user32.dll", Charset = CharSet.Auto)]
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
                    foreach (DeviceObjectInstance deviceObject in sticks.GetObjects())
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

            bool[] buttons = state.GetButtons();

            if (id == 0)
            {
                if (buttons[0])
                {
                    if (mouseClicked = false)
                    {
                        mouse_event(MOUSEEVENT_LEFTDOWN, 0, 0, 0, 0);
                        mouseClicked = true;
                    }
                }
                else
                {
                    if (mouseClicked == true)
                    {
                        mouse_event(MOUSEEVENT_LEFTUP, 0, 0, 0, 0);
                        mouseClicked = false;
                    }
                }
            }
        }

        public void MouseMove(int posx, int posy)
        {
            Cursor.Position = new Point(Cursor.Position.X + posx, Cursor.Position.Y + posy);
            Cursor.Clip = new Rectangle(this.Location, this.Size);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int a = 0; a < Sticks.Length; a++)
            {
                stickHandle(Sticks[a], a);
            }
        }

        private void ControllerScreen_Load(object sender, EventArgs e)
        {
            Joystick[] joystick = GetSticks();
        }
    }
}
    