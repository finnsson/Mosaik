using System;
using System.Collections.Generic;
using Db4objects.Db4o;
using System.Linq;

namespace Mosaik.Library
{
	public class Db4oModel : IModelDB
	{
		#region Fields

		private readonly String file;
		
		private IEmbeddedObjectContainer db;

		#endregion

		#region IModelDB implementation
		public void Create (ImageInfo info)
		{
				db.Store (info);
				db.Commit ();
		}

		public ImageInfo[] Read ()
		{
			ImageInfo[] result;
				var res = db.Query<ImageInfo> (typeof(ImageInfo));
				result = res.ToArray ();
			return result;
		}

		public void DeleteByPath (String path)
		{
				db.DeleteByExample (new ImageInfo { path = path });
				db.Commit ();
		}

		public void DeleteAll ()
		{			
				db.Delete<ImageInfo> (typeof(ImageInfo));
				db.Commit ();	
		}
		
		public int CountRGB() {
			var res = db.Query(typeof(RGB));
			return res.Count;
		}

		#endregion

		private IEmbeddedObjectContainer Container ()
		{
			var config = Db4oEmbedded.NewConfiguration ();
			config.Common.ObjectClass (typeof(ImageInfo)).CascadeOnDelete (true);
			return Db4oEmbedded.OpenFile (config, file);
		}

		public Db4oModel (String fileName)
		{
			if (fileName == null) {
				throw new ArgumentNullException ("fileName");
			}
			file = fileName;
			
			db = Container();
		}
		
		
		#region IDisposable implementation
		public void Dispose ()
		{
			if(db != null) {
				db.Close();
				db.Dispose();
			}
		}
		
		#endregion
	}
}
