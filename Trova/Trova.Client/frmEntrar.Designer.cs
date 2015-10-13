namespace Trova.Client
{
    partial class frmEntrar
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
            this.btnEntrar = new System.Windows.Forms.Button();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblPorta = new System.Windows.Forms.Label();
            this.lblApelido = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.txtApelido = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnEntrar
            // 
            this.btnEntrar.Location = new System.Drawing.Point(132, 111);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(75, 23);
            this.btnEntrar.TabIndex = 0;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(12, 25);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(29, 13);
            this.lblHost.TabIndex = 1;
            this.lblHost.Text = "Host";
            // 
            // lblPorta
            // 
            this.lblPorta.AutoSize = true;
            this.lblPorta.Location = new System.Drawing.Point(12, 54);
            this.lblPorta.Name = "lblPorta";
            this.lblPorta.Size = new System.Drawing.Size(32, 13);
            this.lblPorta.TabIndex = 2;
            this.lblPorta.Text = "Porta";
            // 
            // lblApelido
            // 
            this.lblApelido.AutoSize = true;
            this.lblApelido.Location = new System.Drawing.Point(12, 83);
            this.lblApelido.Name = "lblApelido";
            this.lblApelido.Size = new System.Drawing.Size(42, 13);
            this.lblApelido.TabIndex = 3;
            this.lblApelido.Text = "Apelido";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(107, 18);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(100, 20);
            this.txtHost.TabIndex = 4;
            this.txtHost.Text = "localhost";
            // 
            // txtPorta
            // 
            this.txtPorta.Location = new System.Drawing.Point(107, 47);
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(100, 20);
            this.txtPorta.TabIndex = 5;
            this.txtPorta.Text = "1337";
            // 
            // txtApelido
            // 
            this.txtApelido.Location = new System.Drawing.Point(107, 76);
            this.txtApelido.Name = "txtApelido";
            this.txtApelido.Size = new System.Drawing.Size(100, 20);
            this.txtApelido.TabIndex = 6;
            // 
            // frmEntrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 150);
            this.Controls.Add(this.txtApelido);
            this.Controls.Add(this.txtPorta);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.lblApelido);
            this.Controls.Add(this.lblPorta);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.btnEntrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEntrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trova";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEntrar_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblPorta;
        private System.Windows.Forms.Label lblApelido;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtPorta;
        private System.Windows.Forms.TextBox txtApelido;
    }
}

