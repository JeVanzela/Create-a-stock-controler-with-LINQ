using System;

namespace Exceptions {
    class FormException : ApplicationException{
        public FormException(String mensage) : base(mensage) { }
    }
}
