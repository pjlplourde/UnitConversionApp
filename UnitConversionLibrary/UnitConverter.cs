using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnitConversionLibrary.Models;

namespace UnitConversionLibrary
{
	public class UnitConverter
	{
		public T Convert<T, U>(Dimension dimension, T dataModel, U outputUnit)
		{
			T output = default(T);

			switch ( dimension ) {
				case Dimension.Length:
					if ( dataModel is LengthDataModel lengthDataModel && outputUnit is LengthUnit lengthOutputUnit ) {
						output = (T)(object)ConvertLength(lengthDataModel, lengthOutputUnit);
					} else if ( dataModel is LengthDataModel ) {
						throw new ArgumentException($"Data Type Mismatch: {typeof(U)} does not correspond to the selected dimension {dimension}.", nameof(outputUnit));
					} else if ( outputUnit is LengthUnit ) {
						throw new ArgumentException($"Data Type Mismatch: {typeof(T)} does not correspond to the selected dimension {dimension}.", nameof(dataModel));
					} else {
						throw new ArgumentException($"Data Type Mismatch: {typeof(T)} or {typeof(U)} does not correspond to the selected dimension {dimension}.");
					}
					break;
				case Dimension.Mass:
					if ( dataModel is MassDataModel massDataModel && outputUnit is Mass massOutputUnit ) {
						output = (T)(object)ConvertMass(massDataModel, massOutputUnit);
					} else if ( dataModel is MassDataModel ) {
						throw new ArgumentException($"Data Type Mismatch: {typeof(U)} does not correspond to the selected dimension {dimension}.", nameof(outputUnit));
					} else if ( outputUnit is Mass ) {
						throw new ArgumentException($"Data Type Mismatch: {typeof(T)} does not correspond to the selected dimension {dimension}.", nameof(dataModel));
					} else {
						throw new ArgumentException($"Data Type Mismatch: {typeof(T)} or {typeof(U)} does not correspond to the selected dimension {dimension}.");
					}
					break;
				case Dimension.Temperature:
					if ( dataModel is TemperatureDataModel temperatureDataModel && outputUnit is Temperature temperatureOutputUnit ) {
						output = (T)(object)ConvertTemperature(temperatureDataModel, temperatureOutputUnit);
					} else if ( dataModel is TemperatureDataModel ) {
						throw new ArgumentException($"Data Type Mismatch: {typeof(U)} does not correspond to the selected dimension {dimension}.", nameof(outputUnit));
					} else if ( outputUnit is Temperature ) {
						throw new ArgumentException($"Data Type Mismatch: {typeof(T)} does not correspond to the selected dimension {dimension}.", nameof(dataModel));
					} else {
						throw new ArgumentException($"Data Type Mismatch: {typeof(T)} or {typeof(U)} does not correspond to the selected dimension {dimension}.");
					}
					break;
				default:
					throw new ArgumentException($"Invalid Data Type: {typeof(T)} cannot be converted to {typeof(U)}.", nameof(dataModel));
			}

			return output;
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
