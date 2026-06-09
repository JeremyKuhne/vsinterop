// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaSectionContrib : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x0CF4B60E, 0x35B1, 0x4C6C, 0xBD, 0xD8, 0x85, 0x4B, 0x9C, 0x8E, 0x38, 0x57);
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
                0x0E, 0xB6, 0xF4, 0x0C,
                0xB1, 0x35,
                0x6C, 0x4C,
                0xBD, 0xD8, 0x85, 0x4B, 0x9C, 0x8E, 0x38, 0x57
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get_compiland"/>
    public HRESULT get_compiland(IDiaSymbol** pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, IDiaSymbol**, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_addressSection"/>
    public HRESULT get_addressSection(uint* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, uint*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_addressOffset"/>
    public HRESULT get_addressOffset(uint* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, uint*, HRESULT>)_lpVtbl[5])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_relativeVirtualAddress"/>
    public HRESULT get_relativeVirtualAddress(uint* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, uint*, HRESULT>)_lpVtbl[6])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_virtualAddress"/>
    public HRESULT get_virtualAddress(ulong* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, ulong*, HRESULT>)_lpVtbl[7])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_length"/>
    public HRESULT get_length(uint* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, uint*, HRESULT>)_lpVtbl[8])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_notPaged"/>
    public HRESULT get_notPaged(BOOL* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, BOOL*, HRESULT>)_lpVtbl[9])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_code"/>
    public HRESULT get_code(BOOL* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, BOOL*, HRESULT>)_lpVtbl[10])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_initializedData"/>
    public HRESULT get_initializedData(BOOL* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, BOOL*, HRESULT>)_lpVtbl[11])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_uninitializedData"/>
    public HRESULT get_uninitializedData(BOOL* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, BOOL*, HRESULT>)_lpVtbl[12])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_remove"/>
    public HRESULT get_remove(BOOL* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, BOOL*, HRESULT>)_lpVtbl[13])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_comdat"/>
    public HRESULT get_comdat(BOOL* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, BOOL*, HRESULT>)_lpVtbl[14])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_discardable"/>
    public HRESULT get_discardable(BOOL* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, BOOL*, HRESULT>)_lpVtbl[15])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_notCached"/>
    public HRESULT get_notCached(BOOL* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, BOOL*, HRESULT>)_lpVtbl[16])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_share"/>
    public HRESULT get_share(BOOL* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, BOOL*, HRESULT>)_lpVtbl[17])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_execute"/>
    public HRESULT get_execute(BOOL* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, BOOL*, HRESULT>)_lpVtbl[18])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_read"/>
    public HRESULT get_read(BOOL* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, BOOL*, HRESULT>)_lpVtbl[19])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_write"/>
    public HRESULT get_write(BOOL* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, BOOL*, HRESULT>)_lpVtbl[20])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_dataCrc"/>
    public HRESULT get_dataCrc(uint* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, uint*, HRESULT>)_lpVtbl[21])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_relocationsCrc"/>
    public HRESULT get_relocationsCrc(uint* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, uint*, HRESULT>)_lpVtbl[22])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_compilandId"/>
    public HRESULT get_compilandId(uint* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, uint*, HRESULT>)_lpVtbl[23])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_code16bit"/>
    public HRESULT get_code16bit(BOOL* pRetVal)
    {
        fixed (IDiaSectionContrib* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaSectionContrib*, BOOL*, HRESULT>)_lpVtbl[24])(pThis, pRetVal);
    }

    /// <summary>
    ///  Represents a section contribution; that is, a contiguous block of memory contributed to the image by a compiland.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiasectioncontrib">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("0CF4B60E-35B1-4C6C-BDD8-854B9C8E3857")]
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
        ///  Retrieves the not paged.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_notPaged(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the code.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_code(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the initialized data.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_initializedData(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the uninitialized data.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_uninitializedData(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the remove.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_remove(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the comdat.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_comdat(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the discardable.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_discardable(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the not cached.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_notCached(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the share.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_share(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the execute.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_execute(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the read.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_read(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the write.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_write(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the data crc.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_dataCrc(uint* pRetVal);

        /// <summary>
        ///  Retrieves the relocations crc.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_relocationsCrc(uint* pRetVal);

        /// <summary>
        ///  Retrieves the compiland id.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_compilandId(uint* pRetVal);

        /// <summary>
        ///  Retrieves the code16bit.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_code16bit(BOOL* pRetVal);
    }
}
