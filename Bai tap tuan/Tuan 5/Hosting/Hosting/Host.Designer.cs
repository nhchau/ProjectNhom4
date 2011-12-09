namespace Hosting
{
    partial class Host
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
            this.Txt_BasAdd = new System.Windows.Forms.TextBox();
            this.Bt_StaLis = new System.Windows.Forms.Button();
            this.Txt_EndPoi = new System.Windows.Forms.TextBox();
            this.Lb_BasAdd = new System.Windows.Forms.Label();
            this.Lb_EndPoi = new System.Windows.Forms.Label();
            this.Lb_Sta = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Txt_BasAdd
            // 
            this.Txt_BasAdd.Location = new System.Drawing.Point(149, 81);
            this.Txt_BasAdd.Name = "Txt_BasAdd";
            this.Txt_BasAdd.Size = new System.Drawing.Size(134, 20);
            this.Txt_BasAdd.TabIndex = 1;
            this.Txt_BasAdd.Text = "http://localhost:8000";
            // 
            // Bt_StaLis
            // 
            this.Bt_StaLis.Location = new System.Drawing.Point(12, 12);
            this.Bt_StaLis.Name = "Bt_StaLis";
            this.Bt_StaLis.Size = new System.Drawing.Size(101, 23);
            this.Bt_StaLis.TabIndex = 2;
            this.Bt_StaLis.Text = "Start Listening";
            this.Bt_StaLis.UseVisualStyleBackColor = true;
            this.Bt_StaLis.Click += new System.EventHandler(this.button2_Click);
            // 
            // Txt_EndPoi
            // 
            this.Txt_EndPoi.Location = new System.Drawing.Point(152, 118);
            this.Txt_EndPoi.Name = "Txt_EndPoi";
            this.Txt_EndPoi.Size = new System.Drawing.Size(100, 20);
            this.Txt_EndPoi.TabIndex = 11;
            this.Txt_EndPoi.Text = "Calculator";
            // 
            // Lb_BasAdd
            // 
            this.Lb_BasAdd.AutoSize = true;
            this.Lb_BasAdd.Location = new System.Drawing.Point(25, 88);
            this.Lb_BasAdd.Name = "Lb_BasAdd";
            this.Lb_BasAdd.Size = new System.Drawing.Size(72, 13);
            this.Lb_BasAdd.TabIndex = 14;
            this.Lb_BasAdd.Text = "Base Address";
            // 
            // Lb_EndPoi
            // 
            this.Lb_EndPoi.AutoSize = true;
            this.Lb_EndPoi.Location = new System.Drawing.Point(25, 121);
            this.Lb_EndPoi.Name = "Lb_EndPoi";
            this.Lb_EndPoi.Size = new System.Drawing.Size(53, 13);
            this.Lb_EndPoi.TabIndex = 16;
            this.Lb_EndPoi.Text = "End Point";
            // 
            // Lb_Sta
            // 
            this.Lb_Sta.AutoSize = true;
            this.Lb_Sta.Location = new System.Drawing.Point(149, 21);
            this.Lb_Sta.Name = "Lb_Sta";
            this.Lb_Sta.Size = new System.Drawing.Size(0, 13);
            this.Lb_Sta.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Host
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 211);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Lb_Sta);
            this.Controls.Add(this.Lb_EndPoi);
            this.Controls.Add(this.Lb_BasAdd);
            this.Controls.Add(this.Txt_EndPoi);
            this.Controls.Add(this.Bt_StaLis);
            this.Controls.Add(this.Txt_BasAdd);
            this.Name = "Host";
            this.Text = "Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_BasAdd;
        private System.Windows.Forms.Button Bt_StaLis;
        private System.Windows.Forms.TextBox Txt_EndPoi;
        private System.Windows.Forms.Label Lb_BasAdd;
        private System.Windows.Forms.Label Lb_EndPoi;
        private System.Windows.Forms.Label Lb_Sta;
        private System.Windows.Forms.Button button1;
    }
}

