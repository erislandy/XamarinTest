namespace App1.components.SkiaComponents
{
    using SkiaSharp;
    using SkiaSharp.Views.Forms;
    public class ArrowNavigationComponent: SKCanvasView
    {
        SKPaint border = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            StrokeCap = SKStrokeCap.Square,
            StrokeJoin = SKStrokeJoin.Miter,
            StrokeWidth = 5.6f

        };


        SKPaint fill = new SKPaint
        {
            Style = SKPaintStyle.Fill,

        };
        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            int width = e.Info.Width;
            int height = e.Info.Height;

            //Translate to the center and scale to 200px
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 200f);

            var arrowPath = new SKPath();

            arrowPath.MoveTo(-76.2f, 0);
            arrowPath.RLineTo(149.41f, -74.54f);
            arrowPath.RLineTo(-42.46f, 74.54f);
            arrowPath.RLineTo(42.46f, 74.54f);
            arrowPath.Close();

            var fillColors = new SKColor[10];
            SKColor.TryParse("b1fffb", out fillColors[0]);
            SKColor.TryParse("00fff5", out fillColors[1]);
            SKColor.TryParse("00faf4", out fillColors[2]);
            SKColor.TryParse("00ebf3", out fillColors[3]);
            SKColor.TryParse("00d2f0", out fillColors[4]);
            SKColor.TryParse("00b0ec", out fillColors[5]);
            SKColor.TryParse("0083e7", out fillColors[6]);
            SKColor.TryParse("014de1", out fillColors[7]);
            SKColor.TryParse("010eda", out fillColors[8]);
            SKColor.TryParse("0101d9", out fillColors[9]);


            fill.Shader = SKShader.CreateLinearGradient(
                new SKPoint(-73, 0),
                new SKPoint(75, 0),
                fillColors,
                new float[] { 0, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
                SKShaderTileMode.Repeat
                );
            var bordersColors = new SKColor[16];
            SKColor.TryParse("0005ff", out bordersColors[0]);
            SKColor.TryParse("0015fe", out bordersColors[1]);
            SKColor.TryParse("002ffd", out bordersColors[2]);
            SKColor.TryParse("0053fc", out bordersColors[3]);
            SKColor.TryParse("0081fa", out bordersColors[4]);
            SKColor.TryParse("00b9f8", out bordersColors[5]);
            SKColor.TryParse("00faf5", out bordersColors[6]);
            SKColor.TryParse("00fff5", out bordersColors[7]);
            SKColor.TryParse("00e7f2", out bordersColors[8]);
            SKColor.TryParse("00abec", out bordersColors[9]);
            SKColor.TryParse("0177e6", out bordersColors[10]);
            SKColor.TryParse("014de1", out bordersColors[11]);
            SKColor.TryParse("012cde", out bordersColors[12]);
            SKColor.TryParse("0114db", out bordersColors[13]);
            SKColor.TryParse("0106da", out bordersColors[14]);
            SKColor.TryParse("0101d9", out bordersColors[15]);


            border.Shader = SKShader.CreateLinearGradient(
                new SKPoint(-78, 0),
                new SKPoint(80, 0),
                bordersColors,
                new float[] { 0.05f, 0.11f, 0.18f, 0.25f, 0.33f, 0.41f, 0.49f, 0.49f, 0.52f, 0.6f, 0.67f, 0.75f, 0.82f, 0.88f, 0.95f, 1 },
                SKShaderTileMode.Repeat
                );
            var shadowColor = new SKColor();
            SKColor.TryParse("25739c", out shadowColor);
            fill.ImageFilter = SKImageFilter.CreateDropShadow(
                 0,20,6,6, shadowColor
                );
            canvas.DrawPath(arrowPath, fill);
            canvas.DrawPath(arrowPath, border);
        }
    }
}
