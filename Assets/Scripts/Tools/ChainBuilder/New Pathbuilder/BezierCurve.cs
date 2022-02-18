﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotReaper.Tools.PathBuilder
{
    public class BezierCurve
    {
        public Vector3 CubicLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
        {
            Vector3 ab_cd = QuadraticLerp(a, b, c, t);
            Vector3 bc_cd = QuadraticLerp(b, c, d, t);

            return Vector3.Lerp(ab_cd, bc_cd, t);
        }
        private Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
        {
            Vector3 ab = Vector3.Lerp(a, b, t);
            Vector3 bc = Vector3.Lerp(b, c, t);
            return Vector3.Lerp(ab, bc, t);
        }
    }

}
