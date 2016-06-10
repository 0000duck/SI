using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI.Exceptions
{
    class NoFileException : Exception
    {
        private string _message;
        public override string Message
        {
            get
            {
                return _message + " Exception";
            }
        }

        public NoFileException()
        {
            _message = "No File";
        }

        public NoFileException(string message)
        {
            _message = message;
        }


    }
}
