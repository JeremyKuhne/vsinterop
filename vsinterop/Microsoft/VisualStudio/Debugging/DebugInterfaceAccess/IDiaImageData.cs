// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaImageData : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0xC8E40ED2, 0xA1D9, 0x4221, 0x86, 0x92, 0x3C, 0xE6, 0x61, 0x18, 0x4B, 0x44);
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
                0xD2, 0x0E, 0xE4, 0xC8,
                0xD9, 0xA1,
                0x21, 0x42,
                0x86, 0x92, 0x3C, 0xE6, 0x61, 0x18, 0x4B, 0x44
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaImageData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaImageData*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaImageData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaImageData*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaImageData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaImageData*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get_relativeVirtualAddress"/>
    public HRESULT get_relativeVirtualAddress(uint* pRetVal)
    {
        fixed (IDiaImageData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaImageData*, uint*, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_virtualAddress"/>
    public HRESULT get_virtualAddress(ulong* pRetVal)
    {
        fixed (IDiaImageData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaImageData*, ulong*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_imageBase"/>
    public HRESULT get_imageBase(ulong* pRetVal)
    {
        fixed (IDiaImageData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaImageData*, ulong*, HRESULT>)_lpVtbl[5])(pThis, pRetVal);
    }

    /// <summary>
    ///  Exposes the location and length of an image's loaded address, base address, and relative virtual address.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaimagedata">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("C8E40ED2-A1D9-4221-8692-3CE661184B44")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
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

        /// <summary>
        ///  Retrieves the image base.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_imageBase(ulong* pRetVal);
    }
}
