using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnitConversionLibrary.Models;

namespace UnitConversionLibrary
{
	/// <summary>
	/// The UnitConverter Class contains the logic to convert between different units
	/// </summary>
	public class UnitConverter
	{
		/// <summary>
		/// The Convert method triages to the appropriate private method based on the Dimension input in the dimension parameter, takes in the result of the conversion, and passes it back to the caller as a Data Model of the same type as the input Data Model
		/// </summary>
		/// <typeparam name="T">The type of data model (length, mass, temperature) that is to be input and returned; must match the input Dimension</typeparam>
		/// <typeparam name="U">The type of the desired output unit for the conversion; must be of the same Dimension type as the input Data Model and the input Dimension</typeparam>
		/// <param name="dimension">The Dimension (length, mass, temperature) for the units to be converted</param>
		/// <param name="dataModel">The data model to be converted, which contains the quantity, significant digits, and unit properties; must be of the same Dimension type as the input Dimension</param>
		/// <param name="outputUnit">The desired output unit for the conversion; must be of the same Dimension type as the input Data Model and the input Dimension</param>
		/// <returns>A converted data model, which contains the quantity, significant digits, and unit properties; will be of the same Dimension type as the input Dimension and will be the same type as the input data model</returns>
		/// <exception cref="ArgumentException">An ArgumentException will be thrown if there is a data type mismatch between the type of the outputUnit and the input Dimension or between the type of the input dataModel and the input Dimension</exception>
		public T Convert<T, U>(Dimension dimension, T dataModel, U outputUnit)
		{
			throw new NotImplementedException();

			//T output;

			//switch ( dimension ) {
			//	case Dimension.Length:
			//		if ( dataModel is LengthDataModel lengthDataModel && outputUnit is Length lengthOutputUnit ) {
			//			output = (T)(object)ConvertLength(lengthDataModel, lengthOutputUnit);
			//		} else if ( dataModel is LengthDataModel ) {
			//			throw new ArgumentException($"Data Type Mismatch: {typeof(U)} does not correspond to the selected dimension {dimension}.", nameof(outputUnit));
			//		} else if ( outputUnit is Length ) {
			//			throw new ArgumentException($"Data Type Mismatch: {typeof(T)} does not correspond to the selected dimension {dimension}.", nameof(dataModel));
			//		} else {
			//			throw new ArgumentException($"Data Type Mismatch: {typeof(T)} or {typeof(U)} does not correspond to the selected dimension {dimension}.");
			//		}

			//		break;
			//	case Dimension.Mass:
			//		if ( dataModel is MassDataModel massDataModel && outputUnit is Mass massOutputUnit ) {
			//			output = (T)(object)ConvertMass(massDataModel, massOutputUnit);
			//		} else if ( dataModel is MassDataModel ) {
			//			throw new ArgumentException($"Data Type Mismatch: {typeof(U)} does not correspond to the selected dimension {dimension}.", nameof(outputUnit));
			//		} else if ( outputUnit is Mass ) {
			//			throw new ArgumentException($"Data Type Mismatch: {typeof(T)} does not correspond to the selected dimension {dimension}.", nameof(dataModel));
			//		} else {
			//			throw new ArgumentException($"Data Type Mismatch: {typeof(T)} or {typeof(U)} does not correspond to the selected dimension {dimension}.");
			//		}

			//		break;
			//	case Dimension.Temperature:
			//		if ( dataModel is TemperatureDataModel temperatureDataModel && outputUnit is Temperature temperatureOutputUnit ) {
			//			output = (T)(object)ConvertTemperature(temperatureDataModel, temperatureOutputUnit);
			//		} else if ( dataModel is TemperatureDataModel ) {
			//			throw new ArgumentException($"Data Type Mismatch: {typeof(U)} does not correspond to the selected dimension {dimension}.", nameof(outputUnit));
			//		} else if ( outputUnit is Temperature ) {
			//			throw new ArgumentException($"Data Type Mismatch: {typeof(T)} does not correspond to the selected dimension {dimension}.", nameof(dataModel));
			//		} else {
			//			throw new ArgumentException($"Data Type Mismatch: {typeof(T)} or {typeof(U)} does not correspond to the selected dimension {dimension}.");
			//		}

			//		break;
			//	default:
			//		throw new ArgumentException($"Invalid Data Type: {typeof(T)} cannot be converted to {typeof(U)}.", nameof(dataModel));
			//}

			//return output;
		}

		private LengthDataModel ConvertLength(LengthDataModel lengthDataModel, LengthUnit outputUnit)
		{
			throw new NotImplementedException();
		}

		private MassDataModel ConvertMass(MassDataModel massDataModel, Mass outputUnit)
		{
			throw new NotImplementedException();
		}

		private TemperatureDataModel ConvertTemperature(TemperatureDataModel temperatureDataModel, Temperature outputUnit)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Converts metres to other units of length.
		/// </summary>
		/// <param name="metres"></param>
		/// <param name="lengthOutputUnits"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public double ConvertMetresToLengthUnits(LengthDataModel metres, LengthUnit lengthOutputUnits)
		{
			double output;

			const double inchesInOneMetre = 39.3700787402;
			const double feetInOneMetre = 3.28084;
			const double yardsInOneMetre = 1.0936132983;
			const double milesInOneMetre = 0.0006213712;
			const double centimetresInOneMetre = 100;

			if (lengthOutputUnits == LengthUnit.inches)
			{
				output = metres.Quantity * inchesInOneMetre;
			}
			else if (lengthOutputUnits == LengthUnit.feet)
			{
				output = metres.Quantity * feetInOneMetre;
			}
			else if (lengthOutputUnits == LengthUnit.yards)
			{
				output = metres.Quantity * yardsInOneMetre;
			}
			else if (lengthOutputUnits == LengthUnit.miles)
			{
				output = metres.Quantity * milesInOneMetre;
			}
			else if (lengthOutputUnits == LengthUnit.centimetres)
			{
				output = metres.Quantity * centimetresInOneMetre;
			}
			else
			{
				throw new Exception("Invalid conversion");
			}

			return output;
		}
	}
}
