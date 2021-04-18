using System;
using System.Runtime.CompilerServices;

namespace ImageConverter.Rendering.Calculation
{
    public static class Matrix4x4
    {
        private static double[,] m;
        static Matrix4x4() 
        {
           m = new double[4,4];
           for (int i = 0; i < 4; i++) 
           {
              m[i,i] = 1;
           }
        }

  public static double[,] GetTransformationMatrix(Vector3 translation, Vector3 rotation, Vector3 scale)
  {
     generateTransformation(translation, rotation, scale);
     return m;
  }

  public static Vector3 TransformToWorldCoordinates(double[,] matrix, Vector3 point)
  {
    double[,] vector = new double[4, 1];
    vector[0, 0] = point.x;
    vector[1, 0] = point.y;
    vector[2, 0] = point.z;
    vector[3, 0] = 1;
    var res = multiply(matrix, vector);
    return new Vector3(res[0, 0], res[1, 0], res[2, 0]);

  }
  
  public static void generateTransformation(Vector3 translation, Vector3 rotation, Vector3 scale) {
    applyRotation(rotation);
    applyScale(scale);
    applyTranslation(translation);
  }

  public static void applyTranslation(Vector3 translation) {
    m[0,3] += translation.x;
    m[1,3] += translation.y;
    m[2,3] += translation.z;
  }

  public static void applyScale(Vector3 scale)
  {
    double[,] s = new double[4, 4];
    s[0, 0] = scale.x;
    s[1, 1] = scale.y;
    s[2, 2] = scale.z;
    s[3, 3] = 1;
    s = multiply(s, m);
    for (int i = 0; i < 4; i++) {
      for (int j = 0; j < 4; j++) {
        m[j,i] = s[j,i];
      }
    }
  }

  private static void applyRotation(Vector3 rotation) {
    double[,] rot = multiply(applyRotationAroundX(rotation.x), m);
    rot = multiply(applyRotationAroundY(rotation.y), rot);
    rot = multiply(applyRotationAroundZ(rotation.z), rot);
    for (int i = 0; i < 4; i++) {
      for (int j = 0; j < 4; j++) {
        m[j,i] = rot[j,i];
      }
    }
  }

  private static double[,] applyRotationAroundX(double angle) {
    double[,] rotation = new double[4,4];
    rotation[3, 3] = 1;
    rotation[0,0] = 1;
    double radians = MathCalculations.DegreeToRad(angle);
    rotation[1,1] = Math.Cos(radians);
    rotation[1,2] = Math.Sin(radians);
    rotation[2,1] = -Math.Sin(radians);
    rotation[2,2] = Math.Cos(radians);
    return rotation;
  }

  private static double[,] applyRotationAroundY(double angle) {
    double[,] rotation = new double[4,4];
    rotation[3, 3] = 1;
    rotation[1,1] = 1;
    double radians = MathCalculations.DegreeToRad(angle);
    rotation[0,0] = Math.Cos(radians);
    rotation[0,2] = -Math.Sin(radians);
    rotation[2,0] = Math.Sin(radians);
    rotation[2,2] = Math.Cos(radians);
    return rotation;
  }

  private static double[,] applyRotationAroundZ(double angle) {
    double[,] rotation = new double[4,4];
    rotation[3, 3] = 1;
    rotation[2,2] = 1;
    double radians = MathCalculations.DegreeToRad(angle);
    rotation[0,0] = Math.Cos(radians);
    rotation[0,1] = -Math.Sin(radians);
    rotation[1,0] = Math.Sin(radians);
    rotation[1,1] = Math.Cos(radians);
    return rotation;
  }

    private static double[,] multiply(double[,] a, double[,] b)
    {
      int rowNumber = a.GetLength(0);
      int columnNumber = b.GetLength(1);
      double[,] res = new double[rowNumber,columnNumber];
      for (int i = 0; i < rowNumber; i++) 
      {
        for (int j = 0; j < columnNumber; j++)
        {
          res[i, j] = a[i, 0] * b[0, j]
                      + a[i, 1] * b[1, j]
                      + a[i, 2] * b[2, j]
                      + a[i, 3] * b[3, j];
        }
      }
      return res;
    }
  
    }
}