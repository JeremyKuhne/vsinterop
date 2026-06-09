// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaReadExeAtOffsetCallback : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x587A461C, 0xB80B, 0x4F54, 0x91, 0x94, 0x50, 0x32, 0x58, 0x9A, 0x63, 0x19);
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
                0x1C, 0x46, 0x7A, 0x58,
                0x0B, 0xB8,
                0x54, 0x4F,
                0x91, 0x94, 0x50, 0x32, 0x58, 0x9A, 0x63, 0x19
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaReadExeAtOffsetCallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaReadExeAtOffsetCallback*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaReadExeAtOffsetCallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaReadExeAtOffsetCallback*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaReadExeAtOffsetCallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaReadExeAtOffsetCallback*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.ReadExecutableAt"/>
    public HRESULT ReadExecutableAt(ulong fileOffset, uint cbData, uint* pcbData, byte* pbData)
    {
        fixed (IDiaReadExeAtOffsetCallback* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaReadExeAtOffsetCallback*, ulong, uint, uint*, byte*, HRESULT>)_lpVtbl[3])(pThis, fileOffset, cbData, pcbData, pbData);
    }

    /// <summary>
    ///  Allows a client to read from a portion of an executable file by file offset when the file is not on the symbol path.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiareadexeatoffsetcallback">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("587A461C-B80B-4F54-9194-5032589A6319")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Read executable at.
        /// </summary>
        /// <summary>
        ///  Reads data from the executable file at the specified file offset.
        /// </summary>
        /// <param name="fileOffset">The offset, in bytes, from the start of the executable file at which to begin reading.</param>
        /// <param name="cbData">The size, in bytes, of the buffer.</param>
        /// <param name="pcbData">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <param name="pbData">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT ReadExecutableAt(ulong fileOffset, uint cbData, uint* pcbData, byte* pbData);
    }
}
