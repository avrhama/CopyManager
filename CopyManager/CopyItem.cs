using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyManager
{
    //represents single copied item.
    public class CopyItem
    {
        public string Path { set; get; }
       public string Name { set; get; }
        bool Exists { set; get; }
       public bool isFile;
        
        DateTime copyiedDate=DateTime.MinValue;
        public CopyItem(string path,string name, bool isFile = true,bool exists=true)
        {
            this.Path = path;
            Name = name;
            Exists = exists;
            this.isFile = isFile;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            return this.Path == ((CopyItem)obj).Path;
        }

    }
}
