﻿using System;
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
using TodoAppMVVM.ViewModels;

namespace TodoAppMVVM.Views
{
    /// <summary>
    /// Interaction logic for CreateTodoView.xaml
    /// </summary>
    public partial class CreateTodoView : Window
    {
        public CreateTodoView()
        {
            InitializeComponent();
            Loaded += CreateTodoView_Loaded;
        }
        private void CreateTodoView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindows vm)
            {
                vm.Close += () =>
               {
                   this.Close();
               };
            }
        }
    }
}
