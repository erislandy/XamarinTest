
namespace App1.components
{
    using SkiaSharp;
    using SkiaSharp.Views.Forms;

    public class CounterGoogleMap : SKCanvasView
    {
        public CounterGoogleMap(string text)
        {
            LabelText = text;
        }
        SKPaint greenFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Green
        };

        SKPaint textPaint = new SKPaint
        {
            Color = SKColors.White
        };
        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);
            var canvas = e.Surface.Canvas;

            var width = e.Info.Width;
            var height = e.Info.Height;

            canvas.Translate(width / 2f, height / 2f);
            canvas.Scale(width / 200f);
            canvas.DrawCircle(0, 0, 100, greenFillPaint);
            
            textPaint.TextSize = 40;
            
            float textWidth = textPaint.MeasureText(LabelText);

            SKRect textBounds = new SKRect();
            textPaint.MeasureText(LabelText, ref textBounds);

            //Calculate offsets to center the text on the screen
            float xText = width / 2 - textBounds.MidX;
            float yText = height / 2 - textBounds.MidY;

            // And draw the text
            canvas.DrawText(LabelText, (-1) * textWidth / 2, 20, textPaint);

        }

        public string LabelText { get; set; }
    }
}
