using System;
using System.Windows.Controls;

namespace GTimer
{
   public partial class CountdownTimerView : UserControl
   {
      public CountdownTimerView(CountdownTimerViewModel viewModel)
      {
         this.InitializeComponent();
         DataContext = viewModel;
      }
   }
}