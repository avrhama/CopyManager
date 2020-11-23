namespace CopyManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.filesAndFoldersTab = new System.Windows.Forms.TabPage();
            this.textsTab = new System.Windows.Forms.TabPage();
            this.copyItemsflwLytPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.copiedTextsListBox = new System.Windows.Forms.ListBox();
            this.copiedtextRichText = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.filesAndFoldersTab.SuspendLayout();
            this.textsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.filesAndFoldersTab);
            this.tabControl1.Controls.Add(this.textsTab);
            this.tabControl1.Location = new System.Drawing.Point(175, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2039, 916);
            this.tabControl1.TabIndex = 5;
            // 
            // filesAndFoldersTab
            // 
            this.filesAndFoldersTab.Controls.Add(this.copyItemsflwLytPnl);
            this.filesAndFoldersTab.Controls.Add(this.listView1);
            this.filesAndFoldersTab.Location = new System.Drawing.Point(10, 48);
            this.filesAndFoldersTab.Name = "filesAndFoldersTab";
            this.filesAndFoldersTab.Padding = new System.Windows.Forms.Padding(3);
            this.filesAndFoldersTab.Size = new System.Drawing.Size(2019, 858);
            this.filesAndFoldersTab.TabIndex = 0;
            this.filesAndFoldersTab.Text = "Files&Folders";
            this.filesAndFoldersTab.UseVisualStyleBackColor = true;
            // 
            // textsTab
            // 
            this.textsTab.Controls.Add(this.copiedtextRichText);
            this.textsTab.Controls.Add(this.copiedTextsListBox);
            this.textsTab.Location = new System.Drawing.Point(10, 48);
            this.textsTab.Name = "textsTab";
            this.textsTab.Padding = new System.Windows.Forms.Padding(3);
            this.textsTab.Size = new System.Drawing.Size(2019, 858);
            this.textsTab.TabIndex = 1;
            this.textsTab.Text = "Texts";
            this.textsTab.UseVisualStyleBackColor = true;
            // 
            // copyItemsflwLytPnl
            // 
            this.copyItemsflwLytPnl.Location = new System.Drawing.Point(31, 25);
            this.copyItemsflwLytPnl.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.copyItemsflwLytPnl.Name = "copyItemsflwLytPnl";
            this.copyItemsflwLytPnl.Size = new System.Drawing.Size(632, 548);
            this.copyItemsflwLytPnl.TabIndex = 8;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(701, 41);
            this.listView1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(969, 543);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(199, 1052);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(671, 223);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // copiedTextsListBox
            // 
            this.copiedTextsListBox.FormattingEnabled = true;
            this.copiedTextsListBox.ItemHeight = 31;
            this.copiedTextsListBox.Location = new System.Drawing.Point(41, 41);
            this.copiedTextsListBox.Name = "copiedTextsListBox";
            this.copiedTextsListBox.Size = new System.Drawing.Size(410, 779);
            this.copiedTextsListBox.TabIndex = 0;
            // 
            // copiedtextRichText
            // 
            this.copiedtextRichText.Location = new System.Drawing.Point(519, 41);
            this.copiedtextRichText.Name = "copiedtextRichText";
            this.copiedtextRichText.Size = new System.Drawing.Size(1120, 779);
            this.copiedtextRichText.TabIndex = 1;
            this.copiedtextRichText.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2294, 1401);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.filesAndFoldersTab.ResumeLayout(false);
            this.textsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage filesAndFoldersTab;
        private System.Windows.Forms.FlowLayoutPanel copyItemsflwLytPnl;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabPage textsTab;
        private System.Windows.Forms.RichTextBox copiedtextRichText;
        private System.Windows.Forms.ListBox copiedTextsListBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

