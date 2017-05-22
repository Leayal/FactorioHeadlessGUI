using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FactorioHeadlessGUI.Methods
{
    public static class Common
    {
        private const int VK_CONTROL = 0x11;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_CHAR = 0x102;
        private const int WM_KEYUP = 0x101;
        private const int VK_CANCEL = 0x03;
        private const int VK_C = 0x0043;

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static void SendSIGINT(IntPtr hWnd)
        {
            //TODO: There is indication that something similar to his should work. 
            //TODO: The trick is to find the right message combination.
            PostMessage(hWnd, WM_KEYDOWN, new IntPtr(VK_CONTROL), IntPtr.Zero);
            PostMessage(hWnd, WM_KEYDOWN, new IntPtr('C'), IntPtr.Zero);
            PostMessage(hWnd, WM_KEYUP, new IntPtr('C'), IntPtr.Zero);
            PostMessage(hWnd, WM_KEYUP, new IntPtr(VK_CONTROL), IntPtr.Zero);
        }


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AttachConsole(uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool FreeConsole();

        // Enumerated type for the control messages sent to the handler routine
        enum CtrlTypes : uint
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        delegate bool ConsoleEventDelegate(CtrlTypes ctrlType);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GenerateConsoleCtrlEvent(CtrlTypes dwCtrlEvent, uint dwProcessGroupId);

        public static void SendSIGINT(Process proc)
        {
            //This does not require the console window to be visible.
            if (AttachConsole((uint)proc.Id))
            {
                // Disable Ctrl-C handling for our program
                SetConsoleCtrlHandler(null, true);
                GenerateConsoleCtrlEvent(CtrlTypes.CTRL_C_EVENT, 0);

                // Must wait here. If we don't and re-enable Ctrl-C
                // handling below too fast, we might terminate ourselves.
                proc.WaitForExit(1000);
                FreeConsole();

                //Re-enable Ctrl-C handling or any subsequently started
                //programs will inherit the disabled state.
                SetConsoleCtrlHandler(null, false);
            }
        }
    }
}
