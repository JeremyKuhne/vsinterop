// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaSession : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x2F609EE1, 0xD1C8, 0x4E24, 0x82, 0x88, 0x33, 0x26, 0xBA, 0xDC, 0xD2, 0x11);
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
                0xE1, 0x9E, 0x60, 0x2F,
                0xC8, 0xD1,
                0x24, 0x4E,
                0x82, 0x88, 0x33, 0x26, 0xBA, 0xDC, 0xD2, 0x11
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get_loadAddress"/>
    public HRESULT get_loadAddress(ulong* pRetVal)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, ulong*, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.put_loadAddress"/>
    public HRESULT put_loadAddress(ulong NewVal)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, ulong, HRESULT>)_lpVtbl[4])(pThis, NewVal);
    }

    /// <inheritdoc cref="Interface.get_globalScope"/>
    public HRESULT get_globalScope(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol**, HRESULT>)_lpVtbl[5])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.getEnumTables"/>
    public HRESULT getEnumTables(IDiaEnumTables** ppEnumTables)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaEnumTables**, HRESULT>)_lpVtbl[6])(pThis, ppEnumTables);
    }

    /// <inheritdoc cref="Interface.getSymbolsByAddr"/>
    public HRESULT getSymbolsByAddr(IDiaEnumSymbolsByAddr** ppEnumbyAddr)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaEnumSymbolsByAddr**, HRESULT>)_lpVtbl[7])(pThis, ppEnumbyAddr);
    }

    /// <inheritdoc cref="Interface.findChildren"/>
    public HRESULT findChildren(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, SymTagEnum, PCWSTR, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[8])(pThis, parent, symtag, name, compareFlags, ppResult);
    }

    /// <inheritdoc cref="Interface.findChildrenEx"/>
    public HRESULT findChildrenEx(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, SymTagEnum, PCWSTR, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[9])(pThis, parent, symtag, name, compareFlags, ppResult);
    }

    /// <inheritdoc cref="Interface.findChildrenExByAddr"/>
    public HRESULT findChildrenExByAddr(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, uint isect, uint offset, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, SymTagEnum, PCWSTR, uint, uint, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[10])(pThis, parent, symtag, name, compareFlags, isect, offset, ppResult);
    }

    /// <inheritdoc cref="Interface.findChildrenExByVA"/>
    public HRESULT findChildrenExByVA(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, ulong va, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, SymTagEnum, PCWSTR, uint, ulong, IDiaEnumSymbols**, HRESULT>)_lpVtbl[11])(pThis, parent, symtag, name, compareFlags, va, ppResult);
    }

    /// <inheritdoc cref="Interface.findChildrenExByRVA"/>
    public HRESULT findChildrenExByRVA(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, uint rva, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, SymTagEnum, PCWSTR, uint, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[12])(pThis, parent, symtag, name, compareFlags, rva, ppResult);
    }

    /// <inheritdoc cref="Interface.findSymbolByAddr"/>
    public HRESULT findSymbolByAddr(uint isect, uint offset, SymTagEnum symtag, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, uint, SymTagEnum, IDiaSymbol**, HRESULT>)_lpVtbl[13])(pThis, isect, offset, symtag, ppSymbol);
    }

    /// <inheritdoc cref="Interface.findSymbolByRVA"/>
    public HRESULT findSymbolByRVA(uint rva, SymTagEnum symtag, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, SymTagEnum, IDiaSymbol**, HRESULT>)_lpVtbl[14])(pThis, rva, symtag, ppSymbol);
    }

    /// <inheritdoc cref="Interface.findSymbolByVA"/>
    public HRESULT findSymbolByVA(ulong va, SymTagEnum symtag, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, ulong, SymTagEnum, IDiaSymbol**, HRESULT>)_lpVtbl[15])(pThis, va, symtag, ppSymbol);
    }

    /// <inheritdoc cref="Interface.findSymbolByToken"/>
    public HRESULT findSymbolByToken(uint token, SymTagEnum symtag, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, SymTagEnum, IDiaSymbol**, HRESULT>)_lpVtbl[16])(pThis, token, symtag, ppSymbol);
    }

    /// <inheritdoc cref="Interface.symsAreEquiv"/>
    public HRESULT symsAreEquiv(IDiaSymbol* symbolA, IDiaSymbol* symbolB)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, IDiaSymbol*, HRESULT>)_lpVtbl[17])(pThis, symbolA, symbolB);
    }

    /// <inheritdoc cref="Interface.symbolById"/>
    public HRESULT symbolById(uint id, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, IDiaSymbol**, HRESULT>)_lpVtbl[18])(pThis, id, ppSymbol);
    }

    /// <inheritdoc cref="Interface.findSymbolByRVAEx"/>
    public HRESULT findSymbolByRVAEx(uint rva, SymTagEnum symtag, IDiaSymbol** ppSymbol, int* displacement)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, SymTagEnum, IDiaSymbol**, int*, HRESULT>)_lpVtbl[19])(pThis, rva, symtag, ppSymbol, displacement);
    }

    /// <inheritdoc cref="Interface.findSymbolByVAEx"/>
    public HRESULT findSymbolByVAEx(ulong va, SymTagEnum symtag, IDiaSymbol** ppSymbol, int* displacement)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, ulong, SymTagEnum, IDiaSymbol**, int*, HRESULT>)_lpVtbl[20])(pThis, va, symtag, ppSymbol, displacement);
    }

    /// <inheritdoc cref="Interface.findFile"/>
    public HRESULT findFile(IDiaSymbol* pCompiland, PCWSTR name, uint compareFlags, IDiaEnumSourceFiles** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, PCWSTR, uint, IDiaEnumSourceFiles**, HRESULT>)_lpVtbl[21])(pThis, pCompiland, name, compareFlags, ppResult);
    }

    /// <inheritdoc cref="Interface.findFileById"/>
    public HRESULT findFileById(uint uniqueId, IDiaSourceFile** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, IDiaSourceFile**, HRESULT>)_lpVtbl[22])(pThis, uniqueId, ppResult);
    }

    /// <inheritdoc cref="Interface.findLines"/>
    public HRESULT findLines(IDiaSymbol* compiland, IDiaSourceFile* file, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, IDiaSourceFile*, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[23])(pThis, compiland, file, ppResult);
    }

    /// <inheritdoc cref="Interface.findLinesByAddr"/>
    public HRESULT findLinesByAddr(uint seg, uint offset, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[24])(pThis, seg, offset, length, ppResult);
    }

    /// <inheritdoc cref="Interface.findLinesByRVA"/>
    public HRESULT findLinesByRVA(uint rva, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[25])(pThis, rva, length, ppResult);
    }

    /// <inheritdoc cref="Interface.findLinesByVA"/>
    public HRESULT findLinesByVA(ulong va, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, ulong, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[26])(pThis, va, length, ppResult);
    }

    /// <inheritdoc cref="Interface.findLinesByLinenum"/>
    public HRESULT findLinesByLinenum(IDiaSymbol* compiland, IDiaSourceFile* file, uint linenum, uint column, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, IDiaSourceFile*, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[27])(pThis, compiland, file, linenum, column, ppResult);
    }

    /// <inheritdoc cref="Interface.findInjectedSource"/>
    public HRESULT findInjectedSource(PCWSTR srcFile, IDiaEnumInjectedSources** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, PCWSTR, IDiaEnumInjectedSources**, HRESULT>)_lpVtbl[28])(pThis, srcFile, ppResult);
    }

    /// <inheritdoc cref="Interface.getEnumDebugStreams"/>
    public HRESULT getEnumDebugStreams(IDiaEnumDebugStreams** ppEnumDebugStreams)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaEnumDebugStreams**, HRESULT>)_lpVtbl[29])(pThis, ppEnumDebugStreams);
    }

    /// <inheritdoc cref="Interface.findInlineFramesByAddr"/>
    public HRESULT findInlineFramesByAddr(IDiaSymbol* parent, uint isect, uint offset, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, uint, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[30])(pThis, parent, isect, offset, ppResult);
    }

    /// <inheritdoc cref="Interface.findInlineFramesByRVA"/>
    public HRESULT findInlineFramesByRVA(IDiaSymbol* parent, uint rva, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[31])(pThis, parent, rva, ppResult);
    }

    /// <inheritdoc cref="Interface.findInlineFramesByVA"/>
    public HRESULT findInlineFramesByVA(IDiaSymbol* parent, ulong va, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, ulong, IDiaEnumSymbols**, HRESULT>)_lpVtbl[32])(pThis, parent, va, ppResult);
    }

    /// <inheritdoc cref="Interface.findInlineeLines"/>
    public HRESULT findInlineeLines(IDiaSymbol* parent, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[33])(pThis, parent, ppResult);
    }

    /// <inheritdoc cref="Interface.findInlineeLinesByAddr"/>
    public HRESULT findInlineeLinesByAddr(IDiaSymbol* parent, uint isect, uint offset, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, uint, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[34])(pThis, parent, isect, offset, length, ppResult);
    }

    /// <inheritdoc cref="Interface.findInlineeLinesByRVA"/>
    public HRESULT findInlineeLinesByRVA(IDiaSymbol* parent, uint rva, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[35])(pThis, parent, rva, length, ppResult);
    }

    /// <inheritdoc cref="Interface.findInlineeLinesByVA"/>
    public HRESULT findInlineeLinesByVA(IDiaSymbol* parent, ulong va, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, ulong, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[36])(pThis, parent, va, length, ppResult);
    }

    /// <inheritdoc cref="Interface.findInlineeLinesByLinenum"/>
    public HRESULT findInlineeLinesByLinenum(IDiaSymbol* compiland, IDiaSourceFile* file, uint linenum, uint column, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, IDiaSourceFile*, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[37])(pThis, compiland, file, linenum, column, ppResult);
    }

    /// <inheritdoc cref="Interface.findInlineesByName"/>
    public HRESULT findInlineesByName(PCWSTR name, uint option, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, PCWSTR, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[38])(pThis, name, option, ppResult);
    }

    /// <inheritdoc cref="Interface.findAcceleratorInlineeLinesByLinenum"/>
    public HRESULT findAcceleratorInlineeLinesByLinenum(IDiaSymbol* parent, IDiaSourceFile* file, uint linenum, uint column, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, IDiaSourceFile*, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[39])(pThis, parent, file, linenum, column, ppResult);
    }

    /// <inheritdoc cref="Interface.findSymbolsForAcceleratorPointerTag"/>
    public HRESULT findSymbolsForAcceleratorPointerTag(IDiaSymbol* parent, uint tagValue, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[40])(pThis, parent, tagValue, ppResult);
    }

    /// <inheritdoc cref="Interface.findSymbolsByRVAForAcceleratorPointerTag"/>
    public HRESULT findSymbolsByRVAForAcceleratorPointerTag(IDiaSymbol* parent, uint tagValue, uint rva, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, uint, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[41])(pThis, parent, tagValue, rva, ppResult);
    }

    /// <inheritdoc cref="Interface.findAcceleratorInlineesByName"/>
    public HRESULT findAcceleratorInlineesByName(PCWSTR name, uint option, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, PCWSTR, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[42])(pThis, name, option, ppResult);
    }

    /// <inheritdoc cref="Interface.addressForVA"/>
    public HRESULT addressForVA(ulong va, uint* pISect, uint* pOffset)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, ulong, uint*, uint*, HRESULT>)_lpVtbl[43])(pThis, va, pISect, pOffset);
    }

    /// <inheritdoc cref="Interface.addressForRVA"/>
    public HRESULT addressForRVA(uint rva, uint* pISect, uint* pOffset)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, uint*, uint*, HRESULT>)_lpVtbl[44])(pThis, rva, pISect, pOffset);
    }

    /// <inheritdoc cref="Interface.findILOffsetsByAddr"/>
    public HRESULT findILOffsetsByAddr(uint isect, uint offset, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[45])(pThis, isect, offset, length, ppResult);
    }

    /// <inheritdoc cref="Interface.findILOffsetsByRVA"/>
    public HRESULT findILOffsetsByRVA(uint rva, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[46])(pThis, rva, length, ppResult);
    }

    /// <inheritdoc cref="Interface.findILOffsetsByVA"/>
    public HRESULT findILOffsetsByVA(ulong va, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, ulong, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[47])(pThis, va, length, ppResult);
    }

    /// <inheritdoc cref="Interface.findInputAssemblyFiles"/>
    public HRESULT findInputAssemblyFiles(IDiaEnumInputAssemblyFiles** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaEnumInputAssemblyFiles**, HRESULT>)_lpVtbl[48])(pThis, ppResult);
    }

    /// <inheritdoc cref="Interface.findInputAssembly"/>
    public HRESULT findInputAssembly(uint index, IDiaInputAssemblyFile** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, IDiaInputAssemblyFile**, HRESULT>)_lpVtbl[49])(pThis, index, ppResult);
    }

    /// <inheritdoc cref="Interface.findInputAssemblyById"/>
    public HRESULT findInputAssemblyById(uint uniqueId, IDiaInputAssemblyFile** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, IDiaInputAssemblyFile**, HRESULT>)_lpVtbl[50])(pThis, uniqueId, ppResult);
    }

    /// <inheritdoc cref="Interface.getFuncMDTokenMapSize"/>
    public HRESULT getFuncMDTokenMapSize(uint* pcb)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint*, HRESULT>)_lpVtbl[51])(pThis, pcb);
    }

    /// <inheritdoc cref="Interface.getFuncMDTokenMap"/>
    public HRESULT getFuncMDTokenMap(uint cb, uint* pcb, byte* pb)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, uint*, byte*, HRESULT>)_lpVtbl[52])(pThis, cb, pcb, pb);
    }

    /// <inheritdoc cref="Interface.getTypeMDTokenMapSize"/>
    public HRESULT getTypeMDTokenMapSize(uint* pcb)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint*, HRESULT>)_lpVtbl[53])(pThis, pcb);
    }

    /// <inheritdoc cref="Interface.getTypeMDTokenMap"/>
    public HRESULT getTypeMDTokenMap(uint cb, uint* pcb, byte* pb)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, uint*, byte*, HRESULT>)_lpVtbl[54])(pThis, cb, pcb, pb);
    }

    /// <inheritdoc cref="Interface.getNumberOfFunctionFragments_VA"/>
    public HRESULT getNumberOfFunctionFragments_VA(ulong vaFunc, uint cbFunc, uint* pNumFragments)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, ulong, uint, uint*, HRESULT>)_lpVtbl[55])(pThis, vaFunc, cbFunc, pNumFragments);
    }

    /// <inheritdoc cref="Interface.getNumberOfFunctionFragments_RVA"/>
    public HRESULT getNumberOfFunctionFragments_RVA(uint rvaFunc, uint cbFunc, uint* pNumFragments)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, uint, uint*, HRESULT>)_lpVtbl[56])(pThis, rvaFunc, cbFunc, pNumFragments);
    }

    /// <inheritdoc cref="Interface.getFunctionFragments_VA"/>
    public HRESULT getFunctionFragments_VA(ulong vaFunc, uint cbFunc, uint cFragments, ulong* pVaFragment, uint* pLenFragment)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, ulong, uint, uint, ulong*, uint*, HRESULT>)_lpVtbl[57])(pThis, vaFunc, cbFunc, cFragments, pVaFragment, pLenFragment);
    }

    /// <inheritdoc cref="Interface.getFunctionFragments_RVA"/>
    public HRESULT getFunctionFragments_RVA(uint rvaFunc, uint cbFunc, uint cFragments, uint* pRvaFragment, uint* pLenFragment)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, uint, uint, uint, uint*, uint*, HRESULT>)_lpVtbl[58])(pThis, rvaFunc, cbFunc, cFragments, pRvaFragment, pLenFragment);
    }

    /// <inheritdoc cref="Interface.getExports"/>
    public HRESULT getExports(IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaEnumSymbols**, HRESULT>)_lpVtbl[59])(pThis, ppResult);
    }

    /// <inheritdoc cref="Interface.getHeapAllocationSites"/>
    public HRESULT getHeapAllocationSites(IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaEnumSymbols**, HRESULT>)_lpVtbl[60])(pThis, ppResult);
    }

    /// <inheritdoc cref="Interface.findInputAssemblyFile"/>
    public HRESULT findInputAssemblyFile(IDiaSymbol* pSymbol, IDiaInputAssemblyFile** ppResult)
    {
        fixed (IDiaSession* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSession*, IDiaSymbol*, IDiaInputAssemblyFile**, HRESULT>)_lpVtbl[61])(pThis, pSymbol, ppResult);
    }

    /// <summary>
    ///  Provides a query context for debug symbols.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiasession">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("2F609EE1-D1C8-4E24-8288-3326BADCD211")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Dll/Exe load address.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_loadAddress(ulong* pRetVal);

        /// <summary>
        ///  Dll/Exe load address.
        /// </summary>
        /// <param name="NewVal">The NewVal value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT put_loadAddress(ulong NewVal);

        /// <summary>
        ///  Global scope (exe) symbol.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_globalScope(IDiaSymbol** pRetVal);

        /// <summary>
        ///  Get enum tables.
        /// </summary>
        /// <param name="ppEnumTables">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getEnumTables(IDiaEnumTables** ppEnumTables);

        /// <summary>
        ///  Get symbols by addr.
        /// </summary>
        /// <param name="ppEnumbyAddr">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getSymbolsByAddr(IDiaEnumSymbolsByAddr** ppEnumbyAddr);

        /// <summary>
        ///  Find children.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="symtag">The symbol tag that restricts the kinds of symbols returned, or SymTagNull to match all symbols.</param>
        /// <param name="name">The name value.</param>
        /// <param name="compareFlags">A combination of name-comparison flags that control how the name is matched.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findChildren(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, IDiaEnumSymbols** ppResult);

        /// <summary>
        ///  Find children ex.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="symtag">The symbol tag that restricts the kinds of symbols returned, or SymTagNull to match all symbols.</param>
        /// <param name="name">The name value.</param>
        /// <param name="compareFlags">A combination of name-comparison flags that control how the name is matched.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findChildrenEx(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, IDiaEnumSymbols** ppResult);

        /// <summary>
        ///  Find children ex by addr.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="symtag">The symbol tag that restricts the kinds of symbols returned, or SymTagNull to match all symbols.</param>
        /// <param name="name">The name value.</param>
        /// <param name="compareFlags">A combination of name-comparison flags that control how the name is matched.</param>
        /// <param name="isect">The section index component of the address.</param>
        /// <param name="offset">The offset component of the address within the section.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findChildrenExByAddr(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, uint isect, uint offset, IDiaEnumSymbols** ppResult);

        /// <summary>
        ///  Find children ex by va.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="symtag">The symbol tag that restricts the kinds of symbols returned, or SymTagNull to match all symbols.</param>
        /// <param name="name">The name value.</param>
        /// <param name="compareFlags">A combination of name-comparison flags that control how the name is matched.</param>
        /// <param name="va">The virtual address (VA).</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findChildrenExByVA(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, ulong va, IDiaEnumSymbols** ppResult);

        /// <summary>
        ///  Find children ex by rva.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="symtag">The symbol tag that restricts the kinds of symbols returned, or SymTagNull to match all symbols.</param>
        /// <param name="name">The name value.</param>
        /// <param name="compareFlags">A combination of name-comparison flags that control how the name is matched.</param>
        /// <param name="rva">The relative virtual address (RVA).</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findChildrenExByRVA(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, uint rva, IDiaEnumSymbols** ppResult);

        /// <summary>
        ///  Find symbol by addr.
        /// </summary>
        /// <param name="isect">The section index component of the address.</param>
        /// <param name="offset">The offset component of the address within the section.</param>
        /// <param name="symtag">The symbol tag that restricts the kinds of symbols returned, or SymTagNull to match all symbols.</param>
        /// <param name="ppSymbol">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findSymbolByAddr(uint isect, uint offset, SymTagEnum symtag, IDiaSymbol** ppSymbol);

        /// <summary>
        ///  Find symbol by rva.
        /// </summary>
        /// <param name="rva">The relative virtual address (RVA).</param>
        /// <param name="symtag">The symbol tag that restricts the kinds of symbols returned, or SymTagNull to match all symbols.</param>
        /// <param name="ppSymbol">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findSymbolByRVA(uint rva, SymTagEnum symtag, IDiaSymbol** ppSymbol);

        /// <summary>
        ///  Find symbol by va.
        /// </summary>
        /// <param name="va">The virtual address (VA).</param>
        /// <param name="symtag">The symbol tag that restricts the kinds of symbols returned, or SymTagNull to match all symbols.</param>
        /// <param name="ppSymbol">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findSymbolByVA(ulong va, SymTagEnum symtag, IDiaSymbol** ppSymbol);

        /// <summary>
        ///  Find symbol by token.
        /// </summary>
        /// <param name="token">The token value.</param>
        /// <param name="symtag">The symbol tag that restricts the kinds of symbols returned, or SymTagNull to match all symbols.</param>
        /// <param name="ppSymbol">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findSymbolByToken(uint token, SymTagEnum symtag, IDiaSymbol** ppSymbol);

        /// <summary>
        ///  Syms are equiv.
        /// </summary>
        /// <param name="symbolA">The symbolA value.</param>
        /// <param name="symbolB">The symbolB value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT symsAreEquiv(IDiaSymbol* symbolA, IDiaSymbol* symbolB);

        /// <summary>
        ///  Symbol by id.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <param name="ppSymbol">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT symbolById(uint id, IDiaSymbol** ppSymbol);

        /// <summary>
        ///  Find symbol by rvaex.
        /// </summary>
        /// <param name="rva">The relative virtual address (RVA).</param>
        /// <param name="symtag">The symbol tag that restricts the kinds of symbols returned, or SymTagNull to match all symbols.</param>
        /// <param name="ppSymbol">Pointer to a variable that receives the requested object.</param>
        /// <param name="displacement">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findSymbolByRVAEx(uint rva, SymTagEnum symtag, IDiaSymbol** ppSymbol, int* displacement);

        /// <summary>
        ///  Find symbol by vaex.
        /// </summary>
        /// <param name="va">The virtual address (VA).</param>
        /// <param name="symtag">The symbol tag that restricts the kinds of symbols returned, or SymTagNull to match all symbols.</param>
        /// <param name="ppSymbol">Pointer to a variable that receives the requested object.</param>
        /// <param name="displacement">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findSymbolByVAEx(ulong va, SymTagEnum symtag, IDiaSymbol** ppSymbol, int* displacement);

        /// <summary>
        ///  Find file.
        /// </summary>
        /// <param name="pCompiland">The pCompiland value.</param>
        /// <param name="name">The name value.</param>
        /// <param name="compareFlags">A combination of name-comparison flags that control how the name is matched.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findFile(IDiaSymbol* pCompiland, PCWSTR name, uint compareFlags, IDiaEnumSourceFiles** ppResult);

        /// <summary>
        ///  Find file by id.
        /// </summary>
        /// <param name="uniqueId">The uniqueId value.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findFileById(uint uniqueId, IDiaSourceFile** ppResult);

        /// <summary>
        ///  Find lines.
        /// </summary>
        /// <param name="compiland">The compiland value.</param>
        /// <param name="file">The file value.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findLines(IDiaSymbol* compiland, IDiaSourceFile* file, IDiaEnumLineNumbers** ppResult);

        /// <summary>
        ///  Find lines by addr.
        /// </summary>
        /// <param name="seg">The seg value.</param>
        /// <param name="offset">The offset component of the address within the section.</param>
        /// <param name="length">The number of bytes in the address range.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findLinesByAddr(uint seg, uint offset, uint length, IDiaEnumLineNumbers** ppResult);

        /// <summary>
        ///  Find lines by rva.
        /// </summary>
        /// <param name="rva">The relative virtual address (RVA).</param>
        /// <param name="length">The number of bytes in the address range.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findLinesByRVA(uint rva, uint length, IDiaEnumLineNumbers** ppResult);

        /// <summary>
        ///  Find lines by va.
        /// </summary>
        /// <param name="va">The virtual address (VA).</param>
        /// <param name="length">The number of bytes in the address range.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findLinesByVA(ulong va, uint length, IDiaEnumLineNumbers** ppResult);

        /// <summary>
        ///  Find lines by linenum.
        /// </summary>
        /// <param name="compiland">The compiland value.</param>
        /// <param name="file">The file value.</param>
        /// <param name="linenum">The linenum value.</param>
        /// <param name="column">The column value.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findLinesByLinenum(IDiaSymbol* compiland, IDiaSourceFile* file, uint linenum, uint column, IDiaEnumLineNumbers** ppResult);

        /// <summary>
        ///  Find injected source.
        /// </summary>
        /// <param name="srcFile">The srcFile value.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findInjectedSource(PCWSTR srcFile, IDiaEnumInjectedSources** ppResult);

        /// <summary>
        ///  Get enum debug streams.
        /// </summary>
        /// <param name="ppEnumDebugStreams">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getEnumDebugStreams(IDiaEnumDebugStreams** ppEnumDebugStreams);

        /// <summary>
        ///  Find inline frames by addr.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="isect">The section index component of the address.</param>
        /// <param name="offset">The offset component of the address within the section.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findInlineFramesByAddr(IDiaSymbol* parent, uint isect, uint offset, IDiaEnumSymbols** ppResult);

        /// <summary>
        ///  Find inline frames by rva.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="rva">The relative virtual address (RVA).</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findInlineFramesByRVA(IDiaSymbol* parent, uint rva, IDiaEnumSymbols** ppResult);

        /// <summary>
        ///  Find inline frames by va.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="va">The virtual address (VA).</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findInlineFramesByVA(IDiaSymbol* parent, ulong va, IDiaEnumSymbols** ppResult);

        /// <summary>
        ///  Find inlinee lines.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findInlineeLines(IDiaSymbol* parent, IDiaEnumLineNumbers** ppResult);

        /// <summary>
        ///  Find inlinee lines by addr.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="isect">The section index component of the address.</param>
        /// <param name="offset">The offset component of the address within the section.</param>
        /// <param name="length">The number of bytes in the address range.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findInlineeLinesByAddr(IDiaSymbol* parent, uint isect, uint offset, uint length, IDiaEnumLineNumbers** ppResult);

        /// <summary>
        ///  Find inlinee lines by rva.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="rva">The relative virtual address (RVA).</param>
        /// <param name="length">The number of bytes in the address range.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findInlineeLinesByRVA(IDiaSymbol* parent, uint rva, uint length, IDiaEnumLineNumbers** ppResult);

        /// <summary>
        ///  Find inlinee lines by va.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="va">The virtual address (VA).</param>
        /// <param name="length">The number of bytes in the address range.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findInlineeLinesByVA(IDiaSymbol* parent, ulong va, uint length, IDiaEnumLineNumbers** ppResult);

        /// <summary>
        ///  Find inlinee lines by linenum.
        /// </summary>
        /// <param name="compiland">The compiland value.</param>
        /// <param name="file">The file value.</param>
        /// <param name="linenum">The linenum value.</param>
        /// <param name="column">The column value.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findInlineeLinesByLinenum(IDiaSymbol* compiland, IDiaSourceFile* file, uint linenum, uint column, IDiaEnumLineNumbers** ppResult);

        /// <summary>
        ///  Find inlinees by name.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="option">The option value.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findInlineesByName(PCWSTR name, uint option, IDiaEnumSymbols** ppResult);

        /// <summary>
        ///  Find accelerator inlinee lines by linenum.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="file">The file value.</param>
        /// <param name="linenum">The linenum value.</param>
        /// <param name="column">The column value.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findAcceleratorInlineeLinesByLinenum(IDiaSymbol* parent, IDiaSourceFile* file, uint linenum, uint column, IDiaEnumLineNumbers** ppResult);

        /// <summary>
        ///  Find symbols for accelerator pointer tag.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="tagValue">The tagValue value.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findSymbolsForAcceleratorPointerTag(IDiaSymbol* parent, uint tagValue, IDiaEnumSymbols** ppResult);

        /// <summary>
        ///  Find symbols by rvafor accelerator pointer tag.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="tagValue">The tagValue value.</param>
        /// <param name="rva">The relative virtual address (RVA).</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findSymbolsByRVAForAcceleratorPointerTag(IDiaSymbol* parent, uint tagValue, uint rva, IDiaEnumSymbols** ppResult);

        /// <summary>
        ///  Find accelerator inlinees by name.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="option">The option value.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findAcceleratorInlineesByName(PCWSTR name, uint option, IDiaEnumSymbols** ppResult);

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
        ///  Address for rva.
        /// </summary>
        /// <param name="rva">The relative virtual address (RVA).</param>
        /// <param name="pISect">Pointer to a variable that receives the requested value.</param>
        /// <param name="pOffset">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT addressForRVA(uint rva, uint* pISect, uint* pOffset);

        /// <summary>
        ///  Find iloffsets by addr.
        /// </summary>
        /// <param name="isect">The section index component of the address.</param>
        /// <param name="offset">The offset component of the address within the section.</param>
        /// <param name="length">The number of bytes in the address range.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findILOffsetsByAddr(uint isect, uint offset, uint length, IDiaEnumLineNumbers** ppResult);

        /// <summary>
        ///  Find iloffsets by rva.
        /// </summary>
        /// <param name="rva">The relative virtual address (RVA).</param>
        /// <param name="length">The number of bytes in the address range.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findILOffsetsByRVA(uint rva, uint length, IDiaEnumLineNumbers** ppResult);

        /// <summary>
        ///  Find iloffsets by va.
        /// </summary>
        /// <param name="va">The virtual address (VA).</param>
        /// <param name="length">The number of bytes in the address range.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findILOffsetsByVA(ulong va, uint length, IDiaEnumLineNumbers** ppResult);

        /// <summary>
        ///  Find input assembly files.
        /// </summary>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findInputAssemblyFiles(IDiaEnumInputAssemblyFiles** ppResult);

        /// <summary>
        ///  Find input assembly.
        /// </summary>
        /// <param name="index">The zero-based index of the item to retrieve.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findInputAssembly(uint index, IDiaInputAssemblyFile** ppResult);

        /// <summary>
        ///  Find input assembly by id.
        /// </summary>
        /// <param name="uniqueId">The uniqueId value.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findInputAssemblyById(uint uniqueId, IDiaInputAssemblyFile** ppResult);

        /// <summary>
        ///  Get func mdtoken map size.
        /// </summary>
        /// <param name="pcb">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getFuncMDTokenMapSize(uint* pcb);

        /// <summary>
        ///  Get func mdtoken map.
        /// </summary>
        /// <param name="cb">The size, in bytes, of the buffer.</param>
        /// <param name="pcb">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <param name="pb">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getFuncMDTokenMap(uint cb, uint* pcb, byte* pb);

        /// <summary>
        ///  Get type mdtoken map size.
        /// </summary>
        /// <param name="pcb">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getTypeMDTokenMapSize(uint* pcb);

        /// <summary>
        ///  Get type mdtoken map.
        /// </summary>
        /// <param name="cb">The size, in bytes, of the buffer.</param>
        /// <param name="pcb">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <param name="pb">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getTypeMDTokenMap(uint cb, uint* pcb, byte* pb);

        /// <summary>
        ///  Get number of function fragments va.
        /// </summary>
        /// <param name="vaFunc">The vaFunc value.</param>
        /// <param name="cbFunc">The size, in bytes, of the buffer.</param>
        /// <param name="pNumFragments">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getNumberOfFunctionFragments_VA(ulong vaFunc, uint cbFunc, uint* pNumFragments);

        /// <summary>
        ///  Get number of function fragments rva.
        /// </summary>
        /// <param name="rvaFunc">The rvaFunc value.</param>
        /// <param name="cbFunc">The size, in bytes, of the buffer.</param>
        /// <param name="pNumFragments">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getNumberOfFunctionFragments_RVA(uint rvaFunc, uint cbFunc, uint* pNumFragments);

        /// <summary>
        ///  Get function fragments va.
        /// </summary>
        /// <param name="vaFunc">The vaFunc value.</param>
        /// <param name="cbFunc">The size, in bytes, of the buffer.</param>
        /// <param name="cFragments">The cFragments value.</param>
        /// <param name="pVaFragment">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <param name="pLenFragment">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getFunctionFragments_VA(ulong vaFunc, uint cbFunc, uint cFragments, ulong* pVaFragment, uint* pLenFragment);

        /// <summary>
        ///  Get function fragments rva.
        /// </summary>
        /// <param name="rvaFunc">The rvaFunc value.</param>
        /// <param name="cbFunc">The size, in bytes, of the buffer.</param>
        /// <param name="cFragments">The cFragments value.</param>
        /// <param name="pRvaFragment">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <param name="pLenFragment">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getFunctionFragments_RVA(uint rvaFunc, uint cbFunc, uint cFragments, uint* pRvaFragment, uint* pLenFragment);

        /// <summary>
        ///  Get exports.
        /// </summary>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getExports(IDiaEnumSymbols** ppResult);

        /// <summary>
        ///  Get heap allocation sites.
        /// </summary>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getHeapAllocationSites(IDiaEnumSymbols** ppResult);

        /// <summary>
        ///  Find input assembly file.
        /// </summary>
        /// <param name="pSymbol">The pSymbol value.</param>
        /// <param name="ppResult">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT findInputAssemblyFile(IDiaSymbol* pSymbol, IDiaInputAssemblyFile** ppResult);
    }
}
