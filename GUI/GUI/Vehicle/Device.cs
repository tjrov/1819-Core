﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public abstract class GenericAbstractDevice : Component
    {
        protected byte messageCommand;
        public GenericAbstractDevice(byte messageCommand)
        {
            this.messageCommand = messageCommand;
        }
        public abstract ROVMessage GetMessage();
        public abstract void UpdateData(ROVMessage msg);
        public bool NeedsResponse { get; protected set; }
    }
    //class that both sensors and actuators extend from
    public abstract class AbstractDevice<TData> : GenericAbstractDevice where TData : new()
    {
        protected TData data;
        public TData Data
        {
            get
            {
                return data;
            }
        }
        public AbstractDevice(byte messageCommand) : base(messageCommand)
        {
            this.data = new TData();
        }
        public event EventHandler<TData> Updated;
        protected void FireUpdated()
        {
            //do not allow other threads to access
            if (Updated != null)
            {
                Updated(this, data);
            }
        }
    }
}
