using Syncfusion.Windows.Tools.Controls;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
                EventManager.RegisterClassHandler(typeof(UIElement), UIElement.PreviewKeyDownEvent, new KeyEventHandler(Control_PreviewKeyDown));
                EventManager.RegisterClassHandler(typeof(UIElement), UIElement.KeyUpEvent, new KeyEventHandler(Control_KeyUp));
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



        private void Control_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
            var uie = e.OriginalSource as UIElement;

            if (e.Key == Key.Enter)
            {
                var zs = uie is ContentPresenter;
                var sd = e.Source is ContentPresenter;
                var zsgh= uie.GetType().ToString();
                if (uie is not Button && 
                    uie is not ButtonAdv &&
                    uie is not ComboBoxItemAdv &&
                    !(uie is TextBox && (e.Source is ComboBoxAdv || e.Source is ContentPresenter)))
                   {
                    e.Handled = true;
                    uie.MoveFocus(
                    new TraversalRequest(
                    FocusNavigationDirection.Next));
                }
            }
        }

        private void Control_KeyUp(object sender, KeyEventArgs e)
       {
            var uie = e.OriginalSource as UIElement;

            if (e.Key == Key.Enter)
            {
                if (
                    uie is ComboBoxAdv &&
                    uie is ComboBoxItemAdv)
                {
                    e.Handled = true;
                    uie.MoveFocus(
                    new TraversalRequest(
                    FocusNavigationDirection.Next));
                }
            }
        }
    }


}
