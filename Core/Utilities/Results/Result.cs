﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message) : this(success)
        {
            Message = message;
            //Get - ReadOnly'dir constructor içerisinde set edilebilir               
        }
        public Result(bool success)
        {
            Success = success;
            //mesaj vermek istemediğimiz zaman
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
