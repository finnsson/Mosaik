//using System;
//using Mono.Data.Sqlite;
//
//using System.Collections.Generic;
//namespace Mosaik.Library
//{
//	public class ModelDB : IModelDB
//	{
//		private readonly String connectionString;
//
//		public ModelDB (String connectionString)
//		{
//			this.connectionString = connectionString;
//			
//			InitDB ();
//		}
//
//		/// <summary>
//		/// Should be run before UpdateDB and ReadAllImageInfo. Is executed in the constructor.
//		/// Makes sure the DB got the correct tables/columns before they are used.
//		/// </summary>
//		private void InitDB ()
//		{
//			using (var connection = new SqliteConnection (connectionString)) {
//				connection.Open ();
//				
//				var createImageInfoCommand = new SqliteCommand ("CREATE TABLE IF NOT EXISTS imageinfo (path text, width integer, height integer);");
//				var imageInfoResult = createImageInfoCommand.ExecuteNonQuery();
//				
//				var createImageAveragesCommand = new SqliteCommand ("CREATE TABLE IF NOT EXISTS imageinfo_averages (path text, r integer, g integer, b integer);");
//				var averagesResult = createImageAveragesCommand.ExecuteNonQuery ();
//				if (imageInfoResult == null && averagesResult != 0) {
//					throw new SqliteException ("DB not created correctly.");
//				}
//			}
//		}
//
//		#region IModelDB implementation
//		public void UpdateDB (string[] pathS)
//		{
//			throw new NotImplementedException ();
//			// should replace with Bitmap[] images
//			// and instead build 2 helper-functions that can read images from system pathS or urlS.
//			
//		}
//
//		public ImageInfo[] ReadAllImageInfo ()
//		{
//			var imageInfoList = new List<ImageInfo> ();
//			using (var connection = new SqliteConnection (connectionString)) {
//				connection.Open ();
//				
//				var commandHeightWidth = new SqliteCommand ("SELECT path,width,height FROM imageinfo", connection);
//				var readerHeightWidth = commandHeightWidth.ExecuteReader ();
//				while (readerHeightWidth.Read ()) {
//					var imageInfo = new ImageInfo ();
//					imageInfo.path = readerHeightWidth.GetString (0);
//					imageInfo.width = readerHeightWidth.GetInt32 (1);
//					imageInfo.height = readerHeightWidth.GetInt32 (2);
//					imageInfo.averages = new List<RGB> ();
//					imageInfoList.Add (imageInfo);
//				}
//				
//				var commandAverages = new SqliteCommand ("SELECT path,r,g,b from imageinfo_averages", connection);
//				var readerAverages = commandAverages.ExecuteReader ();
//				while (readerAverages.Read ()) {
//					var imageInfo = imageInfoList.Find (ii => ii.path == readerAverages.GetString (0));
//					//if (imageInfo == default(ImageInfo)) {
//					//	throw new NullReferenceException ("imageInfo in ModelDB is null.");
//					//}
//					var rgb = new RGB ();
//					rgb.R = readerAverages.GetInt32 (1);
//					rgb.G = readerAverages.GetInt32 (2);
//					rgb.B = readerAverages.GetInt32 (3);
//					imageInfo.averages.Add (rgb);
//				}
//			}
//			return imageInfoList.ToArray ();
//		}
//		#endregion
//	}
//}
//
