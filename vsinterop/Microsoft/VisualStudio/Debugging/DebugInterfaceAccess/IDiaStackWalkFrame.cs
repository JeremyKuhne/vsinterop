// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaStackWalkFrame : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x07C590C1, 0x438D, 0x4F47, 0xBD, 0xCD, 0x43, 0x97, 0xBC, 0x81, 0xAD, 0x75);
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
                0xC1, 0x90, 0xC5, 0x07,
                0x8D, 0x43,
                0x47, 0x4F,
                0xBD, 0xCD, 0x43, 0x97, 0xBC, 0x81, 0xAD, 0x75
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaStackWalkFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkFrame*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaStackWalkFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkFrame*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaStackWalkFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkFrame*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get_registerValue"/>
    public HRESULT get_registerValue(uint index, ulong* pRetVal)
    {
        fixed (IDiaStackWalkFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkFrame*, uint, ulong*, HRESULT>)_lpVtbl[3])(pThis, index, pRetVal);
    }

    /// <inheritdoc cref="Interface.put_registerValue"/>
    public HRESULT put_registerValue(uint index, ulong NewVal)
    {
        fixed (IDiaStackWalkFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkFrame*, uint, ulong, HRESULT>)_lpVtbl[4])(pThis, index, NewVal);
    }

    /// <inheritdoc cref="Interface.readMemory"/>
    public HRESULT readMemory(MemoryTypeEnum type, ulong va, uint cbData, uint* pcbData, byte* pbData)
    {
        fixed (IDiaStackWalkFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkFrame*, MemoryTypeEnum, ulong, uint, uint*, byte*, HRESULT>)_lpVtbl[5])(pThis, type, va, cbData, pcbData, pbData);
    }

    /// <inheritdoc cref="Interface.searchForReturnAddress"/>
    public HRESULT searchForReturnAddress(IDiaFrameData* frame, ulong* returnAddress)
    {
        fixed (IDiaStackWalkFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkFrame*, IDiaFrameData*, ulong*, HRESULT>)_lpVtbl[6])(pThis, frame, returnAddress);
    }

    /// <inheritdoc cref="Interface.searchForReturnAddressStart"/>
    public HRESULT searchForReturnAddressStart(IDiaFrameData* frame, ulong startAddress, ulong* returnAddress)
    {
        fixed (IDiaStackWalkFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkFrame*, IDiaFrameData*, ulong, ulong*, HRESULT>)_lpVtbl[7])(pThis, frame, startAddress, returnAddress);
    }

    /// <summary>
    ///  Provides access to the state of a stack frame and registers during a stack walk.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiastackwalkframe">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("07C590C1-438D-4F47-BDCD-4397BC81AD75")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Register value.
        /// </summary>
        /// <param name="index">The zero-based index of the item to retrieve.</param>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_registerValue(uint index, ulong* pRetVal);

        /// <summary>
        ///  Register value.
        /// </summary>
        /// <param name="index">The zero-based index of the item to retrieve.</param>
        /// <param name="NewVal">The NewVal value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT put_registerValue(uint index, ulong NewVal);

        /// <summary>
        ///  Read memory.
        /// </summary>
        /// <param name="type">The type value.</param>
        /// <param name="va">The virtual address (VA).</param>
        /// <param name="cbData">The size, in bytes, of the buffer.</param>
        /// <param name="pcbData">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <param name="pbData">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT readMemory(MemoryTypeEnum type, ulong va, uint cbData, uint* pcbData, byte* pbData);

        /// <summary>
        ///  Search for return address.
        /// </summary>
        /// <param name="frame">The frame value.</param>
        /// <param name="returnAddress">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT searchForReturnAddress(IDiaFrameData* frame, ulong* returnAddress);

        /// <summary>
        ///  Search for return address start.
        /// </summary>
        /// <param name="frame">The frame value.</param>
        /// <param name="startAddress">The startAddress value.</param>
        /// <param name="returnAddress">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT searchForReturnAddressStart(IDiaFrameData* frame, ulong startAddress, ulong* returnAddress);
    }
}
