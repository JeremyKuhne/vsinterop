// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <summary>
///  Identifies the processor (CPU) type.
/// </summary>
/// <remarks>
///  <para>
///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/cv-cpu-type-e">
///    Official documentation.
///   </see>
///  </para>
/// </remarks>
public enum CV_CPU_TYPE_e
{
    /// <summary>Intel 8080.</summary>
    CV_CFL_8080 = 0x00,

    /// <summary>Intel 8086.</summary>
    CV_CFL_8086 = 0x01,

    /// <summary>Intel 80286.</summary>
    CV_CFL_80286 = 0x02,

    /// <summary>Intel 80386.</summary>
    CV_CFL_80386 = 0x03,

    /// <summary>Intel 80486.</summary>
    CV_CFL_80486 = 0x04,

    /// <summary>Intel Pentium.</summary>
    CV_CFL_PENTIUM = 0x05,

    /// <summary>Intel Pentium II.</summary>
    CV_CFL_PENTIUMII = 0x06,

    /// <summary>Intel Pentium Pro.</summary>
    CV_CFL_PENTIUMPRO = CV_CFL_PENTIUMII,

    /// <summary>Intel Pentium III.</summary>
    CV_CFL_PENTIUMIII = 0x07,

    /// <summary>MIPS.</summary>
    CV_CFL_MIPS = 0x10,

    /// <summary>MIPS R4000.</summary>
    CV_CFL_MIPSR4000 = CV_CFL_MIPS,

    /// <summary>MIPS16.</summary>
    CV_CFL_MIPS16 = 0x11,

    /// <summary>MIPS32.</summary>
    CV_CFL_MIPS32 = 0x12,

    /// <summary>MIPS64.</summary>
    CV_CFL_MIPS64 = 0x13,

    /// <summary>MIPS I.</summary>
    CV_CFL_MIPSI = 0x14,

    /// <summary>MIPS II.</summary>
    CV_CFL_MIPSII = 0x15,

    /// <summary>MIPS III.</summary>
    CV_CFL_MIPSIII = 0x16,

    /// <summary>MIPS IV.</summary>
    CV_CFL_MIPSIV = 0x17,

    /// <summary>MIPS V.</summary>
    CV_CFL_MIPSV = 0x18,

    /// <summary>Motorola 68000.</summary>
    CV_CFL_M68000 = 0x20,

    /// <summary>Motorola 68010.</summary>
    CV_CFL_M68010 = 0x21,

    /// <summary>Motorola 68020.</summary>
    CV_CFL_M68020 = 0x22,

    /// <summary>Motorola 68030.</summary>
    CV_CFL_M68030 = 0x23,

    /// <summary>Motorola 68040.</summary>
    CV_CFL_M68040 = 0x24,

    /// <summary>DEC Alpha.</summary>
    CV_CFL_ALPHA = 0x30,

    /// <summary>DEC Alpha 21064.</summary>
    CV_CFL_ALPHA_21064 = 0x30,

    /// <summary>DEC Alpha 21164.</summary>
    CV_CFL_ALPHA_21164 = 0x31,

    /// <summary>DEC Alpha 21164A.</summary>
    CV_CFL_ALPHA_21164A = 0x32,

    /// <summary>DEC Alpha 21264.</summary>
    CV_CFL_ALPHA_21264 = 0x33,

    /// <summary>DEC Alpha 21364.</summary>
    CV_CFL_ALPHA_21364 = 0x34,

    /// <summary>PowerPC 601.</summary>
    CV_CFL_PPC601 = 0x40,

    /// <summary>PowerPC 603.</summary>
    CV_CFL_PPC603 = 0x41,

    /// <summary>PowerPC 604.</summary>
    CV_CFL_PPC604 = 0x42,

    /// <summary>PowerPC 620.</summary>
    CV_CFL_PPC620 = 0x43,

    /// <summary>PowerPC with floating point.</summary>
    CV_CFL_PPCFP = 0x44,

    /// <summary>PowerPC big-endian.</summary>
    CV_CFL_PPCBE = 0x45,

    /// <summary>Hitachi SH3.</summary>
    CV_CFL_SH3 = 0x50,

    /// <summary>Hitachi SH3E.</summary>
    CV_CFL_SH3E = 0x51,

    /// <summary>Hitachi SH3 DSP.</summary>
    CV_CFL_SH3DSP = 0x52,

    /// <summary>Hitachi SH4.</summary>
    CV_CFL_SH4 = 0x53,

    /// <summary>Hitachi SH media.</summary>
    CV_CFL_SHMEDIA = 0x54,

    /// <summary>ARM 3.</summary>
    CV_CFL_ARM3 = 0x60,

    /// <summary>ARM 4.</summary>
    CV_CFL_ARM4 = 0x61,

    /// <summary>ARM 4T.</summary>
    CV_CFL_ARM4T = 0x62,

    /// <summary>ARM 5.</summary>
    CV_CFL_ARM5 = 0x63,

    /// <summary>ARM 5T.</summary>
    CV_CFL_ARM5T = 0x64,

    /// <summary>ARM 6.</summary>
    CV_CFL_ARM6 = 0x65,

    /// <summary>ARM XMAC.</summary>
    CV_CFL_ARM_XMAC = 0x66,

    /// <summary>ARM WMMX.</summary>
    CV_CFL_ARM_WMMX = 0x67,

    /// <summary>ARM 7.</summary>
    CV_CFL_ARM7 = 0x68,

    /// <summary>Omni.</summary>
    CV_CFL_OMNI = 0x70,

    /// <summary>Intel IA64.</summary>
    CV_CFL_IA64 = 0x80,

    /// <summary>Intel IA64 (variant 1).</summary>
    CV_CFL_IA64_1 = 0x80,

    /// <summary>Intel IA64 (variant 2).</summary>
    CV_CFL_IA64_2 = 0x81,

    /// <summary>Common Language Runtime (managed).</summary>
    CV_CFL_CEE = 0x90,

    /// <summary>Matsushita AM33.</summary>
    CV_CFL_AM33 = 0xA0,

    /// <summary>Mitsubishi M32R.</summary>
    CV_CFL_M32R = 0xB0,

    /// <summary>Infineon TriCore.</summary>
    CV_CFL_TRICORE = 0xC0,

    /// <summary>x64 (AMD64 / Intel 64).</summary>
    CV_CFL_X64 = 0xD0,

    /// <summary>AMD64.</summary>
    CV_CFL_AMD64 = CV_CFL_X64,

    /// <summary>EFI byte code.</summary>
    CV_CFL_EBC = 0xE0,

    /// <summary>ARM Thumb.</summary>
    CV_CFL_THUMB = 0xF0,

    /// <summary>ARM (NT).</summary>
    CV_CFL_ARMNT = 0xF4,

    /// <summary>ARM64.</summary>
    CV_CFL_ARM64 = 0xF6,

    /// <summary>Hybrid x86 on ARM64.</summary>
    CV_CFL_HYBRID_X86_ARM64 = 0xF7,

    /// <summary>ARM64EC.</summary>
    CV_CFL_ARM64EC = 0xF8,

    /// <summary>ARM64X.</summary>
    CV_CFL_ARM64X = 0xF9,

    /// <summary>Unknown processor type.</summary>
    CV_CFL_UNKNOWN = 0xFF,

    /// <summary>Direct3D 11 shader.</summary>
    CV_CFL_D3D11_SHADER = 0x100
}
