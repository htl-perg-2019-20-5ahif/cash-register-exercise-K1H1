using CashRegister.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CashRegister.UICore
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
		public partial class MainWindow : Window
		{
			private readonly MainWindowViewModel ViewModel;

			public MainWindow()
			{
				InitializeComponent();

				// Set the data context for data binding
				DataContext = ViewModel = new MainWindowViewModel();

				// When the view has been loaded, give the view model
				// a chance to initialize.
				Loaded += async (_, __) => await ViewModel.InitAsync();
			}
		}
	}
}
