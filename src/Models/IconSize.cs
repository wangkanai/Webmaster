﻿using System.Drawing;

namespace Wangkanai.Webmaster.Models
{
    public enum IconSize
    {
        X16  = 16,
        X24  = 24,
        X32  = 32,
        X64  = 64,
        X128 = 128,
        X256 = 256,
        X512 = 512
    }
    
    public static class IconSizeExtensions{
        public static int ToInt(this IconSize size) 
            => (int) size;

        public static string Value(this IconSize size)
            => size.ToInt().ToString();
    }
}