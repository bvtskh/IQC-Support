namespace IQC_Auto_Data
{
    partial class FormMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.checkDefault = new System.Windows.Forms.CheckBox();
            this.txtpart = new System.Windows.Forms.TextBox();
            this.panelconfig = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bgrInputData = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelconfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelconfig);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(30, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 169);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnAction);
            this.panel2.Controls.Add(this.checkDefault);
            this.panel2.Controls.Add(this.txtpart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 134);
            this.panel2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Part No:";
            // 
            // btnAction
            // 
            this.btnAction.BackColor = System.Drawing.Color.Moccasin;
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction.Image = global::IPQC_Auto_Data.Properties.Resources.setup;
            this.btnAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAction.Location = new System.Drawing.Point(151, 73);
            this.btnAction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(195, 56);
            this.btnAction.TabIndex = 1;
            this.btnAction.Text = "Nhập dữ liệu";
            this.btnAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAction.UseVisualStyleBackColor = false;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // checkDefault
            // 
            this.checkDefault.AutoSize = true;
            this.checkDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDefault.Location = new System.Drawing.Point(178, 41);
            this.checkDefault.Name = "checkDefault";
            this.checkDefault.Size = new System.Drawing.Size(151, 24);
            this.checkDefault.TabIndex = 3;
            this.checkDefault.Text = "Chế độ tự động";
            this.checkDefault.UseVisualStyleBackColor = true;
            // 
            // txtpart
            // 
            this.txtpart.Location = new System.Drawing.Point(80, 9);
            this.txtpart.Name = "txtpart";
            this.txtpart.ReadOnly = true;
            this.txtpart.Size = new System.Drawing.Size(372, 26);
            this.txtpart.TabIndex = 5;
            // 
            // panelconfig
            // 
            this.panelconfig.BackColor = System.Drawing.Color.White;
            this.panelconfig.Controls.Add(this.label1);
            this.panelconfig.Controls.Add(this.txtFolder);
            this.panelconfig.Controls.Add(this.btnSave);
            this.panelconfig.Controls.Add(this.btnOpen);
            this.panelconfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelconfig.Location = new System.Drawing.Point(0, 0);
            this.panelconfig.Name = "panelconfig";
            this.panelconfig.Size = new System.Drawing.Size(459, 35);
            this.panelconfig.TabIndex = 5;
            this.panelconfig.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Thư mục:";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(80, 5);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(302, 26);
            this.txtFolder.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = global::IPQC_Auto_Data.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(423, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(29, 26);
            this.btnSave.TabIndex = 6;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.White;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpen.Image = global::IPQC_Auto_Data.Properties.Resources.openfile;
            this.btnOpen.Location = new System.Drawing.Point(388, 5);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(29, 26);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::IPQC_Auto_Data.Properties.Resources.sys;
            this.button2.Location = new System.Drawing.Point(30, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 24);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 292);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(30, 92, 30, 31);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "IQC DX - SUPPORT";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.TransparencyKey = System.Drawing.Color.LightGreen;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelconfig.ResumeLayout(false);
            this.panelconfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkDefault;
        private System.Windows.Forms.TextBox txtpart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelconfig;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker bgrInputData;
    }
}