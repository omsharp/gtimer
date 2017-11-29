using System;
using System.Windows.Controls;

namespace GTimer
{
   public partial class TimerSettingView : UserControl
   {
      CountdownTimerViewModel settingViewModel;

      public event EventHandler<TimeSpan> NewTimeSet;
      public event EventHandler Canceled;

      public TimerSettingView(CountdownTimerViewModel viewModel)
      {
         InitializeComponent();

         settingViewModel = viewModel;
         DataContext = settingViewModel;
      }

      private void ApplyButton_Click(object sender, System.Windows.RoutedEventArgs e)
      {
         var timeSpan = new TimeSpan(hoursControl.Value, minutesControl.Value, secondsControl.Value);

         if (timeSpan.TotalSeconds > 0)
            NewTimeSet?.Invoke(this, timeSpan);
      }

      private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
      {
         Canceled?.Invoke(this, EventArgs.Empty);
      }
   }
}
