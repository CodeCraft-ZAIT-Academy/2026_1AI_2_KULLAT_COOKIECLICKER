using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Cookie_clicker
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer _secTimer;
        private DispatcherTimer _fiveSecTimer;
        double AktualnyPocetCookies = 0;
        double upgrady = 0;
        double curzorcena = 10;
        double babka = 100;
        double banauscena = 1000;
        private Random rnd = new Random();
        

        public MainWindow()
        {
            InitializeComponent();
            _secTimer = new DispatcherTimer();
            _secTimer.Interval = TimeSpan.FromSeconds(1);
            _secTimer.Tick += SecTimer_Tick;
            _secTimer.Start();

            _fiveSecTimer = new DispatcherTimer();
            _fiveSecTimer.Interval = TimeSpan.FromSeconds(60);
            _fiveSecTimer.Tick += FiveSecTimer_Tick;
            _fiveSecTimer.Start();

            btnBabka.Content = "Babka " + babka;
            Curzorbtn.Content = "Kurzor " + curzorcena;
            btnBana.Content = "Baňa " + banauscena;
        }

        private void SecTimer_Tick(object sender, EventArgs e)
        {
            AktualnyPocetCookies++;
            AktualnyPocetCookies += upgrady;

           
            AktualnyPocetCookies = Math.Round(AktualnyPocetCookies, 1);

            pocetCookies.Text = AktualnyPocetCookies.ToString();
            double celkovoZaSec = 1 + upgrady;
            txtblockCPS.Text = "Za sekundu: " + Math.Round(celkovoZaSec, 1);
        }

        private void FiveSecTimer_Tick(object sender, EventArgs e)
        {
            int cislo = rnd.Next(1, 11);
            if (cislo == 1)
            {
                double Dvadsatpercent = AktualnyPocetCookies * 0.20;
                AktualnyPocetCookies = AktualnyPocetCookies - Dvadsatpercent;

                
                AktualnyPocetCookies = Math.Round(AktualnyPocetCookies, 1);
                pocetCookies.Text = AktualnyPocetCookies.ToString();

                MessageBox.Show("Monstrum ti zjedlo susienky");
            }
            else
            {
                MessageBox.Show("Mas stastie monstrum ti susienky neukradlo");
            }
        }

        private void Cookie_btn_Click(object sender, RoutedEventArgs e)
        {
            AktualnyPocetCookies++;
            
            pocetCookies.Text = AktualnyPocetCookies.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AktualnyPocetCookies >= curzorcena)
            {
                AktualnyPocetCookies = AktualnyPocetCookies - curzorcena;
                AktualnyPocetCookies = Math.Round(AktualnyPocetCookies, 1);

                upgrady += 0.1;
                upgrady = Math.Round(upgrady, 1);

                curzorcena = curzorcena * 1.3;
                pocetCookies.Text = AktualnyPocetCookies.ToString();
                Curzorbtn.Content = "Curzor " + Math.Round(curzorcena, 1);
            }
            else
            {
                MessageBox.Show("Nedostatok susienok");
            }
        }
        
        private void btnBabka_Click(object sender, RoutedEventArgs e)
        {
            if (AktualnyPocetCookies >= babka)
            {
                AktualnyPocetCookies = AktualnyPocetCookies - babka;
                AktualnyPocetCookies = Math.Round(AktualnyPocetCookies, 1);

                upgrady += 1;
                babka = babka * 1.3;
                pocetCookies.Text = AktualnyPocetCookies.ToString();
                btnBabka.Content = "Babka " + Math.Round(babka, 1);
            }
            else
            {
                MessageBox.Show("Nedostatok susienok");
            }
        }

        private void btnBana_Click(object sender, RoutedEventArgs e)
        {
            if (AktualnyPocetCookies >= banauscena)
            {
                AktualnyPocetCookies = AktualnyPocetCookies - banauscena;
                AktualnyPocetCookies = Math.Round(AktualnyPocetCookies, 1);

                upgrady += 10;
                banauscena = banauscena * 1.3;
                pocetCookies.Text = AktualnyPocetCookies.ToString();
                btnBana.Content = "Baňa " + Math.Round(banauscena, 1);
            }
            else
            {
                MessageBox.Show("Nedostatok susienok");
            }
            
        }
        
       
    }
   
    
}