// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaFrameData : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0xA39184B7, 0x6A36, 0x42DE, 0x8E, 0xEC, 0x7D, 0xF9, 0xF3, 0xF5, 0x9F, 0x33);
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
                0xB7, 0x84, 0x91, 0xA3,
                0x36, 0x6A,
                0xDE, 0x42,
                0x8E, 0xEC, 0x7D, 0xF9, 0xF3, 0xF5, 0x9F, 0x33
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get_addressSection"/>
    public HRESULT get_addressSection(uint* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, uint*, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_addressOffset"/>
    public HRESULT get_addressOffset(uint* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, uint*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_relativeVirtualAddress"/>
    public HRESULT get_relativeVirtualAddress(uint* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, uint*, HRESULT>)_lpVtbl[5])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_virtualAddress"/>
    public HRESULT get_virtualAddress(ulong* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, ulong*, HRESULT>)_lpVtbl[6])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_lengthBlock"/>
    public HRESULT get_lengthBlock(uint* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, uint*, HRESULT>)_lpVtbl[7])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_lengthLocals"/>
    public HRESULT get_lengthLocals(uint* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, uint*, HRESULT>)_lpVtbl[8])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_lengthParams"/>
    public HRESULT get_lengthParams(uint* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, uint*, HRESULT>)_lpVtbl[9])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_maxStack"/>
    public HRESULT get_maxStack(uint* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, uint*, HRESULT>)_lpVtbl[10])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_lengthProlog"/>
    public HRESULT get_lengthProlog(uint* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, uint*, HRESULT>)_lpVtbl[11])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_lengthSavedRegisters"/>
    public HRESULT get_lengthSavedRegisters(uint* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, uint*, HRESULT>)_lpVtbl[12])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_program"/>
    public HRESULT get_program(BSTR* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, BSTR*, HRESULT>)_lpVtbl[13])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_systemExceptionHandling"/>
    public HRESULT get_systemExceptionHandling(BOOL* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, BOOL*, HRESULT>)_lpVtbl[14])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_cplusplusExceptionHandling"/>
    public HRESULT get_cplusplusExceptionHandling(BOOL* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, BOOL*, HRESULT>)_lpVtbl[15])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_functionStart"/>
    public HRESULT get_functionStart(BOOL* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, BOOL*, HRESULT>)_lpVtbl[16])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_allocatesBasePointer"/>
    public HRESULT get_allocatesBasePointer(BOOL* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, BOOL*, HRESULT>)_lpVtbl[17])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_type"/>
    public HRESULT get_type(uint* pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, uint*, HRESULT>)_lpVtbl[18])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_functionParent"/>
    public HRESULT get_functionParent(IDiaFrameData** pRetVal)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, IDiaFrameData**, HRESULT>)_lpVtbl[19])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.execute"/>
    public HRESULT execute(IDiaStackWalkFrame* frame)
    {
        fixed (IDiaFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaFrameData*, IDiaStackWalkFrame*, HRESULT>)_lpVtbl[20])(pThis, frame);
    }

    /// <summary>
    ///  Represents stack frame data.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaframedata">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("A39184B7-6A36-42DE-8EEC-7DF9F3F59F33")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
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
        ///  Retrieves the length block.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_lengthBlock(uint* pRetVal);

        /// <summary>
        ///  Retrieves the length locals.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_lengthLocals(uint* pRetVal);

        /// <summary>
        ///  Retrieves the length params.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_lengthParams(uint* pRetVal);

        /// <summary>
        ///  Retrieves the max stack.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_maxStack(uint* pRetVal);

        /// <summary>
        ///  Retrieves the length prolog.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_lengthProlog(uint* pRetVal);

        /// <summary>
        ///  Retrieves the length saved registers.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_lengthSavedRegisters(uint* pRetVal);

        /// <summary>
        ///  Retrieves the program.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_program(BSTR* pRetVal);

        /// <summary>
        ///  Retrieves the system exception handling.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_systemExceptionHandling(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the cplusplus exception handling.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_cplusplusExceptionHandling(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the function start.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_functionStart(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the allocates base pointer.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_allocatesBasePointer(BOOL* pRetVal);

        /// <summary>
        ///  Retrieves the type.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_type(uint* pRetVal);

        /// <summary>
        ///  Frame data for enclosing function.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_functionParent(IDiaFrameData** pRetVal);

        /// <summary>
        ///  Execute.
        /// </summary>
        /// <param name="frame">The frame value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT execute(IDiaStackWalkFrame* frame);
    }
}
