using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace test_l1.pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public static ObservableCollection<trida> itemsFromDb; //založení observatyvní kolece
   
        public Page1()
        {
            InitializeComponent();
            itemsFromDb = new ObservableCollection<trida>(MainWindow.Data.GetItemsNotDoneAsync().Result); //vložení výsledů do kolekce 

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");//debug nechte tak jak je

            Debug.WriteLine(itemsFromDb.Count);
            foreach (trida todoItem in itemsFromDb)
            {
                Debug.WriteLine(todoItem);
            }

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            ListView.ItemsSource = itemsFromDb; //vložení kolekce do list view

        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.framePublic.Navigate(new Page2()); //přesměrování
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e) //po vybrání z náte z listview
        {
            if (ListView.SelectedItems.Count > 0) //nutná podmínka
            {

                trida todoItem = (trida)ListView.SelectedItems[0];       //vybere vybraný objekt z kolekce   
                //  id_cole = itemsFromDb.IndexOf(todoItem);           
                MainWindow.framePublic.Navigate(new Page2(todoItem)); //přeposlání s celým objektem 
            }
        }

        private void button_Click(object sender, RoutedEventArgs e) //vyhledávač
        {

            if (search.Text.Length == 10 && textBox.Text.Length == 3) 
            {
                if (MainWindow.Data.GetItemssearch(textBox.Text + search.Text).Result == null) //podmínka obsahující dotaz 
                {
                    er.Content = "Pro hledané položky neexistuje výsledek !!";
                    ListView.ItemsSource = "";
                }
                else
                {
                    string kombo = "978" + search.Text;
                    itemsFromDb = new ObservableCollection<trida>(MainWindow.Data.GetItemssearch(textBox.Text + search.Text).Result); //to samé vypsání do téé samé kolekce jako nahoře akorát s jiným dotazem v zavorkách za <trida>()

                    Debug.WriteLine("                             ");
                    Debug.WriteLine("                             ");
                    Debug.WriteLine("                             ");

                    Debug.WriteLine(itemsFromDb.Count);
                    foreach (trida todoItem in itemsFromDb)
                    {
                        Debug.WriteLine(todoItem);
                    }

                    Debug.WriteLine("                             ");
                    Debug.WriteLine("                             ");
                    Debug.WriteLine("                             ");

                    ListView.ItemsSource = itemsFromDb;
                }
           }else
           {
                er.Content = "Neplatné IBSN !!";
              
            }
        }
    }
}
