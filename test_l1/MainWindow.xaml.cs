using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using test_l1.clasy;
using test_l1.pages;

namespace test_l1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        public static Frame framePublic; //vytvoří veřejný frame 
        public static database _data;
        public MainWindow()
        {
            InitializeComponent();
              framePublic = frame;
            MainWindow.framePublic.Navigate(new Page1()); //přesmrování


        }
     
        public static database Data //nutná proměná pro přístup k databzi skopírujte celé akorát změňte název databaze to oranžové !! pozor má to nahoře ještě jeden řádek (řádek číslo 28)
        {
            get
            {
                if (_data == null)
                {
                    var fileHelper = new FileHelper();
                    _data = new database(fileHelper.GetLocalFilePath("knihySQLite.db3")); //
                }
                return _data;
            }
        }
    }
}
