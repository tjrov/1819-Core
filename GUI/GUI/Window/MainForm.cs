using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        private DepthSensor depthSensor;
        private OrientationSensor orientationSensor;
        private StatusSensor statusSensor;
        private PropulsionSensor propulsionSensor;
        private DiagnosticsSensor diagnosticsSensor;

        private StatusActuator statusActuator;
        private PropulsionActuator propulsionActuator;
        private ToolsActuator toolsActuator;

        public MainForm()
        {
            InitializeComponent();

            BetterSerialPort port = new BetterSerialPort("COM4", 1000000);
            SerialCommunication comms = new SerialCommunication(port);
            comms.Connect();


        }
    }
}
