using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyManager
{
   public class CopyItems
    {
        List<CopyItem> items;
        public DateTime CopiedDate { set; get; } = DateTime.MinValue;
        public CopyItems()
        {
            items = new List<CopyItem>();
        }
        public void add(CopyItem ci)
        {
            items.Add(ci);
        }
        public CopyItem get(int i)
        {
            return items[i];
        }
        public void removeAt(int i)
        {
            items.RemoveAt(i);
        }
        public void remove(CopyItem ci)
        {
            items.Remove(ci);
        }
        public void remove(string path)
        {
            CopyItem ci = null;
            foreach(CopyItem c in items)
            {
                if (path == c.Path)
                    ci = c;
            }
            items.Remove(ci);
        }
        public int count()
        {
            return items.Count;
        }
        public string[] getItemsArray(){
            string[] files = new string[items.Count];
            for(int i = 0; i < items.Count; i++)
            {
                files[i] = items[i].Path;
            }

            return files;
        }
         public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType())
                return false;
           
            CopyItems cis = (CopyItems)obj;
            if (cis.count() != count())
                return false;
            foreach(CopyItem ci in cis.items)
            {
                if (!items.Contains(ci))
                    return false;
            }
                
            return true;
        }

    }
}
