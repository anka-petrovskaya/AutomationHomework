using System;

namespace Utils
{
    public class Wait
    {
        public static void RetryUntilTrue(Action method, Func<bool> retryCondition, int timer = 40)
        {
            DateTime start = DateTime.UtcNow;
            while (!retryCondition() && DateTime.UtcNow.Subtract(start).Seconds < timer)
                method.Invoke();
        }
        public static void Until(Func<bool> retryAction, int timer = 60)
        {
            DateTime start = DateTime.UtcNow;
            while (!retryAction() && DateTime.UtcNow.Subtract(start).Seconds < timer)
                retryAction.Invoke();
        }
    }
}