namespace Trova.Server
{
    partial class frmServer
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
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblPorta = new System.Windows.Forms.Label();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.lblClientesConectados = new System.Windows.Forms.Label();
            this.lstClientesConectados = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(175, 17);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblPorta
            // 
            this.lblPorta.AutoSize = true;
            this.lblPorta.Location = new System.Drawing.Point(12, 26);
            this.lblPorta.Name = "lblPorta";
            this.lblPorta.Size = new System.Drawing.Size(32, 13);
            this.lblPorta.TabIndex = 1;
            this.lblPorta.Text = "Porta";
            // 
            // txtPorta
            // 
            this.txtPorta.Location = new System.Drawing.Point(69, 19);
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(100, 20);
            this.txtPorta.TabIndex = 2;
            this.txtPorta.Text = "1337";
            // 
            // lblClientesConectados
            // 
            this.lblClientesConectados.AutoSize = true;
            this.lblClientesConectados.Location = new System.Drawing.Point(12, 60);
            this.lblClientesConectados.Name = "lblClientesConectados";
            this.lblClientesConectados.Size = new System.Drawing.Size(103, 13);
            this.lblClientesConectados.TabIndex = 3;
            this.lblClientesConectados.Text = "Clientes conectados";
            // 
            // lstClientesConectados
            // 
            this.lstClientesConectados.FormattingEnabled = true;
            this.lstClientesConectados.Location = new System.Drawing.Point(15, 76);
            this.lstClientesConectados.Name = "lstClientesConectados";
            this.lstClientesConectados.Size = new System.Drawing.Size(235, 173);
            this.lstClientesConectados.TabIndex = 4;
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 264);
            this.Controls.Add(this.lstClientesConectados);
            this.Controls.Add(this.lblClientesConectados);
            this.Controls.Add(this.txtPorta);
            this.Controls.Add(this.lblPorta);
            this.Controls.Add(this.btnIniciar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmServer";
            this.Text = "Trova Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblPorta;
        private System.Windows.Forms.TextBox txtPorta;
        private System.Windows.Forms.Label lblClientesConectados;
        private System.Windows.Forms.ListBox lstClientesConectados;
    }
}

