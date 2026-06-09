// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaReadExeAtRVACallback : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x8E3F80CA, 0x7517, 0x432A, 0xBA, 0x07, 0x28, 0x51, 0x34, 0xAA, 0xEA, 0x8E);
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
                0xCA, 0x80, 0x3F, 0x8E,
                0x17, 0x75,
                0x2A, 0x43,
                0xBA, 0x07, 0x28, 0x51, 0x34, 0xAA, 0xEA, 0x8E
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaReadExeAtRVACallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaReadExeAtRVACallback*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaReadExeAtRVACallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaReadExeAtRVACallback*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaReadExeAtRVACallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaReadExeAtRVACallback*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.ReadExecutableAtRVA"/>
    public HRESULT ReadExecutableAtRVA(uint relativeVirtualAddress, uint cbData, uint* pcbData, byte* pbData)
    {
        fixed (IDiaReadExeAtRVACallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaReadExeAtRVACallback*, uint, uint, uint*, byte*, HRESULT>)_lpVtbl[3])(pThis, relativeVirtualAddress, cbData, pcbData, pbData);
    }

    /// <summary>
    ///  Allows a client to read from a portion of an executable file by relative virtual address when the file is not on the symbol path.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiareadexeatrvacallback">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("8E3F80CA-7517-432A-BA07-285134AAEA8E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Read executable at rva.
        /// </summary>
        /// <summary>
        ///  Reads data from the executable file at the specified relative virtual address (RVA).
        /// </summary>
        /// <param name="relativeVirtualAddress">The relative virtual address (RVA) at which to begin reading.</param>
        /// <param name="cbData">The size, in bytes, of the buffer.</param>
        /// <param name="pcbData">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <param name="pbData">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT ReadExecutableAtRVA(uint relativeVirtualAddress, uint cbData, uint* pcbData, byte* pbData);
    }
}
