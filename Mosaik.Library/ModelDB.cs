using System;
using System.Data.SQLite;
namespace Mosaik.Library
{
	public class ModelDB : IModelDB
	{
		public ModelDB ()
		{
		}


		#region IModelDB implementation
		public void UpdateDB (string[] urls)
		{
			throw new NotImplementedException ();
		}

		public ImageInfo[] ReadAllImageInfo ()
		{
			using(var connection = new SQLiteConnection("URI=file:MosaikDB.db")) {
				connection.Open();
				
				var commandHeightWidth = new SQLiteCommand("SELECT path,width,height FROM imageinfo", connection);
				SQLiteDataReader readerHeightWidth = commandHeightWidth.ExecuteReader();
				while(readerHeightWidth.Read()) {
					
				}
				
				var commandAverages = new SQLiteCommand("SELECT path,r,g,b from imageinfo_averages", connection);
				var readerAverages = commandAverages.ExecuteReader();
				while(readerAverages.Read()) {
					
				}
			}
			
			throw new NotImplementedException ();
		}
		#endregion
	}
}

