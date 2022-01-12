namespace UnitConversionLibrary.Models
{
	/// <summary>
	/// Data Model for Temperature conversions; inherits Properties of Quantity and Significant Digits from DataModelBase and adds Units Property for Temperature Units
	/// </summary>
	public class TemperatureDataModel : DataModelBase
	{
		/// <summary>
		/// The Unit of the Quantity
		/// </summary>
		public Temperature Units { get; set; }
	}
}
