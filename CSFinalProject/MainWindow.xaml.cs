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

namespace CSFinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Galaxy _galaxy;
        DateAndTime _date;
        public MainWindow()
        {
            _date = new DateAndTime();
            _galaxy = new Galaxy();
            _galaxy.CreateNormalGalaxy();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new GalaxyWindow(_galaxy,_date);
            newWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var solar = _galaxy.SolarSystems[0];
            var newWindow = new SollarSystemWindow(_galaxy, solar, _date);
            newWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var solar = _galaxy.SolarSystems[1];
            var newWindow = new SollarSystemWindow(_galaxy,solar, _date);
            newWindow.Show();
        }
    }
}
