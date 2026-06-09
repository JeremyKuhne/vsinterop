// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaDataSource : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x79F1BB5F, 0xB66E, 0x48E5, 0xB6, 0xA9, 0x15, 0x45, 0xC3, 0x23, 0xCA, 0x3D);
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
                0x5F, 0xBB, 0xF1, 0x79,
                0x6E, 0xB6,
                0xE5, 0x48,
                0xB6, 0xA9, 0x15, 0x45, 0xC3, 0x23, 0xCA, 0x3D
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaDataSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSource*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaDataSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSource*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaDataSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSource*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get_lastError"/>
    public HRESULT get_lastError(BSTR* pRetVal)
    {
        fixed (IDiaDataSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSource*, BSTR*, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.loadDataFromPdb"/>
    public HRESULT loadDataFromPdb(PCWSTR pdbPath)
    {
        fixed (IDiaDataSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSource*, PCWSTR, HRESULT>)_lpVtbl[4])(pThis, pdbPath);
    }

    /// <inheritdoc cref="Interface.loadAndValidateDataFromPdb"/>
    public HRESULT loadAndValidateDataFromPdb(PCWSTR pdbPath, Guid* pcsig70, uint sig, uint age)
    {
        fixed (IDiaDataSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSource*, PCWSTR, Guid*, uint, uint, HRESULT>)_lpVtbl[5])(pThis, pdbPath, pcsig70, sig, age);
    }

    /// <inheritdoc cref="Interface.loadDataForExe"/>
    public HRESULT loadDataForExe(PCWSTR executable, PCWSTR searchPath, IUnknown* pCallback)
    {
        fixed (IDiaDataSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSource*, PCWSTR, PCWSTR, IUnknown*, HRESULT>)_lpVtbl[6])(pThis, executable, searchPath, pCallback);
    }

    /// <inheritdoc cref="Interface.loadDataFromIStream"/>
    public HRESULT loadDataFromIStream(IStream* pIStream)
    {
        fixed (IDiaDataSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSource*, IStream*, HRESULT>)_lpVtbl[7])(pThis, pIStream);
    }

    /// <inheritdoc cref="Interface.openSession"/>
    public HRESULT openSession(IDiaSession** ppSession)
    {
        fixed (IDiaDataSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSource*, IDiaSession**, HRESULT>)_lpVtbl[8])(pThis, ppSession);
    }

    /// <inheritdoc cref="Interface.loadDataFromCodeViewInfo"/>
    public HRESULT loadDataFromCodeViewInfo(PCWSTR executable, PCWSTR searchPath, uint cbCvInfo, byte* pbCvInfo, IUnknown* pCallback)
    {
        fixed (IDiaDataSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSource*, PCWSTR, PCWSTR, uint, byte*, IUnknown*, HRESULT>)_lpVtbl[9])(pThis, executable, searchPath, cbCvInfo, pbCvInfo, pCallback);
    }

    /// <inheritdoc cref="Interface.loadDataFromMiscInfo"/>
    public HRESULT loadDataFromMiscInfo(PCWSTR executable, PCWSTR searchPath, uint timeStampExe, uint timeStampDbg, uint sizeOfExe, uint cbMiscInfo, byte* pbMiscInfo, IUnknown* pCallback)
    {
        fixed (IDiaDataSource* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaDataSource*, PCWSTR, PCWSTR, uint, uint, uint, uint, byte*, IUnknown*, HRESULT>)_lpVtbl[10])(pThis, executable, searchPath, timeStampExe, timeStampDbg, sizeOfExe, cbMiscInfo, pbMiscInfo, pCallback);
    }

    /// <summary>
    ///  Initiates access to a source of debugging symbols.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiadatasource">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("79F1BB5F-B66E-48E5-B6A9-1545C323CA3D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Text for last load error.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_lastError(BSTR* pRetVal);

        /// <summary>
        ///  Load data from pdb.
        /// </summary>
        /// <param name="pdbPath">The pdbPath value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT loadDataFromPdb(PCWSTR pdbPath);

        /// <summary>
        ///  Load and validate data from pdb.
        /// </summary>
        /// <param name="pdbPath">The pdbPath value.</param>
        /// <param name="pcsig70">The pcsig70 value.</param>
        /// <param name="sig">The sig value.</param>
        /// <param name="age">The age value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT loadAndValidateDataFromPdb(PCWSTR pdbPath, Guid* pcsig70, uint sig, uint age);

        /// <summary>
        ///  Load data for exe.
        /// </summary>
        /// <param name="executable">The executable value.</param>
        /// <param name="searchPath">The searchPath value.</param>
        /// <param name="pCallback">The pCallback value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT loadDataForExe(PCWSTR executable, PCWSTR searchPath, IUnknown* pCallback);

        /// <summary>
        ///  Load data from istream.
        /// </summary>
        /// <param name="pIStream">The pIStream value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT loadDataFromIStream(IStream* pIStream);

        /// <summary>
        ///  Open session.
        /// </summary>
        /// <param name="ppSession">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT openSession(IDiaSession** ppSession);

        /// <summary>
        ///  Load data from code view info.
        /// </summary>
        /// <param name="executable">The executable value.</param>
        /// <param name="searchPath">The searchPath value.</param>
        /// <param name="cbCvInfo">The size, in bytes, of the buffer.</param>
        /// <param name="pbCvInfo">Pointer to a buffer that contains the input data.</param>
        /// <param name="pCallback">The pCallback value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT loadDataFromCodeViewInfo(PCWSTR executable, PCWSTR searchPath, uint cbCvInfo, byte* pbCvInfo, IUnknown* pCallback);

        /// <summary>
        ///  Load data from misc info.
        /// </summary>
        /// <param name="executable">The executable value.</param>
        /// <param name="searchPath">The searchPath value.</param>
        /// <param name="timeStampExe">The timeStampExe value.</param>
        /// <param name="timeStampDbg">The timeStampDbg value.</param>
        /// <param name="sizeOfExe">The sizeOfExe value.</param>
        /// <param name="cbMiscInfo">The size, in bytes, of the buffer.</param>
        /// <param name="pbMiscInfo">Pointer to a buffer that contains the input data.</param>
        /// <param name="pCallback">The pCallback value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT loadDataFromMiscInfo(PCWSTR executable, PCWSTR searchPath, uint timeStampExe, uint timeStampDbg, uint sizeOfExe, uint cbMiscInfo, byte* pbMiscInfo, IUnknown* pCallback);
    }
}
