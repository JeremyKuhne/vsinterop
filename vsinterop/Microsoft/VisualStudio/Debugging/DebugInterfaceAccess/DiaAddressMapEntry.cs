// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

// Interop structure: the public fields mirror the native memory layout and are read and written
// directly by callers and passed by pointer to native code, so visible fields are required.
#pragma warning disable CA1051 // Do not declare visible instance fields

/// <summary>
///  Describes a single entry in an address map used by <see cref="IDiaAddressMap"/> to translate
///  between two relative virtual address (RVA) spaces.
/// </summary>
public struct DiaAddressMapEntry
{
    /// <summary>
    ///  The source relative virtual address.
    /// </summary>
    public uint rva;

    /// <summary>
    ///  The relative virtual address that <see cref="rva"/> maps to.
    /// </summary>
    public uint rvaTo;
}
