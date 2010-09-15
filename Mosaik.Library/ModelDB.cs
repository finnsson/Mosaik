using System;
using System.Data.SQLite;
namespace Mosaik.Library
{
	public class ModelDB : IModelDB
	{
		private readonly String connectionString;
		
		public ModelDB (String connectionString)
		{
			this.connectionString = connectionString;
		}

		public void InitDB() {
			using(var connection = new SQLiteConnection(connectionString)) {
				connection.Open();
				
				var createImageInfoCommand = new SQLiteCommand("CREATE TABLE imageinfo (path text, width integer, height integer); COMMIT;");
				var imageInfoResult = createImageInfoCommand.ExecuteNonQuery();

				var createImageAveragesCommand = new SQLiteCommand("CREATE TABLE imageinfo_averages (path text, r integer, g integer, b integer); COMMIT;");
				var averagesResult = createImageAveragesCommand.ExecuteNonQuery();		
				if(imageInfoResult != 0 && averagesResult != 0) {
					throw new SQLiteException("DB not created correctly.");
				}				
			}
		}

		#region IModelDB implementation
		public void UpdateDB (string[] urls)
		{
			throw new NotImplementedException ();
		}

		public ImageInfo[] ReadAllImageInfo ()
		{
			using(var connection = new SQLiteConnection(connectionString)) {
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

