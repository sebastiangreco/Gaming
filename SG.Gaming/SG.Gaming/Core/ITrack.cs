﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SG.Gaming
{
    public interface ITrack
    {
        void LogError(Exception ex, string tag = "");
        void LogError(string message, string tag = "");
        void LogTrace(string message, string tag = "");
        void LogWarning(string message, string tag = "");
    }
}
