namespace UnitConversionLibrary.Models
{
	/// <summary>
	/// Base Class for the Data Model, including Properties of Quantity and Significant Digits
	/// </summary>
	public class DataModelBase
	{
		/// <summary>
		/// The Quantity to be converted, or the result of the conversion, expressed in the Units set in the Derived Classes to the precision set in the Significant Digits Property
		/// </summary>
		public double Quantity { get; set; }
		/// <summary>
		/// The number of significant digits in the Quantity
		/// </summary>
		public int SignificantDigits { get; set; }
	}
}
