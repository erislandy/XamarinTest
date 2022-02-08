
namespace App1.components.SkiaComponents
{
    using SkiaSharp;
    using Xamarin.Forms.Shapes;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using System.Collections.Generic;
    using System.Windows.Input;
    using System;
    using System.Collections.ObjectModel;
    using App1.ViewModels;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolbarComponent : ContentView
    {
        #region Attributes
        readonly SKColor[] fillColors = new SKColor[5]
              {

                    SKColor.Parse("2e313b"),
                    SKColor.Parse("2b2e37"),
                    SKColor.Parse("22242b"),
                    SKColor.Parse("121418"),
                    SKColors.Black

              };
        readonly SKColor[] pathBorderColors;

        #endregion

        #region Bindables Properties
        
        public static readonly BindableProperty LanguagesProperty = BindableProperty.Create(
                                                             "Languages",
                                                             typeof(ObservableCollection<ItemCollectionViewModel>),
                                                             typeof(ToolbarComponent),
                                                             null,
                                                             propertyChanged: LanguagesMethod);
        public static readonly BindableProperty CurrencyListProperty = BindableProperty.Create(
                                                             "CurrencyList",
                                                             typeof(ObservableCollection<ItemCollectionViewModel>),
                                                             typeof(ToolbarComponent),
                                                             null,
                                                             propertyChanged: CurrencyListMethod);

        
        public static readonly BindableProperty ProfileCommandProperty = BindableProperty.Create(
                                                             "ProfileCommand",
                                                             typeof(ICommand),
                                                             typeof(ToolbarComponent),
                                                             null);
        
        public static readonly BindableProperty CreateCommandProperty = BindableProperty.Create(
                                                             "CreateCommand",
                                                             typeof(ICommand),
                                                             typeof(ToolbarComponent),
                                                             null);
        public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(
                                                             "SearchCommand",
                                                             typeof(ICommand),
                                                             typeof(ToolbarComponent),
                                                             null);
        public static readonly BindableProperty ShareCommandProperty = BindableProperty.Create(
                                                             "ShareCommand",
                                                             typeof(ICommand),
                                                             typeof(ToolbarComponent),
                                                             null);
        public static readonly BindableProperty UndoCommandProperty = BindableProperty.Create(
                                                             "UndoCommand",
                                                             typeof(ICommand),
                                                             typeof(ToolbarComponent),
                                                             null);


        public static readonly BindableProperty StateToolbarProperty = BindableProperty.Create(
                                                              "StateToolbar",
                                                              typeof(string),
                                                              typeof(ToolbarComponent),
                                                              ToolbarStates.EXPANDED,
                                                              propertyChanged: StateToolbarMethod,
                                                              defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty ActivatedWindowProperty = BindableProperty.Create(
                                                              "ActivatedWindow",
                                                              typeof(string),
                                                              typeof(ToolbarComponent),
                                                              "search",
                                                              propertyChanged: ActivatedWindowMethod,
                                                              defaultBindingMode: BindingMode.TwoWay);
        #endregion

        #region Constructors
        public ToolbarComponent()
        {
            InitializeComponent();
            pathBorderColors = new SKColor[10];
            SKColor.TryParse("affff9", out pathBorderColors[0]);
            SKColor.TryParse("00fff3", out pathBorderColors[1]);
            SKColor.TryParse("00faf2", out pathBorderColors[2]);
            SKColor.TryParse("00ebf1", out pathBorderColors[3]);
            SKColor.TryParse("00d2ee", out pathBorderColors[4]);
            SKColor.TryParse("00b0ea", out pathBorderColors[5]);
            SKColor.TryParse("0083e5", out pathBorderColors[6]);
            SKColor.TryParse("014ddf", out pathBorderColors[7]);
            SKColor.TryParse("010ed8", out pathBorderColors[8]);
            SKColor.TryParse("0101d7", out pathBorderColors[9]);
        }

        #endregion

        #region Properties
        public string StateToolbar
        {
            get { return (string)GetValue(StateToolbarProperty); }
            set
            {
                VisualStateManager.GoToState(mainContainer, value);
                SetValue(StateToolbarProperty, value);
            }
        }
        public ObservableCollection<ItemCollectionViewModel> Languages
        {
            get { return (ObservableCollection<ItemCollectionViewModel>)GetValue(LanguagesProperty); }
            set
            {
                SetValue(LanguagesProperty, value);
            }
        }
        public ObservableCollection<ItemCollectionViewModel> CurrencyList
        {
            get { return (ObservableCollection<ItemCollectionViewModel>)GetValue(CurrencyListProperty); }
            set
            {
                SetValue(CurrencyListProperty, value);
            }
        }
        public string ActivatedWindow
        {
            get { return (string)GetValue(ActivatedWindowProperty); }
            set
            {
                SetValue(ActivatedWindowProperty, value);
            }
        }
        public ICommand ProfileCommand
        {
            get { return (ICommand)GetValue(ProfileCommandProperty); }
            set
            {
                SetValue(ProfileCommandProperty, value);
            }
        }
        
        public ICommand CreateCommand
        {
            get { return (ICommand)GetValue(CreateCommandProperty); }
            set
            {
                SetValue(CreateCommandProperty, value);
            }
        }
        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
            set
            {
                SetValue(SearchCommandProperty, value);
            }
        }
        public ICommand ShareCommand
        {
            get { return (ICommand)GetValue(ShareCommandProperty); }
            set
            {
                SetValue(ShareCommandProperty, value);
            }
        }
        public ICommand UndoCommand
        {
            get { return (ICommand)GetValue(UndoCommandProperty); }
            set
            {
                SetValue(UndoCommandProperty, value);
            }
        }
        #endregion

        #region Private methods
        private static void LanguagesMethod(BindableObject bindable, object oldValue, object newValue)
        {
            var source = (ObservableCollection<ItemCollectionViewModel>)newValue;
            (bindable as ToolbarComponent).languages.ItemsSource = source;
        }
        private static void CurrencyListMethod(BindableObject bindable, object oldValue, object newValue)
        {
            var source = (ObservableCollection<ItemCollectionViewModel>)newValue;
            (bindable as ToolbarComponent).currencyList.ItemsSource = source;
        }
        static void StateToolbarMethod(BindableObject bindable, object oldValue, object newValue)
        {

            var stateToolbar = (string)newValue;
            (bindable as ToolbarComponent).StateToolbar = stateToolbar;
        }
        static void ActivatedWindowMethod(BindableObject bindable, object oldValue, object newValue)
        {

            var activated = (string)newValue;
            var toolbar = bindable as ToolbarComponent;
            toolbar.ActivatedWindow = activated;

            toolbar.createButton.InvalidateSurface();
            toolbar.perfilButton.InvalidateSurface();
            toolbar.searchButton.InvalidateSurface();
            toolbar.onlySearchButton.InvalidateSurface();
            toolbar.shareButton.InvalidateSurface();
            toolbar.undoButton.InvalidateSurface();

        }
        #endregion

        #region Profile Button
        private void Profile_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            int width = e.Info.Width;
            int height = e.Info.Height;

            //Translate to the center and scale to 1229.71px
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(height / 226.53f);
            //Background circle
            canvas.Translate(-113.26f, -113.26f);
            SKPaint circlePaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,

            };

            circlePaint.Shader = SKShader.CreateLinearGradient(
               new SKPoint(113.26f, 0f),
               new SKPoint(113.26f, 440.79f),
               fillColors,
               new float[] { 0.19f, 0.32f, 0.45f, 0.57f, 0.68f },
               SKShaderTileMode.Repeat);

            canvas.DrawCircle(113.26f, 113.26f, 113.26f, circlePaint);
            canvas.Save();

            //Border
            var pathBorder = SKPath.ParseSvgPathData("M113.26,9.72A103.55,103.55,0,1,1,9.72,113.26,103.66,103.66,0,0,1,113.26,9.72m0-9.72A113.27,113.27,0,1,0,226.53,113.26,113.26,113.26,0,0,0,113.26,0Z");
            var pathBorderPaint = new SKPaint { Style = SKPaintStyle.Fill };


            pathBorderPaint.Shader = SKShader.CreateLinearGradient(
                new SKPoint(226.53f, 113.26f),
                new SKPoint(0, 113.26f),
                pathBorderColors,
                new float[10] { 0f, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
            SKShaderTileMode.Repeat
                );
            canvas.DrawPath(pathBorder, pathBorderPaint);
            canvas.Save();

            //User body
            var pathUserBody = SKPath.ParseSvgPathData("M98,117.27h30.52a37.85,37.85,0,0,1,37.85,37.85v15.26a0,0,0,0,1,0,0H60.15a0,0,0,0,1,0,0V155.12A37.85,37.85,0,0,1,98,117.27Z");
            var color = ActivatedWindow == "profile" ? SKColors.Lime : SKColors.Aqua;
            var userPaint = new SKPaint { Style = SKPaintStyle.Fill, Color = color };
            canvas.DrawPath(pathUserBody, userPaint);
            canvas.Save();

            //User Head

            canvas.DrawCircle(111.66f, 81.6f, 31.38f, userPaint);

        }

        #endregion

        #region Create Button
        private void Create_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            int width = e.Info.Width;
            int height = e.Info.Height;

            //Translate to the center and scale to 1229.71px
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(height / 219.57f);

            //Background circle
            canvas.Translate(-109.785f, -109.785f);
            SKPaint circlePaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,

            };

            circlePaint.Shader = SKShader.CreateLinearGradient(
               new SKPoint(109.19f, 0f),
               new SKPoint(109.19f, 415.24f),
               fillColors,
               new float[] { 0.19f, 0.32f, 0.45f, 0.57f, 0.68f },
               SKShaderTileMode.Repeat);

            canvas.DrawCircle(109.79f, 109.79f, 105.63f, circlePaint);

            //Ring Black
            var pathRing = SKPath.ParseSvgPathData("M109.79,8.31A101.48,101.48,0,1,1,8.31,109.79,101.59,101.59,0,0,1,109.79,8.31m0-8.31h0A109.78,109.78,0,0,0,0,109.79H0A109.78,109.78,0,0,0,109.79,219.57h0A109.78,109.78,0,0,0,219.57,109.79h0A109.78,109.78,0,0,0,109.79,0Z");
            var pathRingPaint = new SKPaint { Style = SKPaintStyle.Fill, Color = SKColor.Parse("1a1a1a") };
            canvas.DrawPath(pathRing, pathRingPaint);

            //plus icon
            var color = ActivatedWindow == "create" ? SKColors.Lime : SKColors.Aqua;

            var iconPaint = new SKPaint { Style = SKPaintStyle.Fill, Color = color };
            canvas.DrawRect(new SKRect(106.61f, 64.12f, 112.74f, 157.57f), iconPaint);
            canvas.DrawRect(new SKRect(63.06f, 107.89f, 156.513f, 114.02f), iconPaint);

            //Alo Ring
            var aloRing = SKPath.ParseSvgPathData("M109.79,18.91a91.94,91.94,0,1,0,91.94,91.94A91.94,91.94,0,0,0,109.79,18.91Zm0,168.55a76.62,76.62,0,1,1,76.61-76.61A76.61,76.61,0,0,1,109.79,187.46Z");
            canvas.DrawPath(aloRing, iconPaint);


        }

        #endregion

        #region Share Button
        private void Share_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            int width = e.Info.Width;
            int height = e.Info.Height;

            //Translate to the center and scale to 1229.71px
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(height / 219.57f);

            //Background circle
            canvas.Translate(-109.785f, -109.785f);
            SKPaint circlePaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,

            };

            circlePaint.Shader = SKShader.CreateLinearGradient(
               new SKPoint(109.19f, 0f),
               new SKPoint(109.19f, 415.24f),
               fillColors,
               new float[] { 0.19f, 0.32f, 0.45f, 0.57f, 0.68f },
               SKShaderTileMode.Repeat);

            canvas.DrawCircle(109.79f, 109.79f, 105.63f, circlePaint);

            //Ring Black
            var pathRing = SKPath.ParseSvgPathData("M109.79,8.31A101.48,101.48,0,1,1,8.31,109.79,101.59,101.59,0,0,1,109.79,8.31m0-8.31h0A109.78,109.78,0,0,0,0,109.79H0A109.78,109.78,0,0,0,109.79,219.57h0A109.78,109.78,0,0,0,219.57,109.79h0A109.78,109.78,0,0,0,109.79,0Z");
            var pathRingPaint = new SKPaint { Style = SKPaintStyle.Fill, Color = SKColor.Parse("1a1a1a") };
            canvas.DrawPath(pathRing, pathRingPaint);

            //Alo Ring
            var aloRing = SKPath.ParseSvgPathData("M109.79,18.91a91.94,91.94,0,1,0,91.94,91.94A91.94,91.94,0,0,0,109.79,18.91Zm0,168.55a76.62,76.62,0,1,1,76.61-76.61A76.61,76.61,0,0,1,109.79,187.46Z");
            var color = ActivatedWindow == "share" ? SKColors.Lime : SKColors.Aqua;

            var iconPaint = new SKPaint { Style = SKPaintStyle.Fill, Color = color };
            canvas.DrawPath(aloRing, iconPaint);

            //Share Icon
            var sharePath = SKPath.ParseSvgPathData("M138.85,131.25a15.35,15.35,0,0,0-5.65,1.08L83.56,109.74l48.68-20.81a15.24,15.24,0,1,0-7.51-7.88L80.31,100a15.29,15.29,0,1,0-2.26,18.4l47.05,21.43a15.29,15.29,0,1,0,13.75-8.61Z");
            canvas.DrawPath(sharePath, iconPaint);


        }

        #endregion

        #region Undo Button
        private void Undo_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            int width = e.Info.Width;
            int height = e.Info.Height;

            //Translate to the center and scale to 1229.71px
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(height / 226.53f);

            //Background circle
            canvas.Translate(-113.26f, -113.26f);
            SKPaint circlePaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,

            };

            circlePaint.Shader = SKShader.CreateLinearGradient(
               new SKPoint(113.26f, 0f),
               new SKPoint(113.26f, 440.79f),
               fillColors,
               new float[] { 0.19f, 0.32f, 0.45f, 0.57f, 0.68f },
               SKShaderTileMode.Repeat);

            canvas.DrawCircle(113.26f, 113.26f, 113.26f, circlePaint);
            canvas.Save();
            //Border
            var pathBorder = SKPath.ParseSvgPathData("M113.26,9.72A103.55,103.55,0,1,1,9.72,113.26,103.66,103.66,0,0,1,113.26,9.72m0-9.72A113.27,113.27,0,1,0,226.53,113.26,113.26,113.26,0,0,0,113.26,0Z");
            var pathBorderPaint = new SKPaint { Style = SKPaintStyle.Fill };


            pathBorderPaint.Shader = SKShader.CreateLinearGradient(
                new SKPoint(0, 113.26f),
                new SKPoint(226.53f, 113.26f),
                pathBorderColors,
                new float[10] { 0f, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
            SKShaderTileMode.Repeat
                );
            canvas.DrawPath(pathBorder, pathBorderPaint);
            canvas.Save();

            //icon
            var arrowPath = SKPath.ParseSvgPathData("M53.38,131.65A6.69,6.69,0,0,1,66.2,127.8,49.9,49.9,0,1,0,79.72,77.23L92.6,80,49.33,107,60.17,57.17,68.1,69.94a62.62,62.62,0,0,1,27.66-17,63.25,63.25,0,1,1-42.38,78.76Z");
            var iconPaint = new SKPaint { Style = SKPaintStyle.Fill, Color = SKColors.Aqua };
            canvas.DrawPath(arrowPath, iconPaint);

        }

        #endregion

        #region Search Button
        private void Search_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            int width = e.Info.Width;
            int height = e.Info.Height;

            //Translate to the center and scale to 320pxpx
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 320.17f);
            canvas.Translate(-160.085f, -114.605f);

            //Poligon
            var poligonPath = new SKPath();
            var points = new SKPoint[]
            {
                new SKPoint(5.63f, 225.21f),
                new SKPoint(82.88f, 4f),
                new SKPoint(237.29f, 4f),
                new SKPoint(314.54f, 225.21f),


            };
            poligonPath.AddPoly(points, true);

            var poligonPaint = new SKPaint { Style = SKPaintStyle.Fill };
            var poligonColors = new SKColor[6]
            {
                SKColor.Parse("2e313b"),
                SKColor.Parse("2b2e37"),
                SKColor.Parse("22242b"),
                SKColor.Parse("121418"),
                SKColors.Black,
                SKColors.Black
            };
            poligonPaint.Shader = SKShader.CreateLinearGradient(
              new SKPoint(5.63f, 114.61f),
              new SKPoint(314.54f, 114.61f),
              poligonColors,
              new float[] { 0.2f, 0.28f, 0.36f, 0.43f, 0.5f, 0.8f },
              SKShaderTileMode.Repeat);

            canvas.DrawPath(poligonPath, poligonPaint);

            //Background
            var pathBackground = SKPath.ParseSvgPathData("M234.45,8,308.9,221.21H11.27L85.72,8H234.45m5.68-8H80L0,229.21H320.17L240.13,0Z");
            canvas.DrawPath(pathBackground, new SKPaint { Style = SKPaintStyle.Fill, Color = SKColor.Parse("1a1a1a") });

            //Search Icon
            var searchIcon = SKPath.ParseSvgPathData("M165.53,198.88l.44-40a36,36,0,1,0-19.33-.22l-.44,40.06a9,9,0,0,0,8.92,9.12h1.3A9,9,0,0,0,165.53,198.88Zm-29.29-96.63a29.95,29.95,0,1,1-1.42,42.32A29.93,29.93,0,0,1,136.24,102.25Z");
            var color = ActivatedWindow == "search" ? SKColors.Lime : SKColors.Aqua;

            canvas.DrawPath(searchIcon, new SKPaint { Style = SKPaintStyle.Fill, Color = color });

            //Light Bar 1
            var barPaintIntern = new SKPaint { Style = SKPaintStyle.Fill };
            var barPaintInternColors = new SKColor[]
            {
                SKColor.Parse("b1fffb"),
                SKColor.Parse("00fff5"),
                SKColor.Parse("00fdf5"),
                SKColor.Parse("00f6f4"),
                SKColor.Parse("00ebf3"),
                SKColor.Parse("00daf1"),
                SKColor.Parse("00c4ee"),
                SKColor.Parse("00a8eb"),
                SKColor.Parse("0088e8"),
                SKColor.Parse("0162e4"),
                SKColor.Parse("0137df"),
                SKColor.Parse("0109da"),
                SKColor.Parse("0101d9")
            };
            barPaintIntern.Shader = SKShader.CreateLinearGradient(
             new SKPoint(96.12f, 27.81f),
             new SKPoint(224.05f, 27.81f),
             barPaintInternColors,
             new float[] { 0f, 0.9f, 0.94f, 0.95f, 0.96f, 0.97f, 0.97f, 0.98f, 0.99f, 0.99f, 1, 1, 1 },
             SKShaderTileMode.Repeat);

            canvas.DrawRect(new SKRect(96.12f, 22.75f, 224.06f, 32.87f), barPaintIntern);

            var barPaintExtern = new SKPaint { Style = SKPaintStyle.Fill };
            var barPaintExternColors = new SKColor[]
            {
                SKColor.Parse("80ffffff"),
                SKColor.Parse("80fcfcfc"),
                SKColor.Parse("80f4f4f4"),
                SKColor.Parse("80e5e5e5"),
                SKColor.Parse("80d0d0d0"),
                SKColor.Parse("80b5b5b5"),
                SKColor.Parse("80949494"),
                SKColor.Parse("806c6c6c"),
                SKColor.Parse("803e3e3e"),
                SKColor.Parse("800c0c0c"),
                SKColor.Parse("80000000"),
                SKColors.Black

            };
            barPaintExtern.Shader = SKShader.CreateRadialGradient(
                new SKPoint(160.09f, 27.37f),
                53.63f,
                barPaintExternColors,
                new float[] { 0.62f, 0.68f, 0.72f, 0.75f, 0.78f, 0.81f, 0.84f, 0.86f, 0.89f, 0.91f, 0.91f, 0.92f },
                SKShaderTileMode.Clamp
            );
            canvas.DrawRect(new SKRect(93.03f, 21.21f, 227.13f, 33.54f), barPaintExtern);

            //Light bar 2
            var barPaintIntern2 = new SKPaint { Style = SKPaintStyle.Fill };
            barPaintIntern2.Shader = SKShader.CreateLinearGradient(
             new SKPoint(109.9f, 51.41f),
             new SKPoint(208.31f, 51.41f),
             barPaintInternColors,
             new float[] { 0f, 0.9f, 0.94f, 0.95f, 0.96f, 0.97f, 0.97f, 0.98f, 0.99f, 0.99f, 1, 1, 1 },
             SKShaderTileMode.Repeat);
            canvas.DrawRect(new SKRect(109.9f, 46.35f, 208.31f, 56.47f), barPaintIntern2);
            var barPaintExtern2 = new SKPaint { Style = SKPaintStyle.Fill };
            barPaintExtern2.Shader = SKShader.CreateRadialGradient(
               new SKPoint(160.86f, 51.265f),
               43.16f,
               barPaintExternColors,
               new float[] { 0.62f, 0.68f, 0.72f, 0.75f, 0.78f, 0.81f, 0.84f, 0.86f, 0.89f, 0.91f, 0.91f, 0.92f },
               SKShaderTileMode.Clamp
           );
            canvas.DrawRect(new SKRect(106.91f, 45.87f, 214.81f, 56.66f), barPaintExtern2);


            //LightBar 3
            var barPaintIntern3 = new SKPaint { Style = SKPaintStyle.Fill };
            barPaintIntern3.Shader = SKShader.CreateLinearGradient(
             new SKPoint(129.58f, 71.64f),
             new SKPoint(188.63f, 71.64f),
             barPaintInternColors,
             new float[] { 0f, 0.9f, 0.94f, 0.95f, 0.96f, 0.97f, 0.97f, 0.98f, 0.99f, 0.99f, 1, 1, 1 },
             SKShaderTileMode.Repeat);
            canvas.DrawRect(new SKRect(129.58f, 66.58f, 188.63f, 77.39f), barPaintIntern3);

            var barPaintExtern3 = new SKPaint { Style = SKPaintStyle.Fill };
            barPaintExtern3.Shader = SKShader.CreateRadialGradient(
               new SKPoint(159.31f, 71.98f),
               27.128f,
               barPaintExternColors,
               new float[] { 0.62f, 0.68f, 0.72f, 0.75f, 0.78f, 0.81f, 0.84f, 0.86f, 0.89f, 0.91f, 0.91f, 0.92f },
               SKShaderTileMode.Clamp
           );
            canvas.DrawRect(new SKRect(125.4f, 66.58f, 193.22f, 77.37f), barPaintExtern3);

        }

        #endregion

        #region Only Search Button
        private void Only_Search_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            int width = e.Info.Width;
            int height = e.Info.Height;

            //Translate to the center and scale to 320pxpx
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 221.69f);
            canvas.Translate(-110.845f, -44.09f);

            //Poligon
            var poligonPath = new SKPath();
            var points = new SKPoint[]
            {
                new SKPoint(5.63f, 84.19f),
                new SKPoint(33.64f, 4f),
                new SKPoint(188.05f, 4f),
                new SKPoint(216.06f, 84.19f),
                new SKPoint(5.63f, 84.19f)
            };
            poligonPath.AddPoly(points, true);

            var poligonPaint = new SKPaint { Style = SKPaintStyle.Fill };
            var poligonColors = new SKColor[6]
            {
                SKColor.Parse("2e313b"),
                SKColor.Parse("2b2e37"),
                SKColor.Parse("22242b"),
                SKColor.Parse("121418"),
                SKColors.Black,
                SKColors.Black
            };
            poligonPaint.Shader = SKShader.CreateLinearGradient(
              new SKPoint(5.63f, 44.09f),
              new SKPoint(221.06f, 44.09f),
              poligonColors,
              new float[] { 0.2f, 0.28f, 0.36f, 0.43f, 0.5f, 0.8f },
              SKShaderTileMode.Repeat);

            canvas.DrawPath(poligonPath, poligonPaint);

            //Background
            var pathBackground = SKPath.ParseSvgPathData("M185.21,8l25.21,72.19H11.27L36.48,8H185.21M0,88.19H221.69L190.89,0H30.8L0,88.19");
            canvas.DrawPath(pathBackground, new SKPaint { Style = SKPaintStyle.Fill, Color = SKColor.Parse("1a1a1a") });


            //Light Bar 1
            var barPaintIntern = new SKPaint { Style = SKPaintStyle.Fill };
            var barPaintInternColors = new SKColor[]
            {
                SKColor.Parse("b1fffb"),
                SKColor.Parse("00fff5"),
                SKColor.Parse("00fdf5"),
                SKColor.Parse("00f6f4"),
                SKColor.Parse("00ebf3"),
                SKColor.Parse("00daf1"),
                SKColor.Parse("00c4ee"),
                SKColor.Parse("00a8eb"),
                SKColor.Parse("0088e8"),
                SKColor.Parse("0162e4"),
                SKColor.Parse("0137df"),
                SKColor.Parse("0109da"),
                SKColor.Parse("0101d9")
            };
            barPaintIntern.Shader = SKShader.CreateLinearGradient(
             new SKPoint(46.88f, 27.95f),
             new SKPoint(174.81f, 27.95f),
             barPaintInternColors,
             new float[] { 0f, 0.9f, 0.94f, 0.95f, 0.96f, 0.97f, 0.97f, 0.98f, 0.99f, 0.99f, 1, 1, 1 },
             SKShaderTileMode.Repeat);

            canvas.DrawRect(new SKRect(46.88f, 22.89f, 174.82f, 33.01f), barPaintIntern);

            var barPaintExtern = new SKPaint { Style = SKPaintStyle.Fill };
            var barPaintExternColors = new SKColor[]
            {
                SKColor.Parse("80ffffff"),
                SKColor.Parse("80fcfcfc"),
                SKColor.Parse("80f4f4f4"),
                SKColor.Parse("80e5e5e5"),
                SKColor.Parse("80d0d0d0"),
                SKColor.Parse("80b5b5b5"),
                SKColor.Parse("80949494"),
                SKColor.Parse("806c6c6c"),
                SKColor.Parse("803e3e3e"),
                SKColor.Parse("800c0c0c"),
                SKColor.Parse("80000000"),
                SKColors.Black

            };
            barPaintExtern.Shader = SKShader.CreateRadialGradient(
                new SKPoint(110.99f, 27.55f),
                53.76f,
                barPaintExternColors,
                new float[] { 0.62f, 0.68f, 0.72f, 0.75f, 0.78f, 0.81f, 0.84f, 0.86f, 0.89f, 0.91f, 0.91f, 0.92f },
                SKShaderTileMode.Clamp
            );
            canvas.DrawRect(new SKRect(43.79f, 21.35f, 178.2f, 33.68f), barPaintExtern);

            //Light bar 2
            var barPaintIntern2 = new SKPaint { Style = SKPaintStyle.Fill };
            barPaintIntern2.Shader = SKShader.CreateLinearGradient(
             new SKPoint(60.65f, 51.55f),
             new SKPoint(159.07f, 51.55f),
             barPaintInternColors,
             new float[] { 0f, 0.9f, 0.94f, 0.95f, 0.96f, 0.97f, 0.97f, 0.98f, 0.99f, 0.99f, 1, 1, 1 },
             SKShaderTileMode.Repeat);
            canvas.DrawRect(new SKRect(60.65f, 46.49f, 159.06f, 56.61f), barPaintIntern2);

            var barPaintExtern2 = new SKPaint { Style = SKPaintStyle.Fill };
            barPaintExtern2.Shader = SKShader.CreateRadialGradient(
               new SKPoint(111.62f, 51.40f),
               43.16f,
               barPaintExternColors,
               new float[] { 0.62f, 0.68f, 0.72f, 0.75f, 0.78f, 0.81f, 0.84f, 0.86f, 0.89f, 0.91f, 0.91f, 0.92f },
               SKShaderTileMode.Clamp
           );
            canvas.DrawRect(new SKRect(57.67f, 46.01f, 165.57f, 56.8f), barPaintExtern2);


            //LightBar 3
            var barPaintIntern3 = new SKPaint { Style = SKPaintStyle.Fill };
            barPaintIntern3.Shader = SKShader.CreateLinearGradient(
             new SKPoint(80.34f, 71.78f),
             new SKPoint(139.38f, 71.78f),
             barPaintInternColors,
             new float[] { 0f, 0.9f, 0.94f, 0.95f, 0.96f, 0.97f, 0.97f, 0.98f, 0.99f, 0.99f, 1, 1, 1 },
             SKShaderTileMode.Repeat);
            canvas.DrawRect(new SKRect(80.34f, 66.72f, 139.39f, 76.84f), barPaintIntern3);

            var barPaintExtern3 = new SKPaint { Style = SKPaintStyle.Fill };
            barPaintExtern3.Shader = SKShader.CreateRadialGradient(
               new SKPoint(110.07f, 71.44f),
               27.128f,
               barPaintExternColors,
               new float[] { 0.62f, 0.68f, 0.72f, 0.75f, 0.78f, 0.81f, 0.84f, 0.86f, 0.89f, 0.91f, 0.91f, 0.92f },
               SKShaderTileMode.Clamp
           );
            canvas.DrawRect(new SKRect(76.16f, 66.05f, 143.98f, 76.84f), barPaintExtern3);

        }


        #endregion

        #region Command Methods
        private void TappedCloseToolbar(object sender, EventArgs e)
        {
            StateToolbar = ToolbarStates.EXPANDED;
        }
        private void Profile_Tapped(object sender, EventArgs e)
        {
            ProfileCommand?.Execute(null);
        }
        private void Create_Tapped(object sender, EventArgs e)
        {
            CreateCommand?.Execute(null);
        }
        private void Search_Tapped(object sender, EventArgs e)
        {
            SearchCommand?.Execute(null);
        }
        private void Share_Tapped(object sender, EventArgs e)
        {
            ShareCommand?.Execute(null);
        }
        private void Undo_Tapped(object sender, EventArgs e)
        {
            UndoCommand?.Execute(null);
        }

        private void OpenToolbarMethod(object sender, EventArgs e)
        {
            StateToolbar = ToolbarStates.OPENED;
        }
        #endregion


    }

}