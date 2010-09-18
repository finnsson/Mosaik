using System;
using NUnit.Framework;
using Mosaik.Library;
using System.Collections.Generic;
using Db4objects.Db4o;
namespace Mosaik.Library.Test
{
	[TestFixture()]
	public class Db4oModelTest
	{
		[Test()]
		public void TestCase ()
		{
			using (var modelDb = ModelDb ("TestCase.db40")) {
				
				var result = modelDb.Read ();
				
				Assert.IsNotNull (result, "ReadAllImageInfo should not return null.");
				
				Assert.AreEqual (0, result.Length, "ReadAllImageInfo should return an empty array.");
			}
		}

		[Test()]
		public void TestCreateAndDelete ()
		{
			using (var modelDb = ModelDb ("TestCreateAndDelete.db40")) {
				
				var path = "testCreateAndDelete";
				
				var img = new ImageInfo { averages = new List<RGB> (), height = 100, width = 100, path = path };
				
				modelDb.Create (img);
				
				var read = modelDb.Read ();
				Assert.AreEqual (1, read.Length);
				Assert.AreEqual (path, read[0].path);
				
				modelDb.DeleteByPath (path);
				var readAgain = modelDb.Read ();
				Assert.AreEqual (0, readAgain.Length);
			}
		}

		[Test()]
		public void TestNestedDelete ()
		{
			using (var modelDb = ModelDb ("TestNestedDelete.db4o")) {
				
				var path = "testCreateAndDelete";
				
				var img = new ImageInfo { averages = new List<RGB> (new[] { new RGB (12, 12, 12), new RGB (100, 100, 100) }), height = 100, width = 100, path = path };
				
				modelDb.Create (img);
				
				var read = modelDb.Read ();
				Assert.AreEqual (1, read.Length);
				
				var countRGB2 = modelDb.CountRGB();
				Assert.AreEqual(2, countRGB2);
				
				modelDb.DeleteAll();
				
				var countRGB = modelDb.CountRGB();
				
				Assert.AreEqual(0, countRGB);
			}
		}
		
		#region Helpers
		
		IModelDB ModelDb (String fileName)
		{
			var factory = new Factory (fileName);
			var modelDb = factory.ModelDB ();
			modelDb.DeleteAll ();
			return modelDb;
		}

		private IEmbeddedObjectContainer Container (String fileName)
		{
			var config = Db4oEmbedded.NewConfiguration ();
			config.Common.ObjectClass (typeof(ImageInfo)).CascadeOnDelete (true);
			return Db4oEmbedded.OpenFile (config, fileName);
		}
		
		#endregion
	}
}
