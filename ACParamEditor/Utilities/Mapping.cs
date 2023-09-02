namespace Utilities
{
    public static class Mapping
    {
        public static Dictionary<string, string> ParseMapping(IEnumerable<string> lines, char separator = '=', string comment = "//")
        {
            var mappings = new Dictionary<string, string>();
            if (comment == separator.ToString())
            {
                throw new ArgumentException($"{nameof(comment)} cannot be the same as the {nameof(separator)} for each mapping.", nameof(comment));
            }

            foreach (var line in lines)
            {
                string validated = line;
                if (validated.Contains(comment))
                {
                    int index = validated.IndexOf(comment);
                    validated = validated.Substring(index, index > 0 ? index - 1 : 0);
                }

                validated = validated.Trim();

                if (validated.Contains(separator))
                {
                    string[] strs = validated.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    mappings.Add(strs[0].Trim(), strs[1].Trim());
                }
            }

            return mappings;
        }
    }
}
