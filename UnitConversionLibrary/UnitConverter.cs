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
		public double Convert<T>(Dimension dimension, T dataModel)
		{
			double output = 0.0;

			switch ( dimension ) {
				case Dimension.Length:
					if ( dataModel is LengthDataModel lengthDataModel ) {
						output = ConvertLength(lengthDataModel);
					} else {
						throw new ArgumentException($"Data Type Mismatch: {typeof(T)} does not correspond to the selected dimension {dimension}.", nameof(dataModel));
					}
					break;
				case Dimension.Mass:
					if ( dataModel is MassDataModel massDataModel ) {
						output = ConvertMass(massDataModel);
					} else {
						throw new ArgumentException($"Data Type Mismatch: {typeof(T)} does not correspond to the selected dimension {dimension}.", nameof(dataModel));
					}
					break;
				case Dimension.Temperature:
					if ( dataModel is TemperatureDataModel temperatureDataModel ) {
						output = ConvertTemperature(temperatureDataModel);
					} else {
						throw new ArgumentException($"Data Type Mismatch: {typeof(T)} does not correspond to the selected dimension {dimension}.", nameof(dataModel));
					}
					break;
				default:
					throw new ArgumentException($"Invalid Data Type: {typeof(T)} cannot be converted.", nameof(dataModel));
			}

			return output;
		}

		private double ConvertLength(LengthDataModel lengthDataModel)
		{
			throw new NotImplementedException();
		}

		private double ConvertMass(MassDataModel massDataModel)
		{
			throw new NotImplementedException();
		}

		private double ConvertTemperature(TemperatureDataModel temperatureDataModel)
		{
			throw new NotImplementedException();
		}
	}
}
