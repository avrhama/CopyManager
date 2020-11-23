namespace CopyManager
{
    partial class CopyItemsCtl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLbl = new System.Windows.Forms.Label();
            this.removePic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.removePic)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Location = new System.Drawing.Point(8, 24);
            this.titleLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(93, 32);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "label1";
            // 
            // removePic
            // 
            this.removePic.BackColor = System.Drawing.Color.Transparent;
            this.removePic.BackgroundImage = global::CopyManager.Properties.Resources.closeOff;
            this.removePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.removePic.Location = new System.Drawing.Point(364, 4);
            this.removePic.Name = "removePic";
            this.removePic.Size = new System.Drawing.Size(32, 32);
            this.removePic.TabIndex = 1;
            this.removePic.TabStop = false;
            // 
            // CopyItemsCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CopyManager.Properties.Resources.windowCaseOffBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.removePic);
            this.Controls.Add(this.titleLbl);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "CopyItemsCtl";
            this.Size = new System.Drawing.Size(400, 69);
            ((System.ComponentModel.ISupportInitialize)(this.removePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.PictureBox removePic;
    }
}
