using ImageConverter.ImageStructure;

namespace ImageConverter.Rendering.Renderer
{
    public interface IRenderer
    {
        Image RenderObj(string inputPath);
    }
}