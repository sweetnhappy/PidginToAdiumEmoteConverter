using System;
using System.Collections.Generic;
using System.Linq;

namespace PidginToAdiumEmoteConverter.Models
{
    public class ParsedPidginInput
    {
        public List<string> Images { get; set; }
        public List<string> Names { get; set; }
        public List<string[]> Equivalents { get; set; }

        public ParsedPidginInput()
        {
            Images = Enumerable.Empty<string>().ToList();
            Names = Enumerable.Empty<string>().ToList();
            Equivalents = Enumerable.Empty<string[]>().ToList();
        }
    }
}