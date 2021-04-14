using ImageConverter.ImageStructure;

namespace ImageConverter.Readers
{
    public abstract class IImageReader
    {
        protected string Path { get; set; }

        protected IImageReader(string path)
        {
            Path = path;
        }

        protected IImageReader()
        {
        }

        public abstract Image ReadImage();
       public abstract string GetReader();
    }
}