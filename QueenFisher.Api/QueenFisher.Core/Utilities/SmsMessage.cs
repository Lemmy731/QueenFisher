using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Core.Utilities
{
    public class SmsMessage
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Message { get; set; }

        public SmsMessage(string to, string from, string message)
        {
            To = to;
            From = from;
            Message = message;
        } 
    }
}
