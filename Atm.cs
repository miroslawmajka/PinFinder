using System;

namespace PinFinder
{
    class Atm
    {
        private int Pin { get; set; }

        public void GeneratePin()
        {
            var rnd = new Random();

            Pin = rnd.Next(0, 9999);
        }

        public bool IsPinCorret(int pin)
        {
            return pin == Pin;
        }

        public bool IsCorrectPinHigher(int incorrectValue)
        {
            return incorrectValue < Pin;
        }

        public string GetPinViewNotSafe()
        {
            return Pin.ToString("D4");
        }
    }
}
