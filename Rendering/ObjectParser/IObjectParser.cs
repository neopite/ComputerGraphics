using System.Collections.Generic;
using ImageConverter.ImageStructure;

namespace ImageConverter.Rendering
{
    public interface IObjectParser
    {
        Mesh ParseObject(string inputPath);
    }
}