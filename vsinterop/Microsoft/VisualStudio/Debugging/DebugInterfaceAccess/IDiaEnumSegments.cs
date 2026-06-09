// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaEnumSegments : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0xE8368CA9, 0x01D1, 0x419D, 0xAC, 0x0C, 0xE3, 0x12, 0x35, 0xDB, 0xDA, 0x9F);
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
                0xA9, 0x8C, 0x36, 0xE8,
                0xD1, 0x01,
                0x9D, 0x41,
                0xAC, 0x0C, 0xE3, 0x12, 0x35, 0xDB, 0xDA, 0x9F
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaEnumSegments* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSegments*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaEnumSegments* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSegments*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaEnumSegments* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSegments*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get__NewEnum"/>
    public HRESULT get__NewEnum(IUnknown** pRetVal)
    {
        fixed (IDiaEnumSegments* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSegments*, IUnknown**, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_Count"/>
    public HRESULT get_Count(int* pRetVal)
    {
        fixed (IDiaEnumSegments* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSegments*, int*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.Item"/>
    public HRESULT Item(uint index, IDiaSegment** segment)
    {
        fixed (IDiaEnumSegments* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSegments*, uint, IDiaSegment**, HRESULT>)_lpVtbl[5])(pThis, index, segment);
    }

    /// <inheritdoc cref="Interface.Next"/>
    public HRESULT Next(uint celt, IDiaSegment** rgelt, uint* pceltFetched)
    {
        fixed (IDiaEnumSegments* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSegments*, uint, IDiaSegment**, uint*, HRESULT>)_lpVtbl[6])(pThis, celt, rgelt, pceltFetched);
    }

    /// <inheritdoc cref="Interface.Skip"/>
    public HRESULT Skip(uint celt)
    {
        fixed (IDiaEnumSegments* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSegments*, uint, HRESULT>)_lpVtbl[7])(pThis, celt);
    }

    /// <inheritdoc cref="Interface.Reset"/>
    public HRESULT Reset()
    {
        fixed (IDiaEnumSegments* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSegments*, HRESULT>)_lpVtbl[8])(pThis);
    }

    /// <inheritdoc cref="Interface.Clone"/>
    public HRESULT Clone(IDiaEnumSegments** ppenum)
    {
        fixed (IDiaEnumSegments* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSegments*, IDiaEnumSegments**, HRESULT>)_lpVtbl[9])(pThis, ppenum);
    }

    /// <summary>
    ///  Enumerates the various segments contained in the data source.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaenumsegments">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("E8368CA9-01D1-419D-AC0C-E31235DBDA9F")]
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
        ///  Number of segments.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_Count(int* pRetVal);

        /// <summary>
        ///  Returns the segment for the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to retrieve.</param>
        /// <param name="segment">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Item(uint index, IDiaSegment** segment);

        /// <summary>
        ///  Retrieves the next item or items in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of items to retrieve.</param>
        /// <param name="rgelt">Pointer to a variable that receives the requested object.</param>
        /// <param name="pceltFetched">Pointer to a variable that receives the number of items actually retrieved.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Next(uint celt, IDiaSegment** rgelt, uint* pceltFetched);

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
        HRESULT Clone(IDiaEnumSegments** ppenum);
    }
}
