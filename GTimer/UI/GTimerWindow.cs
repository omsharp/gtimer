using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace GTimer
{
   [Guid("b1f82b03-65db-4d96-b112-8d26776a7df5")]
   public class StopWatchWindow : ToolWindowPane
   {
      public StopWatchWindow() : base(null)
      {
         Caption = "G-Timer";
         Content = new MainView();
      }
   }
}
