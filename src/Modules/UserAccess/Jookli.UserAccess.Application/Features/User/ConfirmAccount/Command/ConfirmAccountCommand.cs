﻿using Jookli.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.ConfirmAccount.Command
{
    public class ConfirmAccountCommand : CommandBase
    {
        public string TokenValue { get; set; }
    }
}
