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
	/// <summary>
	/// UnitConverterTests Class contains the Unit Test Methods to test the UniverConverterClass
	/// </summary>
	public class UnitConverterTests
	{
		/// <summary>
		/// Tests the UnitConverter.Convert method applied to Length Units to ensure correct conversions
		/// </summary>
		/// <param name="inputQuantity">The quantity for the simulated input data model</param>
		/// <param name="significantDigits">The number of significant digits for the quantity in the simulated input data model</param>
		/// <param name="inputUnit">The units for the simulated input data model</param>
		/// <param name="outputUnit">The desired output units</param>
		/// <param name="expectedQuantity">The expected quantity in the simulated output data model if the conversion is correctly performed</param>
		/// <param name="expectedSignificantDigits">The expected significant digits in the simulated output data model if the conversion is correctly performed</param>
		[Theory]
		[InlineData(1.00, 3, Length.metres, Length.metres, 1.00, 3)]
		[InlineData(1.00, 3, Length.metres, Length.centimetres, 100.0, 3)]
		[InlineData(1.00, 3, Length.metres, Length.miles, 0.0002071237307, 3)]
		[InlineData(1.00, 3, Length.metres, Length.yards, 1.093613298, 3)]
		[InlineData(1.00, 3, Length.metres, Length.feet, 3.280939895, 3)]
		[InlineData(1.00, 3, Length.metres, Length.inches, 39.37007874, 3)]
		[InlineData(1.00, 3, Length.centimetres, Length.metres, 0.0100, 3)]
		[InlineData(1.00, 3, Length.centimetres, Length.centimetres, 1.00, 3)]
		[InlineData(1.00, 3, Length.centimetres, Length.miles, 0.000002071237307, 3)]
		[InlineData(1.00, 3, Length.centimetres, Length.yards, 0.01093613298, 3)]
		[InlineData(1.00, 3, Length.centimetres, Length.feet, 0.3280939895, 3)]
		[InlineData(1.00, 3, Length.centimetres, Length.inches, 0.3937007874, 3)]
		[InlineData(1.00, 3, Length.miles, Length.metres, 1609.344, 3)]
		[InlineData(1.00, 3, Length.miles, Length.centimetres, 160934.4, 3)]
		[InlineData(1.00, 3, Length.miles, Length.miles, 1.00, 3)]
		[InlineData(1.00, 3, Length.miles, Length.yards, 1760.0, 3)]
		[InlineData(1.00, 3, Length.miles, Length.feet, 5280.0, 3)]
		[InlineData(1.00, 3, Length.miles, Length.inches, 63360.0, 3)]
		[InlineData(1.00, 3, Length.yards, Length.metres, 0.9144, 3)]
		[InlineData(1.00, 3, Length.yards, Length.centimetres, 91.44, 3)]
		[InlineData(1.00, 3, Length.yards, Length.miles, 0.0005681818182, 3)]
		[InlineData(1.00, 3, Length.yards, Length.yards, 1.00, 3)]
		[InlineData(1.00, 3, Length.yards, Length.feet, 3.00, 3)]
		[InlineData(1.00, 3, Length.yards, Length.inches, 36.0, 3)]
		[InlineData(1.00, 3, Length.feet, Length.metres, 0.3048, 3)]
		[InlineData(1.00, 3, Length.feet, Length.centimetres, 30.48, 3)]
		[InlineData(1.00, 3, Length.feet, Length.miles, 0.0001893939394, 3)]
		[InlineData(1.00, 3, Length.feet, Length.yards, 0.3333333333, 3)]
		[InlineData(1.00, 3, Length.feet, Length.feet, 1.00, 3)]
		[InlineData(1.00, 3, Length.feet, Length.inches, 12.0, 3)]
		[InlineData(1.00, 3, Length.inches, Length.metres, 0.0254, 3)]
		[InlineData(1.00, 3, Length.inches, Length.centimetres, 2.54, 3)]
		[InlineData(1.00, 3, Length.inches, Length.miles, 0.00001578282828, 3)]
		[InlineData(1.00, 3, Length.inches, Length.yards, 0.02777777778, 3)]
		[InlineData(1.00, 3, Length.inches, Length.feet, 0.08333333333, 3)]
		[InlineData(1.00, 3, Length.inches, Length.inches, 1.00, 3)]
		public void ConvertLengthShouldReturnExpectedValue(double inputQuantity, int significantDigits, Length inputUnit, Length outputUnit, double expectedQuantity, int expectedSignificantDigits)
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

		/// <summary>
		/// Tests the UnitConverter.Convert method applied to Length Units to ensure ArgumentExceptions are correctly thrown
		/// </summary>
		/// <param name="selectedDimension">The input selectedDimension passed to the Convert method</param>
		/// <param name="outputUnitDimension">The Dimension of the output unit to be passed to the Convert method</param>
		/// <param name="paramName">The expected parameter name to be contained in the thrown Argument Exception</param>
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
				Units = Length.metres
			};
			Length lengthOutputUnit = Length.metres;
			Mass massOutputUnit = Mass.kilograms;
			Temperature temperatureOutputUnit = Temperature.Kelvin;

			// Act
			//Assert
			switch ( outputUnitDimension ) {
				case Dimension.Length:
					_ = Assert.Throws<ArgumentException>(paramName, () => converter.Convert(selectedDimension, sampleData, lengthOutputUnit));
					break;
				case Dimension.Mass:
					_ = Assert.Throws<ArgumentException>(paramName, () => converter.Convert(selectedDimension, sampleData, massOutputUnit));
					break;
				case Dimension.Temperature:
					_ = Assert.Throws<ArgumentException>(paramName, () => converter.Convert(selectedDimension, sampleData, temperatureOutputUnit));
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Tests the UnitConverter.Convert method applied to Mass Units to ensure correct conversions
		/// </summary>
		/// <param name="inputQuantity">The quantity for the simulated input data model</param>
		/// <param name="significantDigits">The number of significant digits for the quantity in the simulated input data model</param>
		/// <param name="inputUnit">The units for the simulated input data model</param>
		/// <param name="outputUnit">The desired output units</param>
		/// <param name="expectedQuantity">The expected quantity in the simulated output data model if the conversion is correctly performed</param>
		/// <param name="expectedSignificantDigits">The expected significant digits in the simulated output data model if the conversion is correctly performed</param>
		[Theory]
		[InlineData(1.00, 3, Mass.kilograms, Mass.kilograms, 1.00, 3)]
		[InlineData(1.00, 3, Mass.kilograms, Mass.grams, 1000.00, 3)]
		[InlineData(1.00, 3, Mass.kilograms, Mass.pounds, 2.204622622, 3)]
		[InlineData(1.00, 3, Mass.kilograms, Mass.ounces, 35.27396195, 3)]
		[InlineData(1.00, 3, Mass.kilograms, Mass.slugs, 0.06852176278, 3)]
		[InlineData(1.00, 3, Mass.grams, Mass.kilograms, 0.00100, 3)]
		[InlineData(1.00, 3, Mass.grams, Mass.grams, 1.00, 3)]
		[InlineData(1.00, 3, Mass.grams, Mass.pounds, 0.002204622622, 3)]
		[InlineData(1.00, 3, Mass.grams, Mass.ounces, 0.03527396195, 3)]
		[InlineData(1.00, 3, Mass.grams, Mass.slugs, 0.00006852176278, 3)]
		[InlineData(1.00, 3, Mass.pounds, Mass.kilograms, 0.45359237, 3)]
		[InlineData(1.00, 3, Mass.pounds, Mass.grams, 453.59237, 3)]
		[InlineData(1.00, 3, Mass.pounds, Mass.pounds, 1.00, 3)]
		[InlineData(1.00, 3, Mass.pounds, Mass.ounces, 16.0, 3)]
		[InlineData(1.00, 3, Mass.pounds, Mass.slugs, 0.03108094878, 3)]
		[InlineData(1.00, 3, Mass.ounces, Mass.kilograms, 0.02834952313, 3)]
		[InlineData(1.00, 3, Mass.ounces, Mass.grams, 28.34952313, 3)]
		[InlineData(1.00, 3, Mass.ounces, Mass.pounds, 0.0625, 3)]
		[InlineData(1.00, 3, Mass.ounces, Mass.ounces, 1.00, 3)]
		[InlineData(1.00, 3, Mass.ounces, Mass.slugs, 0.001942559299, 3)]
		[InlineData(1.00, 3, Mass.slugs, Mass.kilograms, 14.59390359, 3)]
		[InlineData(1.00, 3, Mass.slugs, Mass.grams, 14593.90359, 3)]
		[InlineData(1.00, 3, Mass.slugs, Mass.pounds, 32.17405, 3)]
		[InlineData(1.00, 3, Mass.slugs, Mass.ounces, 514.7848, 3)]
		[InlineData(1.00, 3, Mass.slugs, Mass.slugs, 1.00, 3)]
		public void ConvertMassShouldReturnExpectedValue(double inputQuantity, int significantDigits, Mass inputUnit, Mass outputUnit, double expectedQuantity, int expectedSignificantDigits)
		{
			// Arrange
			UnitConverter converter = new UnitConverter();
			MassDataModel input = new MassDataModel
			{
				Quantity = inputQuantity,
				SignificantDigits = significantDigits,
				Units = inputUnit
			};

			// Act
			MassDataModel actual = converter.Convert(Dimension.Mass, input, outputUnit);

			// Assert
			Assert.Equal(expectedQuantity, actual.Quantity);
			Assert.Equal(expectedSignificantDigits, actual.SignificantDigits);
			Assert.Equal(outputUnit, actual.Units);
		}

		/// <summary>
		/// Tests the UnitConverter.Convert method applied to Mass Units to ensure ArgumentExceptions are correctly thrown
		/// </summary>
		/// <param name="selectedDimension">The input selectedDimension passed to the Convert method</param>
		/// <param name="outputUnitDimension">The Dimension of the output unit to be passed to the Convert method</param>
		/// <param name="paramName">The expected parameter name to be contained in the thrown Argument Exception</param>
		[Theory]
		[InlineData(Dimension.Length, Dimension.Length, "dataModel")]
		[InlineData(Dimension.Length, Dimension.Mass, "dataModel")]
		[InlineData(Dimension.Length, Dimension.Temperature, "dataModel")]
		[InlineData(Dimension.Mass, Dimension.Length, "outputUnit")]
		[InlineData(Dimension.Mass, Dimension.Temperature, "outputUnit")]
		[InlineData(Dimension.Temperature, Dimension.Length, "dataModel")]
		[InlineData(Dimension.Temperature, Dimension.Mass, "dataModel")]
		[InlineData(Dimension.Temperature, Dimension.Temperature, "dataModel")]
		public void ConvertMassDataModelShouldThrowArgumentException(Dimension selectedDimension, Dimension outputUnitDimension, string paramName)
		{
			// Arrange
			UnitConverter converter = new UnitConverter();
			MassDataModel sampleData = new MassDataModel
			{
				Quantity = 1.00,
				SignificantDigits = 3,
				Units = Mass.kilograms
			};
			Length lengthOutputUnit = Length.metres;
			Mass massOutputUnit = Mass.kilograms;
			Temperature temperatureOutputUnit = Temperature.Kelvin;

			// Act
			//Assert
			switch ( outputUnitDimension )
			{
				case Dimension.Length:
					_ = Assert.Throws<ArgumentException>(paramName, () => converter.Convert(selectedDimension, sampleData, lengthOutputUnit));
					break;
				case Dimension.Mass:
					_ = Assert.Throws<ArgumentException>(paramName, () => converter.Convert(selectedDimension, sampleData, massOutputUnit));
					break;
				case Dimension.Temperature:
					_ = Assert.Throws<ArgumentException>(paramName, () => converter.Convert(selectedDimension, sampleData, temperatureOutputUnit));
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Tests the UnitConverter.Convert method applied to Temperature Units to ensure correct conversions
		/// </summary>
		/// <param name="inputQuantity">The quantity for the simulated input data model</param>
		/// <param name="significantDigits">The number of significant digits for the quantity in the simulated input data model</param>
		/// <param name="inputUnit">The units for the simulated input data model</param>
		/// <param name="outputUnit">The desired output units</param>
		/// <param name="expectedQuantity">The expected quantity in the simulated output data model if the conversion is correctly performed</param>
		/// <param name="expectedSignificantDigits">The expected significant digits in the simulated output data model if the conversion is correctly performed</param>
		[Theory]
		[InlineData(1.00, 3, Temperature.DegreesCelsius, Temperature.DegreesCelsius, 1.00, 3)]
		[InlineData(1.00, 3, Temperature.DegreesCelsius, Temperature.DegreesFahrenheit, 33.80, 4)]
		[InlineData(1.00, 3, Temperature.DegreesCelsius, Temperature.Kelvin, 274.15, 5)]
		[InlineData(1.00, 3, Temperature.DegreesFahrenheit, Temperature.DegreesCelsius, -17.22222222, 4)]
		[InlineData(1.00, 3, Temperature.DegreesFahrenheit, Temperature.DegreesFahrenheit, 1.00, 3)]
		[InlineData(1.00, 3, Temperature.DegreesFahrenheit, Temperature.Kelvin, 255.9277778, 5)]
		[InlineData(1.00, 3, Temperature.Kelvin, Temperature.DegreesCelsius, -272.15, 5)]
		[InlineData(1.00, 3, Temperature.Kelvin, Temperature.DegreesFahrenheit, -457.87, 5)]
		[InlineData(1.00, 3, Temperature.Kelvin, Temperature.Kelvin, 1.00, 3)]
		public void ConvertTemperatureShouldReturnExpectedValue(double inputQuantity, int significantDigits, Temperature inputUnit, Temperature outputUnit, double expectedQuantity, int expectedSignificantDigits)
		{
			// Arrange
			UnitConverter converter = new UnitConverter();
			TemperatureDataModel input = new TemperatureDataModel
			{
				Quantity = inputQuantity,
				SignificantDigits = significantDigits,
				Units = inputUnit
			};

			// Act
			TemperatureDataModel actual = converter.Convert(Dimension.Temperature, input, outputUnit);

			// Assert
			Assert.Equal(expectedQuantity, actual.Quantity);
			Assert.Equal(expectedSignificantDigits, actual.SignificantDigits);
			Assert.Equal(outputUnit, actual.Units);
		}

		/// <summary>
		/// Tests the UnitConverter.Convert method applied to Temperature Units to ensure ArgumentExceptions are correctly thrown
		/// </summary>
		/// <param name="selectedDimension">The input selectedDimension passed to the Convert method</param>
		/// <param name="outputUnitDimension">The Dimension of the output unit to be passed to the Convert method</param>
		/// <param name="paramName">The expected parameter name to be contained in the thrown Argument Exception</param>
		[Theory]
		[InlineData(Dimension.Length, Dimension.Length, "dataModel")]
		[InlineData(Dimension.Length, Dimension.Mass, "dataModel")]
		[InlineData(Dimension.Length, Dimension.Temperature, "dataModel")]
		[InlineData(Dimension.Mass, Dimension.Length, "dataModel")]
		[InlineData(Dimension.Mass, Dimension.Mass, "dataModel")]
		[InlineData(Dimension.Mass, Dimension.Temperature, "dataModel")]
		[InlineData(Dimension.Temperature, Dimension.Length, "outputUnit")]
		[InlineData(Dimension.Temperature, Dimension.Mass, "outputUnit")]
		public void ConvertTemperatureDataModelShouldThrowArgumentException(Dimension selectedDimension, Dimension outputUnitDimension, string paramName)
		{
			// Arrange
			UnitConverter converter = new UnitConverter();
			TemperatureDataModel sampleData = new TemperatureDataModel
			{
				Quantity = 1.00,
				SignificantDigits = 3,
				Units = Temperature.Kelvin
			};
			Length lengthOutputUnit = Length.metres;
			Mass massOutputUnit = Mass.kilograms;
			Temperature temperatureOutputUnit = Temperature.Kelvin;

			// Act
			//Assert
			switch ( outputUnitDimension )
			{
				case Dimension.Length:
					_ = Assert.Throws<ArgumentException>(paramName, () => converter.Convert(selectedDimension, sampleData, lengthOutputUnit));
					break;
				case Dimension.Mass:
					_ = Assert.Throws<ArgumentException>(paramName, () => converter.Convert(selectedDimension, sampleData, massOutputUnit));
					break;
				case Dimension.Temperature:
					_ = Assert.Throws<ArgumentException>(paramName, () => converter.Convert(selectedDimension, sampleData, temperatureOutputUnit));
					break;
				default:
					break;
			}
		}
	}
}
