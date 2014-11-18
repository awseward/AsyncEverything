using System;
using System.Windows;
using Api;

namespace WpfApplication
{
    public class GetThingsCommand : Command<MainVM>
    {
        protected override async void Execute(MainVM viewModel)
        {
            var client = new Client<Thing>();
            var request = client.IndexAsync();

            try
            {
                viewModel.Requests.Add(request);
                var things = await request;

                foreach (var thing in things)
                {
                    viewModel.Things.Add(thing);
                }
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
