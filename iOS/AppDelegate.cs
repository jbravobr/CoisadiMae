using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace CoisadiMae.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();


            UXDivers.Artina.Shared.GrialKit.Init(new ThemeColors(), "Sliphis.iOS.GrialLicense");
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
