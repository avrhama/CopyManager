using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyManager
{
    public partial class Form1 : Form
    {
        bool registerToCopyEvent = true;
        public Form1()
        {
            InitializeComponent();
            config();
            //test();

            if (registerToCopyEvent)
                _ClipboardViewerNext = SetClipboardViewer(this.Handle);

        }
        public void config()
        {
            copyItemsList = new List<CopyItems>();
            //add scrollbar to panel.
            copyItemsflwLytPnl.AutoScroll = true;

            listView1.MouseUp += ListView1_MouseUp;
            listView1.ItemDrag += ListView1_ItemDrag;

            listView1.SmallImageList = imageList1;
            listView1.View = View.SmallIcon;

        }
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(
            IntPtr hWndRemove,  // handle to window to remove
            IntPtr hWndNewNext  // handle to next window
            );
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        public delegate int WindowProcDelegate(IntPtr hw, IntPtr uMsg, IntPtr wParam, IntPtr lParam);
        IntPtr _ClipboardViewerNext;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (registerToCopyEvent)
                ChangeClipboardChain(this.Handle, _ClipboardViewerNext);
        }
        public void writeLog(string msg)
        {
            richTextBox1.Invoke(new Action(() =>
            {
                richTextBox1.AppendText($"{msg}\n");
            }));
        }
       
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0300:

                    writeLog("Cut");
                    SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
                    break;
                case 0x0301:
                    SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
                    writeLog("Copy");
                    break;
                case 0x0308:
                   
                    writeLog(Clipboard.ContainsFileDropList().ToString());
                    getData();
                    SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
                    break;
                case 0x030D:
                    if (m.WParam == _ClipboardViewerNext)
                    {
                        //
                        // If wParam is the next clipboard viewer then it
                        // is being removed so update pointer to the next
                        // window in the clipboard chain
                        //
                        _ClipboardViewerNext = m.LParam;
                    }
                    else
                    {
                        SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void test()
        {
           
          
        }

        private void ListView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            grabItems = listView1.SelectedItems.Count > 0;
            ListViewItem[] items = listView1.SelectedItems.Cast<ListViewItem>().ToArray();

            string[] files = new string[items.Length];
            for (int i = 0; i < items.Length; i++)
                files[i] = items[i].Name;
            this.DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy);
            /*if (grabItems)
				Form1_MouseDown(null, null);*/
        }

      
        private void ListView1_MouseUp(object sender, MouseEventArgs e)
        {
            grabItems = false;
        }

      

      
        bool grabItems = false;
       
        List<CopyItems> copyItemsList;
        public void getData()
        {
            if (Clipboard.ContainsFileDropList())
            {
                //copy items collection.
                CopyItems cis = new CopyItems();
                cis.CopiedDate = DateTime.Now;

                List<string> paths = Clipboard.GetFileDropList().Cast<string>().ToList();
                foreach (string path in paths)
                {
                    System.IO.FileAttributes attr = System.IO.File.GetAttributes(path);
                    CopyItem ci;
                    //detect whether its a directory or file
                    if ((attr & System.IO.FileAttributes.Directory) == System.IO.FileAttributes.Directory)
                    {
                        writeLog(path);
                        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);
                        ci = new CopyItem(path, di.Name,false);

                    }
                    else
                    {
                        writeLog(path);
                        System.IO.FileInfo fi = new System.IO.FileInfo(path);

                        ci = new CopyItem(path, fi.Name);


                    }

                    cis.add(ci);

                }
                //fi.Attributes.
                //avoid duplicates copies.
                if (!copyItemsList.Contains(cis))
                {
                    copyItemsList.Add(cis);
                    //creating copyItems control and add it to the copyItems panel control.
                    CopyItemsCtl cic = new CopyItemsCtl(cis);
                    //register to copyItemsCtl click event.
                    cic.Clicked += copyItmesCtlClicked;
                    copyItemsflwLytPnl.Controls.Add(cic);

                }
            }


        }
        public void displayCopiedFiles (CopyItems cis)
        {
            listView1.Clear();
            imageList1.Images.Clear();
          
            ListViewItem item;
            listView1.BeginUpdate();
            string key;
            for (int i=0;i<cis.count();i++)
            {
                CopyItem ci =cis.get(i);
                string path = ci.Path;
                if (ci.isFile)
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(path);
                    key = file.Extension;
                    if (key == ".lnk")
                        key = file.Name+key;
                }
                else
                {
                    key = path;
                }
                // Set a default icon for the file.
                Icon iconForFile = SystemIcons.WinLogo;

                //item = new ListViewItem(file.Name, 1);
                item = new ListViewItem(ci.Name, 1);
                // Check to see if the image collection contains an image
                // for this extension, using the extension as a key.
                if (!imageList1.Images.ContainsKey(key))
                {
                    // If not, add the image to the image list.
                    if (ci.isFile)
                        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(path);
                    else
                        iconForFile = ExtractFromPath(path); 

                    
                    imageList1.Images.Add(key, iconForFile);
                }
                item.ImageKey = key;
                item.Name = path;
                listView1.Items.Add(item);
            }
            listView1.EndUpdate();

        }
        //Struct used by SHGetFileInfo function
        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };
        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_LARGEICON = 0x0;
        private const uint SHGFI_SMALLICON = 0x000000001;
        private static Icon ExtractFromPath(string path)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            SHGetFileInfo(
                path,
                0, ref shinfo, (uint)Marshal.SizeOf(shinfo),
                SHGFI_ICON | SHGFI_LARGEICON);
            return System.Drawing.Icon.FromHandle(shinfo.hIcon);
        }

        public void copyItmesCtlClicked(object sender,CopyItems ci)
        {
          
            //seems silly[not efficient] that the function's resposability is to call to another function.
            //but i dont know yet if in the future i would like to excute displayCopiedFiles's procedure from another place.
            displayCopiedFiles(ci);

        }
    }
}
