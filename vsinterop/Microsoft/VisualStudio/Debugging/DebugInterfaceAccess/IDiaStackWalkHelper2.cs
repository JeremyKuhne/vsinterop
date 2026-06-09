// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaStackWalkHelper2 : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x8222C490, 0x507B, 0x4BEF, 0xB3, 0xBD, 0x41, 0xDC, 0xA7, 0xB5, 0x93, 0x4C);
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
                0x90, 0xC4, 0x22, 0x82,
                0x7B, 0x50,
                0xEF, 0x4B,
                0xB3, 0xBD, 0x41, 0xDC, 0xA7, 0xB5, 0x93, 0x4C
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="IDiaStackWalkHelper.Interface.get_registerValue"/>
    public HRESULT get_registerValue(uint index, ulong* pRetVal)
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, uint, ulong*, HRESULT>)_lpVtbl[3])(pThis, index, pRetVal);
    }

    /// <inheritdoc cref="IDiaStackWalkHelper.Interface.put_registerValue"/>
    public HRESULT put_registerValue(uint index, ulong NewVal)
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, uint, ulong, HRESULT>)_lpVtbl[4])(pThis, index, NewVal);
    }

    /// <inheritdoc cref="IDiaStackWalkHelper.Interface.readMemory"/>
    public HRESULT readMemory(MemoryTypeEnum type, ulong va, uint cbData, uint* pcbData, byte* pbData)
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, MemoryTypeEnum, ulong, uint, uint*, byte*, HRESULT>)_lpVtbl[5])(pThis, type, va, cbData, pcbData, pbData);
    }

    /// <inheritdoc cref="IDiaStackWalkHelper.Interface.searchForReturnAddress"/>
    public HRESULT searchForReturnAddress(IDiaFrameData* frame, ulong* returnAddress)
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, IDiaFrameData*, ulong*, HRESULT>)_lpVtbl[6])(pThis, frame, returnAddress);
    }

    /// <inheritdoc cref="IDiaStackWalkHelper.Interface.searchForReturnAddressStart"/>
    public HRESULT searchForReturnAddressStart(IDiaFrameData* frame, ulong startAddress, ulong* returnAddress)
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, IDiaFrameData*, ulong, ulong*, HRESULT>)_lpVtbl[7])(pThis, frame, startAddress, returnAddress);
    }

    /// <inheritdoc cref="IDiaStackWalkHelper.Interface.frameForVA"/>
    public HRESULT frameForVA(ulong va, IDiaFrameData** ppFrame)
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, ulong, IDiaFrameData**, HRESULT>)_lpVtbl[8])(pThis, va, ppFrame);
    }

    /// <inheritdoc cref="IDiaStackWalkHelper.Interface.symbolForVA"/>
    public HRESULT symbolForVA(ulong va, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, ulong, IDiaSymbol**, HRESULT>)_lpVtbl[9])(pThis, va, ppSymbol);
    }

    /// <inheritdoc cref="IDiaStackWalkHelper.Interface.pdataForVA"/>
    public HRESULT pdataForVA(ulong va, uint cbData, uint* pcbData, byte* pbData)
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, ulong, uint, uint*, byte*, HRESULT>)_lpVtbl[10])(pThis, va, cbData, pcbData, pbData);
    }

    /// <inheritdoc cref="IDiaStackWalkHelper.Interface.imageForVA"/>
    public HRESULT imageForVA(ulong vaContext, ulong* pvaImageStart)
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, ulong, ulong*, HRESULT>)_lpVtbl[11])(pThis, vaContext, pvaImageStart);
    }

    /// <inheritdoc cref="IDiaStackWalkHelper.Interface.addressForVA"/>
    public HRESULT addressForVA(ulong va, uint* pISect, uint* pOffset)
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, ulong, uint*, uint*, HRESULT>)_lpVtbl[12])(pThis, va, pISect, pOffset);
    }

    /// <inheritdoc cref="IDiaStackWalkHelper.Interface.numberOfFunctionFragmentsForVA"/>
    public HRESULT numberOfFunctionFragmentsForVA(ulong vaFunc, uint cbFunc, uint* pNumFragments)
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, ulong, uint, uint*, HRESULT>)_lpVtbl[13])(pThis, vaFunc, cbFunc, pNumFragments);
    }

    /// <inheritdoc cref="IDiaStackWalkHelper.Interface.functionFragmentsForVA"/>
    public HRESULT functionFragmentsForVA(ulong vaFunc, uint cbFunc, uint cFragments, ulong* pVaFragment, uint* pLenFragment)
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, ulong, uint, uint, ulong*, uint*, HRESULT>)_lpVtbl[14])(pThis, vaFunc, cbFunc, cFragments, pVaFragment, pLenFragment);
    }

    /// <inheritdoc cref="Interface.GetPointerAuthenticationMask"/>
    public HRESULT GetPointerAuthenticationMask(ulong PtrVal, ulong* AuthMask)
    {
        fixed (IDiaStackWalkHelper2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalkHelper2*, ulong, ulong*, HRESULT>)_lpVtbl[15])(pThis, PtrVal, AuthMask);
    }

    /// <summary>
    ///  Extends IDiaStackWalkHelper with pointer authentication support.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiastackwalkhelper2">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("8222C490-507B-4BEF-B3BD-41DCA7B5934C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface : IDiaStackWalkHelper.Interface
    {
        /// <summary>
        ///  Get pointer authentication mask.
        /// </summary>
        /// <param name="PtrVal">The PtrVal value.</param>
        /// <param name="AuthMask">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT GetPointerAuthenticationMask(ulong PtrVal, ulong* AuthMask);
    }
}
