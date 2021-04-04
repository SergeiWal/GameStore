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
    /// Логика взаимодействия для GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        public GameView()
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

            Name.Text = (string)this.TryFindResource("GameViewName");
            Developer.Text = (string)this.TryFindResource("GameViewDeveloper");
            Genre.Text = (string)this.TryFindResource("GameViewGenre");
            Rating.Text = (string)this.TryFindResource("GameViewRating");
            OS.Text = (string)this.TryFindResource("GameViewOS");
            Processor.Text = (string)this.TryFindResource("GameViewProcessor");
            RAM.Text = (string)this.TryFindResource("GameViewRAM");
            FreeMemory.Text = (string)this.TryFindResource("GameViewFreeMemory");

        }
        private void SetEnLocal(LangState langState)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/GameStore;component/ENLocal.xaml", UriKind.Relative) };

            Name.Text = (string)this.TryFindResource("GameViewName");
            Developer.Text = (string)this.TryFindResource("GameViewDeveloper");
            Genre.Text = (string)this.TryFindResource("GameViewGenre");
            Rating.Text = (string)this.TryFindResource("GameViewRating");
            OS.Text = (string)this.TryFindResource("GameViewOS");
            Processor.Text = (string)this.TryFindResource("GameViewProcessor");
            RAM.Text = (string)this.TryFindResource("GameViewRAM");
            FreeMemory.Text = (string)this.TryFindResource("GameViewFreeMemory");
        }
    }
}
