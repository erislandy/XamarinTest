
namespace App1.components
{
    using SkiaSharp;
    using SkiaSharp.Views.Forms;
    public class DefaultMarkerGoogleMap : SKCanvasView
    {
        SKPaint brownFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Brown
        };
        SKPaint strokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Brown,
            StrokeWidth = 2

        };

        SKPaint fillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Red

        };


        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
           
            var with = e.Info.Width;
            var height = e.Info.Height;
            var surface = e.Surface;
            var canvas = surface.Canvas;
            canvas.Clear();

            canvas.Translate(with / 2, height / 2);
            canvas.Scale(with / 200f);
           
            // Create the path
            SKPath path = new SKPath();
            path.MoveTo(0.0f, 0.0f);
            path.LineTo(-45f, -90f);
            path.ArcTo(45, 45, 0, SKPathArcSize.Large, SKPathDirection.Clockwise, 45, -90);
            path.Close();
            
            
            // Fill and stroke the path
            canvas.DrawPath(path, fillPaint);
            canvas.DrawPath(path, strokePaint);

            //Circle
            canvas.DrawCircle(0, -90, 20, brownFillPaint);

        }


    }
}
