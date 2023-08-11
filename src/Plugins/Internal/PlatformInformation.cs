// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace McMaster.NETCore.Plugins
{
    internal class PlatformInformation
    {
        public static readonly string[] NATIVE_LIBRARY_EXTENSIONS;
        public static readonly string[] NATIVE_LIBRARY_PREFIXES;
        public static readonly string[] MANAGED_ASSEMBLY_EXTENSIONS = new[]
        {
                ".dll",
                ".ni.dll",
                ".exe",
                ".ni.exe"
        };

        static PlatformInformation()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                NATIVE_LIBRARY_PREFIXES = new[] { "" };
                NATIVE_LIBRARY_EXTENSIONS = new[] { ".dll" };
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                NATIVE_LIBRARY_PREFIXES = new[] { "", "lib", };
                NATIVE_LIBRARY_EXTENSIONS = new[] { ".dylib" };
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                NATIVE_LIBRARY_PREFIXES = new[] { "", "lib" };
                NATIVE_LIBRARY_EXTENSIONS = new[] { ".so", ".so.1" };
            }
            else
            {
                Debug.Fail("Unknown OS type");
                NATIVE_LIBRARY_PREFIXES = Array.Empty<string>();
                NATIVE_LIBRARY_EXTENSIONS = Array.Empty<string>();
            }
        }
    }
}
