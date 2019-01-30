using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Plugin.BluetoothLE;
using CoreFoundation;


namespace Samples.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

            BleAdapterConfiguration adapterconfig = new BleAdapterConfiguration();
            adapterconfig.ShowPowerAlert = true;
            adapterconfig.DispatchQueue = new CoreFoundation.DispatchQueue("acrble");

            adapterconfig.RestoreIdentifier = "pluginbluetoothle";//fails when uncommented
            //adapterconfig.RestoreIdentifier = "acr";              //works fine
            //adapterconfig.RestoreIdentifier = "acr2";             //works fine
            //adapterconfig.RestoreIdentifier = "pluginbluetoothl"; //works fine
            //adapterconfig.RestoreIdentifier = "pluginbluetoothle2"; //works fine
            //adapterconfig.RestoreIdentifier = "pluginbluetoothl2"; //works fine


            CrossBleAdapter.Init(adapterconfig);

            this.LoadApplication(new App(new PlatformInitializer()));
            new Acr.XamForms.ItemTappedCommandBehavior();

            //UIApplication.SharedApplication.IdleTimerDisabled = false;
            return base.FinishedLaunching(app, options);
        }
    }
}
