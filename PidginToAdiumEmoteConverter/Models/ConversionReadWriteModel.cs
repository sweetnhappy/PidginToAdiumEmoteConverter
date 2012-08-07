using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PidginToAdiumEmoteConverter.Models
{
    public class ConversionReadWriteModel
    {
        public string PidginRawInput { get; set; }
        public ParsedPidginInput ParsedInput { get; set; }
        public string JsonDataToConvert { get; set; }
        public string AdiumOutput { get; set; }

        public void Parse()
        {
            try
            {
                SortedParsedPidginInput sortedParsedInput = new SortedParsedPidginInput();

                string[] delimitedLines = PidginRawInput.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in delimitedLines)
                {
                    string lineContent = line;

                    if (line.StartsWith("! "))
                    {
                        lineContent = line.Substring(2);
                    }

                    string[] delimitedItems = lineContent.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    Regex rgx = new Regex("[^a-zA-Z0-9]");

                    string name = rgx.Replace(delimitedItems[1], "");

                    sortedParsedInput.Names.Add(name, name);

                    sortedParsedInput.Images.Add(name, delimitedItems[0]);

                    string[] equivalents = new string[(delimitedItems.Length - 1)];

                    for (int j = 1; j < delimitedItems.Length; j++)
                    {
                        equivalents[(j - 1)] = delimitedItems[j];
                    }

                    sortedParsedInput.Equivalents.Add(name, equivalents);
                }

                ParsedInput = new ParsedPidginInput(
                    sortedParsedInput.Images, sortedParsedInput.Names, sortedParsedInput.Equivalents);
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }

        public void Generate(ParsedPidginInput customizedPidginInput)
        {
            SortedParsedPidginInput sortedCustomizedInput = new SortedParsedPidginInput();

            for (int k = 0; k < customizedPidginInput.Names.Count; k++)
            {
                sortedCustomizedInput.Names.Add(customizedPidginInput.Names[k], customizedPidginInput.Names[k]);
                sortedCustomizedInput.Images.Add(customizedPidginInput.Names[k], customizedPidginInput.Images[k]);
                sortedCustomizedInput.Equivalents.Add(customizedPidginInput.Names[k], customizedPidginInput.Equivalents[k]);
            }

            ParsedPidginInput updatedCustomizedPidginInput = new ParsedPidginInput(
                sortedCustomizedInput.Images, sortedCustomizedInput.Names, sortedCustomizedInput.Equivalents);

            StringBuilder sb = new StringBuilder();

            sb.Append("<plist version=\"1.0\">\r\n");
            sb.Append("  <dict>\r\n");
            sb.Append("    <key>AdiumSetVersion</key>\r\n");
            sb.Append("    <integer>1</integer>\r\n");
            sb.Append("    <key>Emoticons</key>\r\n");
            sb.Append("    <dict>\r\n");

            string[] images = updatedCustomizedPidginInput.Images.ToArray();
            string[] names = updatedCustomizedPidginInput.Names.ToArray();
            string[][] equivalents = updatedCustomizedPidginInput.Equivalents.ToArray();

            for (int i = 0; i < images.Length; i++)
            {
                sb.Append("      <key>" + images[i] + "</key>\r\n");
                sb.Append("      <dict>\r\n");
                sb.Append("        <key>Equivalents</key>\r\n");
                sb.Append("        <array>\r\n");

                for (int j = 0; j < equivalents[i].Length; j++)
                {
                    sb.Append("          <string>" + equivalents[i][j] + "</string>\r\n");
                }

                sb.Append("        </array>\r\n");
                sb.Append("        <key>Name</key>\r\n");
                sb.Append("        <string>" + names[i] + "</string>\r\n");
                sb.Append("      </dict>\r\n");
            }

            sb.Append("    </dict>\r\n");
            sb.Append("  </dict>\r\n");
            sb.Append("</plist>");

            AdiumOutput = sb.ToString();
        }
    }
}