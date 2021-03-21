using ImageConverter.ImageStructure;

namespace ImageConverter.Readers
{
    public abstract class ImageReader
    {
        protected string Path { get; set; }

        protected ImageReader(string path)
        {
            Path = path;
        }

       public abstract Image ReadImage();
    }
}