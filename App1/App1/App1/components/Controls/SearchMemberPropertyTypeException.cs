using System;
using System.Collections.Generic;
using System.Text;

namespace App1.components.Controls
{
    public class SearchMemberPropertyTypeException : Exception
    {
        public SearchMemberPropertyTypeException()
        {
        }

        public SearchMemberPropertyTypeException(string message) : base(message)
        {
        }

        public SearchMemberPropertyTypeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
