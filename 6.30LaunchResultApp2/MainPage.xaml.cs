using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _6._30LaunchResultApp2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Test();
        }

        public async void Test() {
            string x = await LaunchAppForResults();
            Debug.WriteLine(x);
        }

        public async Task<string> LaunchAppForResults()
        {
            var testAppUri = new Uri("test-app2app:"); // The protocol handled by the launched app
            var options = new LauncherOptions();
            
            options.TargetApplicationPackageFamilyName = "b28ed3ce-a523-49f4-a46f-ef5b8f91ad1d_a1691p6wrfp9c";

            var inputData = new ValueSet();
            inputData["TestData"] = "Test data";

            string theResult = "";
            LaunchUriResult result = await Windows.System.Launcher.LaunchUriForResultsAsync(testAppUri, options, inputData);
            if (result.Status == LaunchUriStatus.Success &&
                result.Result != null &&
                result.Result.ContainsKey("ReturnedData"))
            {
                ValueSet theValues = result.Result;
                theResult = theValues["ReturnedData"] as string;
            }
            return theResult;
        }
    }

   
}
