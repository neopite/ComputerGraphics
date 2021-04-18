using System;
using System.Runtime.CompilerServices;

namespace ImageConverter.Rendering.Calculation
{
    public class Matrix4x4
    {
        private double[,] m;

  public Matrix4x4() {
    m = new double[4,4];
    for (int i = 0; i < 4; i++) {
      m[i,i] = 1;
    }
  }

  public Vector3 TransformToWorldCoordinates(Vector3 pointCoordinatesInPlainSpace, Vector3 translation, Vector3 rotation, Vector3 scale)
  {
      generateTransformation(translation, rotation, scale);
      return applyPoint(pointCoordinatesInPlainSpace);

  }
  
  public void generateTransformation(Vector3 translation, Vector3 rotation, Vector3 scale) {
    applyTranslation(translation);
    applyRotation(rotation);
    applyScale(scale);
  }

  public void applyTranslation(Vector3 translation) {
    m[0,3] = translation.x;
    m[1,3] = translation.y;
    m[2,3] = translation.z;
  }

  public void applyScale(Vector3 scale) {
    m[0,0] *= scale.x;
    m[1,1] *= scale.y;
    m[2,2] *= scale.z;
  }

  private void applyRotation(Vector3 rotation) {
    double[,] rot = applyRotationAroundX(rotation.x);
    rot = multiply(rot, applyRotationAroundY(rotation.y));
    rot = multiply(rot, applyRotationAroundZ(rotation.z));
    for (int i = 0; i < 3; i++) {
      for (int j = 0; j < 3; j++) {
        m[j,i] = rot[j,i];
      }
    }
  }

  private double[,] applyRotationAroundX(double angle) {
    double[,] rotation = new double[3,3];
    rotation[0,0] = 1;
    double radians = MathCalculations.DegreeToRad(angle);
    rotation[1,1] = Math.Cos(radians);
    rotation[1,2] = Math.Sin(radians);
    rotation[2,1] = -Math.Sin(radians);
    rotation[2,2] = Math.Cos(radians);
    return rotation;
  }

  private double[,] applyRotationAroundY(double angle) {
    double[,] rotation = new double[3,3];
    rotation[1,1] = 1;
    double radians = MathCalculations.DegreeToRad(angle);
    rotation[0,0] = Math.Cos(radians);
    rotation[0,2] = -Math.Sin(radians);
    rotation[2,0] = Math.Sin(radians);
    rotation[2,2] = Math.Cos(radians);
    return rotation;
  }

  private double[,] applyRotationAroundZ(double angle) {
    double[,] rotation = new double[3,3];
    rotation[2,2] = 1;
    double radians = MathCalculations.DegreeToRad(angle);
    rotation[0,0] = Math.Cos(radians);
    rotation[0,1] = Math.Sin(radians);
    rotation[1,0] = -Math.Sin(radians);
    rotation[1,1] = Math.Cos(radians);
    return rotation;
  }

  public Vector3 applyVector(Vector3 v) {
    return new Vector3(
            v.x * m[0,0] + v.y * m[0,1] + v.z * m[0,2],
            v.x * m[1,0] + v.y * m[1,1] + v.z * m[1,2],
            v.x * m[2,0] + v.y * m[2,1] + v.z * m[2,2]
    );
  }

  public Vector3 applyPoint(Vector3 p) {
    return translate(applyVector(p));
  }

  private Vector3 translate(Vector3 v) {
    return v+new Vector3(m[0,3], m[1,3], m[2,3]);
  }

  private double[,] multiply(double[,] a, double[,] b) {
    double[,] res = new double[a.Length,b.GetLength(1)];
    for (int i = 0; i < 3; i++) {
      for (int j = 0; j < 3; j++) {
        res[i,j] = a[i,0] * b[0,j]
                + a[i,1] * b[1,j]
                + a[i,2] * b[2,j];
      }
    }
    return res;
  }

  public void setMatrix(Vector3 right, Vector3 up, Vector3 forward, Vector3 translate) {
    m[0,0] = right.x;
    m[1,0] = right.y;
    m[2,0] = right.z;
    m[0,1] = up.x;
    m[1,1] = up.y;
    m[2,1] = up.z;
    m[0,2] = forward.x;
    m[1,2] = forward.y;
    m[2,2] = forward.z;
    m[0,3] = translate.x;
    m[1,3] = translate.y;
    m[2,3] = translate.z;
  }
    }
}