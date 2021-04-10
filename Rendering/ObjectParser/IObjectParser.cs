using System.Collections.Generic;
using ImageConverter.ImageStructure;

namespace ImageConverter.Rendering
{
    public interface IObjectParser
    {
        List<Triangle> ParseObject(string inputPath);
    }
}