
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace ShopingCart.Application.Core.Models
{
    public class MailAttachment
    {
        private Stream _stream;
        private string _filename;
        private string _mediatype;

        public Stream Data => _stream;
        public string FileName => _filename;
        public string MediaType => _mediatype;
        public Attachment File => new Attachment(Data, FileName, MediaType);

        public MailAttachment(byte[] data , string filename)
        {
            _stream = new MemoryStream(data);
            _filename = filename;
            _mediatype = MediaTypeNames.Application.Octet;
        }
        public MailAttachment(string data, string filename)
        {
            _stream =  new MemoryStream(Encoding.ASCII.GetBytes(data));
            _filename = filename;
            _mediatype = MediaTypeNames.Text.Html;
        }
        public MailAttachment(Stream data, string filename)
        {
            _stream =data;
            _filename = filename;
            _mediatype = MediaTypeNames.Text.Html;
        }

    }
}
