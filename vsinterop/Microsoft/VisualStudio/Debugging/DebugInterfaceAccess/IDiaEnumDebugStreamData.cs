// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaEnumDebugStreamData : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x486943E8, 0xD187, 0x4A6B, 0xA3, 0xC4, 0x29, 0x12, 0x59, 0xFF, 0xF6, 0x0D);
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
                0xE8, 0x43, 0x69, 0x48,
                0x87, 0xD1,
                0x6B, 0x4A,
                0xA3, 0xC4, 0x29, 0x12, 0x59, 0xFF, 0xF6, 0x0D
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaEnumDebugStreamData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreamData*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaEnumDebugStreamData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreamData*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaEnumDebugStreamData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreamData*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get__NewEnum"/>
    public HRESULT get__NewEnum(IUnknown** pRetVal)
    {
        fixed (IDiaEnumDebugStreamData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreamData*, IUnknown**, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_Count"/>
    public HRESULT get_Count(int* pRetVal)
    {
        fixed (IDiaEnumDebugStreamData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreamData*, int*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_name"/>
    public HRESULT get_name(BSTR* pRetVal)
    {
        fixed (IDiaEnumDebugStreamData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreamData*, BSTR*, HRESULT>)_lpVtbl[5])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.Item"/>
    public HRESULT Item(uint index, uint cbData, uint* pcbData, byte* pbData)
    {
        fixed (IDiaEnumDebugStreamData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreamData*, uint, uint, uint*, byte*, HRESULT>)_lpVtbl[6])(pThis, index, cbData, pcbData, pbData);
    }

    /// <inheritdoc cref="Interface.Next"/>
    public HRESULT Next(uint celt, uint cbData, uint* pcbData, byte* pbData, uint* pceltFetched)
    {
        fixed (IDiaEnumDebugStreamData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreamData*, uint, uint, uint*, byte*, uint*, HRESULT>)_lpVtbl[7])(pThis, celt, cbData, pcbData, pbData, pceltFetched);
    }

    /// <inheritdoc cref="Interface.Skip"/>
    public HRESULT Skip(uint celt)
    {
        fixed (IDiaEnumDebugStreamData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreamData*, uint, HRESULT>)_lpVtbl[8])(pThis, celt);
    }

    /// <inheritdoc cref="Interface.Reset"/>
    public HRESULT Reset()
    {
        fixed (IDiaEnumDebugStreamData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreamData*, HRESULT>)_lpVtbl[9])(pThis);
    }

    /// <inheritdoc cref="Interface.Clone"/>
    public HRESULT Clone(IDiaEnumDebugStreamData** ppenum)
    {
        fixed (IDiaEnumDebugStreamData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreamData*, IDiaEnumDebugStreamData**, HRESULT>)_lpVtbl[10])(pThis, ppenum);
    }

    /// <summary>
    ///  Enumerates the data contained in a debug data stream.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaenumdebugstreamdata">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("486943E8-D187-4A6B-A3C4-291259FFF60D")]
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
        ///  Number of elements in the stream.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_Count(int* pRetVal);

        /// <summary>
        ///  Stream name.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_name(BSTR* pRetVal);

        /// <summary>
        ///  Returns the element for the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to retrieve.</param>
        /// <param name="cbData">The size, in bytes, of the buffer.</param>
        /// <param name="pcbData">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <param name="pbData">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Item(uint index, uint cbData, uint* pcbData, byte* pbData);

        /// <summary>
        ///  Retrieves the next item or items in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of items to retrieve.</param>
        /// <param name="cbData">The size, in bytes, of the buffer.</param>
        /// <param name="pcbData">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <param name="pbData">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <param name="pceltFetched">Pointer to a variable that receives the number of items actually retrieved.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Next(uint celt, uint cbData, uint* pcbData, byte* pbData, uint* pceltFetched);

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
        HRESULT Clone(IDiaEnumDebugStreamData** ppenum);
    }
}
