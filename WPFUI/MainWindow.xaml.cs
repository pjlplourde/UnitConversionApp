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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UnitConversionLibrary;

namespace WPFUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// Constructor for the MainWindow Class; calls the InitializeComponent method
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
			WireUpDimensionComboBox();
			inputQuantityTextBox.Focus();
		}

		private void WireUpDimensionComboBox()
		{
			dimensionComboBox.ItemsSource = Enum.GetValues(typeof(Dimension));
			dimensionComboBox.SelectedIndex = 0;
		}

		private void DimensionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Dimension selectedDimension = (Dimension)dimensionComboBox.SelectedItem;

			if (selectedDimension == Dimension.Length)
			{
				inputUnitComboBox.ItemsSource = Enum.GetValues(typeof(Length));
				inputUnitComboBox.SelectedIndex = 0;

				outputUnitComboBox.ItemsSource = Enum.GetValues(typeof(Length));
				outputUnitComboBox.SelectedIndex = 0;
			}
			else if (selectedDimension == Dimension.Mass)
			{
				inputUnitComboBox.ItemsSource = Enum.GetValues(typeof(Mass));
				inputUnitComboBox.SelectedIndex = 0;

				outputUnitComboBox.ItemsSource = Enum.GetValues(typeof(Mass));
				outputUnitComboBox.SelectedIndex = 0;
			}
			else if (selectedDimension == Dimension.Temperature)
			{
				inputUnitComboBox.ItemsSource = Enum.GetValues(typeof(Temperature));
				inputUnitComboBox.SelectedIndex = 0;

				outputUnitComboBox.ItemsSource = Enum.GetValues(typeof(Temperature));
				outputUnitComboBox.SelectedIndex = 0;
			}
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			dimensionComboBox.SelectedIndex = 0;
			inputQuantityTextBox.Clear();
			inputQuantityTextBox.Focus();
		}
	}
}
