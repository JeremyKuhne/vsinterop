// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Setup.Configuration;

/// <inheritdoc cref="Interface"/>
public unsafe struct ISetupConfiguration : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
    public static Guid Guid { get; } = new(0x42843719, 0xDB4C, 0x46C2, 0x8E, 0x7C, 0x64, 0xF1, 0x81, 0x6E, 0xFD, 0x5B);

#if NETFRAMEWORK
    readonly Guid IComIID.Guid => Guid;
#else
    static ref readonly Guid IComIID.Guid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ReadOnlySpan<byte> data =
            [
                0x19, 0x37, 0x84, 0x42,
                0x4C, 0xDB,
                0xC2, 0x46,
                0x8E, 0x7C, 0x64, 0xF1, 0x81, 0x6E, 0xFD, 0x5B
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (ISetupConfiguration* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<ISetupConfiguration*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (ISetupConfiguration* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<ISetupConfiguration*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (ISetupConfiguration* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<ISetupConfiguration*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.EnumInstances(IEnumSetupInstances**)"/>
    public HRESULT EnumInstances(IEnumSetupInstances** ppEnumInstances)
    {
        fixed (ISetupConfiguration* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<ISetupConfiguration*, IEnumSetupInstances**, HRESULT>)_lpVtbl[3])(pThis, ppEnumInstances);
    }

    /// <inheritdoc cref="Interface.GetInstanceForCurrentProcess(ISetupInstance**)"/>
    public HRESULT GetInstanceForCurrentProcess(ISetupInstance** ppInstance)
    {
        fixed (ISetupConfiguration* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<ISetupConfiguration*, ISetupInstance**, HRESULT>)_lpVtbl[4])(pThis, ppInstance);
    }

    /// <inheritdoc cref="Interface.GetInstanceForPath(char*, ISetupInstance**)"/>
    public HRESULT GetInstanceForPath(char* path, ISetupInstance** ppInstance)
    {
        fixed (ISetupConfiguration* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<ISetupConfiguration*, char*, ISetupInstance**, HRESULT>)_lpVtbl[5])(pThis, path, ppInstance);
    }

    /// <summary>
    ///  Exposes methods to enumerate and locate Visual Studio instances.
    /// </summary>
    /// <remarks>
    ///  See https://learn.microsoft.com/visualstudio/setup/configuration-interface for detailed information.
    /// </remarks>
    [ComImport]
    [Guid("42843719-DB4C-46C2-8E7C-64F1816EFD5B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Gets an enumerator for all installed instances that are normally discoverable.
        /// </summary>
        [PreserveSig]
        HRESULT EnumInstances(IEnumSetupInstances** ppEnumInstances);

        /// <summary>
        ///  Gets the instance for the calling process, if any.
        /// </summary>
        [PreserveSig]
        HRESULT GetInstanceForCurrentProcess(ISetupInstance** ppInstance);

        /// <summary>
        ///  Gets the instance that has registered installation information for the specified path.
        /// </summary>
        [PreserveSig]
        HRESULT GetInstanceForPath(char* path, ISetupInstance** ppInstance);
    }
}
