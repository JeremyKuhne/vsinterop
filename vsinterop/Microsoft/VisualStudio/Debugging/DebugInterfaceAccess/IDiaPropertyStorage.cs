// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;
using Windows.Win32.System.Com.StructuredStorage;

// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
using ComIUnknown = Windows.Win32.System.Com.IUnknown;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <inheritdoc cref="Interface"/>
public unsafe struct IDiaPropertyStorage : IComIID
{
    /// <inheritdoc cref="IComIID.Guid"/>
#pragma warning disable IDE1006 // Naming Styles
    public static readonly Guid IID_Guid = new(0x9D416F9C, 0xE184, 0x45B2, 0xA4, 0xF0, 0xCE, 0x51, 0x7F, 0x71, 0x9E, 0x9B);
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
                0x9C, 0x6F, 0x41, 0x9D,
                0x84, 0xE1,
                0xB2, 0x45,
                0xA4, 0xF0, 0xCE, 0x51, 0x7F, 0x71, 0x9E, 0x9B
            ];

            return ref Unsafe.As<byte, Guid>(ref MemoryMarshal.GetReference(data));
        }
    }
#endif

    private readonly void** _lpVtbl;

    /// <inheritdoc cref="ComIUnknown.QueryInterface(Guid*, void**)"/>
    public HRESULT QueryInterface(Guid* riid, void** ppvObject)
    {
        fixed (IDiaPropertyStorage* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaPropertyStorage*, Guid*, void**, HRESULT>)_lpVtbl[0])(pThis, riid, ppvObject);
    }

    /// <inheritdoc cref="ComIUnknown.AddRef"/>
    public uint AddRef()
    {
        fixed (IDiaPropertyStorage* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaPropertyStorage*, uint>)_lpVtbl[1])(pThis);
    }

    /// <inheritdoc cref="ComIUnknown.Release"/>
    public uint Release()
    {
        fixed (IDiaPropertyStorage* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaPropertyStorage*, uint>)_lpVtbl[2])(pThis);
    }

    /// <inheritdoc cref="Interface.ReadMultiple"/>
    public HRESULT ReadMultiple(uint cpspec, PROPSPEC* rgpspec, PROPVARIANT* rgvar)
    {
        fixed (IDiaPropertyStorage* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaPropertyStorage*, uint, PROPSPEC*, PROPVARIANT*, HRESULT>)_lpVtbl[3])(pThis, cpspec, rgpspec, rgvar);
    }

    /// <inheritdoc cref="Interface.ReadPropertyNames"/>
    public HRESULT ReadPropertyNames(uint cpropid, uint* rgpropid, BSTR* rglpwstrName)
    {
        fixed (IDiaPropertyStorage* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaPropertyStorage*, uint, uint*, BSTR*, HRESULT>)_lpVtbl[4])(pThis, cpropid, rgpropid, rglpwstrName);
    }

    /// <inheritdoc cref="Interface.Enum"/>
    public HRESULT Enum(IEnumSTATPROPSTG** ppenum)
    {
        fixed (IDiaPropertyStorage* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaPropertyStorage*, IEnumSTATPROPSTG**, HRESULT>)_lpVtbl[5])(pThis, ppenum);
    }

    /// <inheritdoc cref="Interface.ReadDWORD"/>
    public HRESULT ReadDWORD(uint id, uint* pValue)
    {
        fixed (IDiaPropertyStorage* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaPropertyStorage*, uint, uint*, HRESULT>)_lpVtbl[6])(pThis, id, pValue);
    }

    /// <inheritdoc cref="Interface.ReadLONG"/>
    public HRESULT ReadLONG(uint id, int* pValue)
    {
        fixed (IDiaPropertyStorage* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaPropertyStorage*, uint, int*, HRESULT>)_lpVtbl[7])(pThis, id, pValue);
    }

    /// <inheritdoc cref="Interface.ReadBOOL"/>
    public HRESULT ReadBOOL(uint id, BOOL* pValue)
    {
        fixed (IDiaPropertyStorage* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaPropertyStorage*, uint, BOOL*, HRESULT>)_lpVtbl[8])(pThis, id, pValue);
    }

    /// <inheritdoc cref="Interface.ReadULONGLONG"/>
    public HRESULT ReadULONGLONG(uint id, ulong* pValue)
    {
        fixed (IDiaPropertyStorage* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaPropertyStorage*, uint, ulong*, HRESULT>)_lpVtbl[9])(pThis, id, pValue);
    }

    /// <inheritdoc cref="Interface.ReadBSTR"/>
    public HRESULT ReadBSTR(uint id, BSTR* pValue)
    {
        fixed (IDiaPropertyStorage* pThis = &this)
            return ((delegate* unmanaged[Stdcall]<IDiaPropertyStorage*, uint, BSTR*, HRESULT>)_lpVtbl[10])(pThis, id, pValue);
    }

    /// <summary>
    ///  Provides access to a property set through the standard property browser interface.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/idiapropertystorage">
    ///    Official documentation.
    ///   </see>
    ///  </para>
    /// </remarks>
    [ComImport]
    [Guid("9D416F9C-E184-45B2-A4F0-CE517F719E9B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public unsafe interface Interface
    {
        /// <summary>
        ///  Read multiple.
        /// </summary>
        /// <param name="cpspec">The cpspec value.</param>
        /// <param name="rgpspec">Pointer to a buffer that contains the input data.</param>
        /// <param name="rgvar">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT ReadMultiple(uint cpspec, PROPSPEC* rgpspec, PROPVARIANT* rgvar);

        /// <summary>
        ///  Read property names.
        /// </summary>
        /// <param name="cpropid">The cpropid value.</param>
        /// <param name="rgpropid">Pointer to a buffer that contains the input data.</param>
        /// <param name="rglpwstrName">Pointer to a caller-allocated buffer that receives the data.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT ReadPropertyNames(uint cpropid, uint* rgpropid, BSTR* rglpwstrName);

        /// <summary>
        ///  Enum.
        /// </summary>
        /// <param name="ppenum">Pointer to a variable that receives the cloned enumerator.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT Enum(IEnumSTATPROPSTG** ppenum);

        /// <summary>
        ///  Read dword.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <param name="pValue">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT ReadDWORD(uint id, uint* pValue);

        /// <summary>
        ///  Read long.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <param name="pValue">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT ReadLONG(uint id, int* pValue);

        /// <summary>
        ///  Read bool.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <param name="pValue">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT ReadBOOL(uint id, BOOL* pValue);

        /// <summary>
        ///  Read ulonglong.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <param name="pValue">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT ReadULONGLONG(uint id, ulong* pValue);

        /// <summary>
        ///  Read bstr.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <param name="pValue">Pointer to a variable that receives the requested value.</param>
        /// <returns>Standard <see cref="HRESULT"/> indicating success or failure.</returns>
        [PreserveSig]
        HRESULT ReadBSTR(uint id, BSTR* pValue);
    }
}
