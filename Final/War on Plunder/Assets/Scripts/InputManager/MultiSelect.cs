using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG.WOP.InputManager
{
    public static class MultiSelect
    {
        private static Texture2D _whiteTexture;

        public static Texture2D WhiteTexture
        {
            get
            {
                // Checks to see if the _whiteTexture exists
                if (_whiteTexture == null)
                {
                    _whiteTexture = new Texture2D(1, 1);
                    _whiteTexture.SetPixel(0, 0, Color.white);
                    _whiteTexture.Apply();
                }

                return _whiteTexture;
            }
        }

        public static void DrawScreenRect(Rect rect, Color color)
        {
            GUI.color = color;
            GUI.DrawTexture(rect, WhiteTexture);
        }

        /// <summary>
        /// Draws a border around the rectangle for rectangle select
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="thickness"></param>
        /// <param name="color"></param>
        public static void DrawScreenRectBorder(Rect rect, float thickness, Color color)
        {
            //Top side of the rect
            DrawScreenRect(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);
            //Bottom side of the rect
            DrawScreenRect(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), color);
            //Left side of the rect
            DrawScreenRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);
            //Rights side of the rect
            DrawScreenRect(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), color);
        }

        /// <summary>
        /// Sets the points of the rectangle
        /// </summary>
        /// <param name="screenPos1"></param>
        /// <param name="screenPos2"></param>
        /// <returns></returns>
        public static Rect GetScreenRect(Vector3 screenPos1, Vector3 screenPos2)
        {
            // go from the bottom right to the top left

            screenPos1.y = Screen.height - screenPos1.y;
            screenPos2.y = Screen.height - screenPos2.y;

            // corners
            Vector3 bR = Vector3.Max(screenPos1, screenPos2);
            Vector3 tL = Vector3.Min(screenPos1, screenPos2);

            // create the rectangle
            return Rect.MinMaxRect(tL.x, tL.y, bR.x, bR.y);
        }

        /// <summary>
        /// Check to see what the box is selecting in our game Viewport
        /// </summary>
        /// <param name="cam"></param>
        /// <param name="screenPos1"></param>
        /// <param name="screenPos2"></param>
        /// <returns></returns>
        public static Bounds GetVPBounds(Camera cam, Vector3 screenPos1, Vector3 screenPos2)
        {
            Vector3 pos1 = cam.ScreenToViewportPoint(screenPos1);
            Vector3 pos2 = cam.ScreenToViewportPoint(screenPos2);

            Vector3 min = Vector3.Min(pos1, pos2);
            Vector3 max = Vector3.Max(pos1, pos2);

            min.z = cam.nearClipPlane;
            max.z = cam.farClipPlane;

            Bounds bounds = new Bounds();

            bounds.SetMinMax(min, max);

            return bounds;
            

        }
    }
}


