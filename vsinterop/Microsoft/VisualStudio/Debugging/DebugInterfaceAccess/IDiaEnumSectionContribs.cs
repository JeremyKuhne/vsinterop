// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaEnumSectionContribs : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x1994DEB2, 0x2C82, 0x4B1D, 0xA5, 0x7F, 0xAF, 0xF4, 0x24, 0xD5, 0x4A, 0x68);
#pragma warning restore IDE1006

#if NETFRAMEWORK
    readonly ref readonly Guid IComIID.Guid => ref IID_Guid;
#else
    static ref readonly Guid IComIID.Guid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ReadOnlySpan<byte> data =
            [
                0xB2, 0xDE, 0x94, 0x19,
                0x82, 0x2C,
                0x1D, 0x4B,
                0xA5, 0x7F, 0xAF, 0xF4, 0x24, 0xD5, 0x4A, 0x68
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaEnumSectionContribs* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSectionContribs*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaEnumSectionContribs* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSectionContribs*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaEnumSectionContribs* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSectionContribs*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get__NewEnum"/>
    public HRESULT get__NewEnum(IUnknown** pRetVal)
    {
        fixed (IDiaEnumSectionContribs* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSectionContribs*, IUnknown**, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_Count"/>
    public HRESULT get_Count(int* pRetVal)
    {
        fixed (IDiaEnumSectionContribs* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSectionContribs*, int*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.Item"/>
    public HRESULT Item(uint index, IDiaSectionContrib** section)
    {
        fixed (IDiaEnumSectionContribs* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSectionContribs*, uint, IDiaSectionContrib**, HRESULT>)_lpVtbl[5])(pThis, index, section);
    }

    /// <inheritdoc cref="Interface.Next"/>
    public HRESULT Next(uint celt, IDiaSectionContrib** rgelt, uint* pceltFetched)
    {
        fixed (IDiaEnumSectionContribs* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSectionContribs*, uint, IDiaSectionContrib**, uint*, HRESULT>)_lpVtbl[6])(pThis, celt, rgelt, pceltFetched);
    }

    /// <inheritdoc cref="Interface.Skip"/>
    public HRESULT Skip(uint celt)
    {
        fixed (IDiaEnumSectionContribs* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSectionContribs*, uint, HRESULT>)_lpVtbl[7])(pThis, celt);
    }

    /// <inheritdoc cref="Interface.Reset"/>
    public HRESULT Reset()
    {
        fixed (IDiaEnumSectionContribs* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSectionContribs*, HRESULT>)_lpVtbl[8])(pThis);
    }

    /// <inheritdoc cref="Interface.Clone"/>
    public HRESULT Clone(IDiaEnumSectionContribs** ppenum)
    {
        fixed (IDiaEnumSectionContribs* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSectionContribs*, IDiaEnumSectionContribs**, HRESULT>)_lpVtbl[9])(pThis, ppenum);
    }

    /// <summary>
    ///  Enumerates the various section contributions contained in the data source.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaenumsectioncontribs">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("1994DEB2-2C82-4B1D-A57F-AFF424D54A68")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Retrieves a version of this enumerator as a COM <c>IEnumVARIANT</c> enumerator.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get__NewEnum(IUnknown** pRetVal);

        /// <summary>
        ///  Number of section contributions.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_Count(int* pRetVal);

        /// <summary>
        ///  Returns the section contribution for the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to retrieve.</param>
        /// <param name="section">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Item(uint index, IDiaSectionContrib** section);

        /// <summary>
        ///  Retrieves the next item or items in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of items to retrieve.</param>
        /// <param name="rgelt">Pointer to a variable that receives the requested object.</param>
        /// <param name="pceltFetched">Pointer to a variable that receives the number of items actually retrieved.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Next(uint celt, IDiaSectionContrib** rgelt, uint* pceltFetched);

        /// <summary>
        ///  Skips a specified number of items in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of items to retrieve.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Skip(uint celt);

        /// <summary>
        ///  Resets the enumeration sequence to the beginning.
        /// </summary>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        ///  Creates an enumerator that contains the same enumeration state as the current enumerator.
        /// </summary>
        /// <param name="ppenum">Pointer to a variable that receives the cloned enumerator.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Clone(IDiaEnumSectionContribs** ppenum);
    }
}
