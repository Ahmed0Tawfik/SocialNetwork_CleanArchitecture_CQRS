using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Enums
{
    public enum ErrorCode
    {

       ValidationFailed = 400,
       NotFound = 404,
       Conflict = 409,
       ServerError = 500,
       InvalidData = 422

    }
}
