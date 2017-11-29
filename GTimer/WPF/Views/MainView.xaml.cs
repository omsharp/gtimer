using System;
using System.Windows;
using System.Windows.Controls;

namespace GTimer
{
   public partial class MainView : UserControl
   {
      CountdownTimerViewModel timerViewModel;
      CountdownTimerView timerView;
      TimerSettingView settingView;
      
      public MainView()
      {
         InitializeComponent();

         timerViewModel = new CountdownTimerViewModel();
         timerView = new CountdownTimerView(timerViewModel);
         settingView = new TimerSettingView(timerViewModel);

         settingView.NewTimeSet += SettingView_NewTimeSet;
         settingView.Canceled += SettingView_Canceled;

         contentHolder.Content = timerView;
      }

      private void SettingView_Canceled(object sender, EventArgs e)
      {
         contentHolder.Content = timerView;
      }

      private void SettingView_NewTimeSet(object sender, TimeSpan e)
      {
         timerViewModel.SetCommand.Execute(e);
         contentHolder.Content = timerView;
      }

      private void TimerViewButton_Click(object sender, RoutedEventArgs e)
      {
         contentHolder.Content = timerView;
      }

      private void SettingViewButton_Click(object sender, RoutedEventArgs e)
      {
         contentHolder.Content = settingView;
      }
   }
}
