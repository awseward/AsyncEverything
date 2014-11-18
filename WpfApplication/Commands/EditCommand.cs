using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Api;
using WpfApplication.Helpers;

namespace WpfApplication
{
    public class EditCommand : Command
    {
        public override void Execute(object parameter)
        {
            try
            {
                var thing = (Thing) parameter;
                MessageBox.Show(string.Format("Edit Thing {0}",
                    thing.Guid));
            }
            catch (Exception ex)
            {
                ExceptionHelper.DoSomething(ex);
            }
            finally
            {
                // Not really much to do here I guess...
            }
        }
    }
}
