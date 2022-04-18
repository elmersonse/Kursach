using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjE3ODU5QDMyMzAyZTMxMmUzME1pWHI0Qk9HZ0UzTUlrcWtkUVBReWxWMWVHNm1rN01sMnBET09EQkVCWEE9");
        }
    }
}
