using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnitConversionLibrary;
using UnitConversionLibrary.Models;

using Xunit;

namespace UnitConversionLibrary.Tests
{
	public class UnitConverterTests
	{
		[Theory]
		[InlineData(1.00, 3, LengthUnit.metres, LengthUnit.metres, 1.00, 3)]
		[InlineData(1.00, 3, LengthUnit.metres, LengthUnit.centimetres, 100.0, 3)]
		[InlineData(1.00, 3, LengthUnit.metres, LengthUnit.miles, 0.0002071237307, 3)]
		[InlineData(1.00, 3, LengthUnit.metres, LengthUnit.yards, 1.093613298, 3)]
		[InlineData(1.00, 3, LengthUnit.metres, LengthUnit.feet, 3.280939895, 3)]
		[InlineData(1.00, 3, LengthUnit.metres, LengthUnit.inches, 39.37007874, 3)]
		[InlineData(1.00, 3, LengthUnit.centimetres, LengthUnit.metres, 0.0100, 3)]
		[InlineData(1.00, 3, LengthUnit.centimetres, LengthUnit.centimetres, 1.00, 3)]
		[InlineData(1.00, 3, LengthUnit.centimetres, LengthUnit.miles, 0.000002071237307, 3)]
		[InlineData(1.00, 3, LengthUnit.centimetres, LengthUnit.yards, 0.01093613298, 3)]
		[InlineData(1.00, 3, LengthUnit.centimetres, LengthUnit.feet, 0.3280939895, 3)]
		[InlineData(1.00, 3, LengthUnit.centimetres, LengthUnit.inches, 0.3937007874, 3)]
		[InlineData(1.00, 3, LengthUnit.miles, LengthUnit.metres, 1609.344, 3)]
		[InlineData(1.00, 3, LengthUnit.miles, LengthUnit.centimetres, 160934.4, 3)]
		[InlineData(1.00, 3, LengthUnit.miles, LengthUnit.miles, 1.00, 3)]
		[InlineData(1.00, 3, LengthUnit.miles, LengthUnit.yards, 1760.0, 3)]
		[InlineData(1.00, 3, LengthUnit.miles, LengthUnit.feet, 5280.0, 3)]
		[InlineData(1.00, 3, LengthUnit.miles, LengthUnit.inches, 63360.0, 3)]
		[InlineData(1.00, 3, LengthUnit.yards, LengthUnit.metres, 0.9144, 3)]
		[InlineData(1.00, 3, LengthUnit.yards, LengthUnit.centimetres, 91.44, 3)]
		[InlineData(1.00, 3, LengthUnit.yards, LengthUnit.miles, 0.0005681818182, 3)]
		[InlineData(1.00, 3, LengthUnit.yards, LengthUnit.yards, 1.00, 3)]
		[InlineData(1.00, 3, LengthUnit.yards, LengthUnit.feet, 3.00, 3)]
		[InlineData(1.00, 3, LengthUnit.yards, LengthUnit.inches, 36.0, 3)]
		[InlineData(1.00, 3, LengthUnit.feet, LengthUnit.metres, 0.3048, 3)]
		[InlineData(1.00, 3, LengthUnit.feet, LengthUnit.centimetres, 30.48, 3)]
		[InlineData(1.00, 3, LengthUnit.feet, LengthUnit.miles, 0.0001893939394, 3)]
		[InlineData(1.00, 3, LengthUnit.feet, LengthUnit.yards, 0.3333333333, 3)]
		[InlineData(1.00, 3, LengthUnit.feet, LengthUnit.feet, 1.00, 3)]
		[InlineData(1.00, 3, LengthUnit.feet, LengthUnit.inches, 12.0, 3)]
		[InlineData(1.00, 3, LengthUnit.inches, LengthUnit.metres, 0.0254, 3)]
		[InlineData(1.00, 3, LengthUnit.inches, LengthUnit.centimetres, 2.54, 3)]
		[InlineData(1.00, 3, LengthUnit.inches, LengthUnit.miles, 0.00001578282828, 3)]
		[InlineData(1.00, 3, LengthUnit.inches, LengthUnit.yards, 0.02777777778, 3)]
		[InlineData(1.00, 3, LengthUnit.inches, LengthUnit.feet, 0.08333333333, 3)]
		[InlineData(1.00, 3, LengthUnit.inches, LengthUnit.inches, 1.00, 3)]
		public void ConvertLengthShouldReturnExpectedValue(double inputQuantity, int significantDigits, LengthUnit inputUnit, LengthUnit outputUnit, double expectedQuantity, int expectedSignificantDigits)
		{
			// Arrange
			UnitConverter converter = new UnitConverter();
			LengthDataModel input = new LengthDataModel {
				Quantity = inputQuantity,
				SignificantDigits = significantDigits,
				Units = inputUnit
			};

			// Act
			LengthDataModel actual = converter.Convert(Dimension.Length, input, outputUnit);

			// Assert
			Assert.Equal(expectedQuantity, actual.Quantity);
			Assert.Equal(expectedSignificantDigits, actual.SignificantDigits);
			Assert.Equal(outputUnit, actual.Units);
		}

		[Theory]
		[InlineData(Dimension.Length, Dimension.Mass, "outputUnit")]
		[InlineData(Dimension.Length, Dimension.Temperature, "outputUnit")]
		[InlineData(Dimension.Mass, Dimension.Length, "dataModel")]
		[InlineData(Dimension.Mass, Dimension.Mass, "dataModel")]
		[InlineData(Dimension.Mass, Dimension.Temperature, "dataModel")]
		[InlineData(Dimension.Temperature, Dimension.Length, "dataModel")]
		[InlineData(Dimension.Temperature, Dimension.Mass, "dataModel")]
		[InlineData(Dimension.Temperature, Dimension.Temperature, "dataModel")]
		public void ConvertLengthDataModelShouldThrowArgumentException(Dimension selectedDimension, Dimension outputUnitDimension, string paramName)
		{
			// Arrange
			UnitConverter converter = new UnitConverter();
			LengthDataModel sampleData = new LengthDataModel {
				Quantity = 1.00,
				SignificantDigits = 3,
				Units = LengthUnit.metres
			};
			LengthUnit lengthOutputUnit = LengthUnit.metres;
			Mass massOutputUnit = Mass.kilograms;
			Temperature temperatureOutputUnit = Temperature.Kelvin;

			// Act
			//Assert
			switch ( outputUnitDimension ) {
				case Dimension.Length:
					Assert.Throws<ArgumentException>(paramName, () => converter.Convert(selectedDimension, sampleData, lengthOutputUnit));
					break;
				case Dimension.Mass:
					Assert.Throws<ArgumentException>(paramName, () => converter.Convert(selectedDimension, sampleData, massOutputUnit));
					break;
				case Dimension.Temperature:
					Assert.Throws<ArgumentException>(paramName, () => converter.Convert(selectedDimension, sampleData, temperatureOutputUnit));
					break;
				default:
					break;
			}
		}
	}
}
