using System;
using System.IO;
using System.Net;

namespace CookiesTxt
{
    public static class Parser
    {
        public static CookieCollection ParseFileAsCookieCollection(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
                throw new FileNotFoundException("Cookies file not found", fileInfo.FullName);

            var cookies = new CookieCollection();

            using (var fs = fileInfo.OpenRead())
            using (var sr = new StreamReader(fs))
            {
                int lineCount = 0;

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    lineCount++;

                    // Ignore comments
                    if (line[0] == '#')
                        continue;

                    string[] parts = line.Split('\t');
                    if (parts.Length != 7)
                        throw new FormatException($"Line {lineCount} has {parts.Length} columns. Expected 7");

                    // Column 0: Domain
                    string domain = parts[0];

                    // Column 2: Path
                    string path = parts[2];

                    // Column 3: Secure
                    bool secure = parts[3] == "TRUE";

                    // Column 4: Expires
                    DateTime expires = DateTimeOffset.FromUnixTimeSeconds(long.Parse(parts[4])).UtcDateTime;

                    // Column 5: Name
                    string name = parts[5];

                    // Column 6: Value
                    string value = parts[6];

                    var cookie = new Cookie(name, value, path, domain)
                    {
                        Secure = secure,
                        Expires = expires,
                    };

                    cookies.Add(cookie);
                }
            }

            return cookies;
        }
    }
}
