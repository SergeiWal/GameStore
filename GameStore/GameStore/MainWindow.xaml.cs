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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameStore.DataWork;


namespace GameStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Game game = new Game();
            //game.FullName = "Assassin Creed 3";
            //game.Image = "D:\\GIT\\GameStore\\GameStore\\GameStore\\images\\AS3.jpg";
            //Grid gameCell = GameCell.BuildCell(game);
            //DataSectionStack.Children.Add(gameCell);
            DisplayAllGames();
        }

       public void DisplayAllGames()
       {
            List<Game> games = GameDataService.FindAll();
            foreach (var game in games)
            {
                Grid gameCell = GameCell.BuildCell(game);
                DataSectionStack.Children.Add(gameCell);
            }
       }

       
    }
}
