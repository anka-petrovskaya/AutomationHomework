using System;

namespace EntryTasks.Task1
{
    public class Revert
    {
        public string[] RevertArray(string[] array)
        {
            var newArray = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = ReverseString(array[i]);
            }
            return newArray;
        }
        public void ShowResult(string[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
        }
        public static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}