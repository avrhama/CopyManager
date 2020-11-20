using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyManager
{
    public partial class CopyItemsCtl : UserControl
    {
        public CopyItemsCtl()
        {
            InitializeComponent();
        }
        CopyItems ci;
        public CopyItemsCtl(CopyItems ci)
        {
            InitializeComponent();
            this.ci = ci;
            config();


        }
        public EventHandler<CopyItems> Clicked;
        public void config()
        {
            //0 space between this control and its neighbours.
            Margin = new Padding(0, 0, 0, 0);
            BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = Properties.Resources.windowCaseOffBlue;
            titleLbl.BackColor = System.Drawing.Color.Transparent;
            titleLbl.Text = $"{ci.count()} {ci.CopiedDate.ToString()}";
            titleLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            MouseDown += CopyItemsCtl_MouseDown;
            titleLbl.MouseDown += CopyItemsCtl_MouseDown;
            ToolTip tt = new ToolTip();
            titleLbl.MouseHover += new EventHandler((object sender, EventArgs e) =>
             {
                 tt.Show(titleLbl.Text, titleLbl, 5000);
             });
            titleLbl.Click += new EventHandler((object sender, EventArgs e) =>
            {
                Clicked?.Invoke(sender, ci);
            });
            Click += new EventHandler((object sender, EventArgs e) =>
            {
                Clicked?.Invoke(sender, ci);
            });
            /* addWindowPic.Click += addWinPicClicked;
             addWindowPic.MouseEnter += new EventHandler((object sender, EventArgs e) =>
             {
                 addWindowPic.setImage(true);
                 BackgroundImage = Resource1.windowCaseOnBlue;
             });
             addWindowPic.MouseLeave += new EventHandler((object sender, EventArgs e) =>
             {
                 addWindowPic.setImage();
                 BackgroundImage = Resource1.windowCaseOffBlue;
             });*/
            //MouseUp += windowItemShowMenu;
            ////windowIconPic.MouseUp += windowItemShowMenu;
            // windowTitleLbl.MouseUp += windowItemShowMenu;
            MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                BackgroundImage = Properties.Resources.windowCaseOnBlue;
            });

            MouseLeave += new EventHandler((object sender, EventArgs e) =>
            {
                BackgroundImage = Properties.Resources.windowCaseOffBlue;

            });
            /* windowIconPic.MouseEnter += new EventHandler((object sender, EventArgs e) =>
             {
                 BackgroundImage = Resource1.windowCaseOnBlue;
             });*/
            titleLbl.MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                BackgroundImage = Properties.Resources.windowCaseOnBlue;
            });
            titleLbl.MouseMove += CopyItemsCtl_MouseMove;
            titleLbl.MouseUp += CopyItemsCtl_MouseUp;
            MouseMove += CopyItemsCtl_MouseMove;
            MouseUp += CopyItemsCtl_MouseUp;

        }
        bool mouseDown = false;
        private void CopyItemsCtl_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            /*   string[] files = ci.getItemsArray();
               this.DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy);
               Clicked?.Invoke(sender, ci);*/
        }
        private void CopyItemsCtl_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                string[] files = ci.getItemsArray();
                this.DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy);
                Clicked?.Invoke(sender, ci);
                mouseDown = false;
            }
        }
        private void CopyItemsCtl_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
