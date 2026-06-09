// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaInjectedSource : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0xAE605CDC, 0x8105, 0x4A23, 0xB7, 0x10, 0x32, 0x59, 0xF1, 0xE2, 0x61, 0x12);
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
                0xDC, 0x5C, 0x60, 0xAE,
                0x05, 0x81,
                0x23, 0x4A,
                0xB7, 0x10, 0x32, 0x59, 0xF1, 0xE2, 0x61, 0x12
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaInjectedSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInjectedSource*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaInjectedSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInjectedSource*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaInjectedSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInjectedSource*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get_crc"/>
    public HRESULT get_crc(uint* pRetVal)
    {
        fixed (IDiaInjectedSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInjectedSource*, uint*, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_length"/>
    public HRESULT get_length(ulong* pRetVal)
    {
        fixed (IDiaInjectedSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInjectedSource*, ulong*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_filename"/>
    public HRESULT get_filename(BSTR* pRetVal)
    {
        fixed (IDiaInjectedSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInjectedSource*, BSTR*, HRESULT>)_lpVtbl[5])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_objectFilename"/>
    public HRESULT get_objectFilename(BSTR* pRetVal)
    {
        fixed (IDiaInjectedSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInjectedSource*, BSTR*, HRESULT>)_lpVtbl[6])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_virtualFilename"/>
    public HRESULT get_virtualFilename(BSTR* pRetVal)
    {
        fixed (IDiaInjectedSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInjectedSource*, BSTR*, HRESULT>)_lpVtbl[7])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_sourceCompression"/>
    public HRESULT get_sourceCompression(uint* pRetVal)
    {
        fixed (IDiaInjectedSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInjectedSource*, uint*, HRESULT>)_lpVtbl[8])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_source"/>
    public HRESULT get_source(uint cbData, uint* pcbData, byte* pbData)
    {
        fixed (IDiaInjectedSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInjectedSource*, uint, uint*, byte*, HRESULT>)_lpVtbl[9])(pThis, cbData, pcbData, pbData);
    }

    /// <summary>
    ///  Represents a program source that is injected into the symbol store.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiainjectedsource">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("AE605CDC-8105-4A23-B710-3259F1E26112")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  CRC of source bytes.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_crc(uint* pRetVal);

        /// <summary>
        ///  Length of source in bytes.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_length(ulong* pRetVal);

        /// <summary>
        ///  Source filename.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_filename(BSTR* pRetVal);

        /// <summary>
        ///  Object filename.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_objectFilename(BSTR* pRetVal);

        /// <summary>
        ///  Virtual filename.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_virtualFilename(BSTR* pRetVal);

        /// <summary>
        ///  Source compression algorithm.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_sourceCompression(uint* pRetVal);

        /// <summary>
        ///  Retrieves the source.
        /// </summary>
        /// <param name="cbData">The size, in bytes, of the buffer.</param>
        /// <param name="pcbData">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <param name="pbData">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_source(uint cbData, uint* pcbData, byte* pbData);
    }
}
