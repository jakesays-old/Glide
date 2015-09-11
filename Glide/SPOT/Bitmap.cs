////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.CompilerServices;
using Microsoft.SPOT.Hardware;

namespace Microsoft.SPOT
{
    public abstract class Bitmap : IDisposable
    {
        public static readonly int MaxWidth;//      = 220;
        public static readonly int MaxHeight;// = 176;
        public static readonly int CenterX;// = (MaxWidth - 1) / 2;
        public static readonly int CenterY;// = (MaxHeight - 1) / 2;

        static Bitmap()
        {
            int bpp, orientation;
            Microsoft.SPOT.Hardware.HardwareProvider hwProvider1 = Microsoft.SPOT.Hardware.HardwareProvider.HwProvider;

            hwProvider1.GetLCDMetrics(out MaxWidth, out MaxHeight, out bpp, out orientation);

            CenterX = (MaxWidth - 1) / 2;
            CenterY = (MaxHeight - 1) / 2;
        }

        public const ushort OpacityOpaque = 256;
        public const ushort OpacityTransparent = 0;

        public const int SRCCOPY = 0x00000001;
        public const int PATINVERT = 0x00000002;
        public const int DSTINVERT = 0x00000003;
        public const int BLACKNESS = 0x00000004;
        public const int WHITENESS = 0x00000005;
        public const int DSTGRAY = 0x00000006;
        public const int DSTLTGRAY = 0x00000007;
        public const int DSTDKGRAY = 0x00000008;
        public const int SINGLEPIXEL = 0x00000009;
        public const int RANDOM = 0x0000000a;

        //
        // These have to be kept in sync with the CLR_GFX_Bitmap::c_DrawText_ flags.
        //
        public const uint DT_None = 0x00000000;
        public const uint DT_WordWrap = 0x00000001;
        public const uint DT_TruncateAtBottom = 0x00000004;
        [Obsolete("Use DT_TrimmingWordEllipsis or DT_TrimmingCharacterEllipsis to specify the type of trimming needed.", false)]
        public const uint DT_Ellipsis = 0x00000008;
        public const uint DT_IgnoreHeight = 0x00000010;
        public const uint DT_AlignmentLeft = 0x00000000;
        public const uint DT_AlignmentCenter = 0x00000002;
        public const uint DT_AlignmentRight = 0x00000020;
        public const uint DT_AlignmentMask = 0x00000022;

        public const uint DT_TrimmingNone = 0x00000000;
        public const uint DT_TrimmingWordEllipsis = 0x00000008;
        public const uint DT_TrimmingCharacterEllipsis = 0x00000040;
        public const uint DT_TrimmingMask = 0x00000048;

        //--//

        // Note that these values have to match the c_Type* consts in CLR_GFX_BitmapDescription
        public enum BitmapImageType : byte
        {
            TinyCLRBitmap = 0,
            Gif = 1,
            Jpeg = 2,
            Bmp = 3 // The windows .bmp format
        }

        //--//

       
//        public abstract Bitmap(int width, int height);

        

//        public abstract Bitmap(byte[] imageData, BitmapImageType type);

        
        public abstract void Flush();

        
        public abstract void Flush(int x, int y, int width, int height);

        
        public abstract void Clear();

        
        public abstract bool DrawTextInRect(ref string text, ref int xRelStart, ref int yRelStart, int x, int y, int width, int height, uint dtFlags, Microsoft.SPOT.Presentation.Media.Color color, Font font);

        public void DrawTextInRect(string text, int x, int y, int width, int height, uint dtFlags, Microsoft.SPOT.Presentation.Media.Color color, Font font)
        {
            int xRelStart = 0;
            int yRelStart = 0;

            DrawTextInRect(ref text, ref xRelStart, ref yRelStart, x, y, width, height, dtFlags, color, font);
        }

        
        public abstract void SetClippingRectangle(int x, int y, int width, int height);

        public abstract int Width
        {
            
            get;
        }

        public abstract int Height
        {
            
            get;
        }

        
        public abstract void DrawEllipse(
            Microsoft.SPOT.Presentation.Media.Color colorOutline, int thicknessOutline,
            int x, int y, int xRadius, int yRadius,
            Microsoft.SPOT.Presentation.Media.Color colorGradientStart, int xGradientStart, int yGradientStart,
            Microsoft.SPOT.Presentation.Media.Color colorGradientEnd, int xGradientEnd, int yGradientEnd,
            ushort opacity);

        public void DrawEllipse(Microsoft.SPOT.Presentation.Media.Color colorOutline, int x, int y, int xRadius, int yRadius)
        {
            DrawEllipse(colorOutline, 1, x, y, xRadius, yRadius, Microsoft.SPOT.Presentation.Media.Color.Black, 0, 0, Microsoft.SPOT.Presentation.Media.Color.Black, 0, 0, OpacityOpaque);
        }

        public void DrawImage(int xDst, int yDst, Bitmap bitmap, int xSrc, int ySrc, int width, int height)
        {
            DrawImage(xDst, yDst, bitmap, xSrc, ySrc, width, height, OpacityOpaque);
        }

        
        public abstract void DrawImage(int xDst, int yDst, Bitmap bitmap, int xSrc, int ySrc, int width, int height, ushort opacity);

        
        public abstract void RotateImage(int angle, int xDst, int yDst, Bitmap bitmap, int xSrc, int ySrc, int width, int height, ushort opacity);

        
        public abstract void MakeTransparent(Microsoft.SPOT.Presentation.Media.Color color);

        
        public abstract void StretchImage(int xDst, int yDst, Bitmap bitmap, int width, int height, ushort opacity);

        
        public abstract void DrawLine(Microsoft.SPOT.Presentation.Media.Color color, int thickness, int x0, int y0, int x1, int y1);

        
        public abstract void DrawRectangle(
            Microsoft.SPOT.Presentation.Media.Color colorOutline, int thicknessOutline,
            int x, int y, int width, int height, int xCornerRadius, int yCornerRadius,
            Microsoft.SPOT.Presentation.Media.Color colorGradientStart, int xGradientStart, int yGradientStart,
            Microsoft.SPOT.Presentation.Media.Color colorGradientEnd, int xGradientEnd, int yGradientEnd,
            ushort opacity
            );

        
        public abstract void DrawText(string text, Font font, Microsoft.SPOT.Presentation.Media.Color color, int x, int y);

        
        public abstract void SetPixel(int xPos, int yPos, Microsoft.SPOT.Presentation.Media.Color color);

        
        public abstract Microsoft.SPOT.Presentation.Media.Color GetPixel(int xPos, int yPos);

        
        public abstract byte[] GetBitmap();

        
        public abstract void StretchImage(int xDst, int yDst, int widthDst, int heightDst, Bitmap bitmap, int xSrc, int ySrc, int widthSrc, int heightSrc, ushort opacity);

        
        public abstract void TileImage(int xDst, int yDst, Bitmap bitmap, int width, int height, ushort opacity);

        
        public abstract void Scale9Image(int xDst, int yDst, int widthDst, int heightDst, Bitmap bitmap, int leftBorder, int topBorder, int rightBorder, int bottomBorder, ushort opacity);

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        protected abstract void Dispose(bool disposing);

        ~Bitmap()
        {
            Dispose(false);
        }
    }
}


