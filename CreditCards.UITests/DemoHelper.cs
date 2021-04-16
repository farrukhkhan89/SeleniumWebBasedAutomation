using System.Threading;

namespace CreditCards.UITests
{
    public class DemoHelper
    {
        public static void Pause(int secondsToPause=3000)
        {
            Thread.Sleep(secondsToPause);
        }
    }
}
