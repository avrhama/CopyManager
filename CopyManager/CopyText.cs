using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyManager
{
    public class CopyText
    {
        public string Text { set; get; }
        string preview;
        public CopyText(string text)
        {
            Text = text;
            preview = text.Substring(0,Math.Min(16,text.Length));
        }
        public override string ToString()
        {
            return preview;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            return this.Text == ((CopyText)obj).Text;
        }
    }
}
