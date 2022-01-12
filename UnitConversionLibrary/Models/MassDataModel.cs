namespace UnitConversionLibrary.Models
{
	/// <summary>
	/// Data Model for Mass conversions; inherits Properties of Quantity and Significant Digits from DataModelBase and adds Units Property for Mass Units
	/// </summary>
	public class MassDataModel : DataModelBase
	{
		/// <summary>
		/// The Unit of the Quantity
		/// </summary>
		public Mass Units { get; set; }
	}
}
