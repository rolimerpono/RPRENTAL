using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Email
    {
        public string SenderName { get; set; }
        public string SenderMail { get; set; }

        public string RecieverName { get; set; }

        public string RecieverEmail { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
