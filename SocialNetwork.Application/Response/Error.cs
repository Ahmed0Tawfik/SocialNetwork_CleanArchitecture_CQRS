using SocialNetwork.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Response
{
    public class Error
    {
        public string Message { get; set; }
        public ErrorCode Code { get; set; }
    }
}
