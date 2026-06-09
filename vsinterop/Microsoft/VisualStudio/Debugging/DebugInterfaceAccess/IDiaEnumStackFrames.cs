// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaEnumStackFrames : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0xEC9D461D, 0xCE74, 0x4711, 0xA0, 0x20, 0x7D, 0x8F, 0x9A, 0x1D, 0xD2, 0x55);
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
                0x1D, 0x46, 0x9D, 0xEC,
                0x74, 0xCE,
                0x11, 0x47,
                0xA0, 0x20, 0x7D, 0x8F, 0x9A, 0x1D, 0xD2, 0x55
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaEnumStackFrames* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumStackFrames*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaEnumStackFrames* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumStackFrames*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaEnumStackFrames* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumStackFrames*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.Next"/>
    public HRESULT Next(uint celt, IDiaStackFrame** rgelt, uint* pceltFetched)
    {
        fixed (IDiaEnumStackFrames* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumStackFrames*, uint, IDiaStackFrame**, uint*, HRESULT>)_lpVtbl[3])(pThis, celt, rgelt, pceltFetched);
    }

    /// <inheritdoc cref="Interface.Reset"/>
    public HRESULT Reset()
    {
        fixed (IDiaEnumStackFrames* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumStackFrames*, HRESULT>)_lpVtbl[4])(pThis);
    }

    /// <summary>
    ///  Enumerates the various stack frames available in a particular context.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaenumstackframes">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("EC9D461D-CE74-4711-A020-7D8F9A1DD255")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Retrieves the next item or items in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of items to retrieve.</param>
        /// <param name="rgelt">Pointer to a variable that receives the requested object.</param>
        /// <param name="pceltFetched">Pointer to a variable that receives the number of items actually retrieved.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Next(uint celt, IDiaStackFrame** rgelt, uint* pceltFetched);

        /// <summary>
        ///  Resets the enumeration sequence to the beginning.
        /// </summary>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Reset();
    }
}
