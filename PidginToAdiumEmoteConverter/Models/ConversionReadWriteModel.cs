using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace PidginToAdiumEmoteConverter.Models
{
    public class ConversionReadWriteModel
    {
        public string PidginRawInput { get; set; }
        public ParsedPidginInput ParsedInput { get; set; }
        public string JsonDataToConvert { get; set; }
        public string AdiumOutput { get; set; }

        public static ParsedPidginInput Parse(string pidginRawInput)
        {
            ParsedPidginInput parsedInput = new ParsedPidginInput();

            try
            {
                string[] delimitedLines = pidginRawInput.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in delimitedLines)
                {
                    string lineContent = line;

                    if (line.StartsWith("! "))
                    {
                        lineContent = line.Substring(2);
                    }

                    string[] delimitedItems = lineContent.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    parsedInput.Images.Add(delimitedItems[0]);

                    Regex rgx = new Regex("[^a-zA-Z0-9]");

                    parsedInput.Names.Add(rgx.Replace(delimitedItems[1], ""));

                    string[] equivalents = new string[(delimitedItems.Length - 1)];

                    for (int j = 1; j < delimitedItems.Length; j++)
                    {
                        equivalents[(j - 1)] = delimitedItems[j];
                    }

                    parsedInput.Equivalents.Add(equivalents);
                }
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }

            return parsedInput;
        }

        public static string Generate(ParsedPidginInput customizedPidginInput)
        {
            StringBuilder sb = new StringBuilder();

            

            return sb.ToString();
        }
    }
}