// Copyright (c) 2025 Jeremy W Kuhne
// SPDX-License-Identifier: MIT
// See LICENSE file in the project root for full license information

#pragma warning disable IDE0005 // Using directive is unnecessary.
global using System;
global using System.Collections.Generic;
global using System.Diagnostics;
global using System.Diagnostics.CodeAnalysis;
global using System.Runtime.CompilerServices;

global using Windows.Win32;
global using Windows.Win32.Foundation;
global using Windows.Win32.System.Com;

#if NETFRAMEWORK
global using Microsoft.IO;
global using Microsoft.IO.Enumeration;
#else
global using System.IO;
global using System.IO.Enumeration;
#endif

global using IOException = System.IO.IOException;
global using FileNotFoundException = System.IO.FileNotFoundException;
global using DirectoryNotFoundException = System.IO.DirectoryNotFoundException;
global using PathTooLongException = System.IO.PathTooLongException;
global using DriveNotFoundException = System.IO.DriveNotFoundException;

// This isn't defined in Microsoft.IO to facilitate value exchange.
global using FileAttributes = System.IO.FileAttributes;
#pragma warning restore IDE0005 // Using directive is unnecessary.

global using Marshal = System.Runtime.InteropServices.Marshal;
