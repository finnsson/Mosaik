using System;
namespace Mosaik.Library
{
	public interface IGenerateImage
	{
		Byte[] GenerateImage(AppliedImageInfo[][] imageMap);
	}
}