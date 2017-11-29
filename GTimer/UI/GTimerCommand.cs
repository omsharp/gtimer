using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio;

namespace GTimer
{
   internal sealed class GTimerCommand
   {
      public const int CmdId = 0x0100;

      public static readonly Guid CmdSet = new Guid("f2c43744-3e34-4c39-a132-bcd48fdb9349");

      private readonly Package package;

      private GTimerCommand(Package pkg)
      {
         package = pkg ?? throw new ArgumentNullException(nameof(pkg));

         var service = ServiceProvider.GetService(typeof(IMenuCommandService));
         if (service is OleMenuCommandService cmdService)
         {
            cmdService.AddCommand(
               new MenuCommand(ShowToolWindow, new CommandID(CmdSet, CmdId))
               );
         }
      }

      public static GTimerCommand Instance
      {
         get;
         private set;
      }

      private IServiceProvider ServiceProvider
      {
         get { return package; }
      }

      public static void Initialize(Package pkg)
      {
         Instance = new GTimerCommand(pkg);
      }

      private void ShowToolWindow(object sender, EventArgs e)
      {
         var window = package.FindToolWindow(
            toolWindowType: typeof(StopWatchWindow), 
            id: 0, 
            create: true
            );

         if (window == null || window.Frame == null)
            throw new NotSupportedException("Cannot create tool window");

         var windowFrame = (IVsWindowFrame)window.Frame;
         ErrorHandler.ThrowOnFailure(windowFrame.Show());
      }
   }
}
