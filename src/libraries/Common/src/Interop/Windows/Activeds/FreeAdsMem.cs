// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Activeds
    {
        internal static partial class SafeNativeMethods
        {
            [DllImport(Libraries.Activeds)]
            public static extern bool FreeADsMem(IntPtr pVoid);
        }
    }
}
