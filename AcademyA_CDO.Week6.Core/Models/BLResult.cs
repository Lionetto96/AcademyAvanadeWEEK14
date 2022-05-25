using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyA_CDO.Week6.Core.Models
{
    public class BLResult
    {
        public BLResult(bool success, string message) : this(success, message, null) { }

        public BLResult(bool success, string message, Exception ex)
        {
            this.Success = success;
            this.Message = message;
            this.InnerException = ex;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception InnerException { get; set; }
    }
}
