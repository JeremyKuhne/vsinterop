// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

// CsWin32 attaches the IComIID interface (with a static-abstract Guid) to generated COM structs
// only on .NET 7 and later. On .NET Framework we ship this instance-based partial so the generated
// type can be used through ComScope<T> and IID.Get<T>(), mirroring Madowaku's per-struct polyfills.
#if NETFRAMEWORK

namespace Windows.Win32.System.Com;

/// <summary>
///  Enumerates a sequence of COM objects.
/// </summary>
public partial struct IEnumUnknown : IComIID
{
    readonly ref readonly Guid IComIID.Guid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref Unsafe.AsRef(in IID_Guid);
    }
}

#endif
