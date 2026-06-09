// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaLoadCallback2 : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x4688A074, 0x5A4D, 0x4486, 0xAE, 0xA8, 0x7B, 0x90, 0x71, 0x1D, 0x9F, 0x7C);
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
                0x74, 0xA0, 0x88, 0x46,
                0x4D, 0x5A,
                0x86, 0x44,
                0xAE, 0xA8, 0x7B, 0x90, 0x71, 0x1D, 0x9F, 0x7C
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaLoadCallback2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback2*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaLoadCallback2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback2*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaLoadCallback2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback2*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="IDiaLoadCallback.Interface.NotifyDebugDir"/>
    public HRESULT NotifyDebugDir(BOOL fExecutable, uint cbData, byte* pbData)
    {
        fixed (IDiaLoadCallback2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback2*, BOOL, uint, byte*, HRESULT>)_lpVtbl[3])(pThis, fExecutable, cbData, pbData);
    }

    /// <inheritdoc cref="IDiaLoadCallback.Interface.NotifyOpenDBG"/>
    public HRESULT NotifyOpenDBG(PCWSTR dbgPath, HRESULT resultCode)
    {
        fixed (IDiaLoadCallback2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback2*, PCWSTR, HRESULT, HRESULT>)_lpVtbl[4])(pThis, dbgPath, resultCode);
    }

    /// <inheritdoc cref="IDiaLoadCallback.Interface.NotifyOpenPDB"/>
    public HRESULT NotifyOpenPDB(PCWSTR pdbPath, HRESULT resultCode)
    {
        fixed (IDiaLoadCallback2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback2*, PCWSTR, HRESULT, HRESULT>)_lpVtbl[5])(pThis, pdbPath, resultCode);
    }

    /// <inheritdoc cref="IDiaLoadCallback.Interface.RestrictRegistryAccess"/>
    public HRESULT RestrictRegistryAccess()
    {
        fixed (IDiaLoadCallback2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback2*, HRESULT>)_lpVtbl[6])(pThis);
    }

    /// <inheritdoc cref="IDiaLoadCallback.Interface.RestrictSymbolServerAccess"/>
    public HRESULT RestrictSymbolServerAccess()
    {
        fixed (IDiaLoadCallback2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback2*, HRESULT>)_lpVtbl[7])(pThis);
    }

    /// <inheritdoc cref="Interface.RestrictOriginalPathAccess"/>
    public HRESULT RestrictOriginalPathAccess()
    {
        fixed (IDiaLoadCallback2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback2*, HRESULT>)_lpVtbl[8])(pThis);
    }

    /// <inheritdoc cref="Interface.RestrictReferencePathAccess"/>
    public HRESULT RestrictReferencePathAccess()
    {
        fixed (IDiaLoadCallback2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback2*, HRESULT>)_lpVtbl[9])(pThis);
    }

    /// <inheritdoc cref="Interface.RestrictDBGAccess"/>
    public HRESULT RestrictDBGAccess()
    {
        fixed (IDiaLoadCallback2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback2*, HRESULT>)_lpVtbl[10])(pThis);
    }

    /// <inheritdoc cref="Interface.RestrictSystemRootAccess"/>
    public HRESULT RestrictSystemRootAccess()
    {
        fixed (IDiaLoadCallback2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback2*, HRESULT>)_lpVtbl[11])(pThis);
    }

    /// <summary>
    ///  Receives callbacks while the DIA SDK searches for and loads debug symbols.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idialoadcallback2">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("4688A074-5A4D-4486-AEA8-7B90711D9F7C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface Interface : IDiaLoadCallback.Interface
    {
        /// <summary>
        ///  Determines whether the DIA SDK may look up the PDB specified in the debug directory of the executable.
        /// </summary>
        /// <returns>
        ///  Return a value other than <c>S_OK</c> to prevent looking up the PDB specified in the debug directory.
        /// </returns>
        [PreserveSig]
        HRESULT RestrictOriginalPathAccess();

        /// <summary>
        ///  Determines whether the DIA SDK may look up the PDB in the location where the executable file resides.
        /// </summary>
        /// <returns>
        ///  Return a value other than <c>S_OK</c> to prevent looking up the PDB where the executable is located.
        /// </returns>
        [PreserveSig]
        HRESULT RestrictReferencePathAccess();

        /// <summary>
        ///  Determines whether the DIA SDK may look up debug information from .dbg files.
        /// </summary>
        /// <returns>
        ///  Return a value other than <c>S_OK</c> to prevent looking up debug information from .dbg files.
        /// </returns>
        [PreserveSig]
        HRESULT RestrictDBGAccess();

        /// <summary>
        ///  Determines whether the DIA SDK may look up PDBs in the system root directory.
        /// </summary>
        /// <returns>
        ///  Return a value other than <c>S_OK</c> to prevent looking up PDBs in the system root.
        /// </returns>
        [PreserveSig]
        HRESULT RestrictSystemRootAccess();
    }
}
