using System;
using System.Windows;
using Api;

namespace AsyncEverythingWpf
{
    public class GetAThingCommand : Command<MainVM>
    {
        protected async override void Execute(MainVM viewModel)
        {
            var client = new Client<Thing>();
            var request = client.ShowAsync();

            try
            {
                viewModel.Requests.Add(request);
                viewModel.Things.Add(await request);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                viewModel.Requests.Remove(request);
            }
        }
    }
}
