﻿using System;

namespace SunabaSDK.Providers.Texture
{
    [Flags]
    public enum TextureFlags : uint
    {
        None = 1u << 0,
        Transparent = 1u << 1,
    }
}