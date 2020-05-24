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

namespace tower
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Panel fromTower = null;
        Brush nonActive = new SolidColorBrush(Color.FromArgb(128, 0xCC, 0xCC, 0xCC));
        Brush Active = new SolidColorBrush(Color.FromArgb(128, 0xCC, 0x00, 0x00));
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tower_GotFocus(object sender, MouseEventArgs e)
        {
            if (!(sender is Panel))
                return;
            var toTower = (Panel)sender;
            if (fromTower == null)
            {
                if(toTower.Children.Count > 0)
                {
                    fromTower = toTower;
                    fromTower.Background = Active;
                }
            }
            else if(toTower == fromTower)
            {
                fromTower.Background = nonActive;
                fromTower = null;
            }
            else
            {
                var movingDisk = fromTower.Children[fromTower.Children.Count - 1];
                if (toTower.Children.Count == 0 ||
                    (movingDisk as Shape).Width < (toTower.Children[toTower.Children.Count-1] as Shape).Width)
                {
                    fromTower.Children.Remove(movingDisk);
                    toTower.Children.Add(movingDisk);
                    fromTower.Background = nonActive;
                    fromTower = null;
                }
                else
                {
                    MessageBox.Show("Неверный ход!");
                }
            }
        }
    }
}
