// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaEnumFrameData : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x9FC77A4B, 0x3C1C, 0x44ED, 0xA7, 0x98, 0x6C, 0x1D, 0xEE, 0xA5, 0x3E, 0x1F);
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
                0x4B, 0x7A, 0xC7, 0x9F,
                0x1C, 0x3C,
                0xED, 0x44,
                0xA7, 0x98, 0x6C, 0x1D, 0xEE, 0xA5, 0x3E, 0x1F
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaEnumFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumFrameData*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaEnumFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumFrameData*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaEnumFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumFrameData*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get__NewEnum"/>
    public HRESULT get__NewEnum(IUnknown** pRetVal)
    {
        fixed (IDiaEnumFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumFrameData*, IUnknown**, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_Count"/>
    public HRESULT get_Count(int* pRetVal)
    {
        fixed (IDiaEnumFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumFrameData*, int*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.Item"/>
    public HRESULT Item(uint index, IDiaFrameData** frame)
    {
        fixed (IDiaEnumFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumFrameData*, uint, IDiaFrameData**, HRESULT>)_lpVtbl[5])(pThis, index, frame);
    }

    /// <inheritdoc cref="Interface.Next"/>
    public HRESULT Next(uint celt, IDiaFrameData** rgelt, uint* pceltFetched)
    {
        fixed (IDiaEnumFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumFrameData*, uint, IDiaFrameData**, uint*, HRESULT>)_lpVtbl[6])(pThis, celt, rgelt, pceltFetched);
    }

    /// <inheritdoc cref="Interface.Skip"/>
    public HRESULT Skip(uint celt)
    {
        fixed (IDiaEnumFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumFrameData*, uint, HRESULT>)_lpVtbl[7])(pThis, celt);
    }

    /// <inheritdoc cref="Interface.Reset"/>
    public HRESULT Reset()
    {
        fixed (IDiaEnumFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumFrameData*, HRESULT>)_lpVtbl[8])(pThis);
    }

    /// <inheritdoc cref="Interface.Clone"/>
    public HRESULT Clone(IDiaEnumFrameData** ppenum)
    {
        fixed (IDiaEnumFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumFrameData*, IDiaEnumFrameData**, HRESULT>)_lpVtbl[9])(pThis, ppenum);
    }

    /// <inheritdoc cref="Interface.frameByRVA"/>
    public HRESULT frameByRVA(uint relativeVirtualAddress, IDiaFrameData** frame)
    {
        fixed (IDiaEnumFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumFrameData*, uint, IDiaFrameData**, HRESULT>)_lpVtbl[10])(pThis, relativeVirtualAddress, frame);
    }

    /// <inheritdoc cref="Interface.frameByVA"/>
    public HRESULT frameByVA(ulong virtualAddress, IDiaFrameData** frame)
    {
        fixed (IDiaEnumFrameData* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumFrameData*, ulong, IDiaFrameData**, HRESULT>)_lpVtbl[11])(pThis, virtualAddress, frame);
    }

    /// <summary>
    ///  Enumerates the various frame data elements contained in the data source.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaenumframedata">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("9FC77A4B-3C1C-44ED-A798-6C1DEEA53E1F")]
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
        ///  Number of frames.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_Count(int* pRetVal);

        /// <summary>
        ///  Returns the frame for the given index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to retrieve.</param>
        /// <param name="frame">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Item(uint index, IDiaFrameData** frame);

        /// <summary>
        ///  Retrieves the next item or items in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of items to retrieve.</param>
        /// <param name="rgelt">Pointer to a variable that receives the requested object.</param>
        /// <param name="pceltFetched">Pointer to a variable that receives the number of items actually retrieved.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Next(uint celt, IDiaFrameData** rgelt, uint* pceltFetched);

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
        HRESULT Clone(IDiaEnumFrameData** ppenum);

        /// <summary>
        ///  Returns the frame for the given relative virtual address.
        /// </summary>
        /// <param name="relativeVirtualAddress">The relativeVirtualAddress value.</param>
        /// <param name="frame">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT frameByRVA(uint relativeVirtualAddress, IDiaFrameData** frame);

        /// <summary>
        ///  Returns the frame for the given virtual address.
        /// </summary>
        /// <param name="virtualAddress">The virtualAddress value.</param>
        /// <param name="frame">Pointer to a variable that receives the requested object.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT frameByVA(ulong virtualAddress, IDiaFrameData** frame);
    }
}
