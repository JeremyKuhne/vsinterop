// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaLoadCallback : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0xC32ADB82, 0x73F4, 0x421B, 0x95, 0xD5, 0xA4, 0x70, 0x6E, 0xDF, 0x5D, 0xBE);
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
                0x82, 0xDB, 0x2A, 0xC3,
                0xF4, 0x73,
                0x1B, 0x42,
                0x95, 0xD5, 0xA4, 0x70, 0x6E, 0xDF, 0x5D, 0xBE
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaLoadCallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaLoadCallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaLoadCallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.NotifyDebugDir"/>
    public HRESULT NotifyDebugDir(BOOL fExecutable, uint cbData, byte* pbData)
    {
        fixed (IDiaLoadCallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback*, BOOL, uint, byte*, HRESULT>)_lpVtbl[3])(pThis, fExecutable, cbData, pbData);
    }

    /// <inheritdoc cref="Interface.NotifyOpenDBG"/>
    public HRESULT NotifyOpenDBG(PCWSTR dbgPath, HRESULT resultCode)
    {
        fixed (IDiaLoadCallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback*, PCWSTR, HRESULT, HRESULT>)_lpVtbl[4])(pThis, dbgPath, resultCode);
    }

    /// <inheritdoc cref="Interface.NotifyOpenPDB"/>
    public HRESULT NotifyOpenPDB(PCWSTR pdbPath, HRESULT resultCode)
    {
        fixed (IDiaLoadCallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback*, PCWSTR, HRESULT, HRESULT>)_lpVtbl[5])(pThis, pdbPath, resultCode);
    }

    /// <inheritdoc cref="Interface.RestrictRegistryAccess"/>
    public HRESULT RestrictRegistryAccess()
    {
        fixed (IDiaLoadCallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback*, HRESULT>)_lpVtbl[6])(pThis);
    }

    /// <inheritdoc cref="Interface.RestrictSymbolServerAccess"/>
    public HRESULT RestrictSymbolServerAccess()
    {
        fixed (IDiaLoadCallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLoadCallback*, HRESULT>)_lpVtbl[7])(pThis);
    }

    /// <summary>
    ///  Receives callbacks while the DIA SDK loads debug symbols.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idialoadcallback">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("C32ADB82-73F4-421B-95D5-A4706EDF5DBE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Called when the DIA SDK locates a debug directory in the portable executable (PE) file.
        /// </summary>
        /// <param name="fExecutable"><see langword="true"/> if the debug directory comes from an executable file; otherwise, <see langword="false"/>.</param>
        /// <param name="cbData">The size, in bytes, of the data pointed to by <paramref name="pbData"/>.</param>
        /// <param name="pbData">Pointer to the debug directory data (an <c>IMAGE_DEBUG_DIRECTORY</c> structure).</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT NotifyDebugDir(BOOL fExecutable, uint cbData, byte* pbData);

        /// <summary>
        ///  Called when the DIA SDK opens a .dbg file while searching for debug data.
        /// </summary>
        /// <param name="dbgPath">The full path of the .dbg file that was opened.</param>
        /// <param name="resultCode">The <see cref="HRESULT"/> result of opening the .dbg file.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT NotifyOpenDBG(PCWSTR dbgPath, HRESULT resultCode);

        /// <summary>
        ///  Called when the DIA SDK opens a .pdb file while searching for debug data.
        /// </summary>
        /// <param name="pdbPath">The full path of the .pdb file that was opened.</param>
        /// <param name="resultCode">The <see cref="HRESULT"/> result of opening the .pdb file.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT NotifyOpenPDB(PCWSTR pdbPath, HRESULT resultCode);

        /// <summary>
        ///  Determines whether the DIA SDK may query the registry for symbol search paths.
        /// </summary>
        /// <returns>
        ///  Return a value other than <c>S_OK</c> to prevent querying the registry for symbol search paths.
        /// </returns>
        [PreserveSig]
        HRESULT RestrictRegistryAccess();

        /// <summary>
        ///  Determines whether the DIA SDK may access a symbol server.
        /// </summary>
        /// <returns>
        ///  Return a value other than <c>S_OK</c> to prevent accessing a symbol server.
        /// </returns>
        [PreserveSig]
        HRESULT RestrictSymbolServerAccess();
    }
}
