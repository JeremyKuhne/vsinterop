// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

// Interop structure: the public fields mirror the native memory layout and are read and written
// directly by callers and passed by pointer to native code, so visible fields are required.
#pragma warning disable CA1051 // Do not declare visible instance fields

/// <summary>
///  Holds a numeric value obtained from a tagged union, which can be 8, 16, 32, 64 or 128 bits in size.
/// </summary>
/// <remarks>
///  <para>
///   <see cref="valueSizeBytes"/> contains the size, in bytes, of the data stored in <see cref="value"/>.
///  </para>
/// </remarks>
public unsafe struct DiaTagValue
{
    /// <summary>
    ///  The raw value bytes. Up to 16 bytes (128 bits) are valid.
    /// </summary>
    public fixed byte value[16];

    /// <summary>
    ///  The number of valid bytes stored in <see cref="value"/>.
    /// </summary>
    public byte valueSizeBytes;
}
