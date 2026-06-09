// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaSessionEx : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0xCD24EED5, 0x5FEA, 0x4742, 0xA3, 0x20, 0x62, 0x54, 0xC9, 0x20, 0xE7, 0x8B);
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
                0xD5, 0xEE, 0x24, 0xCD,
                0xEA, 0x5F,
                0x42, 0x47,
                0xA3, 0x20, 0x62, 0x54, 0xC9, 0x20, 0xE7, 0x8B
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="IDiaSession.Interface.get_loadAddress"/>
    public HRESULT get_loadAddress(ulong* pRetVal)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, ulong*, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSession.Interface.put_loadAddress"/>
    public HRESULT put_loadAddress(ulong NewVal)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, ulong, HRESULT>)_lpVtbl[4])(pThis, NewVal);
    }

    /// <inheritdoc cref="IDiaSession.Interface.get_globalScope"/>
    public HRESULT get_globalScope(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol**, HRESULT>)_lpVtbl[5])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSession.Interface.getEnumTables"/>
    public HRESULT getEnumTables(IDiaEnumTables** ppEnumTables)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaEnumTables**, HRESULT>)_lpVtbl[6])(pThis, ppEnumTables);
    }

    /// <inheritdoc cref="IDiaSession.Interface.getSymbolsByAddr"/>
    public HRESULT getSymbolsByAddr(IDiaEnumSymbolsByAddr** ppEnumbyAddr)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaEnumSymbolsByAddr**, HRESULT>)_lpVtbl[7])(pThis, ppEnumbyAddr);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findChildren"/>
    public HRESULT findChildren(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, SymTagEnum, PCWSTR, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[8])(pThis, parent, symtag, name, compareFlags, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findChildrenEx"/>
    public HRESULT findChildrenEx(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, SymTagEnum, PCWSTR, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[9])(pThis, parent, symtag, name, compareFlags, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findChildrenExByAddr"/>
    public HRESULT findChildrenExByAddr(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, uint isect, uint offset, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, SymTagEnum, PCWSTR, uint, uint, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[10])(pThis, parent, symtag, name, compareFlags, isect, offset, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findChildrenExByVA"/>
    public HRESULT findChildrenExByVA(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, ulong va, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, SymTagEnum, PCWSTR, uint, ulong, IDiaEnumSymbols**, HRESULT>)_lpVtbl[11])(pThis, parent, symtag, name, compareFlags, va, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findChildrenExByRVA"/>
    public HRESULT findChildrenExByRVA(IDiaSymbol* parent, SymTagEnum symtag, PCWSTR name, uint compareFlags, uint rva, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, SymTagEnum, PCWSTR, uint, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[12])(pThis, parent, symtag, name, compareFlags, rva, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findSymbolByAddr"/>
    public HRESULT findSymbolByAddr(uint isect, uint offset, SymTagEnum symtag, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, uint, SymTagEnum, IDiaSymbol**, HRESULT>)_lpVtbl[13])(pThis, isect, offset, symtag, ppSymbol);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findSymbolByRVA"/>
    public HRESULT findSymbolByRVA(uint rva, SymTagEnum symtag, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, SymTagEnum, IDiaSymbol**, HRESULT>)_lpVtbl[14])(pThis, rva, symtag, ppSymbol);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findSymbolByVA"/>
    public HRESULT findSymbolByVA(ulong va, SymTagEnum symtag, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, ulong, SymTagEnum, IDiaSymbol**, HRESULT>)_lpVtbl[15])(pThis, va, symtag, ppSymbol);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findSymbolByToken"/>
    public HRESULT findSymbolByToken(uint token, SymTagEnum symtag, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, SymTagEnum, IDiaSymbol**, HRESULT>)_lpVtbl[16])(pThis, token, symtag, ppSymbol);
    }

    /// <inheritdoc cref="IDiaSession.Interface.symsAreEquiv"/>
    public HRESULT symsAreEquiv(IDiaSymbol* symbolA, IDiaSymbol* symbolB)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, IDiaSymbol*, HRESULT>)_lpVtbl[17])(pThis, symbolA, symbolB);
    }

    /// <inheritdoc cref="IDiaSession.Interface.symbolById"/>
    public HRESULT symbolById(uint id, IDiaSymbol** ppSymbol)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, IDiaSymbol**, HRESULT>)_lpVtbl[18])(pThis, id, ppSymbol);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findSymbolByRVAEx"/>
    public HRESULT findSymbolByRVAEx(uint rva, SymTagEnum symtag, IDiaSymbol** ppSymbol, int* displacement)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, SymTagEnum, IDiaSymbol**, int*, HRESULT>)_lpVtbl[19])(pThis, rva, symtag, ppSymbol, displacement);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findSymbolByVAEx"/>
    public HRESULT findSymbolByVAEx(ulong va, SymTagEnum symtag, IDiaSymbol** ppSymbol, int* displacement)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, ulong, SymTagEnum, IDiaSymbol**, int*, HRESULT>)_lpVtbl[20])(pThis, va, symtag, ppSymbol, displacement);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findFile"/>
    public HRESULT findFile(IDiaSymbol* pCompiland, PCWSTR name, uint compareFlags, IDiaEnumSourceFiles** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, PCWSTR, uint, IDiaEnumSourceFiles**, HRESULT>)_lpVtbl[21])(pThis, pCompiland, name, compareFlags, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findFileById"/>
    public HRESULT findFileById(uint uniqueId, IDiaSourceFile** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, IDiaSourceFile**, HRESULT>)_lpVtbl[22])(pThis, uniqueId, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findLines"/>
    public HRESULT findLines(IDiaSymbol* compiland, IDiaSourceFile* file, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, IDiaSourceFile*, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[23])(pThis, compiland, file, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findLinesByAddr"/>
    public HRESULT findLinesByAddr(uint seg, uint offset, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[24])(pThis, seg, offset, length, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findLinesByRVA"/>
    public HRESULT findLinesByRVA(uint rva, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[25])(pThis, rva, length, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findLinesByVA"/>
    public HRESULT findLinesByVA(ulong va, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, ulong, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[26])(pThis, va, length, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findLinesByLinenum"/>
    public HRESULT findLinesByLinenum(IDiaSymbol* compiland, IDiaSourceFile* file, uint linenum, uint column, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, IDiaSourceFile*, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[27])(pThis, compiland, file, linenum, column, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findInjectedSource"/>
    public HRESULT findInjectedSource(PCWSTR srcFile, IDiaEnumInjectedSources** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, PCWSTR, IDiaEnumInjectedSources**, HRESULT>)_lpVtbl[28])(pThis, srcFile, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.getEnumDebugStreams"/>
    public HRESULT getEnumDebugStreams(IDiaEnumDebugStreams** ppEnumDebugStreams)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaEnumDebugStreams**, HRESULT>)_lpVtbl[29])(pThis, ppEnumDebugStreams);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findInlineFramesByAddr"/>
    public HRESULT findInlineFramesByAddr(IDiaSymbol* parent, uint isect, uint offset, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, uint, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[30])(pThis, parent, isect, offset, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findInlineFramesByRVA"/>
    public HRESULT findInlineFramesByRVA(IDiaSymbol* parent, uint rva, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[31])(pThis, parent, rva, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findInlineFramesByVA"/>
    public HRESULT findInlineFramesByVA(IDiaSymbol* parent, ulong va, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, ulong, IDiaEnumSymbols**, HRESULT>)_lpVtbl[32])(pThis, parent, va, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findInlineeLines"/>
    public HRESULT findInlineeLines(IDiaSymbol* parent, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[33])(pThis, parent, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findInlineeLinesByAddr"/>
    public HRESULT findInlineeLinesByAddr(IDiaSymbol* parent, uint isect, uint offset, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, uint, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[34])(pThis, parent, isect, offset, length, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findInlineeLinesByRVA"/>
    public HRESULT findInlineeLinesByRVA(IDiaSymbol* parent, uint rva, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[35])(pThis, parent, rva, length, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findInlineeLinesByVA"/>
    public HRESULT findInlineeLinesByVA(IDiaSymbol* parent, ulong va, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, ulong, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[36])(pThis, parent, va, length, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findInlineeLinesByLinenum"/>
    public HRESULT findInlineeLinesByLinenum(IDiaSymbol* compiland, IDiaSourceFile* file, uint linenum, uint column, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, IDiaSourceFile*, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[37])(pThis, compiland, file, linenum, column, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findInlineesByName"/>
    public HRESULT findInlineesByName(PCWSTR name, uint option, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, PCWSTR, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[38])(pThis, name, option, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findAcceleratorInlineeLinesByLinenum"/>
    public HRESULT findAcceleratorInlineeLinesByLinenum(IDiaSymbol* parent, IDiaSourceFile* file, uint linenum, uint column, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, IDiaSourceFile*, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[39])(pThis, parent, file, linenum, column, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findSymbolsForAcceleratorPointerTag"/>
    public HRESULT findSymbolsForAcceleratorPointerTag(IDiaSymbol* parent, uint tagValue, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[40])(pThis, parent, tagValue, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findSymbolsByRVAForAcceleratorPointerTag"/>
    public HRESULT findSymbolsByRVAForAcceleratorPointerTag(IDiaSymbol* parent, uint tagValue, uint rva, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, uint, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[41])(pThis, parent, tagValue, rva, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findAcceleratorInlineesByName"/>
    public HRESULT findAcceleratorInlineesByName(PCWSTR name, uint option, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, PCWSTR, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[42])(pThis, name, option, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.addressForVA"/>
    public HRESULT addressForVA(ulong va, uint* pISect, uint* pOffset)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, ulong, uint*, uint*, HRESULT>)_lpVtbl[43])(pThis, va, pISect, pOffset);
    }

    /// <inheritdoc cref="IDiaSession.Interface.addressForRVA"/>
    public HRESULT addressForRVA(uint rva, uint* pISect, uint* pOffset)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, uint*, uint*, HRESULT>)_lpVtbl[44])(pThis, rva, pISect, pOffset);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findILOffsetsByAddr"/>
    public HRESULT findILOffsetsByAddr(uint isect, uint offset, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[45])(pThis, isect, offset, length, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findILOffsetsByRVA"/>
    public HRESULT findILOffsetsByRVA(uint rva, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[46])(pThis, rva, length, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findILOffsetsByVA"/>
    public HRESULT findILOffsetsByVA(ulong va, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, ulong, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[47])(pThis, va, length, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findInputAssemblyFiles"/>
    public HRESULT findInputAssemblyFiles(IDiaEnumInputAssemblyFiles** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaEnumInputAssemblyFiles**, HRESULT>)_lpVtbl[48])(pThis, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findInputAssembly"/>
    public HRESULT findInputAssembly(uint index, IDiaInputAssemblyFile** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, IDiaInputAssemblyFile**, HRESULT>)_lpVtbl[49])(pThis, index, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findInputAssemblyById"/>
    public HRESULT findInputAssemblyById(uint uniqueId, IDiaInputAssemblyFile** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, IDiaInputAssemblyFile**, HRESULT>)_lpVtbl[50])(pThis, uniqueId, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.getFuncMDTokenMapSize"/>
    public HRESULT getFuncMDTokenMapSize(uint* pcb)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint*, HRESULT>)_lpVtbl[51])(pThis, pcb);
    }

    /// <inheritdoc cref="IDiaSession.Interface.getFuncMDTokenMap"/>
    public HRESULT getFuncMDTokenMap(uint cb, uint* pcb, byte* pb)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, uint*, byte*, HRESULT>)_lpVtbl[52])(pThis, cb, pcb, pb);
    }

    /// <inheritdoc cref="IDiaSession.Interface.getTypeMDTokenMapSize"/>
    public HRESULT getTypeMDTokenMapSize(uint* pcb)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint*, HRESULT>)_lpVtbl[53])(pThis, pcb);
    }

    /// <inheritdoc cref="IDiaSession.Interface.getTypeMDTokenMap"/>
    public HRESULT getTypeMDTokenMap(uint cb, uint* pcb, byte* pb)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, uint*, byte*, HRESULT>)_lpVtbl[54])(pThis, cb, pcb, pb);
    }

    /// <inheritdoc cref="IDiaSession.Interface.getNumberOfFunctionFragments_VA"/>
    public HRESULT getNumberOfFunctionFragments_VA(ulong vaFunc, uint cbFunc, uint* pNumFragments)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, ulong, uint, uint*, HRESULT>)_lpVtbl[55])(pThis, vaFunc, cbFunc, pNumFragments);
    }

    /// <inheritdoc cref="IDiaSession.Interface.getNumberOfFunctionFragments_RVA"/>
    public HRESULT getNumberOfFunctionFragments_RVA(uint rvaFunc, uint cbFunc, uint* pNumFragments)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, uint, uint*, HRESULT>)_lpVtbl[56])(pThis, rvaFunc, cbFunc, pNumFragments);
    }

    /// <inheritdoc cref="IDiaSession.Interface.getFunctionFragments_VA"/>
    public HRESULT getFunctionFragments_VA(ulong vaFunc, uint cbFunc, uint cFragments, ulong* pVaFragment, uint* pLenFragment)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, ulong, uint, uint, ulong*, uint*, HRESULT>)_lpVtbl[57])(pThis, vaFunc, cbFunc, cFragments, pVaFragment, pLenFragment);
    }

    /// <inheritdoc cref="IDiaSession.Interface.getFunctionFragments_RVA"/>
    public HRESULT getFunctionFragments_RVA(uint rvaFunc, uint cbFunc, uint cFragments, uint* pRvaFragment, uint* pLenFragment)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, uint, uint, uint, uint*, uint*, HRESULT>)_lpVtbl[58])(pThis, rvaFunc, cbFunc, cFragments, pRvaFragment, pLenFragment);
    }

    /// <inheritdoc cref="IDiaSession.Interface.getExports"/>
    public HRESULT getExports(IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaEnumSymbols**, HRESULT>)_lpVtbl[59])(pThis, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.getHeapAllocationSites"/>
    public HRESULT getHeapAllocationSites(IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaEnumSymbols**, HRESULT>)_lpVtbl[60])(pThis, ppResult);
    }

    /// <inheritdoc cref="IDiaSession.Interface.findInputAssemblyFile"/>
    public HRESULT findInputAssemblyFile(IDiaSymbol* pSymbol, IDiaInputAssemblyFile** ppResult)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, IDiaInputAssemblyFile**, HRESULT>)_lpVtbl[61])(pThis, pSymbol, ppResult);
    }

    /// <inheritdoc cref="Interface.isFastLinkPDB"/>
    public HRESULT isFastLinkPDB(BOOL* pfFastLinkPDB)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, BOOL*, HRESULT>)_lpVtbl[62])(pThis, pfFastLinkPDB);
    }

    /// <inheritdoc cref="Interface.isPortablePDB"/>
    public HRESULT isPortablePDB(BOOL* pfPortablePDB)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, BOOL*, HRESULT>)_lpVtbl[63])(pThis, pfPortablePDB);
    }

    /// <inheritdoc cref="Interface.getSourceLinkInfo"/>
    public HRESULT getSourceLinkInfo(IDiaSymbol* parent, IDiaEnumSourceLink** ppenum)
    {
        fixed (IDiaSessionEx* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSessionEx*, IDiaSymbol*, IDiaEnumSourceLink**, HRESULT>)_lpVtbl[64])(pThis, parent, ppenum);
    }

    /// <summary>
    ///  Extends IDiaSession with additional query support for portable and fast-link PDBs.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiasessionex">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("CD24EED5-5FEA-4742-A320-6254C920E78B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface : IDiaSession.Interface
    {
        /// <summary>
        ///  Is fast link pdb.
        /// </summary>
        /// <param name="pfFastLinkPDB">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT isFastLinkPDB(BOOL* pfFastLinkPDB);

        /// <summary>
        ///  Is portable pdb.
        /// </summary>
        /// <param name="pfPortablePDB">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT isPortablePDB(BOOL* pfPortablePDB);

        /// <summary>
        ///  Get source link info.
        /// </summary>
        /// <param name="parent">The parent value.</param>
        /// <param name="ppenum">Pointer to a variable that receives the cloned enumerator.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getSourceLinkInfo(IDiaSymbol* parent, IDiaEnumSourceLink** ppenum);
    }
}
