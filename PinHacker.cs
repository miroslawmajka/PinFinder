namespace PinFinder
{
    class PinHacker
    {
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 9999;
        private const int START_VALUE = 4999;

        public int CurrentPin { get; private set; } = START_VALUE;

        private int lastMinValue = MIN_VALUE;
        private int lastMaxValue = MAX_VALUE;

        public string GetCurrentPinText()
        {
            return $"{CurrentPin.ToString("D4")}";
        }

        public bool Matches(int randomPin)
        {
            return randomPin == CurrentPin;
        }

        public void SetNextValue(bool higher)
        {
             if (higher)
            {
                lastMinValue = CurrentPin;
            }
            else
            {
                lastMaxValue = CurrentPin;
            }

            CurrentPin = (lastMaxValue + lastMinValue) / 2;
        }
    }
}
