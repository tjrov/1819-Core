﻿/**
 * @author Shreepa Parthaje
 **/

using System;
using System.Windows.Forms;

namespace EmguCVShapeDetectionTest {
    class Program {

        [STAThread]
        static void Main(string[] args) {

            Application.EnableVisualStyles();
            Application.Run(new MainForm());

        }
    }
}
