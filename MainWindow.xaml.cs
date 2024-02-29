using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace WpfDataTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<object> Items { get; set; } = new();
        public MainWindow()
        {
            InitializeComponent();
            Items.Add(new Cat { Name = "Мурзик I", Image = File.ReadAllBytes("1.png") });
            Items.Add(new MichaelДжексон
            {
                Songs = new List<Song>(new Song[]{
                        new Song{ Title = "Can’t Get Outta the Rain"},
                        new Song{ Title = "Can’t Let Her Get Away"},
                        new Song{ Title = "Carousel"},
                        new Song{ Title = "Centipede (бэк-вокал)"},
                        new Song{ Title = "Cheater"},
                        new Song{ Title = "Chicago"},
                        new Song{ Title = "Childhood"},
                        new Song{ Title = "Cinderella Stay Awhile"},
                        new Song{ Title = "Come Together"},
                        new Song{ Title = "Cry"},
                        new Song{ Title = "D.S."},
                        new Song{ Title = "Dangerous"},
                        new Song{ Title = "Dapper-Dan"},
                        new Song{ Title = "Dirty Diana"},
                        new Song{ Title = "Do the Bartman (бэк-вокал)"},
                        new Song{ Title = "Do You Know Where Your Children Are"},
                        new Song{ Title = "Doggin' Around"},
                        new Song{ Title = "Don’t Be Messin' 'Round"},
                        new Song{ Title = "Don’t Let a Woman (Make a Fool Out of You)"} })
            });
            Items.Add(new Cat { Name = "Мурзик II", Image = File.ReadAllBytes("2.png") });
            DataContext = this;
            // шаблоны для элементов списка
            // для создания шаблонов для определенных типов данных
            // используется запись типа <DataTemplate DataType="{x:Type targetType}">
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var song = (Song)button.Tag;
            song.Rating++;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }

    public class Cat
    {
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }

    public class MichaelДжексон
    {
        public List<Song> Songs { get; set; } = new();
    }

    public class Song : INotifyPropertyChanged
    {
        private int rating;

        public string Title { get; set; }
        public int Rating {
            get => rating;
            set
            {
                rating = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Rating)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}




















