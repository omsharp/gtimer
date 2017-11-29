using System;
using System.Timers;

namespace GTimer
{
   public class CountdownTimer
   {
      private static readonly TimeSpan oneSecond = 
         new TimeSpan(hours: 0, minutes: 0, seconds: 1);

      private Timer timer;

      public TimeSpan TimeLeft { get; set; }

      public bool Running { get; private set; }

      public event EventHandler<TimerTickEventArgs> Tick;

      public CountdownTimer()
      {
         timer = new Timer
         {
            Interval = 1000,
            Enabled = true
         };

         timer.Stop();
         timer.Elapsed += Timer_Elapsed;
      }

      public void Start()
      {
         timer.Start();
         Running = true;
      }

      public void Stop()
      {
         timer.Stop();
         Running = false;
      }

      public void Set(TimeSpan time)
      {
         TimeLeft = time;
      }

      private void Timer_Elapsed(object sender, ElapsedEventArgs e)
      {
         var oldSecs = TimeLeft.TotalSeconds;

         if (TimeLeft.TotalSeconds > 0)
         {
            TimeLeft = TimeLeft.Subtract(oneSecond);
         }
         
         Tick?.Invoke(this, new TimerTickEventArgs(oldSecs - TimeLeft.TotalSeconds));
      }
   }

   public class TimerTickEventArgs : EventArgs
   {
      public double DeltaSeconds { get; }

      public TimerTickEventArgs(double delta)
      {
         DeltaSeconds = delta;
      }
   }
}