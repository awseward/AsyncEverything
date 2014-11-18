using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Api;

namespace AsyncEverything
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client<Thing>();

            GetAThingAsync(client);
            GetSomeThingsAsync(client);
            FailToGetAThingAsync(client);

            Thread.Sleep(30 * 1000);
        }

        private static void GetAThing(Client<Thing> client)
        {
            Message("Getting a Thing");
            var thing = client.Show();
            Message("Got a Thing");
        }

        private static async void GetAThingAsync(Client<Thing> client)
        {
            AsyncMessage("Getting a Thing");
            var thing = await client.ShowAsync();
            AsyncMessage("Got a Thing");
        }

        private static void GetSomeThings(Client<Thing> client)
        {
            Message("Getting some Things");
            var things = client.Index();
            Message("Got some Things");
        }

        private static async void GetSomeThingsAsync(Client<Thing> client)
        {
            AsyncMessage("Getting some Things");
            var things = await client.IndexAsync();
            AsyncMessage("Got some Things");
        }

        private static void FailToGetAThing(Client<Thing> client)
        {
            try
            {
                Message("Trying to get a Thing");
                var thing = client.Fail();
                Message("Got a Thing"); // Should never happen...
            }
            catch (Exception ex)
            {
                Message(ex.Message);
            }
        }

        private static async void FailToGetAThingAsync(Client<Thing> client)
        {
            try
            {
                AsyncMessage("Trying to get a Thing");
                var thing = await client.FailAsync();
                AsyncMessage("Got a Thing"); // Should never happen...
            }
            catch (Exception ex)
            {
                AsyncMessage(ex.Message);
            }
        }

        private static void Message(string message)
        {
            Console.WriteLine("[{0}] {1}", DateTime.Now, message);
        }

        private static void AsyncMessage(string message)
        {
            Console.WriteLine("[{0} (ASYNC)] {1}", DateTime.Now, message);
        }
    }
}
