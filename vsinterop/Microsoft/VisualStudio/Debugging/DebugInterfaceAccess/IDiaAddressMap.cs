// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaAddressMap : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0xB62A2E7A, 0x067A, 0x4EA3, 0xB5, 0x98, 0x04, 0xC0, 0x97, 0x17, 0x50, 0x2C);
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
                0x7A, 0x2E, 0x2A, 0xB6,
                0x7A, 0x06,
                0xA3, 0x4E,
                0xB5, 0x98, 0x04, 0xC0, 0x97, 0x17, 0x50, 0x2C
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaAddressMap* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaAddressMap*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaAddressMap* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaAddressMap*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaAddressMap* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaAddressMap*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get_addressMapEnabled"/>
    public HRESULT get_addressMapEnabled(BOOL* pRetVal)
    {
        fixed (IDiaAddressMap* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaAddressMap*, BOOL*, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.put_addressMapEnabled"/>
    public HRESULT put_addressMapEnabled(BOOL NewVal)
    {
        fixed (IDiaAddressMap* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaAddressMap*, BOOL, HRESULT>)_lpVtbl[4])(pThis, NewVal);
    }

    /// <inheritdoc cref="Interface.get_relativeVirtualAddressEnabled"/>
    public HRESULT get_relativeVirtualAddressEnabled(BOOL* pRetVal)
    {
        fixed (IDiaAddressMap* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaAddressMap*, BOOL*, HRESULT>)_lpVtbl[5])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.put_relativeVirtualAddressEnabled"/>
    public HRESULT put_relativeVirtualAddressEnabled(BOOL NewVal)
    {
        fixed (IDiaAddressMap* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaAddressMap*, BOOL, HRESULT>)_lpVtbl[6])(pThis, NewVal);
    }

    /// <inheritdoc cref="Interface.get_imageAlign"/>
    public HRESULT get_imageAlign(uint* pRetVal)
    {
        fixed (IDiaAddressMap* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaAddressMap*, uint*, HRESULT>)_lpVtbl[7])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.put_imageAlign"/>
    public HRESULT put_imageAlign(uint NewVal)
    {
        fixed (IDiaAddressMap* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaAddressMap*, uint, HRESULT>)_lpVtbl[8])(pThis, NewVal);
    }

    /// <inheritdoc cref="Interface.set_imageHeaders"/>
    public HRESULT set_imageHeaders(uint cbData, byte* pbData, BOOL originalHeaders)
    {
        fixed (IDiaAddressMap* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaAddressMap*, uint, byte*, BOOL, HRESULT>)_lpVtbl[9])(pThis, cbData, pbData, originalHeaders);
    }

    /// <inheritdoc cref="Interface.set_addressMap"/>
    public HRESULT set_addressMap(uint cData, DiaAddressMapEntry* pData, BOOL imageToSymbols)
    {
        fixed (IDiaAddressMap* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaAddressMap*, uint, DiaAddressMapEntry*, BOOL, HRESULT>)_lpVtbl[10])(pThis, cData, pData, imageToSymbols);
    }

    /// <summary>
    ///  Controls how the DIA SDK maps between relative virtual addresses and image offsets.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaaddressmap">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("B62A2E7A-067A-4EA3-B598-04C09717502C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Enable address translations.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_addressMapEnabled(BOOL* pRetVal);

        /// <summary>
        ///  Enable address translations.
        /// </summary>
        /// <param name="NewVal">The NewVal value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT put_addressMapEnabled(BOOL NewVal);

        /// <summary>
        ///  Enable relative virtual address computations.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_relativeVirtualAddressEnabled(BOOL* pRetVal);

        /// <summary>
        ///  Enable relative virtual address computations.
        /// </summary>
        /// <param name="NewVal">The NewVal value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT put_relativeVirtualAddressEnabled(BOOL NewVal);

        /// <summary>
        ///  Original image alignment.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_imageAlign(uint* pRetVal);

        /// <summary>
        ///  Original image alignment.
        /// </summary>
        /// <param name="NewVal">The NewVal value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT put_imageAlign(uint NewVal);

        /// <summary>
        ///  Set image headers.
        /// </summary>
        /// <param name="cbData">The size, in bytes, of the buffer.</param>
        /// <param name="pbData">Pointer to a buffer that contains the input data.</param>
        /// <param name="originalHeaders">The originalHeaders value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT set_imageHeaders(uint cbData, byte* pbData, BOOL originalHeaders);

        /// <summary>
        ///  Set address map.
        /// </summary>
        /// <param name="cData">The cData value.</param>
        /// <param name="pData">Pointer to a buffer that contains the input data.</param>
        /// <param name="imageToSymbols">The imageToSymbols value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT set_addressMap(uint cData, DiaAddressMapEntry* pData, BOOL imageToSymbols);
    }
}
