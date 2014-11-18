using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Api;

namespace WpfApplication
{
    public class GetAThingCommand : Command<MainVM>
    {
        protected async override void Execute(MainVM viewModel)
        {
            Task<Thing> request = null;

            try
            {
                var client = new ApiClient<Thing>();
                request = client.ShowAsync();

                viewModel.Requests.Add(request);
                viewModel.Things.Add(await request);
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Status.ToString());
            }
            finally
            {
                viewModel.Requests.Remove(request);
            }
        }
    }
}
