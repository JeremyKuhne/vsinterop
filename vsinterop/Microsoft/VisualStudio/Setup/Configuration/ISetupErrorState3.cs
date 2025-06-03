// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Setup.Configuration;

/// <inheritdoc cref="Interface"/>
public unsafe struct ISetupErrorState3 : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
    public static Guid Guid { get; } = new(0x290019AD, 0x28E2, 0x46D5, 0x9D, 0xE5, 0xDA, 0x4B, 0x6B, 0xCF, 0x80, 0x57);

#if NETFRAMEWORK
    readonly Guid IComIID.Guid => Guid;
#else
    static ref readonly Guid IComIID.Guid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ReadOnlySpan<byte> data =
            [
                0xAD, 0x19, 0x00, 0x29,
                0xE2, 0x28,
                0xD5, 0x46,
                0x9D, 0xE5, 0xDA, 0x4B, 0x6B, 0xCF, 0x80, 0x57
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (ISetupErrorState3* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<ISetupErrorState3*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (ISetupErrorState3* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<ISetupErrorState3*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (ISetupErrorState3* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<ISetupErrorState3*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="ISetupErrorState.Interface.GetFailedPackages"/>
    public HRESULT GetFailedPackages(uint* pcFailedPackages, ISetupFailedPackageReference*** pppFailedPackages)
    {
        fixed (ISetupErrorState3* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<ISetupErrorState3*, uint*, ISetupFailedPackageReference***, HRESULT>)_lpVtbl[3])(pThis, pcFailedPackages, pppFailedPackages);
    }

    /// <inheritdoc cref="ISetupErrorState.Interface.GetSkippedPackages"/>
    public HRESULT GetSkippedPackages(uint* pcSkippedPackages, ISetupPackageReference*** pppSkippedPackages)
    {
        fixed (ISetupErrorState3* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<ISetupErrorState3*, uint*, ISetupPackageReference***, HRESULT>)_lpVtbl[4])(pThis, pcSkippedPackages, pppSkippedPackages);
    }

    /// <inheritdoc cref="ISetupErrorState2.Interface.GetErrorLogFilePath"/>
    public HRESULT GetErrorLogFilePath(BSTR* pbstrErrorLogFilePath)
    {
        fixed (ISetupErrorState3* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<ISetupErrorState3*, BSTR*, HRESULT>)_lpVtbl[5])(pThis, pbstrErrorLogFilePath);
    }

    /// <inheritdoc cref="ISetupErrorState2.Interface.GetLogFilePath"/>
    public HRESULT GetLogFilePath(BSTR* pbstrLogFilePath)
    {
        fixed (ISetupErrorState3* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<ISetupErrorState3*, BSTR*, HRESULT>)_lpVtbl[6])(pThis, pbstrLogFilePath);
    }

    /// <inheritdoc cref="Interface.GetRuntimeError"/>
    public HRESULT GetRuntimeError(ISetupErrorInfo** ppErrorInfo)
    {
        fixed (ISetupErrorState3* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<ISetupErrorState3*, ISetupErrorInfo**, HRESULT>)_lpVtbl[7])(pThis, ppErrorInfo);
    }

    /// <summary>
    ///  Information about the error state of an instance.
    /// </summary>
    [ComImport]
    [Guid("290019AD-28E2-46D5-9DE5-DA4B6BCF8057")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface : ISetupErrorState2.Interface
    {
        /// <inheritdoc cref="ISetupErrorState.Interface.GetFailedPackages"/>
        [PreserveSig]
        new HRESULT GetFailedPackages(uint* pcFailedPackages, ISetupFailedPackageReference*** pppFailedPackages);

        /// <inheritdoc cref="ISetupErrorState.Interface.GetSkippedPackages"/>
        [PreserveSig]
        new HRESULT GetSkippedPackages(uint* pcSkippedPackages, ISetupPackageReference*** pppSkippedPackages);

        /// <inheritdoc cref="ISetupErrorState2.Interface.GetErrorLogFilePath"/>
        [PreserveSig]
        new HRESULT GetErrorLogFilePath(BSTR* pbstrErrorLogFilePath);

        /// <inheritdoc cref="ISetupErrorState2.Interface.GetLogFilePath"/>
        [PreserveSig]
        new HRESULT GetLogFilePath(BSTR* pbstrLogFilePath);

        /// <summary>
        ///  Gets the runtime error that occurred during install of an instance.
        /// </summary>
        /// <param name="ppErrorInfo">Pointer to receive the runtime error information interface.</param>
        /// <returns>Standard HRESULT indicating success or failure.</returns>
        [PreserveSig]
        HRESULT GetRuntimeError(ISetupErrorInfo** ppErrorInfo);
    }
}
