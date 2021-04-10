using System.Collections.Generic;
using System.IO;
using ImageConverter.ImageStructure;
using ObjLoader.Loader.Loaders;

namespace ImageConverter.Rendering
{
    public class Parser : IObjectParser
    {
        public List<Triangle> ParseObject(string inputPath)
        {
            var objLoaderFactory = new ObjLoaderFactory();
            var objLoader = objLoaderFactory.Create();
            var fileStream = new FileStream(inputPath,FileMode.Open);
            var result = objLoader.Load(fileStream);
            List<Triangle> faces = new List<Triangle>();
            for (int i = 0; i < result.Groups.Count; i++)
            {
                for (int j = 0; j < result.Groups[i].Faces.Count; j++)
                {
                    Vector3 a = new Vector3(result.Vertices[result.Groups[i].Faces[j][0].VertexIndex - 1].X,
                        result.Vertices[result.Groups[i].Faces[j][0].VertexIndex - 1].Y,
                        result.Vertices[result.Groups[i].Faces[j][0].VertexIndex - 1].Z);
                    
                    Vector3 b =new Vector3(result.Vertices[result.Groups[i].Faces[j][1].VertexIndex - 1].X,
                        result.Vertices[result.Groups[i].Faces[j][1].VertexIndex - 1].Y,
                        result.Vertices[result.Groups[i].Faces[j][1].VertexIndex - 1].Z);

                    Vector3 c =new Vector3(result.Vertices[result.Groups[i].Faces[j][2].VertexIndex - 1].X,
                        result.Vertices[result.Groups[i].Faces[j][2].VertexIndex - 1].Y,
                        result.Vertices[result.Groups[i].Faces[j][2].VertexIndex - 1].Z);
                    
                    faces.Add(new Triangle(a,b,c));
                }
            }

            return faces;
        }
    }
}