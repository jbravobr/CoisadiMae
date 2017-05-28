﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;

namespace CoisadiMae.Droid
{
    [Activity(Label = "Coisa di Mãe", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
			Acr.UserDialogs.UserDialogs.Init(() => (Activity)Forms.Context);
			UXDivers.Artina.Shared.GrialKit.Init(this, "CoisadiMae.Droid.GrialLicense");

            LoadApplication(new App());
        }
    }
}