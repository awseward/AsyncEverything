using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication.Helpers
{
    public static class ExceptionHelper
    {
        public static void DoSomething(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        public static void DoSomething(WebException ex)
        {
            MessageBox.Show(ex.Status.ToString());
        }
    }
}
