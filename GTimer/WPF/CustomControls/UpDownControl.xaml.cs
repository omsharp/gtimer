using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GTimer
{
   [ContentProperty(nameof(Value))]
   public partial class UpDownControl : UserControl
   {
      public static readonly DependencyProperty ValueProperty =
          DependencyProperty.Register(nameof(Value), typeof(int), typeof(UpDownControl));

      public static readonly DependencyProperty LabelProperty =
         DependencyProperty.Register(nameof(Label), typeof(string), typeof(UpDownControl));

      public int Value
      {
         get { return (int)GetValue(ValueProperty); }
         set
         {
            SetValue(ValueProperty, value);
            valueTextBox.Text = value.ToString();
         }
      }

      public string Label
      {
         get { return GetValue(LabelProperty).ToString(); }
         set
         {
            SetValue(LabelProperty, value);
         }
      }

      public int Max { get; set; }
      public int Min { get; set; }

      public UpDownControl()
      {
         InitializeComponent();
      }

      private void UpButton_Click(object sender, RoutedEventArgs e)
      {
         if (Value >= Max)
            return;

         Value++;
      }

      private void DownButton_Click(object sender, RoutedEventArgs e)
      {
         if (Value <= Min)
            return;

         Value--;
      }

      private void ValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
      {
         int.TryParse(valueTextBox.Text, out var val);

         if (val < Min)
         {
            valueTextBox.Text = Min.ToString();
         }
         else if (val > Max)
         {
            valueTextBox.Text = Max.ToString();
         }
      }

      private void ValueTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
      {
         try
         {
            int.Parse(e.Text);
         }
         catch
         {
            e.Handled = true;
         }
      }

      private void ValueTextBox_LostFocus(object sender, RoutedEventArgs e)
      {
         if (valueTextBox.Text == string.Empty)
            valueTextBox.Text = "0";
      }
   }
}
