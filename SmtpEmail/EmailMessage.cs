using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmtpEmail
{
    public class EmailMessage
    {
        public string send_to { get; set; }
        public string email_subject { get; set; }
        public string email_body { get; set; }
        public string reply_to { get; set; }
        public bool text_body { get; set; }
        public string send_from { get; set; }

    }
}
