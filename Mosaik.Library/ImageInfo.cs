using System;
namespace Mosaik.Library
{	
	/// <summary>
	/// Contains an X*X square of RGB-values over the image as well as its path/url.
	/// </summary>
	public struct ImageInfo
	{
		/// <summary>
		/// Path to original image.
		/// </summary>
		public String path;
		/// <summary>
		/// Width of original image.
		/// </summary>
		public int width;
		/// <summary>
		/// Height of original image.
		/// </summary>
		public int height;
		/// <summary>
		/// Mean RGB-values for the image.
		/// </summary>
		public RGB[][] averages;
	}
}