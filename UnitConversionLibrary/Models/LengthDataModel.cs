namespace UnitConversionLibrary.Models
{
	/// <summary>
	/// Data Model for Length conversions; inherits Properties of Quantity and Significant Digits from DataModelBase and adds Units Property for Length Units
	/// </summary>
	public class LengthDataModel : DataModelBase
	{
		/// <summary>
		/// The Unit of the Quantity
		/// </summary>
		public Length Units { get; set; }
	}
}
