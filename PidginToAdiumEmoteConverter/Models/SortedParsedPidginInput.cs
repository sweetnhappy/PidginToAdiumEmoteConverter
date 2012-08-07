using System;
using System.Collections.Generic;
using System.Linq;

namespace PidginToAdiumEmoteConverter.Models
{
    public class SortedParsedPidginInput
    {
        public SortedList<string, string> Images { get; set; }
        public SortedList<string, string> Names { get; set; }
        public SortedList<string, string[]> Equivalents { get; set; }

        public SortedParsedPidginInput()
        {
            Images = new SortedList<string, string>();
            Names = new SortedList<string, string>();
            Equivalents = new SortedList<string, string[]>();
        }
    }
}