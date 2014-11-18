using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Api;

namespace WpfApplication
{
    public class DestroyAThingCommand : Command
    {
        public async override void Execute(object parameter)
        {
            Task<bool> request = null;

            try
            {
                var client = new ApiClient<Thing>();
                request = client.DestroyAsync((Thing) parameter);

                // Not sure how to add it to its viewmodel...

                var destroySucceeded = await request;

                // Same here as above...
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Status.ToString());
            }
            finally
            {
                // Would like to remove from requests, but I haven't quite
                // figured out the best way to do that just yet...
            }
        }
    }
}
