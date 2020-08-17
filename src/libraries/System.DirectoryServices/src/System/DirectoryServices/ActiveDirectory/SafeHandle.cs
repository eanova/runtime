// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Security;
using Microsoft.Win32.SafeHandles;
using static Interop.Advapi32;

namespace System.DirectoryServices.ActiveDirectory
{
    internal sealed class PolicySafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal PolicySafeHandle(IntPtr value) : base(true)
        {
            SetHandle(value);
        }

        protected override bool ReleaseHandle() => LsaClose(handle) == 0;
    }

    internal sealed class LsaLogonProcessSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private LsaLogonProcessSafeHandle() : base(true) { }

        internal LsaLogonProcessSafeHandle(IntPtr value) : base(true)
        {
            SetHandle(value);
        }

        protected override bool ReleaseHandle() => NativeMethods.LsaDeregisterLogonProcess(handle) == 0;
    }

    internal sealed class LoadLibrarySafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private LoadLibrarySafeHandle() : base(true) { }

        internal LoadLibrarySafeHandle(IntPtr value) : base(true)
        {
            SetHandle(value);
        }

        protected override bool ReleaseHandle() => UnsafeNativeMethods.FreeLibrary(handle) != 0;
    }
}
