using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace GTimer
{
   [PackageRegistration(UseManagedResourcesOnly = true)]
   [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
   [ProvideMenuResource("Menus.ctmenu", 1)]
   [ProvideToolWindow(typeof(StopWatchWindow))]
   [Guid(GTimerPackage.PackageGuidString)]
   [SuppressMessage(
      "StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly",
      Justification = "pkgdef, VS and vsixmanifest are valid VS terms"
   )]
   public sealed class GTimerPackage : Package
   {
      public const string PackageGuidString = "871639cc-6d70-4d62-9581-3e01f1e7ebbe";

      #region Package Members

      protected override void Initialize()
      {
         GTimerCommand.Initialize(this);
         base.Initialize();
      }

      #endregion
   }
}
