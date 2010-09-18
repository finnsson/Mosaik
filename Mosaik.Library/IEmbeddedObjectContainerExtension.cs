using System;
using Db4objects.Db4o;
namespace Mosaik.Library
{
	static public class IEmbeddedObjectContainerExtension
	{
		public static void DeleteByExample(this IEmbeddedObjectContainer db, object template) {
			var result = db.QueryByExample(template);	
			foreach(var r in result) {
				db.Delete(r);
			}
		}
		
		public static void Delete<T>(this IEmbeddedObjectContainer db, Type t) {
			var result = db.Query<T>(t);
			foreach(var r in result) {
				db.Delete(r);
			}
		}
	}
}

