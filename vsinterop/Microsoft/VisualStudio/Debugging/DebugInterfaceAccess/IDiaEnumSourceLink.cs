// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaEnumSourceLink : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x45CD1EB3, 0x5C6C, 0x43E3, 0xB2, 0x0A, 0xA4, 0xD8, 0x03, 0x5D, 0xE4, 0xE2);
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
                0xB3, 0x1E, 0xCD, 0x45,
                0x6C, 0x5C,
                0xE3, 0x43,
                0xB2, 0x0A, 0xA4, 0xD8, 0x03, 0x5D, 0xE4, 0xE2
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaEnumSourceLink* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaEnumSourceLink* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaEnumSourceLink* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.Count"/>
    public HRESULT Count(uint* pCnt)
    {
        fixed (IDiaEnumSourceLink* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink*, uint*, HRESULT>)_lpVtbl[3])(pThis, pCnt);
    }

    /// <inheritdoc cref="Interface.SizeOfNext"/>
    public HRESULT SizeOfNext(uint* pcb)
    {
        fixed (IDiaEnumSourceLink* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink*, uint*, HRESULT>)_lpVtbl[4])(pThis, pcb);
    }

    /// <inheritdoc cref="Interface.Next"/>
    public HRESULT Next(uint cb, uint* pcb, byte* pb)
    {
        fixed (IDiaEnumSourceLink* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink*, uint, uint*, byte*, HRESULT>)_lpVtbl[5])(pThis, cb, pcb, pb);
    }

    /// <inheritdoc cref="Interface.Skip"/>
    public HRESULT Skip(uint cnt)
    {
        fixed (IDiaEnumSourceLink* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink*, uint, HRESULT>)_lpVtbl[6])(pThis, cnt);
    }

    /// <inheritdoc cref="Interface.Reset"/>
    public HRESULT Reset()
    {
        fixed (IDiaEnumSourceLink* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink*, HRESULT>)_lpVtbl[7])(pThis);
    }

    /// <inheritdoc cref="Interface.Clone"/>
    public HRESULT Clone(IDiaEnumSourceLink** ppenum)
    {
        fixed (IDiaEnumSourceLink* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink*, IDiaEnumSourceLink**, HRESULT>)_lpVtbl[8])(pThis, ppenum);
    }

    /// <summary>
    ///  Enumerates source link key and value pairs.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaenumsourcelink">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("45CD1EB3-5C6C-43E3-B20A-A4D8035DE4E2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Count.
        /// </summary>
        /// <param name="pCnt">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Count(uint* pCnt);

        /// <summary>
        ///  Size of next.
        /// </summary>
        /// <param name="pcb">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT SizeOfNext(uint* pcb);

        /// <summary>
        ///  Retrieves the next item or items in the enumeration sequence.
        /// </summary>
        /// <param name="cb">The size, in bytes, of the buffer.</param>
        /// <param name="pcb">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <param name="pb">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Next(uint cb, uint* pcb, byte* pb);

        /// <summary>
        ///  Skips a specified number of items in the enumeration sequence.
        /// </summary>
        /// <param name="cnt">The cnt value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Skip(uint cnt);

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
        HRESULT Clone(IDiaEnumSourceLink** ppenum);
    }
}
