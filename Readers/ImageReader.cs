namespace ImageFormatConverter
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