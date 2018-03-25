﻿/*******************************************************************************

INTEL CORPORATION PROPRIETARY INFORMATION
This software is supplied under the terms of a license agreement or nondisclosure
agreement with Intel Corporation and may not be copied or disclosed except in
accordance with the terms of that agreement
Copyright(c) 2013 Intel Corporation. All Rights Reserved.

*******************************************************************************/
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FF_HandsViewer.cs;
using System.Threading;

namespace hands_viewer.cs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PXCMSession session = null;
            session = PXCMSession.CreateInstance();
            if (session != null)
            {
                // Optional steps to send feedback to Intel Corporation to understand how often each SDK sample is used.
                PXCMMetadata md = session.QueryInstance<PXCMMetadata>();
                if (md != null)
                {
                    string sample_name = "Hands Viewer CS";
                    md.AttachBuffer(1297303632, System.Text.Encoding.Unicode.GetBytes(sample_name));
                }
                Form splash = new Form1();
                splash.Show();
                Thread.Sleep(3000);
                splash.Close();
                Application.Run(new MainForm(session));
                session.Dispose();
            }
        }
    }
}
