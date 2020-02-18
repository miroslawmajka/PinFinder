using System;
using System.Collections.Generic;
using System.Linq;

namespace PinFinder
{
    class Program
    {
        private static List<int> runs = new List<int>();

        static void Main(string[] args)
        {
            for (var i = 0; i < 100; i++)
            {
                RunAtmHack();
            }

            foreach(var attemps in runs)
            {
                Console.WriteLine($"Took {attemps} attempts to find PIN in run");
            }

            Console.WriteLine($"Average {runs.Average()} attempts to find PIN per run");
        }

        private static void RunAtmHack()
        {
            Console.WriteLine("PIN Finder");
            Console.WriteLine("Allowed values: 0000 - 9999");

            var atm = new Atm();

            atm.GeneratePin();

            Console.WriteLine($"Actual PIN to find: {atm.GetPinViewNotSafe()}");

            var pinHacker = new PinHacker();

            Console.WriteLine($"Current proposed value: {pinHacker.GetCurrentPinText()}");

            int attempt = 0;

            while (!atm.IsPinCorret(pinHacker.CurrentPin))
            {
                attempt++;

                Console.WriteLine($"Finding PIN, attemp {attempt}...");

                pinHacker.SetNextValue(atm.IsCorrectPinHigher(pinHacker.CurrentPin));

                Console.WriteLine($"Current proposed value: {pinHacker.GetCurrentPinText()}");
            }

            Console.WriteLine($"Found PIN after {attempt} attempts");

            runs.Add(attempt);
        }
    }
}
