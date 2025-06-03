﻿// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

namespace Windows.Win32.Foundation;

/// <summary>
///  Represents a COM BSTR string pointer.
/// </summary>
public readonly unsafe partial struct BSTR : IDisposable, ISpanFormattable
{
    /// <summary>
    ///  Initializes a new instance of the <see cref="BSTR"/> struct from a managed string.
    /// </summary>
    /// <param name="value">The managed string to convert to a BSTR.</param>
    public BSTR(string value) : this((char*)Marshal.StringToBSTR(value))
    {
    }

    /// <summary>
    ///  Frees the memory allocated for the <see cref="BSTR"/>.
    /// </summary>
    public void Dispose()
    {
        Marshal.FreeBSTR((nint)Value);
        Unsafe.AsRef(in this) = default;
    }

    /// <summary>
    ///  Converts the <see cref="BSTR"/> to a managed string and frees the underlying memory.
    /// </summary>
    /// <returns>A managed string representation of the <see cref="BSTR"/>.</returns>
    public string ToStringAndFree()
    {
        string result = ToString();
        Dispose();
        return result;
    }

    /// <inheritdoc cref="ISpanFormattable.TryFormat(Span{char}, out int, ReadOnlySpan{char}, IFormatProvider?)"/>
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        int length = Length;
        if (length > destination.Length)
        {
            charsWritten = 0;
            return false;
        }

        AsSpan().CopyTo(destination);
        charsWritten = length;
        return true;
    }

    /// <inheritdoc cref="IFormattable.ToString(string?, IFormatProvider?)"/>
    public string ToString(string? format, IFormatProvider? formatProvider) => ToString();

    /// <summary>
    ///  Gets a value indicating whether the <see cref="BSTR"/> pointer is <see langword="null"/>.
    /// </summary>
    /// <value>
    ///  <see langword="true"/> if the <see cref="BSTR"/> pointer is null; otherwise, <see langword="false"/>.
    /// </value>
    public bool IsNull => Value is null;
}
