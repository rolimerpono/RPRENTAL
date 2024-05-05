using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Email
    {

        [MaxLength(50)]
        public string SenderName { get; set; }

        [DataType(DataType.EmailAddress,ErrorMessage = "The email you entered was invalid.")]
        public string SenderMail { get; set; }

        [MaxLength(50)]
        public string RecieverName { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "The email you entered was invalid.")]
        public string RecieverEmail { get; set; }

        [MaxLength(200)]
        public string Subject { get; set; }
    
        public string HtmlContent { get; set; }

        public string TextContent { get; set; }
    }
}
