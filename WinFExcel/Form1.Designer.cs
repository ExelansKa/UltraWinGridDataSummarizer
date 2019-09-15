namespace WinFExcel
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
            this.components = new System.ComponentModel.Container();
            this.Ugv = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn = new System.Windows.Forms.Button();
            this.CtMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MnSoma = new System.Windows.Forms.ToolStripTextBox();
            this.MnCont = new System.Windows.Forms.ToolStripTextBox();
            this.MnAvg = new System.Windows.Forms.ToolStripTextBox();
            this.MnMax = new System.Windows.Forms.ToolStripTextBox();
            this.MnMin = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Ugv)).BeginInit();
            this.panel1.SuspendLayout();
            this.CtMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ugv
            // 
            this.Ugv.DisplayLayout.MaxColScrollRegions = 1;
            this.Ugv.DisplayLayout.MaxRowScrollRegions = 1;
            this.Ugv.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.Ugv.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.Ugv.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Ugv.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Ugv.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.Ugv.Location = new System.Drawing.Point(0, 0);
            this.Ugv.Name = "Ugv";
            this.Ugv.Size = new System.Drawing.Size(800, 297);
            this.Ugv.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 293);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 33);
            this.panel1.TabIndex = 1;
            // 
            // btn
            // 
            this.btn.AutoSize = true;
            this.btn.FlatAppearance.BorderSize = 0;
            this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn.Font = new System.Drawing.Font("Leelawadee UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn.ForeColor = System.Drawing.Color.White;
            this.btn.Location = new System.Drawing.Point(518, 6);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(81, 25);
            this.btn.TabIndex = 2;
            this.btn.UseVisualStyleBackColor = true;
            // 
            // CtMenu
            // 
            this.CtMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CtMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnSoma,
            this.MnCont,
            this.MnAvg,
            this.MnMax,
            this.MnMin});
            this.CtMenu.Name = "CtMenu";
            this.CtMenu.Size = new System.Drawing.Size(161, 94);
            // 
            // MnSoma
            // 
            this.MnSoma.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MnSoma.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MnSoma.Enabled = false;
            this.MnSoma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MnSoma.Name = "MnSoma";
            this.MnSoma.Size = new System.Drawing.Size(100, 16);
            this.MnSoma.Text = "Sum";
            // 
            // MnCont
            // 
            this.MnCont.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MnCont.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MnCont.Enabled = false;
            this.MnCont.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MnCont.Name = "MnCont";
            this.MnCont.Size = new System.Drawing.Size(100, 16);
            this.MnCont.Text = "Count";
            // 
            // MnAvg
            // 
            this.MnAvg.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MnAvg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MnAvg.Enabled = false;
            this.MnAvg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MnAvg.Name = "MnAvg";
            this.MnAvg.Size = new System.Drawing.Size(100, 16);
            this.MnAvg.Text = "Avg";
            // 
            // MnMax
            // 
            this.MnMax.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MnMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MnMax.Enabled = false;
            this.MnMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MnMax.Name = "MnMax";
            this.MnMax.Size = new System.Drawing.Size(100, 16);
            this.MnMax.Text = "Max";
            // 
            // MnMin
            // 
            this.MnMin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MnMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MnMin.Enabled = false;
            this.MnMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MnMin.Name = "MnMin";
            this.MnMin.Size = new System.Drawing.Size(100, 16);
            this.MnMin.Text = "Min";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 326);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Ugv);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Ugv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.CtMenu.ResumeLayout(false);
            this.CtMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid Ugv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip CtMenu;
        private System.Windows.Forms.ToolStripTextBox MnSoma;
        private System.Windows.Forms.ToolStripTextBox MnCont;
        private System.Windows.Forms.ToolStripTextBox MnAvg;
        private System.Windows.Forms.ToolStripTextBox MnMax;
        private System.Windows.Forms.ToolStripTextBox MnMin;
        private System.Windows.Forms.Button btn;
    }
}

