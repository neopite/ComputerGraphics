﻿namespace ImageConverter.Rendering
{
    public class StaticCamera : ICamera
    {
        public Vector3 Origin { get;private set; }

        public StaticCamera(Transform transform, Vector3 origin) : base(transform, origin)
        {
        }
    }
}