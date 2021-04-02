using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameStore
{
    static class GameCell
    {
        public static Grid BuildCell(Game game)
        {
            Grid grid = CreateGrid();
            grid.Children.Add(CreateImage(game));
            grid.Children.Add(CreateTextBlock(game));
            grid.Children.Add(CreateButtomPanel(game));
            return grid;
        }

        private static Grid CreateGrid()
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

        private static WrapPanel CreateButtomPanel(Game game)
        {
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Name = "ButtonPanel";
            wrapPanel.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetColumn(wrapPanel, 2);
            wrapPanel.Children.Add(CreateViewButtom(game));
            wrapPanel.Children.Add(CreateUpdateButtom(game));
            wrapPanel.Children.Add(CreateDeleteButtom(game));
            return wrapPanel;
        }

        private static Image CreateImage(Game game)
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

        private static TextBlock CreateTextBlock(Game game)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = game.FullName;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Margin = new Thickness(5, 2, 5, 2);
            Grid.SetColumn(textBlock, 1);
            Grid.SetRow(textBlock, 0);
            return textBlock;
        }

        private static Button CreateViewButtom(Game game)
        {
            Button button = new Button();
            button.Template = CreateStyleForButton();
            button.Width = 35;
            button.Height = 35;
            button.VerticalAlignment = VerticalAlignment.Center;
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.Margin = new Thickness(3);
            //Grid.SetColumn(button, 2);

            Image image = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(@"/GameStore;component/images/eye.png", UriKind.Relative);
            bi3.EndInit();
            image.Source = bi3;

            button.Content = image;

            return button;
        }

        private static Button CreateDeleteButtom(Game game)
        {
            Button button = new Button();
            button.Template = CreateStyleForButton();
            button.Width = 35;
            button.Height = 35;
            button.VerticalAlignment = VerticalAlignment.Center;
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.Margin = new Thickness(3);
            //Grid.SetColumn(button, 4);

            Image image = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(@"/GameStore;component/images/delete.png", UriKind.Relative);
            bi3.EndInit();
            image.Source = bi3;

            button.Content = image;

            return button;
        }

        private static Button CreateUpdateButtom(Game game)
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



        private static ControlTemplate CreateStyleForButton()
        {
            string controlTemplateBuf = "<ControlTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'" + " TargetType=\"Button\">\n<Grid>\n<Ellipse Fill = \"#427E8E\" ></Ellipse >\n" +
                             "<Label Content = \"{TemplateBinding Content}\" HorizontalAlignment = \"Center\" VerticalAlignment = \"Center\"></Label>\n" +
                        "</Grid ></ControlTemplate >";
            return (ControlTemplate)XamlReader.Parse(controlTemplateBuf);
        }
    }
}
