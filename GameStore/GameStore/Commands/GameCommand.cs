using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameStore.Commands
{
    class GameCommand
    {
        static GameCommand()
        {
            View = new RoutedCommand("View", typeof(MainWindow));
            Add = new RoutedCommand("Add", typeof(MainWindow));
            Update = new RoutedCommand("Update", typeof(MainWindow));
            Delete = new RoutedCommand("Delete", typeof(MainWindow));
        }

        public static RoutedCommand View{get; set;}
        public static RoutedCommand Add { get; set;}
        public static RoutedCommand Update { get; set;}
        public static RoutedCommand Delete { get; set;}
    }
}
