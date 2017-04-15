using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using PropertyFinderAutomation.Extensions;

namespace PropertyFinderAutomation.Utilities
{
    public class Utilities
    {
        private static readonly Random Getrandom = new Random();
        private static readonly object SyncLock = new object();

        public static int GetRandomNumber(int min, int max)
        {
            lock (SyncLock)
            {
                // synchronize
                return Getrandom.Next(min, max);
            }
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            lock (SyncLock)
            {
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[Getrandom.Next(s.Length)]).ToArray());
            }
        }

        public static void SelectElementInList(IReadOnlyCollection<IWebElement> elements,string text)
        {
            foreach (IWebElement e in elements)
            {
                if (e.Text == text)
                {
                    e.ClickOnIt(e.Text);
                    break;
                }
            }
        }
    }
}

