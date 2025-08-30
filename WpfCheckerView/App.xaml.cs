using System.Configuration;
using System.Data;
using System.Windows;
using SystemConfigChecker;

namespace WpfCheckerView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            try
            {
                //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF5cXmVCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdgWXZfd3RSRGhZVkxxVko="); 23.1.36
                //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF5cWWJCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWX5dcHRSQ2hdU0J2WUo="); 28.1.41
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NNaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXpfcnRXQmBcWEd1XUBWYUA=");


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering Syncfusion license: {ex.Message}", "License Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            var datas= Program.GetSystemConfig();
        }
    }

}
