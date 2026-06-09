// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaEnumSymbolsByAddr : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x624B7D9C, 0x24EA, 0x4421, 0x9D, 0x06, 0x3B, 0x57, 0x74, 0x71, 0xC1, 0xFA);
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
                0x9C, 0x7D, 0x4B, 0x62,
                0xEA, 0x24,
                0x21, 0x44,
                0x9D, 0x06, 0x3B, 0x57, 0x74, 0x71, 0xC1, 0xFA
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaEnumSymbolsByAddr* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaEnumSymbolsByAddr* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaEnumSymbolsByAddr* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.symbolByAddr"/>
    public HRESULT symbolByAddr(uint isect, uint offset, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaEnumSymbolsByAddr* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr*, uint, uint, IDiaSymbol**, HRESULT>)_lpVtbl[3])(pThis, isect, offset, ppSymbol);
    }

    /// <inheritdoc cref="Interface.symbolByRVA"/>
    public HRESULT symbolByRVA(uint relativeVirtualAddress, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaEnumSymbolsByAddr* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr*, uint, IDiaSymbol**, HRESULT>)_lpVtbl[4])(pThis, relativeVirtualAddress, ppSymbol);
    }

    /// <inheritdoc cref="Interface.symbolByVA"/>
    public HRESULT symbolByVA(ulong virtualAddress, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaEnumSymbolsByAddr* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr*, ulong, IDiaSymbol**, HRESULT>)_lpVtbl[5])(pThis, virtualAddress, ppSymbol);
    }

    /// <inheritdoc cref="Interface.Next"/>
    public HRESULT Next(uint celt, IDiaSymbol** rgelt, uint* pceltFetched)
    {
        fixed (IDiaEnumSymbolsByAddr* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr*, uint, IDiaSymbol**, uint*, HRESULT>)_lpVtbl[6])(pThis, celt, rgelt, pceltFetched);
    }

    /// <inheritdoc cref="Interface.Prev"/>
    public HRESULT Prev(uint celt, IDiaSymbol** rgelt, uint* pceltFetched)
    {
        fixed (IDiaEnumSymbolsByAddr* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr*, uint, IDiaSymbol**, uint*, HRESULT>)_lpVtbl[7])(pThis, celt, rgelt, pceltFetched);
    }

    /// <inheritdoc cref="Interface.Clone"/>
    public HRESULT Clone(IDiaEnumSymbolsByAddr** ppenum)
    {
        fixed (IDiaEnumSymbolsByAddr* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSymbolsByAddr*, IDiaEnumSymbolsByAddr**, HRESULT>)_lpVtbl[8])(pThis, ppenum);
    }

    /// <summary>
    ///  Enumerates by address the various symbols contained in the data source.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaenumsymbolsbyaddr">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("624B7D9C-24EA-4421-9D06-3B577471C1FA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Returns the symbol for the given address.
        /// </summary>
        /// <param name="isect">The section index component of the address.</param>
        /// <param name="offset">The offset component of the address within the section.</param>
        /// <param name="ppSymbol">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT symbolByAddr(uint isect, uint offset, IDiaSymbol** ppSymbol);

        /// <summary>
        ///  Returns the symbol for the given relative virtual address.
        /// </summary>
        /// <param name="relativeVirtualAddress">The relativeVirtualAddress value.</param>
        /// <param name="ppSymbol">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT symbolByRVA(uint relativeVirtualAddress, IDiaSymbol** ppSymbol);

        /// <summary>
        ///  Returns the symbol for the given virtual address.
        /// </summary>
        /// <param name="virtualAddress">The virtualAddress value.</param>
        /// <param name="ppSymbol">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT symbolByVA(ulong virtualAddress, IDiaSymbol** ppSymbol);

        /// <summary>
        ///  Retrieves the next item or items in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of items to retrieve.</param>
        /// <param name="rgelt">Pointer to a variable that receives the requested object.</param>
        /// <param name="pceltFetched">Pointer to a variable that receives the number of items actually retrieved.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Next(uint celt, IDiaSymbol** rgelt, uint* pceltFetched);

        /// <summary>
        ///  Prev.
        /// </summary>
        /// <param name="celt">The number of items to retrieve.</param>
        /// <param name="rgelt">Pointer to a variable that receives the requested object.</param>
        /// <param name="pceltFetched">Pointer to a variable that receives the number of items actually retrieved.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Prev(uint celt, IDiaSymbol** rgelt, uint* pceltFetched);

        /// <summary>
        ///  Creates an enumerator that contains the same enumeration state as the current enumerator.
        /// </summary>
        /// <param name="ppenum">Pointer to a variable that receives the cloned enumerator.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Clone(IDiaEnumSymbolsByAddr** ppenum);
    }
}
