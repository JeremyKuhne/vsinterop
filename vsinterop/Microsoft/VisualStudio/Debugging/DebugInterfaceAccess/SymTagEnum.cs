// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

namespace Microsoft.VisualStudio.Debugging.DebugInterfaceAccess;

/// <summary>
///  Identifies the kind of a symbol (its tag).
/// </summary>
/// <remarks>
///  <para>
///   <see href="https://learn.microsoft.com/visualstudio/debugger/debug-interface-access/symtagenum">
///    Official documentation.
///   </see>
///  </para>
/// </remarks>
public enum SymTagEnum
{
    /// <summary>No symbol.</summary>
    SymTagNull,

    /// <summary>An executable (.exe or .dll) file.</summary>
    SymTagExe,

    /// <summary>A compiland (the result of compiling a single source file).</summary>
    SymTagCompiland,

    /// <summary>Details about a compiland.</summary>
    SymTagCompilandDetails,

    /// <summary>The environment of a compiland.</summary>
    SymTagCompilandEnv,

    /// <summary>A function.</summary>
    SymTagFunction,

    /// <summary>A lexical block of code.</summary>
    SymTagBlock,

    /// <summary>Data.</summary>
    SymTagData,

    /// <summary>An annotation.</summary>
    SymTagAnnotation,

    /// <summary>A label.</summary>
    SymTagLabel,

    /// <summary>A public symbol.</summary>
    SymTagPublicSymbol,

    /// <summary>A user-defined type (UDT).</summary>
    SymTagUDT,

    /// <summary>An enumeration.</summary>
    SymTagEnum,

    /// <summary>A function signature type.</summary>
    SymTagFunctionType,

    /// <summary>A pointer type.</summary>
    SymTagPointerType,

    /// <summary>An array type.</summary>
    SymTagArrayType,

    /// <summary>A base (intrinsic) type.</summary>
    SymTagBaseType,

    /// <summary>A typedef.</summary>
    SymTagTypedef,

    /// <summary>A base class.</summary>
    SymTagBaseClass,

    /// <summary>A friend.</summary>
    SymTagFriend,

    /// <summary>A function argument type.</summary>
    SymTagFunctionArgType,

    /// <summary>The start of a function's debug range.</summary>
    SymTagFuncDebugStart,

    /// <summary>The end of a function's debug range.</summary>
    SymTagFuncDebugEnd,

    /// <summary>A namespace introduced by a using directive.</summary>
    SymTagUsingNamespace,

    /// <summary>The shape of a virtual table.</summary>
    SymTagVTableShape,

    /// <summary>A virtual table.</summary>
    SymTagVTable,

    /// <summary>A custom symbol.</summary>
    SymTagCustom,

    /// <summary>A thunk.</summary>
    SymTagThunk,

    /// <summary>A custom type.</summary>
    SymTagCustomType,

    /// <summary>A managed type.</summary>
    SymTagManagedType,

    /// <summary>A FORTRAN multi-dimensional array dimension.</summary>
    SymTagDimension,

    /// <summary>A call site.</summary>
    SymTagCallSite,

    /// <summary>An inline site.</summary>
    SymTagInlineSite,

    /// <summary>A base interface.</summary>
    SymTagBaseInterface,

    /// <summary>A vector type.</summary>
    SymTagVectorType,

    /// <summary>A matrix type.</summary>
    SymTagMatrixType,

    /// <summary>An HLSL type.</summary>
    SymTagHLSLType,

    /// <summary>A caller.</summary>
    SymTagCaller,

    /// <summary>A callee.</summary>
    SymTagCallee,

    /// <summary>An export.</summary>
    SymTagExport,

    /// <summary>A heap allocation site.</summary>
    SymTagHeapAllocationSite,

    /// <summary>A COFF group.</summary>
    SymTagCoffGroup,

    /// <summary>An inlinee.</summary>
    SymTagInlinee,

    /// <summary>A case of a tagged union UDT type.</summary>
    SymTagTaggedUnionCase,

    /// <summary>The number of valid symbol tags.</summary>
    SymTagMax
}
