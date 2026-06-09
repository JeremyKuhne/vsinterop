// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaEnumSourceLink2 : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x136D8151, 0xADE7, 0x4704, 0xAF, 0x13, 0x32, 0x40, 0x80, 0x76, 0x2E, 0x8F);
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
                0x51, 0x81, 0x6D, 0x13,
                0xE7, 0xAD,
                0x04, 0x47,
                0xAF, 0x13, 0x32, 0x40, 0x80, 0x76, 0x2E, 0x8F
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaEnumSourceLink2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink2*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaEnumSourceLink2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink2*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaEnumSourceLink2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink2*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="IDiaEnumSourceLink.Interface.Count"/>
    public HRESULT Count(uint* pCnt)
    {
        fixed (IDiaEnumSourceLink2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink2*, uint*, HRESULT>)_lpVtbl[3])(pThis, pCnt);
    }

    /// <inheritdoc cref="IDiaEnumSourceLink.Interface.SizeOfNext"/>
    public HRESULT SizeOfNext(uint* pcb)
    {
        fixed (IDiaEnumSourceLink2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink2*, uint*, HRESULT>)_lpVtbl[4])(pThis, pcb);
    }

    /// <inheritdoc cref="IDiaEnumSourceLink.Interface.Next"/>
    public HRESULT Next(uint cb, uint* pcb, byte* pb)
    {
        fixed (IDiaEnumSourceLink2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink2*, uint, uint*, byte*, HRESULT>)_lpVtbl[5])(pThis, cb, pcb, pb);
    }

    /// <inheritdoc cref="IDiaEnumSourceLink.Interface.Skip"/>
    public HRESULT Skip(uint cnt)
    {
        fixed (IDiaEnumSourceLink2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink2*, uint, HRESULT>)_lpVtbl[6])(pThis, cnt);
    }

    /// <inheritdoc cref="IDiaEnumSourceLink.Interface.Reset"/>
    public HRESULT Reset()
    {
        fixed (IDiaEnumSourceLink2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink2*, HRESULT>)_lpVtbl[7])(pThis);
    }

    /// <inheritdoc cref="IDiaEnumSourceLink.Interface.Clone"/>
    public HRESULT Clone(IDiaEnumSourceLink** ppenum)
    {
        fixed (IDiaEnumSourceLink2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink2*, IDiaEnumSourceLink**, HRESULT>)_lpVtbl[8])(pThis, ppenum);
    }

    /// <inheritdoc cref="Interface.SizeOfNext2"/>
    public HRESULT SizeOfNext2(ulong* pcb)
    {
        fixed (IDiaEnumSourceLink2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink2*, ulong*, HRESULT>)_lpVtbl[9])(pThis, pcb);
    }

    /// <inheritdoc cref="Interface.Next2"/>
    public HRESULT Next2(ulong cb, ulong* pcb, byte* pb)
    {
        fixed (IDiaEnumSourceLink2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumSourceLink2*, ulong, ulong*, byte*, HRESULT>)_lpVtbl[10])(pThis, cb, pcb, pb);
    }

    /// <summary>
    ///  Extends IDiaEnumSourceLink with support for larger source link streams.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaenumsourcelink2">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("136D8151-ADE7-4704-AF13-324080762E8F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface : IDiaEnumSourceLink.Interface
    {
        /// <summary>
        ///  Size of next2.
        /// </summary>
        /// <param name="pcb">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT SizeOfNext2(ulong* pcb);

        /// <summary>
        ///  Next2.
        /// </summary>
        /// <param name="cb">The size, in bytes, of the buffer.</param>
        /// <param name="pcb">Pointer to a variable that receives the number of bytes written to the buffer.</param>
        /// <param name="pb">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Next2(ulong cb, ulong* pcb, byte* pb);
    }
}
