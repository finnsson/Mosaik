using System;
namespace Mosaik.Library
{
	public interface IGenerateImageMap
	{
		/// <summary>
		/// Generates a x*y 2-dimensional array of AppliedImageInfoS given a path to an image and an array of ImageInfoS.
		/// </summary>
		/// <param name="urlToImage">
		/// A <see cref="String"/>
		/// </param>
		/// <param name="images">
		/// A <see cref="ImageInfo[]"/>
		/// </param>
		/// <returns>
		/// A <see cref="AppliedImageInfo[][]"/>
		/// </returns>
		AppliedImageInfo[][] GenerateImageMap(String urlToImage, ImageInfo[] images, int x, int y);
	}
}