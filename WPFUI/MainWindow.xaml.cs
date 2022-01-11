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
using UnitConversionLibrary.Models;

namespace WPFUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		UnitConverter uc = new UnitConverter();
		List<Dimension> dimensions = new List<Dimension>() { Dimension.Length };
        List<LengthUnit> fromLengthUnits = new List<LengthUnit>() { LengthUnit.metres };
        List<LengthUnit> toLengthUnits = new List<LengthUnit>() { LengthUnit.centimetres, LengthUnit.miles,
            LengthUnit.yards, LengthUnit.feet, LengthUnit.inches };

        public MainWindow()
		{
			InitializeComponent();
			WireUpDimensionComboBox();
            WireUpInputUnitComboBox();
            WireUpOutputUnitComboBox();
			inputQuantityTextBox.Focus();
		}

		private void WireUpDimensionComboBox()
		{
			dimensionComboBox.ItemsSource = dimensions;
			dimensionComboBox.SelectedIndex = 0;
		}

        private void WireUpInputUnitComboBox()
        {
            inputUnitComboBox.ItemsSource = fromLengthUnits;
            inputUnitComboBox.SelectedIndex = 0;
        }

        private void WireUpOutputUnitComboBox()
        {
            outputUnitComboBox.ItemsSource = toLengthUnits;
            outputUnitComboBox.SelectedIndex = 0;
        }

		private void ConvertButton_Click(object sender, RoutedEventArgs e)
		{
			bool isValidInputQuantity = double.TryParse(inputQuantityTextBox.Text, out double inputQuantity);

            if (isValidInputQuantity == true)
            {
				LengthDataModel metres = new LengthDataModel() { Quantity = inputQuantity, Units = LengthUnit.metres };
				LengthUnit outputLengthUnit = (LengthUnit)outputUnitComboBox.SelectedItem;

				double result = uc.ConvertMetresToLengthUnits(metres, outputLengthUnit);
				resultsTextBlock.Text = result.ToString();
			}
            else
            {
				resultsTextBlock.Text = "Invalid input quantity.";
				inputQuantityTextBox.Clear();
            }
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			dimensionComboBox.SelectedIndex = 0;
			inputQuantityTextBox.Clear();
			resultsTextBlock.Text = "";
			inputQuantityTextBox.Focus();
		}
    }
}
