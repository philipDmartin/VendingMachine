
namespace VendingMachineCsharp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBoxVMViewer = new System.Windows.Forms.TextBox();
            this.textBoxVMStateViewer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button1.Location = new System.Drawing.Point(1547, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 235);
            this.button1.TabIndex = 0;
            this.button1.Text = "Insert Quarters";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(1547, 777);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(227, 233);
            this.button2.TabIndex = 1;
            this.button2.Text = "Eject Quarters";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Enabled = false;
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(448, 1050);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(289, 227);
            this.button3.TabIndex = 2;
            this.button3.Text = "Sprite";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(999, 1050);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(268, 227);
            this.button4.TabIndex = 3;
            this.button4.Text = "Coke";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button6.Location = new System.Drawing.Point(1465, 1251);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(300, 90);
            this.button6.TabIndex = 5;
            this.button6.Text = "Transaction History";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBoxVMViewer
            // 
            this.textBoxVMViewer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxVMViewer.Location = new System.Drawing.Point(177, 279);
            this.textBoxVMViewer.Multiline = true;
            this.textBoxVMViewer.Name = "textBoxVMViewer";
            this.textBoxVMViewer.ReadOnly = true;
            this.textBoxVMViewer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxVMViewer.Size = new System.Drawing.Size(1334, 731);
            this.textBoxVMViewer.TabIndex = 6;
            this.textBoxVMViewer.TextChanged += new System.EventHandler(this.textBoxVMViewer_TextChanged);
            // 
            // textBoxVMStateViewer
            // 
            this.textBoxVMStateViewer.Location = new System.Drawing.Point(685, 177);
            this.textBoxVMStateViewer.Name = "textBoxVMStateViewer";
            this.textBoxVMStateViewer.ReadOnly = true;
            this.textBoxVMStateViewer.Size = new System.Drawing.Size(364, 39);
            this.textBoxVMStateViewer.TabIndex = 7;
            this.textBoxVMStateViewer.Visible = false;
            this.textBoxVMStateViewer.TextChanged += new System.EventHandler(this.textBoxVMStateViewer_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1840, 1378);
            this.Controls.Add(this.textBoxVMStateViewer);
            this.Controls.Add(this.textBoxVMViewer);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBoxVMViewer;
        private System.Windows.Forms.TextBox textBoxVMStateViewer;
    }
}
