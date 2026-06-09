// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaStackWalkHelper : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x21F81B1B, 0xC5BB, 0x42A3, 0xBC, 0x4F, 0xCC, 0xBA, 0xA7, 0x5B, 0x9F, 0x19);
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
                0x1B, 0x1B, 0xF8, 0x21,
                0xBB, 0xC5,
                0xA3, 0x42,
                0xBC, 0x4F, 0xCC, 0xBA, 0xA7, 0x5B, 0x9F, 0x19
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get_registerValue"/>
    public HRESULT get_registerValue(uint index, ulong* pRetVal)
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, uint, ulong*, HRESULT>)_lpVtbl[3])(pThis, index, pRetVal);
    }

    /// <inheritdoc cref="Interface.put_registerValue"/>
    public HRESULT put_registerValue(uint index, ulong NewVal)
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, uint, ulong, HRESULT>)_lpVtbl[4])(pThis, index, NewVal);
    }

    /// <inheritdoc cref="Interface.readMemory"/>
    public HRESULT readMemory(MemoryTypeEnum type, ulong va, uint cbData, uint* pcbData, byte* pbData)
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, MemoryTypeEnum, ulong, uint, uint*, byte*, HRESULT>)_lpVtbl[5])(pThis, type, va, cbData, pcbData, pbData);
    }

    /// <inheritdoc cref="Interface.searchForReturnAddress"/>
    public HRESULT searchForReturnAddress(IDiaFrameData* frame, ulong* returnAddress)
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, IDiaFrameData*, ulong*, HRESULT>)_lpVtbl[6])(pThis, frame, returnAddress);
    }

    /// <inheritdoc cref="Interface.searchForReturnAddressStart"/>
    public HRESULT searchForReturnAddressStart(IDiaFrameData* frame, ulong startAddress, ulong* returnAddress)
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, IDiaFrameData*, ulong, ulong*, HRESULT>)_lpVtbl[7])(pThis, frame, startAddress, returnAddress);
    }

    /// <inheritdoc cref="Interface.frameForVA"/>
    public HRESULT frameForVA(ulong va, IDiaFrameData** ppFrame)
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, ulong, IDiaFrameData**, HRESULT>)_lpVtbl[8])(pThis, va, ppFrame);
    }

    /// <inheritdoc cref="Interface.symbolForVA"/>
    public HRESULT symbolForVA(ulong va, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, ulong, IDiaSymbol**, HRESULT>)_lpVtbl[9])(pThis, va, ppSymbol);
    }

    /// <inheritdoc cref="Interface.pdataForVA"/>
    public HRESULT pdataForVA(ulong va, uint cbData, uint* pcbData, byte* pbData)
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, ulong, uint, uint*, byte*, HRESULT>)_lpVtbl[10])(pThis, va, cbData, pcbData, pbData);
    }

    /// <inheritdoc cref="Interface.imageForVA"/>
    public HRESULT imageForVA(ulong vaContext, ulong* pvaImageStart)
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, ulong, ulong*, HRESULT>)_lpVtbl[11])(pThis, vaContext, pvaImageStart);
    }

    /// <inheritdoc cref="Interface.addressForVA"/>
    public HRESULT addressForVA(ulong va, uint* pISect, uint* pOffset)
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, ulong, uint*, uint*, HRESULT>)_lpVtbl[12])(pThis, va, pISect, pOffset);
    }

    /// <inheritdoc cref="Interface.numberOfFunctionFragmentsForVA"/>
    public HRESULT numberOfFunctionFragmentsForVA(ulong vaFunc, uint cbFunc, uint* pNumFragments)
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, ulong, uint, uint*, HRESULT>)_lpVtbl[13])(pThis, vaFunc, cbFunc, pNumFragments);
    }

    /// <inheritdoc cref="Interface.functionFragmentsForVA"/>
    public HRESULT functionFragmentsForVA(ulong vaFunc, uint cbFunc, uint cFragments, ulong* pVaFragment, uint* pLenFragment)
    {
        fixed (IDiaStackWalkHelper* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper*, ulong, uint, uint, ulong*, uint*, HRESULT>)_lpVtbl[14])(pThis, vaFunc, cbFunc, cFragments, pVaFragment, pLenFragment);
    }

    /// <summary>
    ///  Facilitates walking the stack using the program debug database in the data source.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiastackwalkhelper">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("21F81B1B-C5BB-42A3-BC4F-CCBAA75B9F19")]
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

        /// <summary>
        ///  Frame for va.
        /// </summary>
        /// <param name="va">The virtual address (VA).</param>
        /// <param name="ppFrame">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT frameForVA(ulong va, IDiaFrameData** ppFrame);

        /// <summary>
        ///  Symbol for va.
        /// </summary>
        /// <param name="va">The virtual address (VA).</param>
        /// <param name="ppSymbol">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT symbolForVA(ulong va, IDiaSymbol** ppSymbol);

        /// <summary>
        ///  Pdata for va.
        /// </summary>
        /// <param name="va">The virtual address (VA).</param>
        /// <param name="cbData">The size, in bytes, of the buffer.</param>
        /// <param name="pcbData">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <param name="pbData">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT pdataForVA(ulong va, uint cbData, uint* pcbData, byte* pbData);

        /// <summary>
        ///  Image for va.
        /// </summary>
        /// <param name="vaContext">The vaContext value.</param>
        /// <param name="pvaImageStart">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT imageForVA(ulong vaContext, ulong* pvaImageStart);

        /// <summary>
        ///  Address for va.
        /// </summary>
        /// <param name="va">The virtual address (VA).</param>
        /// <param name="pISect">Pointer to a variable that receives the requested value.</param>
        /// <param name="pOffset">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT addressForVA(ulong va, uint* pISect, uint* pOffset);

        /// <summary>
        ///  Number of function fragments for va.
        /// </summary>
        /// <param name="vaFunc">The vaFunc value.</param>
        /// <param name="cbFunc">The size, in bytes, of the buffer.</param>
        /// <param name="pNumFragments">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT numberOfFunctionFragmentsForVA(ulong vaFunc, uint cbFunc, uint* pNumFragments);

        /// <summary>
        ///  Function fragments for va.
        /// </summary>
        /// <param name="vaFunc">The vaFunc value.</param>
        /// <param name="cbFunc">The size, in bytes, of the buffer.</param>
        /// <param name="cFragments">The cFragments value.</param>
        /// <param name="pVaFragment">Pointer to a variable that receives the requested value.</param>
        /// <param name="pLenFragment">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT functionFragmentsForVA(ulong vaFunc, uint cbFunc, uint cFragments, ulong* pVaFragment, uint* pLenFragment);
    }
}
