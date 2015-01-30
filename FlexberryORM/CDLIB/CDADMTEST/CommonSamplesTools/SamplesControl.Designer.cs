namespace NewPlatform.Flexberry.Samples
{
    partial class SamplesControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SamplesControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SamplesTree = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.WebBrowserControl = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.WikiUrlLinkLabel = new System.Windows.Forms.LinkLabel();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.RunSampleToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ClearLogToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SamplesTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(816, 686);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 0;
            // 
            // SamplesTree
            // 
            this.SamplesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SamplesTree.Location = new System.Drawing.Point(0, 0);
            this.SamplesTree.Name = "SamplesTree";
            this.SamplesTree.Size = new System.Drawing.Size(272, 686);
            this.SamplesTree.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.WebBrowserControl);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.LogTextBox);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer2.Size = new System.Drawing.Size(540, 686);
            this.splitContainer2.SplitterDistance = 309;
            this.splitContainer2.TabIndex = 1;
            // 
            // WebBrowserControl
            // 
            this.WebBrowserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebBrowserControl.Location = new System.Drawing.Point(0, 30);
            this.WebBrowserControl.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowserControl.Name = "WebBrowserControl";
            this.WebBrowserControl.Size = new System.Drawing.Size(540, 279);
            this.WebBrowserControl.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.WikiUrlLinkLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 30);
            this.panel1.TabIndex = 0;
            // 
            // WikiUrlLinkLabel
            // 
            this.WikiUrlLinkLabel.AutoSize = true;
            this.WikiUrlLinkLabel.Location = new System.Drawing.Point(4, 4);
            this.WikiUrlLinkLabel.Name = "WikiUrlLinkLabel";
            this.WikiUrlLinkLabel.Size = new System.Drawing.Size(55, 13);
            this.WikiUrlLinkLabel.TabIndex = 0;
            this.WikiUrlLinkLabel.TabStop = true;
            this.WikiUrlLinkLabel.Text = "linkLabel1";
            this.WikiUrlLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WikiUrlLinkLabel_LinkClicked);
            // 
            // LogTextBox
            // 
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Location = new System.Drawing.Point(0, 25);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(540, 348);
            this.LogTextBox.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunSampleToolStripButton,
            this.ClearLogToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(540, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // RunSampleToolStripButton
            // 
            this.RunSampleToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RunSampleToolStripButton.Image")));
            this.RunSampleToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RunSampleToolStripButton.Name = "RunSampleToolStripButton";
            this.RunSampleToolStripButton.Size = new System.Drawing.Size(48, 22);
            this.RunSampleToolStripButton.Text = "Run";
            this.RunSampleToolStripButton.Click += new System.EventHandler(this.RunSampleToolStripButton_Click);
            // 
            // ClearLogToolStripButton
            // 
            this.ClearLogToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearLogToolStripButton.Image")));
            this.ClearLogToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearLogToolStripButton.Name = "ClearLogToolStripButton";
            this.ClearLogToolStripButton.Size = new System.Drawing.Size(74, 22);
            this.ClearLogToolStripButton.Text = "Clear log";
            this.ClearLogToolStripButton.Click += new System.EventHandler(this.ClearLogToolStripButton_Click);
            // 
            // SamplesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SamplesControl";
            this.Size = new System.Drawing.Size(816, 686);
            this.Load += new System.EventHandler(this.SamplesControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton RunSampleToolStripButton;
        private System.Windows.Forms.ToolStripButton ClearLogToolStripButton;
        private System.Windows.Forms.TreeView SamplesTree;
        private System.Windows.Forms.WebBrowser WebBrowserControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel WikiUrlLinkLabel;
        private System.Windows.Forms.TextBox LogTextBox;
    }
}
