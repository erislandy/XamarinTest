using System;
using System.Collections.Generic;
using System.Text;

namespace App1.components.SkiaComponents
{
    using SkiaSharp;
    using SkiaSharp.Views.Forms;
    public class PlaySkiaControl: SKCanvasView
    {
        SKPaint fillColor = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Aqua

        };
        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            int width = e.Info.Width;
            int height = e.Info.Height;

            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 216.45f);

            canvas.Translate(-108.2f, -125.15f);

            var drawExt = SKPath.ParseSvgPathData("M34.92,250.31h-.15A35.22,35.22,0,0,1,0,215V34.92A34.44,34.44,0,0,1,17.85,4.49a34.46,34.46,0,0,1,35.27.75L199.87,95.7a34.85,34.85,0,0,1-.12,59.43l-106.1,65A10.6,10.6,0,1,1,82.58,202l106.1-65a13.64,13.64,0,0,0,.07-23.27L42,23.3A13.64,13.64,0,0,0,21.21,34.92V215A14.14,14.14,0,0,0,34.89,229.1,14.19,14.19,0,0,0,42,226.77a10.61,10.61,0,0,1,11,18.11A35,35,0,0,1,34.92,250.31Z");
            canvas.DrawPath(drawExt, fillColor);

            var drawIn = SKPath.ParseSvgPathData("M46.41,124.7V88a12.7,12.7,0,0,1,19-11L97.21,95.37,129,113.7a12.7,12.7,0,0,1,0,22L97.21,154,65.46,172.36a12.7,12.7,0,0,1-19-11Z");
            canvas.DrawPath(drawIn, fillColor);

        }


    }
}
