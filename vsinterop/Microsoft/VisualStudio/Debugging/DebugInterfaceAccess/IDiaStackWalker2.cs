// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaStackWalker2 : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x7C185885, 0xA015, 0x4CAC, 0x94, 0x11, 0x0F, 0x4F, 0xB3, 0x9B, 0x1F, 0x3A);
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
                0x85, 0x58, 0x18, 0x7C,
                0x15, 0xA0,
                0xAC, 0x4C,
                0x94, 0x11, 0x0F, 0x4F, 0xB3, 0x9B, 0x1F, 0x3A
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaStackWalker2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalker2*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaStackWalker2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalker2*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaStackWalker2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalker2*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="IDiaStackWalker.Interface.getEnumFrames"/>
    public HRESULT getEnumFrames(IDiaStackWalkHelper* pHelper, IDiaEnumStackFrames** ppEnum)
    {
        fixed (IDiaStackWalker2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalker2*, IDiaStackWalkHelper*, IDiaEnumStackFrames**, HRESULT>)_lpVtbl[3])(pThis, pHelper, ppEnum);
    }

    /// <inheritdoc cref="IDiaStackWalker.Interface.getEnumFrames2"/>
    public HRESULT getEnumFrames2(CV_CPU_TYPE_e cpuid, IDiaStackWalkHelper* pHelper, IDiaEnumStackFrames** ppEnum)
    {
        fixed (IDiaStackWalker2* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaStackWalker2*, CV_CPU_TYPE_e, IDiaStackWalkHelper*, IDiaEnumStackFrames**, HRESULT>)_lpVtbl[4])(pThis, cpuid, pHelper, ppEnum);
    }

    /// <summary>
    ///  Extends IDiaStackWalker for additional stack walking scenarios.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiastackwalker2">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("7C185885-A015-4CAC-9411-0F4FB39B1F3A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface Interface : IDiaStackWalker.Interface
    {
    }
}
