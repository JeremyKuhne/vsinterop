// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <summary>
///  Specifies the kind of memory to read during a stack walk.
/// </summary>
public enum MemoryTypeEnum
{
    /// <summary>Read-only code memory.</summary>
    MemTypeCode = 0,

    /// <summary>Read-only data or stack memory.</summary>
    MemTypeData = 1,

    /// <summary>Read-only stack memory.</summary>
    MemTypeStack = 2,

    /// <summary>Read-only memory for code generated on the heap by the runtime.</summary>
    MemTypeCodeOnHeap = 3,

    /// <summary>Any of the available memory types.</summary>
    MemTypeAny = -1
}
