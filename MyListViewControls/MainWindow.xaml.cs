/******************************************************************************/
/*                                                                            */
/*   Program: MyListViewControls                                              */
/*   Example for puting controls in ListView Colomns                          */
/*                                                                            */
/*   08.08.2016 0.0.0.0 uhwgmxorg Start                                       */
/*                                                                            */
/******************************************************************************/
using System.Windows;

namespace MyListViewControls
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
