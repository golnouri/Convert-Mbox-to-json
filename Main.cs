using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using System.Collections.Generic;

namespace mBoxProject
{
    internal class Main
    {
        public List<string> ExtractEmailAddresses()
        {
            var emailAddresses = new List<string>();
            string mboxFilePath = @"C:\mail.mbox";

            using (var stream = File.OpenRead(mboxFilePath))
            {
                var parser = new MimeParser(stream, MimeFormat.Mbox);

                while (!parser.IsEndOfStream)
                {
                    var message = parser.ParseMessage();
                    emailAddresses.Add(message.From.Mailboxes.First().Address);
                }
            }

            return emailAddresses;
        }
    }
}
