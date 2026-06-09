// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <summary>
///  Class identifiers (CLSIDs) for the Debug Interface Access (DIA) SDK coclasses exposed by msdia*.dll.
/// </summary>
/// <remarks>
///  <para>
///   Use these with <c>CoCreateInstance</c> or a class factory (for example, by loading <c>msdia140.dll</c>
///   directly and calling <c>DllGetClassObject</c>) to create the corresponding DIA objects.
///  </para>
/// </remarks>
public static class CLASSID
{
    /// <summary>
    ///  CLSID of the <c>DiaSource</c> class, which provides an <see cref="IDiaDataSource"/> that allocates from
    ///  the process heap and returns <c>BSTR</c> values that can be freed with the standard <c>SysFreeString</c>.
    /// </summary>
    /// <value>The CLSID <c>{E6756135-1E65-4D17-8576-610761398C3C}</c>.</value>
    public static Guid DiaSource { get; } = new(0xe6756135, 0x1e65, 0x4d17, 0x85, 0x76, 0x61, 0x07, 0x61, 0x39, 0x8c, 0x3c);

    /// <summary>
    ///  CLSID of the <c>DiaSourceAlt</c> class, a variant of <c>DiaSource</c> that does not use the system heap.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   A process may create either <c>DiaSourceAlt</c> objects or <c>DiaSource</c> objects, but not both. When
    ///   using <c>DiaSourceAlt</c>, all returned <c>BSTR</c> values are really <c>LPCOLESTR</c> and must be released
    ///   with <c>LocalFree</c> rather than the usual <c>BSTR</c> routines.
    ///  </para>
    /// </remarks>
    /// <value>The CLSID <c>{91904831-49CA-4766-B95C-25397E2DD6DC}</c>.</value>
    public static Guid DiaSourceAlt { get; } = new(0x91904831, 0x49ca, 0x4766, 0xb9, 0x5c, 0x25, 0x39, 0x7e, 0x2d, 0xd6, 0xdc);

    /// <summary>
    ///  CLSID of the <c>DiaStackWalker</c> class, which provides an <see cref="IDiaStackWalker"/> for performing
    ///  general stack walks.
    /// </summary>
    /// <value>The CLSID <c>{CE4A85DB-5768-475B-A4E1-C0BCA2112A6B}</c>.</value>
    public static Guid DiaStackWalker { get; } = new(0xce4a85db, 0x5768, 0x475b, 0xa4, 0xe1, 0x0c, 0xbc, 0xa2, 0x11, 0x2a, 0x6b);
}
