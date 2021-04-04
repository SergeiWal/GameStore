using GameStore.DataWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameStore
{
    class GameCell
    {
        private Game game;
        private readonly MainWindow mainWindow;

        public Game getGame()
        {
            return game;
        }

        public GameCell(Game game, MainWindow mainWindow)
        {
            this.game = game;
            this.mainWindow = mainWindow;
        }

        public Grid BuildCell()
        {
            Grid grid = CreateGrid();
            grid.Children.Add(CreateImage());
            grid.Children.Add(CreateTextBlock());
            grid.Children.Add(CreateButtomPanel());
            return grid;
        }

        private Grid CreateGrid()
        {
            Grid grid = new Grid();
            grid.Background = new SolidColorBrush(Color.FromRgb(120, 151, 228));//#7897E4
            grid.Margin = new Thickness(5);

            ColumnDefinition column1 = new ColumnDefinition();
            ColumnDefinition column2 = new ColumnDefinition();
            ColumnDefinition column3 = new ColumnDefinition();
            column1.Width = new GridLength(1, GridUnitType.Star);
            column2.Width = new GridLength(4, GridUnitType.Star);
            column3.Width = new GridLength(3, GridUnitType.Star);
            RowDefinition row = new RowDefinition();
            row.Height = new GridLength(45, GridUnitType.Pixel);

            grid.ColumnDefinitions.Add(column1);
            grid.ColumnDefinitions.Add(column2);
            grid.ColumnDefinitions.Add(column3);
            grid.RowDefinitions.Add(row);
            return grid;
        }

        private WrapPanel CreateButtomPanel()
        {
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Name = "ButtonPanel";
            wrapPanel.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetColumn(wrapPanel, 2);
            wrapPanel.Children.Add(CreateViewButtom());
            wrapPanel.Children.Add(CreateUpdateButtom());
            wrapPanel.Children.Add(CreateDeleteButtom());
            return wrapPanel;
        }

        private Image CreateImage()
        {
            Image image = new Image();
            image.Margin = new Thickness(5);
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(game.Image, UriKind.Absolute);
            bi3.EndInit();
            image.Source = bi3;
            Grid.SetColumn(image, 0);
            Grid.SetRow(image, 0);
            return image;
        }

        private TextBlock CreateTextBlock()
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = game.FullName;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Margin = new Thickness(5, 2, 5, 2);
            Grid.SetColumn(textBlock, 1);
            Grid.SetRow(textBlock, 0);
            return textBlock;
        }

        private Button CreateViewButtom()
        {
            Button button = new Button();
            button.Template = CreateStyleForButton();
            button.Width = 35;
            button.Height = 35;
            button.VerticalAlignment = VerticalAlignment.Center;
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.Margin = new Thickness(3);
            button.Command = Commands.GameCommand.View;
            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = Commands.GameCommand.View;
            commandBinding.Executed += ViewGame_Executed;
            button.CommandBindings.Add(commandBinding);

            Image image = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(@"/GameStore;component/images/eye.png", UriKind.Relative);
            bi3.EndInit();
            image.Source = bi3;

            button.Content = image;

            return button;
        }

        private  Button CreateDeleteButtom()
        {
            Button button = new Button();
            button.Template = CreateStyleForButton();
            button.Width = 35;
            button.Height = 35;
            button.VerticalAlignment = VerticalAlignment.Center;
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.Margin = new Thickness(3);
            button.Command = Commands.GameCommand.Delete;
            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = Commands.GameCommand.Delete;
            commandBinding.Executed += DeleteGame_Executed;
            button.CommandBindings.Add(commandBinding);

            Image image = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(@"/GameStore;component/images/delete.png", UriKind.Relative);
            bi3.EndInit();
            image.Source = bi3;

            button.Content = image;

            return button;
        }

        private  Button CreateUpdateButtom()
        {
            Button button = new Button();
            button.Template = CreateStyleForButton();
            button.Width = 35;
            button.Height = 35;
            button.VerticalAlignment = VerticalAlignment.Center;
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.Margin = new Thickness(3);
            //Grid.SetColumn(button, 3);

            Image image = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(@"/GameStore;component/images/update.png", UriKind.Relative);
            bi3.EndInit();
            image.Source = bi3;

            button.Content = image;

            return button;
        }

        private ControlTemplate CreateStyleForButton()
        {
            string controlTemplateBuf = "<ControlTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'" + " TargetType=\"Button\">\n<Grid>\n<Ellipse Fill = \"#427E8E\" ></Ellipse >\n" +
                             "<Label Content = \"{TemplateBinding Content}\" HorizontalAlignment = \"Center\" VerticalAlignment = \"Center\"></Label>\n" +
                        "</Grid ></ControlTemplate >";
            return (ControlTemplate)XamlReader.Parse(controlTemplateBuf);
        }

        public void ViewGame_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameView gameView = new GameView();
            GameViewFieldInicalization(gameView);
            gameView.Show();
        }

        private void GameViewFieldInicalization(GameView gameView)
        {
            gameView.Owner = mainWindow;
            gameView.DescriptionText.Text = "Description:\n" + game.Description;
            gameView.GameName.Text = game.FullName;
            gameView.Price.Text = game.Price.ToString();
            gameView.Name.Text += game.SmallName;
            gameView.Developer.Text += game.Developer;
            gameView.Genre.Text += GenreToString(game.Genre);
            gameView.OS.Text += game.SystemRequirements.OS;
            gameView.Processor.Text += game.SystemRequirements.Processor;
            gameView.RAM.Text += game.SystemRequirements.RAM + "GB";
            gameView.FreeMemory.Text += game.SystemRequirements.FreeMemory + "GB";
            gameView.Rating.Text += game.Rating;
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(game.Image, UriKind.Absolute);
            bi3.EndInit();
            gameView.GameImage.Source = bi3;
        }

        private string GenreToString(Genre genre)
        {
            switch (genre)
            {
                case Genre.ACTION: return "action";
                case Genre.ARCADE: return "arcade";
                case Genre.FIGHTING: return "fighting";
                case Genre.HORROR: return "horror";
                case Genre.RPG: return "rpg";
                case Genre.RACE: return "race";
                case Genre.SIMULATOR: return "simulator";
                default:
                    return "";
            }
        }

        public void DeleteGame_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GameDataService.RemoveGame(game);
            mainWindow.DisplayGames();
        }
    }
}
