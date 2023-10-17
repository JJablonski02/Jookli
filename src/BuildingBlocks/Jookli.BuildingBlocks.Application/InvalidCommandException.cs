﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Application
{
    public class InvalidCommandException : Exception
    {
        public List<string> Errors { get; }

        public InvalidCommandException(List<string> errors)
        {
            this.Errors = errors;
        }
    }
}
