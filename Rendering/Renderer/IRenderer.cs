using System.Collections.Generic;
using ImageConverter.ImageStructure;
using Ninject;

namespace ImageConverter.Rendering.Renderer
{
    public abstract  class IRenderer
    {
        public  abstract Image RenderObj(string inputPath);
        
        [Inject]
        private IObjectParser _objectParser;

        public List<Triangle> GetModel(string inputPath)
        {
            _objectParser = new Parser();
            return  _objectParser.ParseObject(inputPath);
        }
    }
}