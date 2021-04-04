using GameStore.DataWork;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace GameStore
{
    /// <summary>
    /// Логика взаимодействия для DataUpdate.xaml
    /// </summary>
    public partial class DataUpdate : Window
    {

        public string Path { get; set; } = "";

        public DataUpdate()
        {
            InitializeComponent();
            FieldsInit();
        }

        private void FieldsInit()
        {
            LangState langState = LangState.GetState();
            switch (langState.Languege)
            {
                case Languege.EN:
                    SetEnLocal(langState);
                    break;
                case Languege.RU:
                    SetRuLocal(langState);
                    break;
                default:
                    break;
            }
        }
        private void SetRuLocal(LangState langState)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/GameStore;component/RULocal.xaml", UriKind.Relative) };

            NameLabel.Text = (string)this.TryFindResource("DataUpdateName");
            SmallNameLabel.Text = (string)this.TryFindResource("DataUpdateSmallName");
            DeveloperLabel.Text = (string)this.TryFindResource("DataUpdateDeveloper");
            GenreLabel.Text = (string)this.TryFindResource("DataUpdateGenre");
            ImageLabel.Text = (string)this.TryFindResource("DataUpdateImage");
            RatingLabel.Text = (string)this.TryFindResource("DataUpdateRating");
            PriceLabel.Text = (string)this.TryFindResource("DataUpdatePrice");
            DescriptionLabel.Text = (string)this.TryFindResource("DataUpdateDescription");
            OSLabel.Text = (string)this.TryFindResource("DataUpdateOS");
            ProcessorLabel.Text = (string)this.TryFindResource("DataUpdateProcessor");
            RAMLabel.Text = (string)this.TryFindResource("DataUpdateRAM");
            FreeMemoryLabel.Text = (string)this.TryFindResource("DataUpdateFreeMemory");
            ExitButton.Content = (string)this.TryFindResource("DataUpdateExitButton");
            EnterButton.Content = (string)this.TryFindResource("DataUpdateEnterButton");
            ImageButton.Content = (string)this.TryFindResource("DataUpdateImageButton");

        }
        private void SetEnLocal(LangState langState)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/GameStore;component/ENLocal.xaml", UriKind.Relative) };

            NameLabel.Text = (string)this.TryFindResource("DataUpdateName");
            SmallNameLabel.Text = (string)this.TryFindResource("DataUpdateSmallName");
            DeveloperLabel.Text = (string)this.TryFindResource("DataUpdateDeveloper");
            GenreLabel.Text = (string)this.TryFindResource("DataUpdateGenre");
            ImageLabel.Text = (string)this.TryFindResource("DataUpdateImage");
            RatingLabel.Text = (string)this.TryFindResource("DataUpdateRating");
            PriceLabel.Text = (string)this.TryFindResource("DataUpdatePrice");
            DescriptionLabel.Text = (string)this.TryFindResource("DataUpdateDescription");
            OSLabel.Text = (string)this.TryFindResource("DataUpdateOS");
            ProcessorLabel.Text = (string)this.TryFindResource("DataUpdateProcessor");
            RAMLabel.Text = (string)this.TryFindResource("DataUpdateRAM");
            FreeMemoryLabel.Text = (string)this.TryFindResource("DataUpdateFreeMemory");
            ExitButton.Content = (string)this.TryFindResource("DataUpdateExitButton");
            EnterButton.Content = (string)this.TryFindResource("DataUpdateEnterButton");
            ImageButton.Content = (string)this.TryFindResource("DataUpdateImageButton");
        }

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
        private void Image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @"D:\GIT";

            if (openFileDialog.ShowDialog() == true)
            {
                Path = openFileDialog.FileName;
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                GameDataService.AddGame(CreateGame());
                this.Close();
            }
            else
            {
                MessageBox.Show("Please write all fields ...");
            }
        }
        private Game CreateGame()
        {
            Game game = new Game();
            game.FullName = Name.Text;
            game.SmallName = SmallName.Text;
            game.Image = Path;
            game.Genre = StringToGenre(Genre.Text);
            game.Developer = Developer.Text;
            game.Price = Convert.ToInt32(Price.Text);
            game.Rating = Convert.ToInt32(Rating.Text);
            game.Description = Description.Text;
            game.SystemRequirements = new SystemRequirements();
            game.SystemRequirements.OS = OS.Text;
            game.SystemRequirements.Processor = Processor.Text;
            game.SystemRequirements.RAM = Convert.ToInt32(RAM.Text);
            game.SystemRequirements.FreeMemory = Convert.ToInt32(FreeMemory.Text);
            return game;
        }
        private bool IsValid()
        {
            return Name.Text.Length > 0 && SmallName.Text.Length > 0 && Developer.Text.Length > 0 &&
                Genre.SelectedItem != null && Path.Length > 0 && OS.Text.Length > 0 && Processor.Text.Length > 0 &&
                RAM.Text.Length > 0 && FreeMemory.Text.Length > 0 && Rating.Text.Length > 0 && Price.Text.Length > 0;
        }
        private Genre StringToGenre(string genre)
        {
            switch (genre)
            {
                case "action": return GameStore.Genre.ACTION;
                case "race": return GameStore.Genre.RACE;
                case "rpg": return GameStore.Genre.RPG;
                case "shooter": return GameStore.Genre.SHOOTER;
                case "simulator": return GameStore.Genre.SIMULATOR;
                case "horror": return GameStore.Genre.HORROR;
                case "arcade": return GameStore.Genre.ARCADE;
                case "fighting": return GameStore.Genre.FIGHTING;
                default:
                    return GameStore.Genre.ALL;
            }
        }
    }
}
