using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        int ID_dat; //pomocná poměna pro uchování ID objektu s databáze 
        public Page2() //konstruktor funkce pokud nedochází k přenosu hodnoty
        {
            InitializeComponent();
            edit.Visibility = Visibility.Collapsed; //visibilita 
            smazat.Visibility = Visibility.Collapsed;
        }

        public Page2(trida x) { //konstruktor pokud je přenášena hodnota pomocí kraviny na přepínání x je celá třída (podobné tomu todo)
            InitializeComponent(); //anicializace je schválne dvakrát
                                 
                naz.Text = x.name; //přenesení hodnoty z prvků v databázy, který byl vybrán
                aut.Text = x.autor;
                isbn.Text = x.ISBN.ToString();
                str.Text = x.strany.ToString();
                ID_dat = x.ID;
                pridat.Visibility = Visibility.Collapsed; //visibilita
                edit.Visibility = Visibility.Visible;
                smazat.Visibility = Visibility.Visible;
           
        }

        private void pridat_Click(object sender, RoutedEventArgs e) //funkce po buttonu nový
        {
            add(); //funkce deklarovaná níže
           
        }

        private void add() //funkce pro přidání
        {
            trida item = new trida(); //založí novou třídu, tak jak si zvyklí
            
                if(isbn.Text.Length == 10 && isbn2.Text.Length == 3) //skontroluje delku stringů
                {
                    
                        item.ISBN = isbn2.Text +isbn.Text; //vložení hodnot s textboxů do třidy kterou zakládáš
                        item.name = naz.Text;
                        item.autor = aut.Text;
                        item.strany = Int32.Parse(str.Text);

                        MainWindow.Data.SaveItemAsync(item); //provede uložení do DB (Mainvindow tam je schválně protože proměná data je v Mainvindow
                        Page1.itemsFromDb.Add(item); //přidá nové itemy do kolekce aby byly real time přeneseny do listviwe
                        MainWindow.framePublic.Navigate(new Page1()); //přesměrování
                   
                }
               else
                {
                    error.Content = "Špatně ISBN";
                }
                
                
            
        }
        public void clear_textbox() //vyčití textboxy aby při tlačítu zpět tam pro přístě nic nebylo, tato funkce je pak dále použita
        {
            naz.Text = "";
            aut.Text = "";
            isbn2.Text = "978";
            isbn.Text = "";
            str.Text = "";

        }

        private void back_Click(object sender, RoutedEventArgs e) //tlačítko zpět
        {
            clear_textbox(); //viz víše
            MainWindow.framePublic.Navigate(new Page1());
        }

        private void smazat_Click(object sender, RoutedEventArgs e  //tlačítko pro mazání
        {
            delete(); //funkce delte
            MainWindow.framePublic.Navigate(new Page1());
        }

        private void edit_Click(object sender, RoutedEventArgs e) //editační tlačítko ombinuje funkci delete a přidat v tomto případě nutné v tomto pořadí 
        {
            add();
            delete();
        }

        private void num(object sender, TextCompositionEventArgs e) //kravina na oveření čísel - nepuživejte
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void delete() //funkce delete
        {
            MainWindow.Data.DeleteItemAsync(ID_dat); //použije defici delete a použijese přenesené id
            clear_textbox(); //vyčistí textbox 
        }
    }
}
