// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

// CsWin32 attaches the IComIID interface (with a static-abstract Guid) to generated COM structs
// only on .NET 7 and later. On .NET Framework we ship this instance-based partial so the generated
// type can be used through ComScope<T> and IID.Get<T>(), mirroring Madowaku's per-struct polyfills.
#if NETFRAMEWORK

namespace Windows.Win32.System.Com.StructuredStorage;

/// <summary>
///  Enumerates an array of <c>STATPROPSTG</c> structures describing the properties in a property set.
/// </summary>
public partial struct IEnumSTATPROPSTG : IComIID
{
    readonly ref readonly Guid IComIID.Guid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref Unsafe.AsRef(in IID_Guid);
    }
}

#endif
