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
using GameStore.Commands;


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
            DisplayGames();
        }

        private void GenreSort_All_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataSectionStack.Children.Clear();
            DisplayGames();
        }
        private void GenreSort_Action_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataSectionStack.Children.Clear();
            DisplayGames(Genre.ACTION);
        }
        private void GenreSort_Shooter_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataSectionStack.Children.Clear();
            DisplayGames(Genre.SHOOTER);
        }
        private void GenreSort_Arcade_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataSectionStack.Children.Clear();
            DisplayGames(Genre.ARCADE);
        }
        private void GenreSort_RPG_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataSectionStack.Children.Clear();
            DisplayGames(Genre.RPG);
        }
        private void GenreSort_Horror_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataSectionStack.Children.Clear();
            DisplayGames(Genre.HORROR);
        }
        private void GenreSort_Fighting_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataSectionStack.Children.Clear();
            DisplayGames(Genre.FIGHTING);
        }
        private void GenreSort_Simulator_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataSectionStack.Children.Clear();
            DisplayGames(Genre.SIMULATOR);
        }
        private void GenreSort_Race_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataSectionStack.Children.Clear();
            DisplayGames(Genre.RACE);
        }

        public void DisplayGames(Genre genre = Genre.ALL)
        {
            List<Game> games = GameDataService.FindAll();
            if (genre != Genre.ALL)
            {
                foreach (var game in games)
                {
                    if (game.Genre == genre)
                    {
                        Grid gameCell = GameCell.BuildCell(game);
                        DataSectionStack.Children.Add(gameCell);
                    }
                }
            }
            else
            {
                foreach (var game in games)
                {
                    Grid gameCell = GameCell.BuildCell(game);
                    DataSectionStack.Children.Add(gameCell);
                }
            }
        }
    }
}
