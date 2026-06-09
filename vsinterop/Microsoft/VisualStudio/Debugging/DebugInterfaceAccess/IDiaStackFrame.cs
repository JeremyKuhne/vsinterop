// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaStackFrame : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x5EDBC96D, 0xCDD6, 0x4792, 0xAF, 0xBE, 0xCC, 0x89, 0x00, 0x7D, 0x96, 0x10);
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
                0x6D, 0xC9, 0xDB, 0x5E,
                0xD6, 0xCD,
                0x92, 0x47,
                0xAF, 0xBE, 0xCC, 0x89, 0x00, 0x7D, 0x96, 0x10
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get_type"/>
    public HRESULT get_type(uint* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, uint*, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_base"/>
    public HRESULT get_base(ulong* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, ulong*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_size"/>
    public HRESULT get_size(uint* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, uint*, HRESULT>)_lpVtbl[5])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_returnAddress"/>
    public HRESULT get_returnAddress(ulong* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, ulong*, HRESULT>)_lpVtbl[6])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_localsBase"/>
    public HRESULT get_localsBase(ulong* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, ulong*, HRESULT>)_lpVtbl[7])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_lengthLocals"/>
    public HRESULT get_lengthLocals(uint* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, uint*, HRESULT>)_lpVtbl[8])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_lengthParams"/>
    public HRESULT get_lengthParams(uint* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, uint*, HRESULT>)_lpVtbl[9])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_lengthProlog"/>
    public HRESULT get_lengthProlog(uint* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, uint*, HRESULT>)_lpVtbl[10])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_lengthSavedRegisters"/>
    public HRESULT get_lengthSavedRegisters(uint* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, uint*, HRESULT>)_lpVtbl[11])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_systemExceptionHandling"/>
    public HRESULT get_systemExceptionHandling(BOOL* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, BOOL*, HRESULT>)_lpVtbl[12])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_cplusplusExceptionHandling"/>
    public HRESULT get_cplusplusExceptionHandling(BOOL* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, BOOL*, HRESULT>)_lpVtbl[13])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_functionStart"/>
    public HRESULT get_functionStart(BOOL* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, BOOL*, HRESULT>)_lpVtbl[14])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_allocatesBasePointer"/>
    public HRESULT get_allocatesBasePointer(BOOL* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, BOOL*, HRESULT>)_lpVtbl[15])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_maxStack"/>
    public HRESULT get_maxStack(uint* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, uint*, HRESULT>)_lpVtbl[16])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_registerValue"/>
    public HRESULT get_registerValue(uint index, ulong* pRetVal)
    {
        fixed (IDiaStackFrame* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackFrame*, uint, ulong*, HRESULT>)_lpVtbl[17])(pThis, index, pRetVal);
    }

    /// <summary>
    ///  Exposes the properties of a stack frame.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiastackframe">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("5EDBC96D-CDD6-4792-AFBE-CC89007D9610")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Type.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_type(uint* pRetVal);

        /// <summary>
        ///  Base of the stack frame.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_base(ulong* pRetVal);

        /// <summary>
        ///  Size of frame in bytes.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_size(uint* pRetVal);

        /// <summary>
        ///  Return address of the frame.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_returnAddress(ulong* pRetVal);

        /// <summary>
        ///  Base of locals.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_localsBase(ulong* pRetVal);

        /// <summary>
        ///  CbLocals.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_lengthLocals(uint* pRetVal);

        /// <summary>
        ///  CbParams.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_lengthParams(uint* pRetVal);

        /// <summary>
        ///  CbProlog.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_lengthProlog(uint* pRetVal);

        /// <summary>
        ///  CbSavedRegs.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_lengthSavedRegisters(uint* pRetVal);

        /// <summary>
        ///  FHasSEH.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_systemExceptionHandling(BOOL* pRetVal);

        /// <summary>
        ///  FHasEH.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_cplusplusExceptionHandling(BOOL* pRetVal);

        /// <summary>
        ///  FuncStart.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_functionStart(BOOL* pRetVal);

        /// <summary>
        ///  FUsesBP.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_allocatesBasePointer(BOOL* pRetVal);

        /// <summary>
        ///  MaxStack.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_maxStack(uint* pRetVal);

        /// <summary>
        ///  Register value.
        /// </summary>
        /// <param name="index">The zero-based index of the item to retrieve.</param>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_registerValue(uint index, ulong* pRetVal);
    }
}
