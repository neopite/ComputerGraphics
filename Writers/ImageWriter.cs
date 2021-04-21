using ImageConverter.ImageStructure;
using ImageFormatConverter;
using Ninject;

namespace ImageConverter.Writers
{
    public abstract class ImageWriter
    {
        [Inject]
        protected ImageWriter()
        {
        }

        public abstract void WriteImage(Image image,string output);
    }
}