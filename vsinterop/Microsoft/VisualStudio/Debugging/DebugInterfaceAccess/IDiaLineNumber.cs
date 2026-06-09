// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaLineNumber : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0xB388EB14, 0xBE4D, 0x421D, 0xA8, 0xA1, 0x6C, 0xF7, 0xAB, 0x05, 0x70, 0x86);
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
                0x14, 0xEB, 0x88, 0xB3,
                0x4D, 0xBE,
                0x1D, 0x42,
                0xA8, 0xA1, 0x6C, 0xF7, 0xAB, 0x05, 0x70, 0x86
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get_compiland"/>
    public HRESULT get_compiland(IDiaSymbol** pRetVal)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, IDiaSymbol**, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_sourceFile"/>
    public HRESULT get_sourceFile(IDiaSourceFile** pRetVal)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, IDiaSourceFile**, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_lineNumber"/>
    public HRESULT get_lineNumber(uint* pRetVal)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, uint*, HRESULT>)_lpVtbl[5])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_lineNumberEnd"/>
    public HRESULT get_lineNumberEnd(uint* pRetVal)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, uint*, HRESULT>)_lpVtbl[6])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_columnNumber"/>
    public HRESULT get_columnNumber(uint* pRetVal)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, uint*, HRESULT>)_lpVtbl[7])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_columnNumberEnd"/>
    public HRESULT get_columnNumberEnd(uint* pRetVal)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, uint*, HRESULT>)_lpVtbl[8])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_addressSection"/>
    public HRESULT get_addressSection(uint* pRetVal)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, uint*, HRESULT>)_lpVtbl[9])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_addressOffset"/>
    public HRESULT get_addressOffset(uint* pRetVal)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, uint*, HRESULT>)_lpVtbl[10])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_relativeVirtualAddress"/>
    public HRESULT get_relativeVirtualAddress(uint* pRetVal)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, uint*, HRESULT>)_lpVtbl[11])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_virtualAddress"/>
    public HRESULT get_virtualAddress(ulong* pRetVal)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, ulong*, HRESULT>)_lpVtbl[12])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_length"/>
    public HRESULT get_length(uint* pRetVal)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, uint*, HRESULT>)_lpVtbl[13])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_sourceFileId"/>
    public HRESULT get_sourceFileId(uint* pRetVal)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, uint*, HRESULT>)_lpVtbl[14])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_statement"/>
    public HRESULT get_statement(BOOL* pRetVal)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, BOOL*, HRESULT>)_lpVtbl[15])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_compilandId"/>
    public HRESULT get_compilandId(uint* pRetVal)
    {
        fixed (IDiaLineNumber* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaLineNumber*, uint*, HRESULT>)_lpVtbl[16])(pThis, pRetVal);
    }

    /// <summary>
    ///  Represents the location of a compiland source line.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idialinenumber">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("B388EB14-BE4D-421D-A8A1-6CF7AB057086")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Retrieves the compiland.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_compiland(IDiaSymbol** pRetVal);

        /// <summary>
        ///  Retrieves the source file.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_sourceFile(IDiaSourceFile** pRetVal);

        /// <summary>
        ///  Retrieves the line number.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_lineNumber(uint* pRetVal);

        /// <summary>
        ///  Retrieves the line number end.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_lineNumberEnd(uint* pRetVal);

        /// <summary>
        ///  Retrieves the column number.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_columnNumber(uint* pRetVal);

        /// <summary>
        ///  Retrieves the column number end.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_columnNumberEnd(uint* pRetVal);

        /// <summary>
        ///  Retrieves the address section.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_addressSection(uint* pRetVal);

        /// <summary>
        ///  Retrieves the address offset.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_addressOffset(uint* pRetVal);

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
        ///  Retrieves the length.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_length(uint* pRetVal);

        /// <summary>
        ///  Retrieves the source file id.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_sourceFileId(uint* pRetVal);

        /// <summary>
        ///  Retrieves the statement.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_statement(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the compiland id.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_compilandId(uint* pRetVal);
    }
}
