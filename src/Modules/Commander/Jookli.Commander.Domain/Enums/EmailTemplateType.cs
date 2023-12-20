using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Domain.Enums
{
    public enum EmailTemplateType
    {
        ConfirmAccount = 0,
        RecoverPassword = 1,
        ResetPassword = 2,
        SendQuestion = 5,
    }
}
