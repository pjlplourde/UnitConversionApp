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
					if ( dataModel is LengthDataModel lengthDataModel && outputUnit is Length lengthOutputUnit ) {
						output = (T)(object)ConvertLength(lengthDataModel, lengthOutputUnit);
					} else if ( dataModel is LengthDataModel ) {
						throw new ArgumentException($"Data Type Mismatch: {typeof(U)} does not correspond to the selected dimension {dimension}.", nameof(outputUnit));
					} else if ( outputUnit is Length ) {
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

		private LengthDataModel ConvertLength(LengthDataModel lengthDataModel, Length outputUnit)
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
	}
}
