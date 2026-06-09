// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;
using Windows.Win32.System.Variant;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaSymbol4 : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0xBF6C88A7, 0xE9D6, 0x4346, 0x99, 0xA1, 0xD0, 0x53, 0xDE, 0x5A, 0x78, 0x08);
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
                0xA7, 0x88, 0x6C, 0xBF,
                0xD6, 0xE9,
                0x46, 0x43,
                0x99, 0xA1, 0xD0, 0x53, 0xDE, 0x5A, 0x78, 0x08
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_symIndexId"/>
    public HRESULT get_symIndexId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_symTag"/>
    public HRESULT get_symTag(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_name"/>
    public HRESULT get_name(BSTR* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BSTR*, HRESULT>)_lpVtbl[5])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_lexicalParent"/>
    public HRESULT get_lexicalParent(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[6])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_classParent"/>
    public HRESULT get_classParent(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[7])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_type"/>
    public HRESULT get_type(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[8])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_dataKind"/>
    public HRESULT get_dataKind(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[9])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_locationType"/>
    public HRESULT get_locationType(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[10])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_addressSection"/>
    public HRESULT get_addressSection(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[11])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_addressOffset"/>
    public HRESULT get_addressOffset(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[12])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_relativeVirtualAddress"/>
    public HRESULT get_relativeVirtualAddress(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[13])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_virtualAddress"/>
    public HRESULT get_virtualAddress(ulong* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, ulong*, HRESULT>)_lpVtbl[14])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_registerId"/>
    public HRESULT get_registerId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[15])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_offset"/>
    public HRESULT get_offset(int* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, int*, HRESULT>)_lpVtbl[16])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_length"/>
    public HRESULT get_length(ulong* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, ulong*, HRESULT>)_lpVtbl[17])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_slot"/>
    public HRESULT get_slot(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[18])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_volatileType"/>
    public HRESULT get_volatileType(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[19])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_constType"/>
    public HRESULT get_constType(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[20])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_unalignedType"/>
    public HRESULT get_unalignedType(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[21])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_access"/>
    public HRESULT get_access(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[22])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_libraryName"/>
    public HRESULT get_libraryName(BSTR* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BSTR*, HRESULT>)_lpVtbl[23])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_platform"/>
    public HRESULT get_platform(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[24])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_language"/>
    public HRESULT get_language(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[25])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_editAndContinueEnabled"/>
    public HRESULT get_editAndContinueEnabled(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[26])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_frontEndMajor"/>
    public HRESULT get_frontEndMajor(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[27])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_frontEndMinor"/>
    public HRESULT get_frontEndMinor(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[28])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_frontEndBuild"/>
    public HRESULT get_frontEndBuild(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[29])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_backEndMajor"/>
    public HRESULT get_backEndMajor(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[30])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_backEndMinor"/>
    public HRESULT get_backEndMinor(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[31])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_backEndBuild"/>
    public HRESULT get_backEndBuild(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[32])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_sourceFileName"/>
    public HRESULT get_sourceFileName(BSTR* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BSTR*, HRESULT>)_lpVtbl[33])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_unused"/>
    public HRESULT get_unused(BSTR* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BSTR*, HRESULT>)_lpVtbl[34])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_thunkOrdinal"/>
    public HRESULT get_thunkOrdinal(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[35])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_thisAdjust"/>
    public HRESULT get_thisAdjust(int* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, int*, HRESULT>)_lpVtbl[36])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_virtualBaseOffset"/>
    public HRESULT get_virtualBaseOffset(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[37])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_virtual"/>
    public HRESULT get_virtual(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[38])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_intro"/>
    public HRESULT get_intro(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[39])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_pure"/>
    public HRESULT get_pure(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[40])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_callingConvention"/>
    public HRESULT get_callingConvention(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[41])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_value"/>
    public HRESULT get_value(VARIANT* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, VARIANT*, HRESULT>)_lpVtbl[42])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_baseType"/>
    public HRESULT get_baseType(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[43])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_token"/>
    public HRESULT get_token(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[44])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_timeStamp"/>
    public HRESULT get_timeStamp(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[45])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_guid"/>
    public HRESULT get_guid(Guid* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, Guid*, HRESULT>)_lpVtbl[46])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_symbolsFileName"/>
    public HRESULT get_symbolsFileName(BSTR* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BSTR*, HRESULT>)_lpVtbl[47])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_reference"/>
    public HRESULT get_reference(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[48])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_count"/>
    public HRESULT get_count(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[49])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_bitPosition"/>
    public HRESULT get_bitPosition(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[50])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_arrayIndexType"/>
    public HRESULT get_arrayIndexType(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[51])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_packed"/>
    public HRESULT get_packed(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[52])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_constructor"/>
    public HRESULT get_constructor(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[53])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_overloadedOperator"/>
    public HRESULT get_overloadedOperator(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[54])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_nested"/>
    public HRESULT get_nested(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[55])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasNestedTypes"/>
    public HRESULT get_hasNestedTypes(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[56])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasAssignmentOperator"/>
    public HRESULT get_hasAssignmentOperator(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[57])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasCastOperator"/>
    public HRESULT get_hasCastOperator(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[58])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_scoped"/>
    public HRESULT get_scoped(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[59])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_virtualBaseClass"/>
    public HRESULT get_virtualBaseClass(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[60])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_indirectVirtualBaseClass"/>
    public HRESULT get_indirectVirtualBaseClass(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[61])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_virtualBasePointerOffset"/>
    public HRESULT get_virtualBasePointerOffset(int* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, int*, HRESULT>)_lpVtbl[62])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_virtualTableShape"/>
    public HRESULT get_virtualTableShape(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[63])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_lexicalParentId"/>
    public HRESULT get_lexicalParentId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[64])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_classParentId"/>
    public HRESULT get_classParentId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[65])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_typeId"/>
    public HRESULT get_typeId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[66])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_arrayIndexTypeId"/>
    public HRESULT get_arrayIndexTypeId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[67])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_virtualTableShapeId"/>
    public HRESULT get_virtualTableShapeId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[68])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_code"/>
    public HRESULT get_code(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[69])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_function"/>
    public HRESULT get_function(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[70])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_managed"/>
    public HRESULT get_managed(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[71])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_msil"/>
    public HRESULT get_msil(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[72])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_virtualBaseDispIndex"/>
    public HRESULT get_virtualBaseDispIndex(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[73])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_undecoratedName"/>
    public HRESULT get_undecoratedName(BSTR* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BSTR*, HRESULT>)_lpVtbl[74])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_age"/>
    public HRESULT get_age(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[75])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_signature"/>
    public HRESULT get_signature(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[76])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_compilerGenerated"/>
    public HRESULT get_compilerGenerated(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[77])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_addressTaken"/>
    public HRESULT get_addressTaken(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[78])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_rank"/>
    public HRESULT get_rank(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[79])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_lowerBound"/>
    public HRESULT get_lowerBound(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[80])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_upperBound"/>
    public HRESULT get_upperBound(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[81])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_lowerBoundId"/>
    public HRESULT get_lowerBoundId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[82])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_upperBoundId"/>
    public HRESULT get_upperBoundId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[83])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_dataBytes"/>
    public HRESULT get_dataBytes(uint cbData, uint* pcbData, byte* pbData)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint, uint*, byte*, HRESULT>)_lpVtbl[84])(pThis, cbData, pcbData, pbData);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findChildren"/>
    public HRESULT findChildren(SymTagEnum symtag, PCWSTR name, uint compareFlags, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, SymTagEnum, PCWSTR, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[85])(pThis, symtag, name, compareFlags, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findChildrenEx"/>
    public HRESULT findChildrenEx(SymTagEnum symtag, PCWSTR name, uint compareFlags, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, SymTagEnum, PCWSTR, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[86])(pThis, symtag, name, compareFlags, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findChildrenExByAddr"/>
    public HRESULT findChildrenExByAddr(SymTagEnum symtag, PCWSTR name, uint compareFlags, uint isect, uint offset, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, SymTagEnum, PCWSTR, uint, uint, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[87])(pThis, symtag, name, compareFlags, isect, offset, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findChildrenExByVA"/>
    public HRESULT findChildrenExByVA(SymTagEnum symtag, PCWSTR name, uint compareFlags, ulong va, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, SymTagEnum, PCWSTR, uint, ulong, IDiaEnumSymbols**, HRESULT>)_lpVtbl[88])(pThis, symtag, name, compareFlags, va, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findChildrenExByRVA"/>
    public HRESULT findChildrenExByRVA(SymTagEnum symtag, PCWSTR name, uint compareFlags, uint rva, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, SymTagEnum, PCWSTR, uint, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[89])(pThis, symtag, name, compareFlags, rva, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_targetSection"/>
    public HRESULT get_targetSection(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[90])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_targetOffset"/>
    public HRESULT get_targetOffset(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[91])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_targetRelativeVirtualAddress"/>
    public HRESULT get_targetRelativeVirtualAddress(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[92])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_targetVirtualAddress"/>
    public HRESULT get_targetVirtualAddress(ulong* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, ulong*, HRESULT>)_lpVtbl[93])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_machineType"/>
    public HRESULT get_machineType(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[94])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_oemId"/>
    public HRESULT get_oemId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[95])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_oemSymbolId"/>
    public HRESULT get_oemSymbolId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[96])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_types"/>
    public HRESULT get_types(uint cTypes, uint* pcTypes, IDiaSymbol** pTypes)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint, uint*, IDiaSymbol**, HRESULT>)_lpVtbl[97])(pThis, cTypes, pcTypes, pTypes);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_typeIds"/>
    public HRESULT get_typeIds(uint cTypeIds, uint* pcTypeIds, uint* pdwTypeIds)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint, uint*, uint*, HRESULT>)_lpVtbl[98])(pThis, cTypeIds, pcTypeIds, pdwTypeIds);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_objectPointerType"/>
    public HRESULT get_objectPointerType(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[99])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_udtKind"/>
    public HRESULT get_udtKind(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[100])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_undecoratedNameEx"/>
    public HRESULT get_undecoratedNameEx(uint undecorateOptions, BSTR* name)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint, BSTR*, HRESULT>)_lpVtbl[101])(pThis, undecorateOptions, name);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_noReturn"/>
    public HRESULT get_noReturn(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[102])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_customCallingConvention"/>
    public HRESULT get_customCallingConvention(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[103])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_noInline"/>
    public HRESULT get_noInline(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[104])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_optimizedCodeDebugInfo"/>
    public HRESULT get_optimizedCodeDebugInfo(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[105])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_notReached"/>
    public HRESULT get_notReached(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[106])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_interruptReturn"/>
    public HRESULT get_interruptReturn(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[107])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_farReturn"/>
    public HRESULT get_farReturn(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[108])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isStatic"/>
    public HRESULT get_isStatic(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[109])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasDebugInfo"/>
    public HRESULT get_hasDebugInfo(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[110])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isLTCG"/>
    public HRESULT get_isLTCG(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[111])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isDataAligned"/>
    public HRESULT get_isDataAligned(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[112])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasSecurityChecks"/>
    public HRESULT get_hasSecurityChecks(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[113])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_compilerName"/>
    public HRESULT get_compilerName(BSTR* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BSTR*, HRESULT>)_lpVtbl[114])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasAlloca"/>
    public HRESULT get_hasAlloca(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[115])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasSetJump"/>
    public HRESULT get_hasSetJump(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[116])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasLongJump"/>
    public HRESULT get_hasLongJump(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[117])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasInlAsm"/>
    public HRESULT get_hasInlAsm(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[118])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasEH"/>
    public HRESULT get_hasEH(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[119])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasSEH"/>
    public HRESULT get_hasSEH(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[120])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasEHa"/>
    public HRESULT get_hasEHa(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[121])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isNaked"/>
    public HRESULT get_isNaked(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[122])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isAggregated"/>
    public HRESULT get_isAggregated(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[123])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isSplitted"/>
    public HRESULT get_isSplitted(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[124])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_container"/>
    public HRESULT get_container(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[125])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_inlSpec"/>
    public HRESULT get_inlSpec(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[126])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_noStackOrdering"/>
    public HRESULT get_noStackOrdering(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[127])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_virtualBaseTableType"/>
    public HRESULT get_virtualBaseTableType(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[128])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasManagedCode"/>
    public HRESULT get_hasManagedCode(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[129])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isHotpatchable"/>
    public HRESULT get_isHotpatchable(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[130])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isCVTCIL"/>
    public HRESULT get_isCVTCIL(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[131])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isMSILNetmodule"/>
    public HRESULT get_isMSILNetmodule(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[132])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isCTypes"/>
    public HRESULT get_isCTypes(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[133])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isStripped"/>
    public HRESULT get_isStripped(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[134])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_frontEndQFE"/>
    public HRESULT get_frontEndQFE(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[135])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_backEndQFE"/>
    public HRESULT get_backEndQFE(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[136])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_wasInlined"/>
    public HRESULT get_wasInlined(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[137])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_strictGSCheck"/>
    public HRESULT get_strictGSCheck(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[138])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isCxxReturnUdt"/>
    public HRESULT get_isCxxReturnUdt(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[139])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isConstructorVirtualBase"/>
    public HRESULT get_isConstructorVirtualBase(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[140])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_RValueReference"/>
    public HRESULT get_RValueReference(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[141])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_unmodifiedType"/>
    public HRESULT get_unmodifiedType(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[142])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_framePointerPresent"/>
    public HRESULT get_framePointerPresent(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[143])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isSafeBuffers"/>
    public HRESULT get_isSafeBuffers(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[144])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_intrinsic"/>
    public HRESULT get_intrinsic(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[145])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_sealed"/>
    public HRESULT get_sealed(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[146])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hfaFloat"/>
    public HRESULT get_hfaFloat(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[147])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hfaDouble"/>
    public HRESULT get_hfaDouble(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[148])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_liveRangeStartAddressSection"/>
    public HRESULT get_liveRangeStartAddressSection(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[149])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_liveRangeStartAddressOffset"/>
    public HRESULT get_liveRangeStartAddressOffset(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[150])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_liveRangeStartRelativeVirtualAddress"/>
    public HRESULT get_liveRangeStartRelativeVirtualAddress(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[151])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_countLiveRanges"/>
    public HRESULT get_countLiveRanges(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[152])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_liveRangeLength"/>
    public HRESULT get_liveRangeLength(ulong* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, ulong*, HRESULT>)_lpVtbl[153])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_offsetInUdt"/>
    public HRESULT get_offsetInUdt(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[154])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_paramBasePointerRegisterId"/>
    public HRESULT get_paramBasePointerRegisterId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[155])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_localBasePointerRegisterId"/>
    public HRESULT get_localBasePointerRegisterId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[156])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isLocationControlFlowDependent"/>
    public HRESULT get_isLocationControlFlowDependent(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[157])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_stride"/>
    public HRESULT get_stride(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[158])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_numberOfRows"/>
    public HRESULT get_numberOfRows(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[159])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_numberOfColumns"/>
    public HRESULT get_numberOfColumns(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[160])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isMatrixRowMajor"/>
    public HRESULT get_isMatrixRowMajor(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[161])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_numericProperties"/>
    public HRESULT get_numericProperties(uint cnt, uint* pcnt, uint* pProperties)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint, uint*, uint*, HRESULT>)_lpVtbl[162])(pThis, cnt, pcnt, pProperties);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_modifierValues"/>
    public HRESULT get_modifierValues(uint cnt, uint* pcnt, ushort* pModifiers)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint, uint*, ushort*, HRESULT>)_lpVtbl[163])(pThis, cnt, pcnt, pModifiers);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isReturnValue"/>
    public HRESULT get_isReturnValue(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[164])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isOptimizedAway"/>
    public HRESULT get_isOptimizedAway(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[165])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_builtInKind"/>
    public HRESULT get_builtInKind(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[166])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_registerType"/>
    public HRESULT get_registerType(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[167])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_baseDataSlot"/>
    public HRESULT get_baseDataSlot(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[168])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_baseDataOffset"/>
    public HRESULT get_baseDataOffset(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[169])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_textureSlot"/>
    public HRESULT get_textureSlot(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[170])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_samplerSlot"/>
    public HRESULT get_samplerSlot(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[171])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_uavSlot"/>
    public HRESULT get_uavSlot(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[172])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_sizeInUdt"/>
    public HRESULT get_sizeInUdt(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[173])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_memorySpaceKind"/>
    public HRESULT get_memorySpaceKind(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[174])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_unmodifiedTypeId"/>
    public HRESULT get_unmodifiedTypeId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[175])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_subTypeId"/>
    public HRESULT get_subTypeId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[176])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_subType"/>
    public HRESULT get_subType(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[177])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_numberOfModifiers"/>
    public HRESULT get_numberOfModifiers(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[178])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_numberOfRegisterIndices"/>
    public HRESULT get_numberOfRegisterIndices(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[179])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isHLSLData"/>
    public HRESULT get_isHLSLData(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[180])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isPointerToDataMember"/>
    public HRESULT get_isPointerToDataMember(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[181])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isPointerToMemberFunction"/>
    public HRESULT get_isPointerToMemberFunction(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[182])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isSingleInheritance"/>
    public HRESULT get_isSingleInheritance(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[183])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isMultipleInheritance"/>
    public HRESULT get_isMultipleInheritance(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[184])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isVirtualInheritance"/>
    public HRESULT get_isVirtualInheritance(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[185])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_restrictedType"/>
    public HRESULT get_restrictedType(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[186])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isPointerBasedOnSymbolValue"/>
    public HRESULT get_isPointerBasedOnSymbolValue(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[187])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_baseSymbol"/>
    public HRESULT get_baseSymbol(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[188])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_baseSymbolId"/>
    public HRESULT get_baseSymbolId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[189])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_objectFileName"/>
    public HRESULT get_objectFileName(BSTR* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BSTR*, HRESULT>)_lpVtbl[190])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isAcceleratorGroupSharedLocal"/>
    public HRESULT get_isAcceleratorGroupSharedLocal(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[191])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isAcceleratorPointerTagLiveRange"/>
    public HRESULT get_isAcceleratorPointerTagLiveRange(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[192])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isAcceleratorStubFunction"/>
    public HRESULT get_isAcceleratorStubFunction(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[193])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_numberOfAcceleratorPointerTags"/>
    public HRESULT get_numberOfAcceleratorPointerTags(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[194])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isSdl"/>
    public HRESULT get_isSdl(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[195])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isWinRTPointer"/>
    public HRESULT get_isWinRTPointer(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[196])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isRefUdt"/>
    public HRESULT get_isRefUdt(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[197])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isValueUdt"/>
    public HRESULT get_isValueUdt(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[198])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isInterfaceUdt"/>
    public HRESULT get_isInterfaceUdt(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[199])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findInlineFramesByAddr"/>
    public HRESULT findInlineFramesByAddr(uint isect, uint offset, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[200])(pThis, isect, offset, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findInlineFramesByRVA"/>
    public HRESULT findInlineFramesByRVA(uint rva, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[201])(pThis, rva, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findInlineFramesByVA"/>
    public HRESULT findInlineFramesByVA(ulong va, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, ulong, IDiaEnumSymbols**, HRESULT>)_lpVtbl[202])(pThis, va, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findInlineeLines"/>
    public HRESULT findInlineeLines(IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[203])(pThis, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findInlineeLinesByAddr"/>
    public HRESULT findInlineeLinesByAddr(uint isect, uint offset, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[204])(pThis, isect, offset, length, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findInlineeLinesByRVA"/>
    public HRESULT findInlineeLinesByRVA(uint rva, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[205])(pThis, rva, length, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findInlineeLinesByVA"/>
    public HRESULT findInlineeLinesByVA(ulong va, uint length, IDiaEnumLineNumbers** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, ulong, uint, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[206])(pThis, va, length, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findSymbolsForAcceleratorPointerTag"/>
    public HRESULT findSymbolsForAcceleratorPointerTag(uint tagValue, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[207])(pThis, tagValue, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findSymbolsByRVAForAcceleratorPointerTag"/>
    public HRESULT findSymbolsByRVAForAcceleratorPointerTag(uint tagValue, uint rva, IDiaEnumSymbols** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint, uint, IDiaEnumSymbols**, HRESULT>)_lpVtbl[208])(pThis, tagValue, rva, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_acceleratorPointerTags"/>
    public HRESULT get_acceleratorPointerTags(uint cnt, uint* pcnt, uint* pPointerTags)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint, uint*, uint*, HRESULT>)_lpVtbl[209])(pThis, cnt, pcnt, pPointerTags);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.getSrcLineOnTypeDefn"/>
    public HRESULT getSrcLineOnTypeDefn(IDiaLineNumber** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaLineNumber**, HRESULT>)_lpVtbl[210])(pThis, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isPGO"/>
    public HRESULT get_isPGO(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[211])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasValidPGOCounts"/>
    public HRESULT get_hasValidPGOCounts(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[212])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_isOptimizedForSpeed"/>
    public HRESULT get_isOptimizedForSpeed(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[213])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_PGOEntryCount"/>
    public HRESULT get_PGOEntryCount(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[214])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_PGOEdgeCount"/>
    public HRESULT get_PGOEdgeCount(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[215])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_PGODynamicInstructionCount"/>
    public HRESULT get_PGODynamicInstructionCount(ulong* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, ulong*, HRESULT>)_lpVtbl[216])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_staticSize"/>
    public HRESULT get_staticSize(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[217])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_finalLiveStaticSize"/>
    public HRESULT get_finalLiveStaticSize(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[218])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_phaseName"/>
    public HRESULT get_phaseName(BSTR* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BSTR*, HRESULT>)_lpVtbl[219])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_hasControlFlowCheck"/>
    public HRESULT get_hasControlFlowCheck(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[220])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_constantExport"/>
    public HRESULT get_constantExport(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[221])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_dataExport"/>
    public HRESULT get_dataExport(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[222])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_privateExport"/>
    public HRESULT get_privateExport(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[223])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_noNameExport"/>
    public HRESULT get_noNameExport(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[224])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_exportHasExplicitlyAssignedOrdinal"/>
    public HRESULT get_exportHasExplicitlyAssignedOrdinal(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[225])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_exportIsForwarder"/>
    public HRESULT get_exportIsForwarder(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[226])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_ordinal"/>
    public HRESULT get_ordinal(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[227])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_frameSize"/>
    public HRESULT get_frameSize(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[228])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_exceptionHandlerAddressSection"/>
    public HRESULT get_exceptionHandlerAddressSection(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[229])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_exceptionHandlerAddressOffset"/>
    public HRESULT get_exceptionHandlerAddressOffset(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[230])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_exceptionHandlerRelativeVirtualAddress"/>
    public HRESULT get_exceptionHandlerRelativeVirtualAddress(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[231])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_exceptionHandlerVirtualAddress"/>
    public HRESULT get_exceptionHandlerVirtualAddress(ulong* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, ulong*, HRESULT>)_lpVtbl[232])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.findInputAssemblyFile"/>
    public HRESULT findInputAssemblyFile(IDiaInputAssemblyFile** ppResult)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaInputAssemblyFile**, HRESULT>)_lpVtbl[233])(pThis, ppResult);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_characteristics"/>
    public HRESULT get_characteristics(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[234])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_coffGroup"/>
    public HRESULT get_coffGroup(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[235])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_bindID"/>
    public HRESULT get_bindID(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[236])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_bindSpace"/>
    public HRESULT get_bindSpace(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[237])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol.Interface.get_bindSlot"/>
    public HRESULT get_bindSlot(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[238])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol2.Interface.get_isObjCClass"/>
    public HRESULT get_isObjCClass(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[239])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol2.Interface.get_isObjCCategory"/>
    public HRESULT get_isObjCCategory(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[240])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol2.Interface.get_isObjCProtocol"/>
    public HRESULT get_isObjCProtocol(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[241])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol3.Interface.get_inlinee"/>
    public HRESULT get_inlinee(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, IDiaSymbol**, HRESULT>)_lpVtbl[242])(pThis, pRetVal);
    }

    /// <inheritdoc cref="IDiaSymbol3.Interface.get_inlineeId"/>
    public HRESULT get_inlineeId(uint* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, uint*, HRESULT>)_lpVtbl[243])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_noexcept"/>
    public HRESULT get_noexcept(BOOL* pRetVal)
    {
        fixed (IDiaSymbol4* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSymbol4*, BOOL*, HRESULT>)_lpVtbl[244])(pThis, pRetVal);
    }

    /// <summary>
    ///  Extends IDiaSymbol3 with the noexcept property.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiasymbol4">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("BF6C88A7-E9D6-4346-99A1-D053DE5A7808")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface : IDiaSymbol3.Interface
    {
        /// <summary>
        ///  Noexcept.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_noexcept(BOOL* pRetVal);
    }
}
