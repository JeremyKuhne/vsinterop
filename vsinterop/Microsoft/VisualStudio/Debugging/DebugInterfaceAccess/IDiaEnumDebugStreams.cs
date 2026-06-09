// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;
using Windows.Win32.System.Variant;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaEnumDebugStreams : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x08CBB41E, 0x47A6, 0x4F87, 0x92, 0xF1, 0x1C, 0x9C, 0x87, 0xCE, 0xD0, 0x44);
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
                0x1E, 0xB4, 0xCB, 0x08,
                0xA6, 0x47,
                0x87, 0x4F,
                0x92, 0xF1, 0x1C, 0x9C, 0x87, 0xCE, 0xD0, 0x44
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaEnumDebugStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreams*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaEnumDebugStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreams*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaEnumDebugStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreams*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get__NewEnum"/>
    public HRESULT get__NewEnum(IUnknown** pRetVal)
    {
        fixed (IDiaEnumDebugStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreams*, IUnknown**, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_Count"/>
    public HRESULT get_Count(int* pRetVal)
    {
        fixed (IDiaEnumDebugStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreams*, int*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.Item"/>
    public HRESULT Item(VARIANT index, IDiaEnumDebugStreamData** stream)
    {
        fixed (IDiaEnumDebugStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreams*, VARIANT, IDiaEnumDebugStreamData**, HRESULT>)_lpVtbl[5])(pThis, index, stream);
    }

    /// <inheritdoc cref="Interface.Next"/>
    public HRESULT Next(uint celt, IDiaEnumDebugStreamData** rgelt, uint* pceltFetched)
    {
        fixed (IDiaEnumDebugStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreams*, uint, IDiaEnumDebugStreamData**, uint*, HRESULT>)_lpVtbl[6])(pThis, celt, rgelt, pceltFetched);
    }

    /// <inheritdoc cref="Interface.Skip"/>
    public HRESULT Skip(uint celt)
    {
        fixed (IDiaEnumDebugStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreams*, uint, HRESULT>)_lpVtbl[7])(pThis, celt);
    }

    /// <inheritdoc cref="Interface.Reset"/>
    public HRESULT Reset()
    {
        fixed (IDiaEnumDebugStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreams*, HRESULT>)_lpVtbl[8])(pThis);
    }

    /// <inheritdoc cref="Interface.Clone"/>
    public HRESULT Clone(IDiaEnumDebugStreams** ppenum)
    {
        fixed (IDiaEnumDebugStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumDebugStreams*, IDiaEnumDebugStreams**, HRESULT>)_lpVtbl[9])(pThis, ppenum);
    }

    /// <summary>
    ///  Enumerates the various debug streams contained in the data source.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaenumdebugstreams">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("08CBB41E-47A6-4F87-92F1-1C9C87CED044")]
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
        ///  Number of streams.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_Count(int* pRetVal);

        /// <summary>
        ///  Returns the stream for the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to retrieve.</param>
        /// <param name="stream">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Item(VARIANT index, IDiaEnumDebugStreamData** stream);

        /// <summary>
        ///  Retrieves the next item or items in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of items to retrieve.</param>
        /// <param name="rgelt">Pointer to a variable that receives the requested object.</param>
        /// <param name="pceltFetched">Pointer to a variable that receives the number of items actually retrieved.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Next(uint celt, IDiaEnumDebugStreamData** rgelt, uint* pceltFetched);

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
        HRESULT Clone(IDiaEnumDebugStreams** ppenum);
    }
}
