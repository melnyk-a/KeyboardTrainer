using System;

namespace KeyboardTrainer.Models
{
    internal sealed class SpeedCalculator
    {
        private const int secondsInMinute = 60;
        private int actions = 0;
        private DateTime lastActionTime;
        private DateTime startTime;

        public void ActionDone()
        {
            lastActionTime = DateTime.Now;
            ++actions;
        }

        public void StartCounting()
        {
            startTime = DateTime.Now;
            actions = 0;
        }

        public void SecondPassed()
        {
            lastActionTime = DateTime.Now;
        }

        public double Speed
        {
            get=> Math.Round(secondsInMinute * actions / lastActionTime.Subtract(startTime).TotalSeconds);
        }
    }
}