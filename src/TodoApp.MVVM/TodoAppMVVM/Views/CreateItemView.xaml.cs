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
using TodoApp.MVVM.EventCommands;

namespace TodoAppMVVM.Views
{
    /// <summary>
    /// Interaction logic for CreateItemView.xaml
    /// </summary>
    public partial class CreateItemView : Window
    {
        public CreateItemView()
        {
            InitializeComponent();
            Loaded += CreateItemView_Loaded;
        }
        private void CreateItemView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is IVisibilityCommand vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
    }
}
