namespace Ubots
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnRecomendacao = new System.Windows.Forms.Button();
            this.btnClientesFieis = new System.Windows.Forms.Button();
            this.btnMaiorClienteCompra = new System.Windows.Forms.Button();
            this.btnListaClientesMaiorValor = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 0);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(518, 479);
            this.dgvDados.TabIndex = 4;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.Controls.Add(this.btnRecomendacao);
            this.pnlBotoes.Controls.Add(this.btnClientesFieis);
            this.pnlBotoes.Controls.Add(this.btnMaiorClienteCompra);
            this.pnlBotoes.Controls.Add(this.btnListaClientesMaiorValor);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBotoes.Location = new System.Drawing.Point(518, 0);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(264, 479);
            this.pnlBotoes.TabIndex = 6;
            // 
            // btnRecomendacao
            // 
            this.btnRecomendacao.Location = new System.Drawing.Point(21, 201);
            this.btnRecomendacao.Name = "btnRecomendacao";
            this.btnRecomendacao.Size = new System.Drawing.Size(223, 37);
            this.btnRecomendacao.TabIndex = 3;
            this.btnRecomendacao.Text = "Recomende um vinho para um determinado cliente a partir do histórico de compras";
            this.btnRecomendacao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecomendacao.UseVisualStyleBackColor = true;
            this.btnRecomendacao.Click += new System.EventHandler(this.btnRecomendacao_Click);
            // 
            // btnClientesFieis
            // 
            this.btnClientesFieis.Location = new System.Drawing.Point(21, 138);
            this.btnClientesFieis.Name = "btnClientesFieis";
            this.btnClientesFieis.Size = new System.Drawing.Size(223, 37);
            this.btnClientesFieis.TabIndex = 2;
            this.btnClientesFieis.Text = "Liste os clientes mais fiéis.";
            this.btnClientesFieis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientesFieis.UseVisualStyleBackColor = true;
            this.btnClientesFieis.Click += new System.EventHandler(this.btnClientesFieis_Click);
            // 
            // btnMaiorClienteCompra
            // 
            this.btnMaiorClienteCompra.Location = new System.Drawing.Point(21, 78);
            this.btnMaiorClienteCompra.Name = "btnMaiorClienteCompra";
            this.btnMaiorClienteCompra.Size = new System.Drawing.Size(223, 37);
            this.btnMaiorClienteCompra.TabIndex = 1;
            this.btnMaiorClienteCompra.Text = "Mostre o cliente com maior compra única no último ano (2016).";
            this.btnMaiorClienteCompra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaiorClienteCompra.UseVisualStyleBackColor = true;
            this.btnMaiorClienteCompra.Click += new System.EventHandler(this.btnMaiorClienteCompra_Click);
            // 
            // btnListaClientesMaiorValor
            // 
            this.btnListaClientesMaiorValor.Location = new System.Drawing.Point(21, 22);
            this.btnListaClientesMaiorValor.Name = "btnListaClientesMaiorValor";
            this.btnListaClientesMaiorValor.Size = new System.Drawing.Size(223, 37);
            this.btnListaClientesMaiorValor.TabIndex = 0;
            this.btnListaClientesMaiorValor.Text = "Liste os clientes ordenados pelo maior valor total em compras.";
            this.btnListaClientesMaiorValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListaClientesMaiorValor.UseVisualStyleBackColor = true;
            this.btnListaClientesMaiorValor.Click += new System.EventHandler(this.btnListaClientesMaiorValor_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvDados);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(518, 479);
            this.pnlGrid.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 479);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlBotoes);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teste";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Button btnRecomendacao;
        private System.Windows.Forms.Button btnClientesFieis;
        private System.Windows.Forms.Button btnMaiorClienteCompra;
        private System.Windows.Forms.Button btnListaClientesMaiorValor;
        private System.Windows.Forms.Panel pnlGrid;
    }
}

