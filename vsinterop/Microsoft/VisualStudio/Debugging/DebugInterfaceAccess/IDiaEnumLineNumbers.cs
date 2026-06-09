// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaEnumLineNumbers : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0xFE30E878, 0x54AC, 0x44F1, 0x81, 0xBA, 0x39, 0xDE, 0x94, 0x0F, 0x60, 0x52);
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
                0x78, 0xE8, 0x30, 0xFE,
                0xAC, 0x54,
                0xF1, 0x44,
                0x81, 0xBA, 0x39, 0xDE, 0x94, 0x0F, 0x60, 0x52
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaEnumLineNumbers* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumLineNumbers*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaEnumLineNumbers* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumLineNumbers*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaEnumLineNumbers* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumLineNumbers*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get__NewEnum"/>
    public HRESULT get__NewEnum(IUnknown** pRetVal)
    {
        fixed (IDiaEnumLineNumbers* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumLineNumbers*, IUnknown**, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_Count"/>
    public HRESULT get_Count(int* pRetVal)
    {
        fixed (IDiaEnumLineNumbers* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumLineNumbers*, int*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.Item"/>
    public HRESULT Item(uint index, IDiaLineNumber** lineNumber)
    {
        fixed (IDiaEnumLineNumbers* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumLineNumbers*, uint, IDiaLineNumber**, HRESULT>)_lpVtbl[5])(pThis, index, lineNumber);
    }

    /// <inheritdoc cref="Interface.Next"/>
    public HRESULT Next(uint celt, IDiaLineNumber** rgelt, uint* pceltFetched)
    {
        fixed (IDiaEnumLineNumbers* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumLineNumbers*, uint, IDiaLineNumber**, uint*, HRESULT>)_lpVtbl[6])(pThis, celt, rgelt, pceltFetched);
    }

    /// <inheritdoc cref="Interface.Skip"/>
    public HRESULT Skip(uint celt)
    {
        fixed (IDiaEnumLineNumbers* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumLineNumbers*, uint, HRESULT>)_lpVtbl[7])(pThis, celt);
    }

    /// <inheritdoc cref="Interface.Reset"/>
    public HRESULT Reset()
    {
        fixed (IDiaEnumLineNumbers* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumLineNumbers*, HRESULT>)_lpVtbl[8])(pThis);
    }

    /// <inheritdoc cref="Interface.Clone"/>
    public HRESULT Clone(IDiaEnumLineNumbers** ppenum)
    {
        fixed (IDiaEnumLineNumbers* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumLineNumbers*, IDiaEnumLineNumbers**, HRESULT>)_lpVtbl[9])(pThis, ppenum);
    }

    /// <summary>
    ///  Enumerates the various line numbers contained in the data source.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaenumlinenumbers">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("FE30E878-54AC-44F1-81BA-39DE940F6052")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Retrieves a version of this enumerator as a COM <c>IEnumVARIANT</c> enumerator.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get__NewEnum(IUnknown** pRetVal);

        /// <summary>
        ///  Number of line numbers.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_Count(int* pRetVal);

        /// <summary>
        ///  Returns the line number for the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to retrieve.</param>
        /// <param name="lineNumber">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Item(uint index, IDiaLineNumber** lineNumber);

        /// <summary>
        ///  Retrieves the next item or items in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of items to retrieve.</param>
        /// <param name="rgelt">Pointer to a variable that receives the requested object.</param>
        /// <param name="pceltFetched">Pointer to a variable that receives the number of items actually retrieved.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Next(uint celt, IDiaLineNumber** rgelt, uint* pceltFetched);

        /// <summary>
        ///  Skips a specified number of items in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of items to retrieve.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Skip(uint celt);

        /// <summary>
        ///  Resets the enumeration sequence to the beginning.
        /// </summary>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        ///  Creates an enumerator that contains the same enumeration state as the current enumerator.
        /// </summary>
        /// <param name="ppenum">Pointer to a variable that receives the cloned enumerator.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Clone(IDiaEnumLineNumbers** ppenum);
    }
}
