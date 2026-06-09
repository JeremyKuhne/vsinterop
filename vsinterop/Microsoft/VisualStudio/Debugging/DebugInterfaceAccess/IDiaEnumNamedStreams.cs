// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaEnumNamedStreams : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x2B01F5E0, 0x98DB, 0x4824, 0xA9, 0xA0, 0x51, 0x92, 0x83, 0x3B, 0xEF, 0x47);
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
                0xE0, 0xF5, 0x01, 0x2B,
                0xDB, 0x98,
                0x24, 0x48,
                0xA9, 0xA0, 0x51, 0x92, 0x83, 0x3B, 0xEF, 0x47
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaEnumNamedStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumNamedStreams*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaEnumNamedStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumNamedStreams*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaEnumNamedStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumNamedStreams*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.get__NewEnum"/>
    public HRESULT get__NewEnum(IUnknown** pRetVal)
    {
        fixed (IDiaEnumNamedStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumNamedStreams*, IUnknown**, HRESULT>)_lpVtbl[3])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.get_Count"/>
    public HRESULT get_Count(int* pRetVal)
    {
        fixed (IDiaEnumNamedStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumNamedStreams*, int*, HRESULT>)_lpVtbl[4])(pThis, pRetVal);
    }

    /// <inheritdoc cref="Interface.Next"/>
    public HRESULT Next(BSTR* pName)
    {
        fixed (IDiaEnumNamedStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumNamedStreams*, BSTR*, HRESULT>)_lpVtbl[5])(pThis, pName);
    }

    /// <inheritdoc cref="Interface.Skip"/>
    public HRESULT Skip(uint celt)
    {
        fixed (IDiaEnumNamedStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumNamedStreams*, uint, HRESULT>)_lpVtbl[6])(pThis, celt);
    }

    /// <inheritdoc cref="Interface.Reset"/>
    public HRESULT Reset()
    {
        fixed (IDiaEnumNamedStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumNamedStreams*, HRESULT>)_lpVtbl[7])(pThis);
    }

    /// <inheritdoc cref="Interface.Clone"/>
    public HRESULT Clone(IDiaEnumNamedStreams** ppenum)
    {
        fixed (IDiaEnumNamedStreams* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaEnumNamedStreams*, IDiaEnumNamedStreams**, HRESULT>)_lpVtbl[8])(pThis, ppenum);
    }

    /// <summary>
    ///  Enumerates the various named streams contained in the data source.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiaenumnamedstreams">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("2B01F5E0-98DB-4824-A9A0-5192833BEF47")]
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
        ///  Number of named streams.
        /// </summary>
        /// <param name="pRetVal">Pointer to a variable that receives the value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT get_Count(int* pRetVal);

        /// <summary>
        ///  Retrieves the next item or items in the enumeration sequence.
        /// </summary>
        /// <param name="pName">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Next(BSTR* pName);

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
        HRESULT Clone(IDiaEnumNamedStreams** ppenum);
    }
}
