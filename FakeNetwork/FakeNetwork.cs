using System;
using System.Net;
using System.Threading;

namespace Utilities
{
    public static class Network
    {
        private static int _minimum = 1 * 1000;

        public static int Minimum
        {
            get { return _minimum; }
            set { _minimum = value; }
        }

        private static int _maximum = 5 * 1000;

        public static int Maximum
        {
            get { return _maximum; }
            set { _maximum = value; }
        }

        public static void FakeDelay()
        {
            var random = RandomHelper.Instance;
            var sleepTime = random.Next(_minimum, _maximum);

            Thread.Sleep(sleepTime);
        }

        public static WebException GetRandomWebException()
        {
            return new WebException(
                "Something bad has happened on the network",
                GetRandomWebExceptionStatus());
        }

        private static WebExceptionStatus GetRandomWebExceptionStatus()
        {
            var random = RandomHelper.Instance;
            var values = Enum.GetValues(typeof(WebExceptionStatus));
            var index = random.Next(values.Length - 1);

            return (WebExceptionStatus) values.GetValue(index);
        }
    }
}
