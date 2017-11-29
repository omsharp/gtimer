using System;
using System.ComponentModel;
using System.Media;
using System.Windows.Input;

namespace GTimer
{
   public class CountdownTimerViewModel : INotifyPropertyChanged
   {
      private readonly CountdownTimer timer;
      private bool flash;

      public ICommand StartCommand { get; private set; }
      public ICommand StopCommand { get; private set; }
      public ICommand SetCommand { get; private set; }

      public event PropertyChangedEventHandler PropertyChanged;
      
      public TimeSpan TimeLeft
      {
         get { return timer.TimeLeft; }
      }

      public bool Flash
      {
         get
         {
            return flash;
         }

         private set
         {
            if (flash != value)
            {
               flash = value;
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Flash)));
            }
         }
      }

      public CountdownTimerViewModel()
      {
         timer = new CountdownTimer();
         timer.Tick += Timer_Tick;

         StartCommand = new RelayCommand(timer.Start, () => !timer.Running && timer.TimeLeft.TotalSeconds > 0);
         StopCommand = new RelayCommand(Stop, () => timer.Running);
         SetCommand = new RelayCommand<TimeSpan>(Set, () => !timer.Running);
      }

      private void Set(TimeSpan time)
      {
         timer.Set(time);
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeLeft)));
      }

      private void Stop()
      {
         timer.Stop();
         Flash = false;
      }

      private void Timer_Tick(object sender, TimerTickEventArgs e)
      {
         if (e.DeltaSeconds > 0)
         {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeLeft)));
         }
         else
         {
            Flash = !Flash;
            SystemSounds.Hand.Play();
         }
      }
   }
}