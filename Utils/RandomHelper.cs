using System;
using System.Linq;

namespace Utils
{
    public static class RandomHelper
    {
        private static Random random = new Random();
        public static string GetString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GetStringWithoutNums(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GetEmail() => $"{GetStringWithoutNums(10)}@{GetStringWithoutNums(5)}.{GetStringWithoutNums(3)}";
    }
}