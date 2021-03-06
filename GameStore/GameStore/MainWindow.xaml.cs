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
using System.Windows.Resources;

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
            LangState.GetState().Languege = Languege.EN;
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
                        GameCell gameCell = new GameCell(game, this);
                        Grid viewGameCell = gameCell.BuildCell();
                        DataSectionStack.Children.Add(viewGameCell);
                        currentGames.Add(game);
                    }
                }
            }
            else
            {
                foreach (var game in games)
                {
                    GameCell gameCell = new GameCell(game, this);
                    Grid viewGameCell = gameCell.BuildCell();
                    DataSectionStack.Children.Add(viewGameCell);
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
                GameCell gameCell = new GameCell(game, this);
                Grid viewGameCell = gameCell.BuildCell();
                DataSectionStack.Children.Add(viewGameCell);
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
        private void AddGame_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataUpdate dataUpdate = new DataUpdate();
            dataUpdate.Owner = this;
            dataUpdate.Show();
        }

        private void LangButton_Click(object sender, RoutedEventArgs e)
        {
            LangState langState = LangState.GetState();
            switch (langState.Languege)
            {
                case Languege.EN:
                    SetRuLocal(langState);
                    break;
                case Languege.RU:
                    SetEnLocal(langState);
                    break;
                default:
                    break;
            }
        }

        private void SetRuLocal(LangState langState)
        {
            langState.Languege = Languege.RU;
            LangButton.Text = "RU";
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/GameStore;component/RULocal.xaml", UriKind.Relative)};

            TableTitleText.Text = (string)this.TryFindResource("TableTitle");

            AllGames.Text = (string)this.TryFindResource("AllGameGenre");
            Action.Text = (string)this.TryFindResource("ActionGameGenre");
            Shooter.Text = (string)this.TryFindResource("ShooterGameGenre");
            Arcade.Text = (string)this.TryFindResource("ArcadeGameGenre");
            Fighting.Text = (string)this.TryFindResource("FightingGameGenre");
            Race.Text = (string)this.TryFindResource("RaceGameGenre");
            Simulator.Text = (string)this.TryFindResource("SimulatorGameGenre");
            RPG.Text = (string)this.TryFindResource("RpgGameGenre");
            Horror.Text = (string)this.TryFindResource("HorrorGameGenre");

            FilterPlaceTitle.Text = (string)this.TryFindResource("FilterTitle");
            ByName.Text = (string)this.TryFindResource("FilterByName");
            ByPrice.Text = (string)this.TryFindResource("FilterByPrice");
            ByRating.Text = (string)this.TryFindResource("FilterByPopularity");
            GroupButtonText.Text = (string)this.TryFindResource("CommandToFilter");
        }
        private void SetEnLocal(LangState langState)
        {
            langState.Languege = Languege.EN;
            LangButton.Text = "EN";
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/GameStore;component/ENLocal.xaml", UriKind.Relative) };

            TableTitleText.Text = (string)this.TryFindResource("TableTitle");

            AllGames.Text = (string)this.TryFindResource("AllGameGenre");
            Action.Text = (string)this.TryFindResource("ActionGameGenre");
            Shooter.Text = (string)this.TryFindResource("ShooterGameGenre");
            Arcade.Text = (string)this.TryFindResource("ArcadeGameGenre");
            Fighting.Text = (string)this.TryFindResource("FightingGameGenre");
            Race.Text = (string)this.TryFindResource("RaceGameGenre");
            Simulator.Text = (string)this.TryFindResource("SimulatorGameGenre");
            RPG.Text = (string)this.TryFindResource("RpgGameGenre");
            Horror.Text = (string)this.TryFindResource("HorrorGameGenre");

            FilterPlaceTitle.Text = (string)this.TryFindResource("FilterTitle");
            ByName.Text = (string)this.TryFindResource("FilterByName");
            ByPrice.Text = (string)this.TryFindResource("FilterByPrice");
            ByRating.Text = (string)this.TryFindResource("FilterByPopularity");
            GroupButtonText.Text = (string)this.TryFindResource("CommandToFilter");
        }
    }
}
