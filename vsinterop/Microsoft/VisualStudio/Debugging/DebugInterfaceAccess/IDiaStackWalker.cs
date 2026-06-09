// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaStackWalker : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x5485216B, 0xA54C, 0x469F, 0x96, 0x70, 0x52, 0xB2, 0x4D, 0x52, 0x29, 0xBB);
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
                0x6B, 0x21, 0x85, 0x54,
                0x4C, 0xA5,
                0x9F, 0x46,
                0x96, 0x70, 0x52, 0xB2, 0x4D, 0x52, 0x29, 0xBB
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaStackWalker* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalker*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaStackWalker* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalker*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaStackWalker* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalker*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.getEnumFrames"/>
    public HRESULT getEnumFrames(IDiaStackWalkHelper* pHelper, IDiaEnumStackFrames** ppEnum)
    {
        fixed (IDiaStackWalker* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalker*, IDiaStackWalkHelper*, IDiaEnumStackFrames**, HRESULT>)_lpVtbl[3])(pThis, pHelper, ppEnum);
    }

    /// <inheritdoc cref="Interface.getEnumFrames2"/>
    public HRESULT getEnumFrames2(CV_CPU_TYPE_e cpuid, IDiaStackWalkHelper* pHelper, IDiaEnumStackFrames** ppEnum)
    {
        fixed (IDiaStackWalker* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalker*, CV_CPU_TYPE_e, IDiaStackWalkHelper*, IDiaEnumStackFrames**, HRESULT>)_lpVtbl[4])(pThis, cpuid, pHelper, ppEnum);
    }

    /// <summary>
    ///  Walks a call stack using the supplied stack-walking helper.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiastackwalker">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("5485216B-A54C-469F-9670-52B24D5229BB")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Get enum frames.
        /// </summary>
        /// <param name="pHelper">The pHelper value.</param>
        /// <param name="ppEnum">Pointer to a variable that receives the cloned enumerator.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getEnumFrames(IDiaStackWalkHelper* pHelper, IDiaEnumStackFrames** ppEnum);

        /// <summary>
        ///  Get enum frames2.
        /// </summary>
        /// <param name="cpuid">The cpuid value.</param>
        /// <param name="pHelper">The pHelper value.</param>
        /// <param name="ppEnum">Pointer to a variable that receives the cloned enumerator.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT getEnumFrames2(CV_CPU_TYPE_e cpuid, IDiaStackWalkHelper* pHelper, IDiaEnumStackFrames** ppEnum);
    }
}
