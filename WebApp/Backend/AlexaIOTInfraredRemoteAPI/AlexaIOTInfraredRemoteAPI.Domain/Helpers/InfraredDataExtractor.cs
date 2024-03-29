﻿using System.Text.RegularExpressions;

namespace AlexaIOTInfraredRemoteAPI.Domain.Helpers
{
    public class InfraredDataExtractor
    {
        public static ushort[] ExtractRawData(string data)
        {
            var match = Regex.Match(data, @"\{([^}]*)\}");
            if (!match.Success)
            {
                throw new ArgumentException("Invalid infrared data format.");
            }

            var rawDataString = match.Groups[1].Value;

            var rawData = rawDataString.Split(',')
                                       .Select(s => ushort.Parse(s.Trim()))
                                       .ToArray();

            return rawData;
        }
    }
}
