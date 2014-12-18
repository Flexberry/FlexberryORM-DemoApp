namespace nHibernateSample
{
    partial class SampleForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createDetails = new System.Windows.Forms.Button();
            this.readD0 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.readWithMaster = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.createMasters = new System.Windows.Forms.Button();
            this.loadMasters = new System.Windows.Forms.Button();
            this.create10000 = new System.Windows.Forms.Button();
            this.listItems = new System.Windows.Forms.Button();
            this.openSession = new System.Windows.Forms.Button();
            this.generateSheme = new System.Windows.Forms.Button();
            this.removeConstaint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.createDetails);
            this.groupBox1.Controls.Add(this.readD0);
            this.groupBox1.Location = new System.Drawing.Point(12, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 135);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Multiple details";
            // 
            // createDetails
            // 
            this.createDetails.Location = new System.Drawing.Point(6, 19);
            this.createDetails.Name = "createDetails";
            this.createDetails.Size = new System.Drawing.Size(355, 23);
            this.createDetails.TabIndex = 2;
            this.createDetails.Text = "Create detail hierarhy";
            this.createDetails.UseVisualStyleBackColor = true;
            this.createDetails.Click += new System.EventHandler(this.createDetails_Click);
            // 
            // readD0
            // 
            this.readD0.Location = new System.Drawing.Point(6, 48);
            this.readD0.Name = "readD0";
            this.readD0.Size = new System.Drawing.Size(355, 23);
            this.readD0.TabIndex = 2;
            this.readD0.Text = "Read random D0 with hierarhy";
            this.readD0.UseVisualStyleBackColor = true;
            this.readD0.Click += new System.EventHandler(this.readD0_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 234);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1150, 451);
            this.textBox1.TabIndex = 6;
            // 
            // readWithMaster
            // 
            this.readWithMaster.Location = new System.Drawing.Point(12, 66);
            this.readWithMaster.Name = "readWithMaster";
            this.readWithMaster.Size = new System.Drawing.Size(361, 23);
            this.readWithMaster.TabIndex = 5;
            this.readWithMaster.Text = "Read object with related master";
            this.readWithMaster.UseVisualStyleBackColor = true;
            this.readWithMaster.Click += new System.EventHandler(this.readWithMaster_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.removeConstaint);
            this.groupBox2.Controls.Add(this.createMasters);
            this.groupBox2.Controls.Add(this.loadMasters);
            this.groupBox2.Controls.Add(this.create10000);
            this.groupBox2.Location = new System.Drawing.Point(400, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 133);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Multimaster";
            // 
            // createMasters
            // 
            this.createMasters.Location = new System.Drawing.Point(6, 17);
            this.createMasters.Name = "createMasters";
            this.createMasters.Size = new System.Drawing.Size(355, 25);
            this.createMasters.TabIndex = 3;
            this.createMasters.Text = "Generate masters";
            this.createMasters.UseVisualStyleBackColor = true;
            this.createMasters.Click += new System.EventHandler(this.createMasters_Click);
            // 
            // loadMasters
            // 
            this.loadMasters.Location = new System.Drawing.Point(6, 103);
            this.loadMasters.Name = "loadMasters";
            this.loadMasters.Size = new System.Drawing.Size(355, 23);
            this.loadMasters.TabIndex = 2;
            this.loadMasters.Text = "Load Internals with masters";
            this.loadMasters.UseVisualStyleBackColor = true;
            this.loadMasters.Click += new System.EventHandler(this.loadMasters_Click);
            // 
            // create10000
            // 
            this.create10000.Location = new System.Drawing.Point(6, 74);
            this.create10000.Name = "create10000";
            this.create10000.Size = new System.Drawing.Size(355, 23);
            this.create10000.TabIndex = 2;
            this.create10000.Text = "Create 10000 with masters";
            this.create10000.UseVisualStyleBackColor = true;
            this.create10000.Click += new System.EventHandler(this.create10000_Click);
            // 
            // listItems
            // 
            this.listItems.Location = new System.Drawing.Point(12, 37);
            this.listItems.Name = "listItems";
            this.listItems.Size = new System.Drawing.Size(361, 23);
            this.listItems.TabIndex = 10;
            this.listItems.Text = "List";
            this.listItems.UseVisualStyleBackColor = true;
            this.listItems.Click += new System.EventHandler(this.listItems_Click);
            // 
            // openSession
            // 
            this.openSession.Location = new System.Drawing.Point(12, 8);
            this.openSession.Name = "openSession";
            this.openSession.Size = new System.Drawing.Size(361, 23);
            this.openSession.TabIndex = 11;
            this.openSession.Text = "Init SessionFactory";
            this.openSession.UseVisualStyleBackColor = true;
            this.openSession.Click += new System.EventHandler(this.openSession_Click);
            // 
            // generateSheme
            // 
            this.generateSheme.Location = new System.Drawing.Point(400, 8);
            this.generateSheme.Name = "generateSheme";
            this.generateSheme.Size = new System.Drawing.Size(382, 23);
            this.generateSheme.TabIndex = 12;
            this.generateSheme.Text = "Generate database sheme";
            this.generateSheme.UseVisualStyleBackColor = true;
            this.generateSheme.Click += new System.EventHandler(this.generateSheme_Click);
            // 
            // removeConstaint
            // 
            this.removeConstaint.Location = new System.Drawing.Point(6, 48);
            this.removeConstaint.Name = "removeConstaint";
            this.removeConstaint.Size = new System.Drawing.Size(355, 23);
            this.removeConstaint.TabIndex = 4;
            this.removeConstaint.Text = "Remove constraint at MasterSpecial_0 field";
            this.removeConstaint.UseVisualStyleBackColor = true;
            this.removeConstaint.Click += new System.EventHandler(this.removeConstaint_Click);
            // 
            // SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 697);
            this.Controls.Add(this.generateSheme);
            this.Controls.Add(this.openSession);
            this.Controls.Add(this.listItems);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.readWithMaster);
            this.Controls.Add(this.groupBox2);
            this.Name = "SampleForm";
            this.Text = "nHibernate Sample";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button createDetails;
        private System.Windows.Forms.Button readD0;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button readWithMaster;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button loadMasters;
        private System.Windows.Forms.Button create10000;
        private System.Windows.Forms.Button listItems;
        private System.Windows.Forms.Button openSession;
        private System.Windows.Forms.Button createMasters;
        private System.Windows.Forms.Button generateSheme;
        private System.Windows.Forms.Button removeConstaint;
    }
}

