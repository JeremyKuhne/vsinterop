// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaDataSourceEx : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x1A21EB69, 0x962A, 0x4BC4, 0x8B, 0xD3, 0x68, 0x17, 0x97, 0xD3, 0x8B, 0x23);
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
                0x69, 0xEB, 0x21, 0x1A,
                0x2A, 0x96,
                0xC4, 0x4B,
                0x8B, 0xD3, 0x68, 0x17, 0x97, 0xD3, 0x8B, 0x23
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="IDiaDataSource.Interface.get_lastError"/>
    public HRESULT get_lastError(BSTR* pRetVal)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, BSTR*, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaDataSource.Interface.loadDataFromPdb"/>
    public HRESULT loadDataFromPdb(PCWSTR pdbPath)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, PCWSTR, HRESULT>)_lpVtbl[4])(pThis, pdbPath);
    }

    /// <inheritdoc cref="IDiaDataSource.Interface.loadAndValidateDataFromPdb"/>
    public HRESULT loadAndValidateDataFromPdb(PCWSTR pdbPath, Guid* pcsig70, uint sig, uint age)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, PCWSTR, Guid*, uint, uint, HRESULT>)_lpVtbl[5])(pThis, pdbPath, pcsig70, sig, age);
    }

    /// <inheritdoc cref="IDiaDataSource.Interface.loadDataForExe"/>
    public HRESULT loadDataForExe(PCWSTR executable, PCWSTR searchPath, IUnknown* pCallback)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, PCWSTR, PCWSTR, IUnknown*, HRESULT>)_lpVtbl[6])(pThis, executable, searchPath, pCallback);
    }

    /// <inheritdoc cref="IDiaDataSource.Interface.loadDataFromIStream"/>
    public HRESULT loadDataFromIStream(IStream* pIStream)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, IStream*, HRESULT>)_lpVtbl[7])(pThis, pIStream);
    }

    /// <inheritdoc cref="IDiaDataSource.Interface.openSession"/>
    public HRESULT openSession(IDiaSession** ppSession)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, IDiaSession**, HRESULT>)_lpVtbl[8])(pThis, ppSession);
    }

    /// <inheritdoc cref="IDiaDataSource.Interface.loadDataFromCodeViewInfo"/>
    public HRESULT loadDataFromCodeViewInfo(PCWSTR executable, PCWSTR searchPath, uint cbCvInfo, byte* pbCvInfo, IUnknown* pCallback)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, PCWSTR, PCWSTR, uint, byte*, IUnknown*, HRESULT>)_lpVtbl[9])(pThis, executable, searchPath, cbCvInfo, pbCvInfo, pCallback);
    }

    /// <inheritdoc cref="IDiaDataSource.Interface.loadDataFromMiscInfo"/>
    public HRESULT loadDataFromMiscInfo(PCWSTR executable, PCWSTR searchPath, uint timeStampExe, uint timeStampDbg, uint sizeOfExe, uint cbMiscInfo, byte* pbMiscInfo, IUnknown* pCallback)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, PCWSTR, PCWSTR, uint, uint, uint, uint, byte*, IUnknown*, HRESULT>)_lpVtbl[10])(pThis, executable, searchPath, timeStampExe, timeStampDbg, sizeOfExe, cbMiscInfo, pbMiscInfo, pCallback);
    }

    /// <inheritdoc cref="Interface.loadDataFromPdbEx"/>
    public HRESULT loadDataFromPdbEx(PCWSTR pdbPath, BOOL fPdbPrefetching)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, PCWSTR, BOOL, HRESULT>)_lpVtbl[11])(pThis, pdbPath, fPdbPrefetching);
    }

    /// <inheritdoc cref="Interface.loadAndValidateDataFromPdbEx"/>
    public HRESULT loadAndValidateDataFromPdbEx(PCWSTR pdbPath, Guid* pcsig70, uint sig, uint age, BOOL fPdbPrefetching)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, PCWSTR, Guid*, uint, uint, BOOL, HRESULT>)_lpVtbl[12])(pThis, pdbPath, pcsig70, sig, age, fPdbPrefetching);
    }

    /// <inheritdoc cref="Interface.loadDataForExeEx"/>
    public HRESULT loadDataForExeEx(PCWSTR executable, PCWSTR searchPath, IUnknown* pCallback, BOOL fPdbPrefetching)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, PCWSTR, PCWSTR, IUnknown*, BOOL, HRESULT>)_lpVtbl[13])(pThis, executable, searchPath, pCallback, fPdbPrefetching);
    }

    /// <inheritdoc cref="Interface.loadDataFromIStreamEx"/>
    public HRESULT loadDataFromIStreamEx(IStream* pIStream, BOOL fPdbPrefetching)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, IStream*, BOOL, HRESULT>)_lpVtbl[14])(pThis, pIStream, fPdbPrefetching);
    }

    /// <inheritdoc cref="Interface.getStreamSize"/>
    public HRESULT getStreamSize(PCWSTR stream, ulong* pcb)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, PCWSTR, ulong*, HRESULT>)_lpVtbl[15])(pThis, stream, pcb);
    }

    /// <inheritdoc cref="Interface.getStreamRawData"/>
    public HRESULT getStreamRawData(PCWSTR stream, ulong cbOffset, ulong cbRead, ulong* pcbRead, byte* pbData)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, PCWSTR, ulong, ulong, ulong*, byte*, HRESULT>)_lpVtbl[16])(pThis, stream, cbOffset, cbRead, pcbRead, pbData);
    }

    /// <inheritdoc cref="Interface.setPfnMiniPDBErrorCallback2"/>
    public HRESULT setPfnMiniPDBErrorCallback2(void* pvContext, void* pfn)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, void*, void*, HRESULT>)_lpVtbl[17])(pThis, pvContext, pfn);
    }

    /// <inheritdoc cref="Interface.ValidatePdb"/>
    public HRESULT ValidatePdb(PCWSTR pdbPath, Guid* pcsig70, uint sig, uint age, BOOL* pfStripped)
    {
        fixed (IDiaDataSourceEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSourceEx*, PCWSTR, Guid*, uint, uint, BOOL*, HRESULT>)_lpVtbl[18])(pThis, pdbPath, pcsig70, sig, age, pfStripped);
    }

    /// <summary>
    ///  Extends IDiaDataSource to allow control of PDB prefetching and raw stream access.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiadatasourceex">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("1A21EB69-962A-4BC4-8BD3-681797D38B23")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface : IDiaDataSource.Interface
    {
        /// <summary>
        ///  Load data from pdb ex.
        /// </summary>
        /// <param name="pdbPath">The pdbPath value.</param>
        /// <param name="fPdbPrefetching">The fPdbPrefetching value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT loadDataFromPdbEx(PCWSTR pdbPath, BOOL fPdbPrefetching);

        /// <summary>
        ///  Load and validate data from pdb ex.
        /// </summary>
        /// <param name="pdbPath">The pdbPath value.</param>
        /// <param name="pcsig70">The pcsig70 value.</param>
        /// <param name="sig">The sig value.</param>
        /// <param name="age">The age value.</param>
        /// <param name="fPdbPrefetching">The fPdbPrefetching value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT loadAndValidateDataFromPdbEx(PCWSTR pdbPath, Guid* pcsig70, uint sig, uint age, BOOL fPdbPrefetching);

        /// <summary>
        ///  Load data for exe ex.
        /// </summary>
        /// <param name="executable">The executable value.</param>
        /// <param name="searchPath">The searchPath value.</param>
        /// <param name="pCallback">The pCallback value.</param>
        /// <param name="fPdbPrefetching">The fPdbPrefetching value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT loadDataForExeEx(PCWSTR executable, PCWSTR searchPath, IUnknown* pCallback, BOOL fPdbPrefetching);

        /// <summary>
        ///  Load data from istream ex.
        /// </summary>
        /// <param name="pIStream">The pIStream value.</param>
        /// <param name="fPdbPrefetching">The fPdbPrefetching value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT loadDataFromIStreamEx(IStream* pIStream, BOOL fPdbPrefetching);

        /// <summary>
        ///  Get stream size.
        /// </summary>
        /// <param name="stream">The stream value.</param>
        /// <param name="pcb">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getStreamSize(PCWSTR stream, ulong* pcb);

        /// <summary>
        ///  Get stream raw data.
        /// </summary>
        /// <param name="stream">The stream value.</param>
        /// <param name="cbOffset">The size, in bytes, of the buffer.</param>
        /// <param name="cbRead">The size, in bytes, of the buffer.</param>
        /// <param name="pcbRead">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <param name="pbData">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getStreamRawData(PCWSTR stream, ulong cbOffset, ulong cbRead, ulong* pcbRead, byte* pbData);

        /// <summary>
        ///  Set pfn mini pdberror callback2.
        /// </summary>
        /// <param name="pvContext">The pvContext value.</param>
        /// <param name="pfn">The pfn value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT setPfnMiniPDBErrorCallback2(void* pvContext, void* pfn);

        /// <summary>
        ///  Validate pdb.
        /// </summary>
        /// <param name="pdbPath">The pdbPath value.</param>
        /// <param name="pcsig70">The pcsig70 value.</param>
        /// <param name="sig">The sig value.</param>
        /// <param name="age">The age value.</param>
        /// <param name="pfStripped">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT ValidatePdb(PCWSTR pdbPath, Guid* pcsig70, uint sig, uint age, BOOL* pfStripped);
    }
}
