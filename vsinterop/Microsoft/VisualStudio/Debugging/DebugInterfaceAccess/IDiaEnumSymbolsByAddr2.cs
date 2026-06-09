// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaEnumSymbolsByAddr2 : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x1E45BD02, 0xBE45, 0x4D71, 0xBA, 0x32, 0x0E, 0x57, 0x6C, 0xFC, 0xD5, 0x9F);
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
                0x02, 0xBD, 0x45, 0x1E,
                0x45, 0xBE,
                0x71, 0x4D,
                0xBA, 0x32, 0x0E, 0x57, 0x6C, 0xFC, 0xD5, 0x9F
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaEnumSymbolsByAddr2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr2*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaEnumSymbolsByAddr2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr2*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaEnumSymbolsByAddr2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr2*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="IDiaEnumSymbolsByAddr.Interface.symbolByAddr"/>
    public HRESULT symbolByAddr(uint isect, uint offset, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaEnumSymbolsByAddr2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr2*, uint, uint, IDiaSymbol**, HRESULT>)_lpVtbl[3])(pThis, isect, offset, ppSymbol);
    }

    /// <inheritdoc cref="IDiaEnumSymbolsByAddr.Interface.symbolByRVA"/>
    public HRESULT symbolByRVA(uint relativeVirtualAddress, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaEnumSymbolsByAddr2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr2*, uint, IDiaSymbol**, HRESULT>)_lpVtbl[4])(pThis, relativeVirtualAddress, ppSymbol);
    }

    /// <inheritdoc cref="IDiaEnumSymbolsByAddr.Interface.symbolByVA"/>
    public HRESULT symbolByVA(ulong virtualAddress, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaEnumSymbolsByAddr2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr2*, ulong, IDiaSymbol**, HRESULT>)_lpVtbl[5])(pThis, virtualAddress, ppSymbol);
    }

    /// <inheritdoc cref="IDiaEnumSymbolsByAddr.Interface.Next"/>
    public HRESULT Next(uint celt, IDiaSymbol** rgelt, uint* pceltFetched)
    {
        fixed (IDiaEnumSymbolsByAddr2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr2*, uint, IDiaSymbol**, uint*, HRESULT>)_lpVtbl[6])(pThis, celt, rgelt, pceltFetched);
    }

    /// <inheritdoc cref="IDiaEnumSymbolsByAddr.Interface.Prev"/>
    public HRESULT Prev(uint celt, IDiaSymbol** rgelt, uint* pceltFetched)
    {
        fixed (IDiaEnumSymbolsByAddr2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr2*, uint, IDiaSymbol**, uint*, HRESULT>)_lpVtbl[7])(pThis, celt, rgelt, pceltFetched);
    }

    /// <inheritdoc cref="IDiaEnumSymbolsByAddr.Interface.Clone"/>
    public HRESULT Clone(IDiaEnumSymbolsByAddr** ppenum)
    {
        fixed (IDiaEnumSymbolsByAddr2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr2*, IDiaEnumSymbolsByAddr**, HRESULT>)_lpVtbl[8])(pThis, ppenum);
    }

    /// <inheritdoc cref="Interface.symbolByAddrEx"/>
    public HRESULT symbolByAddrEx(BOOL fPromoteBlockSym, uint isect, uint offset, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaEnumSymbolsByAddr2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr2*, BOOL, uint, uint, IDiaSymbol**, HRESULT>)_lpVtbl[9])(pThis, fPromoteBlockSym, isect, offset, ppSymbol);
    }

    /// <inheritdoc cref="Interface.symbolByRVAEx"/>
    public HRESULT symbolByRVAEx(BOOL fPromoteBlockSym, uint relativeVirtualAddress, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaEnumSymbolsByAddr2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr2*, BOOL, uint, IDiaSymbol**, HRESULT>)_lpVtbl[10])(pThis, fPromoteBlockSym, relativeVirtualAddress, ppSymbol);
    }

    /// <inheritdoc cref="Interface.symbolByVAEx"/>
    public HRESULT symbolByVAEx(BOOL fPromoteBlockSym, ulong virtualAddress, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaEnumSymbolsByAddr2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr2*, BOOL, ulong, IDiaSymbol**, HRESULT>)_lpVtbl[11])(pThis, fPromoteBlockSym, virtualAddress, ppSymbol);
    }

    /// <inheritdoc cref="Interface.NextEx"/>
    public HRESULT NextEx(BOOL fPromoteBlockSym, uint celt, IDiaSymbol** rgelt, uint* pceltFetched)
    {
        fixed (IDiaEnumSymbolsByAddr2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr2*, BOOL, uint, IDiaSymbol**, uint*, HRESULT>)_lpVtbl[12])(pThis, fPromoteBlockSym, celt, rgelt, pceltFetched);
    }

    /// <inheritdoc cref="Interface.PrevEx"/>
    public HRESULT PrevEx(BOOL fPromoteBlockSym, uint celt, IDiaSymbol** rgelt, uint* pceltFetched)
    {
        fixed (IDiaEnumSymbolsByAddr2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr2*, BOOL, uint, IDiaSymbol**, uint*, HRESULT>)_lpVtbl[13])(pThis, fPromoteBlockSym, celt, rgelt, pceltFetched);
    }

    /// <summary>
    ///  Extends IDiaEnumSymbolsByAddr with enumeration that can optionally promote block symbols.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaenumsymbolsbyaddr2">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("1E45BD02-BE45-4D71-BA32-0E576CFCD59F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface : IDiaEnumSymbolsByAddr.Interface
    {
        /// <summary>
        ///  Symbol by addr ex.
        /// </summary>
        /// <param name="fPromoteBlockSym">The fPromoteBlockSym value.</param>
        /// <param name="isect">The section index component of the address.</param>
        /// <param name="offset">The offset component of the address within the section.</param>
        /// <param name="ppSymbol">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT symbolByAddrEx(BOOL fPromoteBlockSym, uint isect, uint offset, IDiaSymbol** ppSymbol);

        /// <summary>
        ///  Symbol by rvaex.
        /// </summary>
        /// <param name="fPromoteBlockSym">The fPromoteBlockSym value.</param>
        /// <param name="relativeVirtualAddress">The relativeVirtualAddress value.</param>
        /// <param name="ppSymbol">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT symbolByRVAEx(BOOL fPromoteBlockSym, uint relativeVirtualAddress, IDiaSymbol** ppSymbol);

        /// <summary>
        ///  Symbol by vaex.
        /// </summary>
        /// <param name="fPromoteBlockSym">The fPromoteBlockSym value.</param>
        /// <param name="virtualAddress">The virtualAddress value.</param>
        /// <param name="ppSymbol">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT symbolByVAEx(BOOL fPromoteBlockSym, ulong virtualAddress, IDiaSymbol** ppSymbol);

        /// <summary>
        ///  Next ex.
        /// </summary>
        /// <param name="fPromoteBlockSym">The fPromoteBlockSym value.</param>
        /// <param name="celt">The number of items to retrieve.</param>
        /// <param name="rgelt">Pointer to a variable that receives the requested object.</param>
        /// <param name="pceltFetched">Pointer to a variable that receives the number of items actually retrieved.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT NextEx(BOOL fPromoteBlockSym, uint celt, IDiaSymbol** rgelt, uint* pceltFetched);

        /// <summary>
        ///  Prev ex.
        /// </summary>
        /// <param name="fPromoteBlockSym">The fPromoteBlockSym value.</param>
        /// <param name="celt">The number of items to retrieve.</param>
        /// <param name="rgelt">Pointer to a variable that receives the requested object.</param>
        /// <param name="pceltFetched">Pointer to a variable that receives the number of items actually retrieved.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT PrevEx(BOOL fPromoteBlockSym, uint celt, IDiaSymbol** rgelt, uint* pceltFetched);
    }
}
