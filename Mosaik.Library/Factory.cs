using System;
namespace Mosaik.Library
{
	public class Factory
	{
		public Factory ()
		{
		}
		
		public IModelDB ModelDB() {
			throw new NotImplementedException();
		}
		
		public IGenerateImage GenerateImage() {
			throw new NotImplementedException();
		}		
		
		public IGenerateImageMap GenerateImageMap() {
			throw new NotImplementedException();
		}
	}
}