// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaInputAssemblyFile : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x3BFE56B0, 0x390C, 0x4863, 0x94, 0x30, 0x1F, 0x3D, 0x08, 0x3B, 0x76, 0x84);
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
                0xB0, 0x56, 0xFE, 0x3B,
                0x0C, 0x39,
                0x63, 0x48,
                0x94, 0x30, 0x1F, 0x3D, 0x08, 0x3B, 0x76, 0x84
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaInputAssemblyFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInputAssemblyFile*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaInputAssemblyFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInputAssemblyFile*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaInputAssemblyFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInputAssemblyFile*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get_uniqueId"/>
    public HRESULT get_uniqueId(uint* pRetVal)
    {
        fixed (IDiaInputAssemblyFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInputAssemblyFile*, uint*, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_index"/>
    public HRESULT get_index(uint* pRetVal)
    {
        fixed (IDiaInputAssemblyFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInputAssemblyFile*, uint*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_timestamp"/>
    public HRESULT get_timestamp(uint* pRetVal)
    {
        fixed (IDiaInputAssemblyFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInputAssemblyFile*, uint*, HRESULT>)_lpVtbl[5])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_pdbAvailableAtILMerge"/>
    public HRESULT get_pdbAvailableAtILMerge(BOOL* pRetVal)
    {
        fixed (IDiaInputAssemblyFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInputAssemblyFile*, BOOL*, HRESULT>)_lpVtbl[6])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_fileName"/>
    public HRESULT get_fileName(BSTR* pRetVal)
    {
        fixed (IDiaInputAssemblyFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInputAssemblyFile*, BSTR*, HRESULT>)_lpVtbl[7])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_version"/>
    public HRESULT get_version(uint cbData, uint* pcbData, byte* pbData)
    {
        fixed (IDiaInputAssemblyFile* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaInputAssemblyFile*, uint, uint*, byte*, HRESULT>)_lpVtbl[8])(pThis, cbData, pcbData, pbData);
    }

    /// <summary>
    ///  Represents an input assembly file for the Microsoft Intermediate Language (MSIL).
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiainputassemblyfile">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("3BFE56B0-390C-4863-9430-1F3D083B7684")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Assembly file ID.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_uniqueId(uint* pRetVal);

        /// <summary>
        ///  Assembly file index.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_index(uint* pRetVal);

        /// <summary>
        ///  Time stamp.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_timestamp(uint* pRetVal);

        /// <summary>
        ///  PDB is available at IL merge time.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_pdbAvailableAtILMerge(BOOL* pRetVal);

        /// <summary>
        ///  Assembly file name.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_fileName(BSTR* pRetVal);

        /// <summary>
        ///  Retrieves the version.
        /// </summary>
        /// <param name="cbData">The size, in bytes, of the buffer.</param>
        /// <param name="pcbData">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <param name="pbData">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_version(uint cbData, uint* pcbData, byte* pbData);
    }
}
