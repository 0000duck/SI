using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI.Exceptions
{
    class NoFieldsException : Exception
    {
        private string _message;
        public override string Message
        {
            get
            {
                return _message + " Exception";
            }
        }

        public NoFieldsException()
        {
            _message = "No fields";
        }

        public NoFieldsException(string message)
        {
            _message = message;
        }


    }
}
