using System;
namespace Mosaik.Library
{
	public class Factory
	{
		String file;
		public Factory (String fileName)
		{
			file = fileName;
		}
		
		public IModelDB ModelDB() {
			return new Db4oModel(file);
		}
		
		public IGenerateImage GenerateImage() {
			throw new NotImplementedException();
		}		
		
		public IGenerateImageMap GenerateImageMap() {
			throw new NotImplementedException();
		}
	}
}