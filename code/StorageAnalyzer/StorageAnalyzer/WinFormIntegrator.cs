using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace StorageAnalyzer
{
    //@ Reference taken from : http://stackoverflow.com/questions/315164/how-to-use-a-folderbrowserdialog-from-a-wpf-application
    public static class WinFormIntegrator
    {
        public static IWin32Window GetIWin32Window(this Window window)
        {
            return new Win32Window(new System.Windows.Interop.WindowInteropHelper(window).Handle);
        }

        class Win32Window : IWin32Window
        { // NOTE: This is System.Windows.Forms.IWin32Window, not System.Windows.Interop.IWin32Window!

            public Win32Window(IntPtr handle)
            {
                Handle = handle; 
            }

            public IntPtr Handle { get; private set; }

        }
    }
}
