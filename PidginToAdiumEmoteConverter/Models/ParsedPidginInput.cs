using System.Collections.Generic;
using System.Linq;
using System;

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

        public ParsedPidginInput(SortedList<string, string> images,
                                 SortedList<string, string> names,
                                 SortedList<string, string[]> equivalents)
        {
            Images = images.Values.ToList();
            Names = names.Values.ToList();
            Equivalents = equivalents.Values.ToList();
        }
    }
}