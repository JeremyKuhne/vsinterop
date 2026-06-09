// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.LibraryLoader;

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <summary>
///  Loads the architecture-appropriate <c>msdia140.dll</c> (supplied by the
///  Microsoft.Diagnostics.Tracing.TraceEvent.SupportFiles package) and creates DIA class factories from it.
/// </summary>
internal static class Msdia
{
    /// <summary>
    ///  The full path to the <c>msdia140.dll</c> that matches the current process architecture.
    /// </summary>
    internal static string LibraryPath { get; } = Path.Combine(
        AppContext.BaseDirectory,
        "Dia",
        RuntimeInformation.ProcessArchitecture switch
        {
            Architecture.X64 => "amd64",
            Architecture.X86 => "x86",
            Architecture.Arm64 => "arm64",
            _ => throw new PlatformNotSupportedException(
                $"msdia140.dll is not available for {RuntimeInformation.ProcessArchitecture}.")
        },
        "msdia140.dll");

    // msdia140.dll has a static dependency on the Visual C++ runtime (msvcp140.dll, vcruntime140*.dll), which
    // the package places next to it. Loading with LOAD_WITH_ALTERED_SEARCH_PATH makes Windows resolve those
    // dependencies from the DLL's own directory rather than the application directory.
    private static readonly Lazy<HMODULE> s_module = new(static () =>
        HMODULE.LoadModule(LibraryPath, LOAD_LIBRARY_FLAGS.LOAD_WITH_ALTERED_SEARCH_PATH));

    /// <summary>
    ///  Creates a <see cref="ComClassFactory"/> for the given DIA class, loading <c>msdia140.dll</c> on first use.
    /// </summary>
    /// <param name="classId">The CLSID of the DIA coclass, for example <see cref="CLASSID.DiaSource"/>.</param>
    internal static ComClassFactory CreateFactory(Guid classId) => new(s_module.Value, classId);
}
