using System;
namespace Mosaik.Library
{
	public interface IModelDB
	{
		/// <summary>
		/// Update the DB with all images under the given path.
		/// </summary>
		/// <param name="urls">
		/// A <see cref="String[]"/> of uris.
		/// </param>
		void UpdateDB(String[] urls);
		
		/// <summary>
		/// An array of all ImageInfo-structs from the DB.
		/// </summary>
		/// <returns>
		/// A <see cref="ImageInfo"/>
		/// </returns>
		ImageInfo[] ReadAllImageInfo();
	}
}