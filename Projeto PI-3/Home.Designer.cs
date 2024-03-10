namespace Projeto_PI_3
{
    partial class Home
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnListaPartida = new System.Windows.Forms.Button();
            this.lblVersao = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCriarPartida = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "Magic Trick";
            // 
            // btnListaPartida
            // 
            this.btnListaPartida.Location = new System.Drawing.Point(337, 236);
            this.btnListaPartida.Name = "btnListaPartida";
            this.btnListaPartida.Size = new System.Drawing.Size(128, 47);
            this.btnListaPartida.TabIndex = 1;
            this.btnListaPartida.Text = "Lista de Partidas";
            this.btnListaPartida.UseVisualStyleBackColor = true;
            this.btnListaPartida.Click += new System.EventHandler(this.btnListaPartida_Click);
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(696, 428);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(40, 13);
            this.lblVersao.TabIndex = 2;
            this.lblVersao.Text = "Versão";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(643, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 78);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grupo: \r\n\r\nAndorra-a-Velha\r\n\r\nAmilton Oliveira Sousa\r\nJoão Paulo Lira Bezerra Sil" +
    "va\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCriarPartida
            // 
            this.btnCriarPartida.Location = new System.Drawing.Point(337, 303);
            this.btnCriarPartida.Name = "btnCriarPartida";
            this.btnCriarPartida.Size = new System.Drawing.Size(128, 47);
            this.btnCriarPartida.TabIndex = 4;
            this.btnCriarPartida.Text = "Criar Partida";
            this.btnCriarPartida.UseVisualStyleBackColor = true;
            this.btnCriarPartida.Click += new System.EventHandler(this.btnCriarPartida_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCriarPartida);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.btnListaPartida);
            this.Controls.Add(this.label1);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnListaPartida;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCriarPartida;
    }
}