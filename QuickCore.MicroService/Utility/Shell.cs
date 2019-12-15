﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace QuickCore.MicroService.Utility
{
    public static class Shell
    {
        public static int Exec(string fileName, string arguments, bool throwIfExitCodeNotZero = true)
        {
            var process =Process.Start(new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
            });
            process.WaitForExit();
            if (process.ExitCode != 0 && throwIfExitCodeNotZero)
            {
                throw new Exception($"Exec process return {process.ExitCode}.");
            }
            return process.ExitCode;
        }
    }
}
