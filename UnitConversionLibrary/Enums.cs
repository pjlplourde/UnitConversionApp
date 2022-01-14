namespace UnitConversionLibrary
{
	/// <summary>
	/// Enumeration of the Dimensions which can be converted
	/// </summary>
	public enum Dimension
	{
		/// <summary>
		/// Conversion of Length Units
		/// </summary>
		Length,
		/// <summary>
		/// Conversion of Mass Units
		/// </summary>
		Mass,
		/// <summary>
		/// Conversion of Temperature Units
		/// </summary>
		Temperature
	}

	/// <summary>
	/// Enumeration of the Length units between which conversion can be done
	/// </summary>
	public enum Length
	{
		/// <summary>
		/// SI Length Unit of Metres
		/// </summary>
		metres,
		/// <summary>
		/// SI Length Unit of Centimetres
		/// </summary>
		centimetres,
		/// <summary>
		/// US Length Unit of (Statute) Miles
		/// </summary>
		miles,
		/// <summary>
		/// US Length Unit of Yards
		/// </summary>
		yards,
		/// <summary>
		/// US Length Unit of Feet
		/// </summary>
		feet,
		/// <summary>
		/// US Length Unit of Inches
		/// </summary>
		inches
	}

	/// <summary>
	/// Enumeration of the Mass units between which conversion can be done
	/// </summary>
	public enum Mass
	{
		/// <summary>
		/// SI Mass Unit of Kilograms
		/// </summary>
		kilograms,
		/// <summary>
		/// SI Mass Unit of Grams
		/// </summary>
		grams,
		/// <summary>
		/// US Weight (pseudo-mass) Unit of Pounds based on standard gravity of 32.17405 ft/s^2
		/// </summary>
		pounds,
		/// <summary>
		/// US Weight (pseudo-mass) Unit of Ounces based on standard gravity of 32.17405 ft/s^2
		/// </summary>
		ounces,
		/// <summary>
		/// US Mass Unit of Slugs
		/// </summary>
		slugs
	}

	/// <summary>
	/// Enumeration of the Temperature units between which conversion can be done
	/// </summary>
	public enum Temperature
	{
		/// <summary>
		/// SI Temperature Unit of °C
		/// </summary>
		DegreesCelsius,
		/// <summary>
		/// US Temperature Unit of °F
		/// </summary>
		DegreesFahrenheit,
		/// <summary>
		/// SI (Absolute) Temperature Unit of Kelvins
		/// </summary>
		Kelvin
	}
}
