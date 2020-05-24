using System.Media;
using System.Windows;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Maakt dat aangenaam geluidje
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"Resources\GameSound.wav";
            player.PlayLooping();

            InitializeComponent();
        }
    }
}
