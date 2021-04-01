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
        private List<Game> currentGames;

        public MainWindow()
        {
            InitializeComponent();
            currentGames = new List<Game>();
            DisplayGames();
        }

        private void GenreSort_All_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DisplayGames();
        }
        private void GenreSort_Action_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DisplayGames(Genre.ACTION);
        }
        private void GenreSort_Shooter_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DisplayGames(Genre.SHOOTER);
        }
        private void GenreSort_Arcade_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DisplayGames(Genre.ARCADE);
        }
        private void GenreSort_RPG_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DisplayGames(Genre.RPG);
        }
        private void GenreSort_Horror_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DisplayGames(Genre.HORROR);
        }
        private void GenreSort_Fighting_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DisplayGames(Genre.FIGHTING);
        }
        private void GenreSort_Simulator_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DisplayGames(Genre.SIMULATOR);
        }
        private void GenreSort_Race_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DisplayGames(Genre.RACE);
        }

        public void DisplayGames(Genre genre = Genre.ALL)
        {
            List<Game> games = GameDataService.FindAll();

            currentGames.Clear();
            DataSectionStack.Children.Clear();

            if (genre != Genre.ALL)
            {
                foreach (var game in games)
                {
                    if (game.Genre == genre)
                    {
                        Grid gameCell = GameCell.BuildCell(game);
                        DataSectionStack.Children.Add(gameCell);
                        currentGames.Add(game);
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
                currentGames = games;
            }
        }

        private void Filters_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (ByPoplarityButton.IsChecked == true)
            {
                SortByPopularity();
                PrintCurrentGames();
                ByPoplarityButton.IsChecked = false;
            }
            else if (ByNameButton.IsChecked == true)
            {
                SortByName();
                PrintCurrentGames();
                ByNameButton.IsChecked = false;
            }
            else if (ByPriceButton.IsChecked == true)
            {
                SortByPrice();
                PrintCurrentGames();
                ByPriceButton.IsChecked = false;
            }
            else 
            {
                MessageBox.Show("Please, choose type for filter...");
            }
        }

        private void SortByPopularity()
        {
            currentGames.Sort((n,q)=> 
            {
                if (n.Rating < q.Rating)
                    return 1;
                else if (n.Rating > q.Rating)
                    return -1;
                else return 0;
            });
        }
        private void SortByName()
        {
            currentGames.Sort((n, q) =>
            {
                if (n.FullName.First() > q.FullName.First())
                    return 1;
                else if (n.FullName.First() < q.FullName.First())
                    return -1;
                else return 0;
            });
        }
        private void SortByPrice()
        {
            currentGames.Sort((n, q) =>
            {
                if (n.Price > q.Price)
                    return 1;
                else if (n.Price < q.Price)
                    return -1;
                else return 0;
            });
        }
        private void PrintCurrentGames()
        {
            DataSectionStack.Children.Clear();
            foreach (var game in currentGames)
            {
                Grid gameCell = GameCell.BuildCell(game);
                DataSectionStack.Children.Add(gameCell);
            }
        }

        private void Find_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string findName = FindBar.Text;

            DataSectionStack.Children.Clear();
            currentGames.Clear();
            currentGames = GameDataService.FindByName(findName);

            if (currentGames != null && currentGames.Count > 0)
            {
                PrintCurrentGames();
            }
        }
    }
}
