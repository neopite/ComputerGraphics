using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ImageConverter.ImageStructure;
using ImageConverter.Rendering.Calculation;
using ImageConverter.Rendering.Lights;
using ImageConverter.Rendering.Rays;
using ImageConverter.Rendering.Renderer.Calculations;
using ImageConverter.Rendering.Scene;
using Ninject;

namespace ImageConverter.Rendering.Renderer
{
    public abstract  class IRenderer
    {
        [Inject] private readonly IObjectParser _objectParser;

        [Inject] protected readonly IRayIntersactionCalculation rayIntersactionSolver;

        [Inject] protected readonly Camera camera;

        [Inject] protected readonly ColorIntensativeCalculation colorIntensativeCalculation;

        [Inject] protected readonly SceneDescription scene;

        protected IRenderer(IObjectParser objectParser, IRayIntersactionCalculation rayIntersactionSolver, Camera camera, ColorIntensativeCalculation colorIntensativeCalculation)
        {
            _objectParser = objectParser;
            this.rayIntersactionSolver = rayIntersactionSolver;
            this.camera = camera;
            this.colorIntensativeCalculation = colorIntensativeCalculation;
        }

        public  abstract Image RenderObj(string inputPath);

        protected Mesh InitModel(string inputPath)
        {
            return  _objectParser.ParseObject(inputPath);
        }
        
    }
}