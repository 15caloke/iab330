using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.Util;
using Amazon;
using Foundation;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;
using UIKit;
using Xamarin.Forms;
using Amazon.S3;

namespace StoragePal1.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
			DependencyService.Register<FilePathiOS>();
			DependencyService.Register<ISQLitePlatform, SQLitePlatformIOS>();
			LoadApplication(new App());
			var loggingConfig = AWSConfigs.LoggingConfig;
			loggingConfig.LogMetrics = true;
			loggingConfig.LogResponses = ResponseLoggingOption.Always;
			loggingConfig.LogMetricsFormat = LogMetricsFormatOption.JSON;
			loggingConfig.LogTo = LoggingOptions.SystemDiagnostics;
			return base.FinishedLaunching(app, options);
            AWSConfigs.AWSRegion = "us-east-1";
            Amazon.Runtime.AWSCredentials credentials = null;
            IAmazonS3 s3Client = new AmazonS3Client(credentials, RegionEndpoint.USEast1);
			var proxyConfig = AWSConfigs.ProxyConfig;
			proxyConfig.Host = "localhost";
			proxyConfig.Port = 80;
			proxyConfig.Username = "<username>";
			proxyConfig.Password = "<password>";
            AWSConfigs.CorrectForClockSkew = true;
            var offset = AWSConfigs.ClockOffset;
        }
    }
}
