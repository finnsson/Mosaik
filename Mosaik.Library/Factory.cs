using System;
namespace Mosaik.Library
{
	public class Factory
	{
		public Factory ()
		{
		}
		
		public IModelDB ModelDB() {
			return new ModelDB("URI=file:MosaikDB.db");
		}
		
		public IGenerateImage GenerateImage() {
			throw new NotImplementedException();
		}		
		
		public IGenerateImageMap GenerateImageMap() {
			throw new NotImplementedException();
		}
	}
}