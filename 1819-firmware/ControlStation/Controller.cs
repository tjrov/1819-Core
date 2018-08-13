/*using System;

public class Controller
{
    public Controller()
    {

    }
    public virtual IList<Controller> Available()
    {
        IList<Controller> result = new List<Controller>();
        DirectInput dinput = new DirectInput();
        foreach (DeviceInstance di in dinput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
        {
            Controller dev = new Controller();
            dev.Guid = di.InstanceGuid;
            dev.Name = di.InstanceName;
            result.Add(dev);
        }
        return result;
    }

    private void acquire(System.Windows.Forms.Form parent)
    {
        DirectInput dinput = new DirectInput();

        pad = new Joystick(dinput, this.Device.Guid);
        foreach (DeviceObjectInstance doi in pad.GetObjects(ObjectDeviceType.Axis))
        {
            pad.GetObjectPropertiesById((int)doi.ObjectType).SetRange(-5000, 5000);
        }

        pad.Properties.AxisMode = DeviceAxisMode.Absolute;
        pad.SetCooperativeLevel(parent, (CooperativeLevel.Nonexclusive | CooperativeLevel.Background));
        pad.Acquire();
    }

    public void update()
    {
        JoystickState state = new JoystickState();

        if (pad.Poll().IsFailure)
        {
            result.Disconnect = true;
            return result;
        }

        if (pad.GetCurrentState(ref state).IsFailure)
        {
            result.Disconnect = true;
            return result;
        }

        result.X = state.X / 5000.0f;
        result.Y = state.Y / 5000.0f;
        int ispressed = 0;
        bool[] buttons = state.GetButtons();
    }

}*/
