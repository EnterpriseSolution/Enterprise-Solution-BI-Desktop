﻿using System.Linq;

namespace EnterpriseSolutionBIDesktop
{
    public static class MatchingExtention
    {
        public static bool In<T>(this T x, params T[] values)
        {
            return values.Contains(x);
        }
    }
}