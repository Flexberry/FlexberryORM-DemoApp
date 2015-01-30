namespace CDADMTEST
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button18 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button16 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.samplesControl1 = new NewPlatform.Flexberry.Samples.SamplesControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(446, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "1. How to instantiate dataobjects and persist into DB";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(446, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "2. How to load dataobject in specific view, change it\'s property, then persist. O" +
    "bject status and loading state";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 72);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(446, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "3. How to load a set of dataobjects in specific view, limitation, quantity, etc.";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(896, 608);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(888, 582);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1. Basic";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button23);
            this.groupBox3.Controls.Add(this.button24);
            this.groupBox3.Controls.Add(this.button22);
            this.groupBox3.Location = new System.Drawing.Point(6, 242);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(638, 131);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "A lot of objects with multiple masters";
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(6, 19);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(446, 23);
            this.button23.TabIndex = 2;
            this.button23.Text = "8. Prepare masters";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(6, 77);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(446, 23);
            this.button24.TabIndex = 2;
            this.button24.Text = "10. Load";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(6, 48);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(446, 23);
            this.button22.TabIndex = 2;
            this.button22.Text = "9. Create 10000";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Controls.Add(this.button21);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Location = new System.Drawing.Point(6, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 106);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Multiple details";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(6, 19);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(446, 23);
            this.button13.TabIndex = 2;
            this.button13.Text = "5. Create";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button9_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(6, 45);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(446, 23);
            this.button21.TabIndex = 2;
            this.button21.Text = "6. Loading";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(6, 74);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(446, 23);
            this.button9.TabIndex = 2;
            this.button9.Text = "7. Prototyping";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(3, 101);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(446, 23);
            this.button7.TabIndex = 2;
            this.button7.Text = "4. How to do something at persistence moment";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button18);
            this.tabPage2.Controls.Add(this.button15);
            this.tabPage2.Controls.Add(this.button14);
            this.tabPage2.Controls.Add(this.button17);
            this.tabPage2.Controls.Add(this.button12);
            this.tabPage2.Controls.Add(this.button20);
            this.tabPage2.Controls.Add(this.button10);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(888, 582);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2. Standard";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(3, 177);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(446, 23);
            this.button18.TabIndex = 4;
            this.button18.Text = "7. How to change storage type";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(3, 119);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(446, 23);
            this.button15.TabIndex = 3;
            this.button15.Text = "5. Custom types";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(3, 90);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(446, 23);
            this.button14.TabIndex = 3;
            this.button14.Text = "4. Type synonyms";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(3, 32);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(446, 23);
            this.button17.TabIndex = 3;
            this.button17.Text = "2. Views and inheritance";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(3, 148);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(446, 23);
            this.button12.TabIndex = 3;
            this.button12.Text = "6. Custom naming of DB structures";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(3, 6);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(446, 23);
            this.button20.TabIndex = 3;
            this.button20.Text = "1. Not stored/calculated properties";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(3, 61);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(446, 23);
            this.button10.TabIndex = 3;
            this.button10.Text = "3. Inheritance: type usages for master associations";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button16);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.button11);
            this.tabPage3.Controls.Add(this.button19);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(888, 582);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3. Advanced";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(3, 32);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(628, 23);
            this.button16.TabIndex = 0;
            this.button16.Text = "5. Working with views";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(3, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(628, 23);
            this.button8.TabIndex = 0;
            this.button8.Text = "4. Advanced limitation";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(3, 235);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(628, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "3. Catching and replacement of query";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(3, 72);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(628, 23);
            this.button11.TabIndex = 0;
            this.button11.Text = "2. Advanced \"Businessserving\"";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(3, 293);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(628, 23);
            this.button19.TabIndex = 0;
            this.button19.Text = "2. How to update a dataobject that wasn\'t read before";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 264);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(628, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "2. How to change primary key type and algorithm";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 206);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(628, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "1. Custom data service";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.samplesControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(888, 582);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Samples tree";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(902, 627);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select sample complexity level:";
            // 
            // samplesControl1
            // 
            this.samplesControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.samplesControl1.Location = new System.Drawing.Point(0, 0);
            this.samplesControl1.Name = "samplesControl1";
            this.samplesControl1.Size = new System.Drawing.Size(888, 582);
            this.samplesControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 627);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "FLEXBERRY ORM samples";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.TabPage tabPage4;
        private NewPlatform.Flexberry.Samples.SamplesControl samplesControl1;
    }
}

