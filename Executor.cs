using System;

namespace ImageFormatConverter
{
    class Executor
    {
        public static void Main(string[] args)
        {
            PPMReader reader =
                new PPMReader("D:\\Study\\ComputerGraphic\\CG\\ImageConverter\\Images\\myppm.ppm");
            PPMImage ppmImage = reader.Read();
        }
    }
}