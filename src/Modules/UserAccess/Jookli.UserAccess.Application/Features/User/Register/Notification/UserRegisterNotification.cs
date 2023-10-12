using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.Register.Notification
{
    public class UserRegisterNotification : INotificationHandler<UserRegisterPostNotification>
    {
        public Task Handle(UserRegisterPostNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
