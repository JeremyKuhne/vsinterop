// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaSegment : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x0775B784, 0xC75B, 0x4449, 0x84, 0x8B, 0xB7, 0xBD, 0x31, 0x59, 0x54, 0x5B);
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
                0x84, 0xB7, 0x75, 0x07,
                0x5B, 0xC7,
                0x49, 0x44,
                0x84, 0x8B, 0xB7, 0xBD, 0x31, 0x59, 0x54, 0x5B
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaSegment* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSegment*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaSegment* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSegment*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaSegment* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSegment*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get_frame"/>
    public HRESULT get_frame(uint* pRetVal)
    {
        fixed (IDiaSegment* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSegment*, uint*, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_offset"/>
    public HRESULT get_offset(uint* pRetVal)
    {
        fixed (IDiaSegment* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSegment*, uint*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_length"/>
    public HRESULT get_length(uint* pRetVal)
    {
        fixed (IDiaSegment* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSegment*, uint*, HRESULT>)_lpVtbl[5])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_read"/>
    public HRESULT get_read(BOOL* pRetVal)
    {
        fixed (IDiaSegment* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSegment*, BOOL*, HRESULT>)_lpVtbl[6])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_write"/>
    public HRESULT get_write(BOOL* pRetVal)
    {
        fixed (IDiaSegment* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSegment*, BOOL*, HRESULT>)_lpVtbl[7])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_execute"/>
    public HRESULT get_execute(BOOL* pRetVal)
    {
        fixed (IDiaSegment* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSegment*, BOOL*, HRESULT>)_lpVtbl[8])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_addressSection"/>
    public HRESULT get_addressSection(uint* pRetVal)
    {
        fixed (IDiaSegment* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSegment*, uint*, HRESULT>)_lpVtbl[9])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_relativeVirtualAddress"/>
    public HRESULT get_relativeVirtualAddress(uint* pRetVal)
    {
        fixed (IDiaSegment* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSegment*, uint*, HRESULT>)_lpVtbl[10])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_virtualAddress"/>
    public HRESULT get_virtualAddress(ulong* pRetVal)
    {
        fixed (IDiaSegment* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSegment*, ulong*, HRESULT>)_lpVtbl[11])(pThis, pRetVal);
    }

    /// <summary>
    ///  Describes a segment in a portable executable (PE) file's segment map.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiasegment">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("0775B784-C75B-4449-848B-B7BD3159545B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Frame.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_frame(uint* pRetVal);

        /// <summary>
        ///  Offset in physical section.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_offset(uint* pRetVal);

        /// <summary>
        ///  Length in bytes of segment.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_length(uint* pRetVal);

        /// <summary>
        ///  Read allowed.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_read(BOOL* pRetVal);

        /// <summary>
        ///  Write allowed.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_write(BOOL* pRetVal);

        /// <summary>
        ///  Execute allowed.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_execute(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the address section.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_addressSection(uint* pRetVal);

        /// <summary>
        ///  Retrieves the relative virtual address.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_relativeVirtualAddress(uint* pRetVal);

        /// <summary>
        ///  Retrieves the virtual address.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_virtualAddress(ulong* pRetVal);
    }
}
