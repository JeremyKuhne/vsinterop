// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaSourceFile : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0xA2EF5353, 0xF5A8, 0x4EB3, 0x90, 0xD2, 0xCB, 0x52, 0x6A, 0xCB, 0x3C, 0xDD);
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
                0x53, 0x53, 0xEF, 0xA2,
                0xA8, 0xF5,
                0xB3, 0x4E,
                0x90, 0xD2, 0xCB, 0x52, 0x6A, 0xCB, 0x3C, 0xDD
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaSourceFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSourceFile*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaSourceFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSourceFile*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaSourceFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSourceFile*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get_uniqueId"/>
    public HRESULT get_uniqueId(uint* pRetVal)
    {
        fixed (IDiaSourceFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSourceFile*, uint*, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_fileName"/>
    public HRESULT get_fileName(BSTR* pRetVal)
    {
        fixed (IDiaSourceFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSourceFile*, BSTR*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_checksumType"/>
    public HRESULT get_checksumType(uint* pRetVal)
    {
        fixed (IDiaSourceFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSourceFile*, uint*, HRESULT>)_lpVtbl[5])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_compilands"/>
    public HRESULT get_compilands(IDiaEnumSymbols** pRetVal)
    {
        fixed (IDiaSourceFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSourceFile*, IDiaEnumSymbols**, HRESULT>)_lpVtbl[6])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_checksum"/>
    public HRESULT get_checksum(uint cbData, uint* pcbData, byte* pbData)
    {
        fixed (IDiaSourceFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSourceFile*, uint, uint*, byte*, HRESULT>)_lpVtbl[7])(pThis, cbData, pcbData, pbData);
    }

    /// <summary>
    ///  Represents a source file.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiasourcefile">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("A2EF5353-F5A8-4EB3-90D2-CB526ACB3CDD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Unique id for the source file (in this data store).
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_uniqueId(uint* pRetVal);

        /// <summary>
        ///  Retrieves the file name.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_fileName(BSTR* pRetVal);

        /// <summary>
        ///  Retrieves the checksum type.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_checksumType(uint* pRetVal);

        /// <summary>
        ///  Retrieves the compilands.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_compilands(IDiaEnumSymbols** pRetVal);

        /// <summary>
        ///  Retrieves the checksum.
        /// </summary>
        /// <param name="cbData">The size, in bytes, of the buffer.</param>
        /// <param name="pcbData">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <param name="pbData">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_checksum(uint cbData, uint* pcbData, byte* pbData);
    }
}
