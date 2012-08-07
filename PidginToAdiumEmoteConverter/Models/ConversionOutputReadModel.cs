using System;
using System.IO;
using System.Linq;
using System.Text;

namespace PidginToAdiumEmoteConverter.Models
{
    public class ConversionOutputReadModel
    {
        /*public string AdiumOutput { get; set; }

        public ConversionOutputReadModel(ConversionInputReadModel input)
        {
            AdiumOutput = Convert(input);
        }

        public string Convert(ConversionInputReadModel input)
        {
            StringBuilder sb = new StringBuilder();

            string[] delimitedLines = input.PidginInput.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            sb.Append("<plist version=\"1.0\">\r\n");
            sb.Append("  <dict>\r\n");
            sb.Append("    <key>AdiumSetVersion</key>\r\n");
            sb.Append("    <integer>1</integer>\r\n");
            sb.Append("    <key>Emoticons</key>\r\n");
            sb.Append("    <dict>\r\n");
            
            foreach (string line in delimitedLines)
            {
                string lineContent = line;

                if (line.StartsWith("! "))
                {
                    lineContent = line.Substring(2);
                }

                string[] delimitedItems = lineContent.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                sb.Append("      <key>" + delimitedItems[0] + "</key>\r\n");
                sb.Append("        <dict>\r\n");
                sb.Append("        <key>Equivalents</key>\r\n");
                sb.Append("        <array>\r\n");

                for (int j = 1; j < delimitedItems.Length; j++)
                {
                    sb.Append("          <string>" + delimitedItems[j] + "</string>\r\n");
                }

                sb.Append("        </array>\r\n");
                sb.Append("        <key>Name</key>\r\n");
                sb.Append("        <string>" + Path.GetFileNameWithoutExtension(delimitedItems[0]) + "</string>\r\n");
                sb.Append("      </dict>\r\n");
            }

            sb.Append("    </dict>\r\n");
            sb.Append("  </dict>\r\n");
            sb.Append("</plist>");

            return sb.ToString();
        }*/
    }
}