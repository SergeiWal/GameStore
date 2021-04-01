using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameStore.Commands
{
    class HomeCommands
    {
        static HomeCommands()
        {
            GenreSort = new RoutedCommand("GenreSort", typeof(MainWindow));
        }
        public static RoutedCommand GenreSort { get; set; }
    }
}
