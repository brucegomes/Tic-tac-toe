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

namespace gomesbhw5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ImageBrush circle { get; private set; }
        public ImageBrush cross { get; private set; }


        public String winner { get; set; }
        Random randomGen;
        private CpuTurn cpuTurn;
        private CheckVictory chkVictory;
        public bool cpuMode { get; private set; }
        public int playerTurn { get; private set; }
        public bool firstPlay { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            initializeBrushes();
            disableAllonStart();
        }

        private void disableAllonStart()
        {
            a1.IsEnabled = false;
            a2.IsEnabled = false;
            a3.IsEnabled = false;
            b1.IsEnabled = false;
            b2.IsEnabled = false;
            b3.IsEnabled = false;
            c1.IsEnabled = false;
            c2.IsEnabled = false;
            c3.IsEnabled = false;
            resetBtn.IsEnabled = false;
            humanRadioBtn.IsChecked = true;
            cpuRadioBtn.IsChecked = false;
            tossBtn.IsEnabled = true;
            firstPlay = true;
           
        }

        private void initializeBrushes()
        {
            this.circle = new ImageBrush();
            circle.ImageSource = new BitmapImage(new Uri(@"circle.png", UriKind.Relative));
            this.cross = new ImageBrush();
            cross.ImageSource = new BitmapImage(new Uri(@"x.jpg", UriKind.Relative));

            randomGen = new Random();
            cpuTurn = new CpuTurn(this);
            chkVictory = new CheckVictory(this);
        }


        private void a1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            playLogic(a1);
            
        }
        private void a2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            playLogic(a2);
        }

        private void a3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            playLogic(a3);
        }

        private void b1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            playLogic(b1);
        }

        private void b2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            playLogic(b2);
        }

        private void b3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            playLogic(b3);
        }

        private void c1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            playLogic(c1);
        }

        private void c2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            playLogic(c2);
        }

        private void c3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            playLogic(c3);
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            // clear all
            SolidColorBrush brushDefault = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF362525"));
            a1.Resources.Clear();
            a2.Resources.Clear();
            a3.Resources.Clear();
            b1.Resources.Clear();
            b2.Resources.Clear();
            b3.Resources.Clear();
            c1.Resources.Clear();
            c2.Resources.Clear();
            c3.Resources.Clear();

            a1.Fill = brushDefault;
            a2.Fill = brushDefault;
            a3.Fill = brushDefault;
            b1.Fill = brushDefault;
            b2.Fill = brushDefault;
            b3.Fill = brushDefault;
            c1.Fill = brushDefault;
            c2.Fill = brushDefault;
            c3.Fill = brushDefault;

            resetBtn.IsEnabled = false;
            resetMenu.IsEnabled = false;
            tossBtn.IsEnabled = true;
            menuToss.IsEnabled = true;
            toggleRects(true);
            statusLabel.Content = "Toss to start again!!!";
            firstPlay = true;
        }

        private void humanRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            this.cpuMode = false;
            cpuRadioBtn.IsChecked = false;
        }

        private void cpuRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            this.cpuMode = true;
        }

        private void tossBtn_Click(object sender, RoutedEventArgs e)
        {

            int turn = randomGen.Next(1, 3);
            if (this.cpuMode == true)
            {
                if (turn == 1)
                {
                    statusLabel.Content = "CPU Turn";
                    this.cpuTurn.play();
                    statusLabel.Content = "Player Turn";
                }
                else
                    statusLabel.Content = "Player Turn";
            }
            else
            {
                if (turn == 1)
                {
                    statusLabel.Content = "Player 1 Turn";
                    this.playerTurn = 1;
                }
                else
                {
                    statusLabel.Content = "Player 2 Turn";
                    this.playerTurn = 2;
                }
            }

            toggleRects(true);
            tossBtn.IsEnabled = false;
            menuToss.IsEnabled = false;
            resetBtn.IsEnabled = true;
            resetMenu.IsEnabled = true;
        }

        public void toggleRects(bool toggle)
        {
            a1.IsEnabled = toggle;
            a2.IsEnabled = toggle;
            a3.IsEnabled = toggle;
            b1.IsEnabled = toggle;
            b2.IsEnabled = toggle;
            b3.IsEnabled = toggle;
            c1.IsEnabled = toggle;
            c2.IsEnabled = toggle;
            c3.IsEnabled = toggle;

        }

        public void playLogic(Rectangle x)
        {
            if (cpuMode)
            {
                x.Fill = cross;
                cpuTurn.play();
                statusLabel.Content = "Player's Turn";
            }
            else
            {
                if (playerTurn == 1)
                {
                    x.Fill = cross;
                    playerTurn = 2;
                    statusLabel.Content = "Player 2 Turn";
                }
                else
                {
                    x.Fill = circle;
                    playerTurn = 1;
                    statusLabel.Content = "Player 1 Turn";
                }
            }
            x.IsEnabled = false;
            if (this.firstPlay != true)
            {
                chkVictory.check();
                firstPlay = false;
            }
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void menuRules_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tic-Tac -Toe (along with a lot of other games) involves looking ahead\n " +
                "and trying to figure out what the person playing against you might do next", "Rules Of Tic Tac Toe",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void menuAboutMe_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bruce J Gomes","About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void menuFile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
