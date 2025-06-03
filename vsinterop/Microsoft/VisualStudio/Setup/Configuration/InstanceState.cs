// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information


// For some reason the XML comment refs for IUnknown can't be resolved on .NET Framework without
// explicitly using the fully qualified name, which falls afoul of the simplify warning.
namespace Microsoft.VisualStudio.Setup.Configuration;

/// <summary>
///  The state of an instance.
/// </summary>
public enum InstanceState : uint
{
    /// <summary>
    ///  The instance state has not been determined.
    /// </summary>
    None = 0,

    /// <summary>
    ///  The instance installation path exists.
    /// </summary>
    Local = 1,

    /// <summary>
    ///  A product is registered to the instance.
    /// </summary>
    Registered = 2,

    /// <summary>
    ///  No reboot is required for the instance.
    /// </summary>
    NoRebootRequired = 4,

    /// <summary>
    ///  No errors were reported for the instance.
    /// </summary>
    NoErrors = 8,

    /// <summary>
    ///  The instance represents a complete install.
    /// </summary>
    Complete = uint.MaxValue
}
