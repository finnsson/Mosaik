using System;
using System.Collections.Generic;
namespace Mosaik.Library
{	
	/// <summary>
	/// Contains an X*X square of RGB-values over the image as well as its path/url.
	/// </summary>
	public class ImageInfo
	{
		/// <summary>
		/// Path to original image.
		/// </summary>
		public String path {get ;set; }
		/// <summary>
		/// Width of original image.
		/// </summary>
		public int width {get ;set; }
		/// <summary>
		/// Height of original image.
		/// </summary>
		public int height {get ;set; }
		/// <summary>
		/// Mean RGB-values for the image.
		/// </summary>
		public List<RGB> averages {get ;set; }
	}
}