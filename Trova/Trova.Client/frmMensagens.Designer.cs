namespace Trova.Client
{
    partial class frmMensagens
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
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.txtMensagens = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Enabled = false;
            this.btnEnviar.Location = new System.Drawing.Point(677, 379);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtMensagem
            // 
            this.txtMensagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensagem.Location = new System.Drawing.Point(12, 381);
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Size = new System.Drawing.Size(659, 20);
            this.txtMensagem.TabIndex = 1;
            this.txtMensagem.TextChanged += new System.EventHandler(this.txtMensagem_TextChanged);
            this.txtMensagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMensagem_KeyDown);
            // 
            // lstClientes
            // 
            this.lstClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.Location = new System.Drawing.Point(12, 12);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(146, 355);
            this.lstClientes.TabIndex = 2;
            // 
            // txtMensagens
            // 
            this.txtMensagens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensagens.BackColor = System.Drawing.Color.White;
            this.txtMensagens.Location = new System.Drawing.Point(164, 12);
            this.txtMensagens.Multiline = true;
            this.txtMensagens.Name = "txtMensagens";
            this.txtMensagens.ReadOnly = true;
            this.txtMensagens.Size = new System.Drawing.Size(588, 355);
            this.txtMensagens.TabIndex = 3;
            // 
            // frmMensagens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 414);
            this.Controls.Add(this.txtMensagens);
            this.Controls.Add(this.lstClientes);
            this.Controls.Add(this.txtMensagem);
            this.Controls.Add(this.btnEnviar);
            this.Name = "frmMensagens";
            this.Text = "Trova";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMensagens_FormClosed);
            this.Load += new System.EventHandler(this.frmMensagens_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtMensagem;
        private System.Windows.Forms.ListBox lstClientes;
        private System.Windows.Forms.TextBox txtMensagens;
    }
}