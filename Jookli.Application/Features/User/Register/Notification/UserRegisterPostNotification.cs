using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Application.Features.User.Register.Notification
{
    public class UserRegisterPostNotification : INotification
    {
        public string WhatToWrite { get; set; }
    }
}
