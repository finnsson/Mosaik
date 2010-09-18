using System;
namespace Mosaik.Library
{
	public interface IModelDB : IDisposable
	{
		/// <summary>
		/// Update the DB with all images under the given path.
		/// </summary>
		/// <param name="info">
		/// A <see cref="ImageInfo"/> of information.
		/// </param>
		void Create(ImageInfo info);
		
		/// <summary>
		/// An array of all ImageInfo-structs from the DB.
		/// </summary>
		/// <returns>
		/// A <see cref="ImageInfo"/>
		/// </returns>
		ImageInfo[] Read();
		
		void DeleteByPath(String path);
		
		/// <summary>
		/// Deletes all data in the db.
		/// </summary>
		void DeleteAll();
		
		int CountRGB();
	}
}