using System;
using System.Windows.Forms;

namespace DTProc
{
    internal class GlobalMessagerFilter : IMessageFilter
    {
        private const int WM_LBUTTONDBLCLK = 0x203;

        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_LBUTTONDBLCLK:
                    return true;

                default:
                    return false;
            }
        }
    }

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
            Application.AddMessageFilter(new GlobalMessagerFilter());
            Application.Run(new DTProc());
        }
    }
}
