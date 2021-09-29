using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;


namespace App1.components
{
    public class ClockSkiaComponent : SKCanvasView
    {
        SKPaint blackFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black
        };

        SKPaint whiteStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.White,
            IsAntialias = true,
            StrokeWidth = 2,
            StrokeCap = SKStrokeCap.Round

        };

        SKPaint whiteFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.White
        };

        public ClockSkiaComponent()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1f / 60), () =>
            {

                this.InvalidateSurface();
                return true;
            });
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);

            var with = e.Info.Width;
            var height = e.Info.Height;


            var surface = e.Surface;
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.CornflowerBlue);

            canvas.Translate(with / 2, height / 2);
            canvas.Scale(with / 200f);
            canvas.DrawCircle(0, 0, 100, blackFillPaint);
            for (int i = 0; i < 360; i += 6)
            {
                canvas.DrawCircle(0, -90, i % 30 == 0 ? 4 : 2, whiteFillPaint);
                canvas.RotateDegrees(6);
            }

            DateTime dateTime = DateTime.Now;
            //Hour

            canvas.RotateDegrees(30 * dateTime.Hour + dateTime.Minute / 2f);
            canvas.Save();
            whiteStrokePaint.StrokeWidth = 15;
            canvas.DrawLine(0, 0, 0, -50, whiteStrokePaint);
            canvas.Restore();


            //Minutes
            canvas.Save();
            whiteStrokePaint.StrokeWidth = 10;

            canvas.RotateDegrees(6 * dateTime.Minute + dateTime.Second / 10f);
            canvas.DrawLine(0, 0, 0, -70, whiteStrokePaint);
            canvas.Restore();

            //Hours
            canvas.Save();
            whiteStrokePaint.StrokeWidth = 2;
            canvas.RotateDegrees(6 * (dateTime.Second + dateTime.Millisecond / 1000f));
            canvas.DrawLine(0, 10, 0, -80, whiteStrokePaint);
            canvas.Restore();

        }

    }
}
