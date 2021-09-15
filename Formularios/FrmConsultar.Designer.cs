
namespace WinFormCarpinteria.Formularios
{
	partial class FrmConsultar
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
			this.dgvConsultar = new System.Windows.Forms.DataGridView();
			this.cNroPresup = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cAccion = new System.Windows.Forms.DataGridViewButtonColumn();
			this.cAccion2 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.lblFiltro = new System.Windows.Forms.Label();
			this.cboFiltro = new System.Windows.Forms.ComboBox();
			this.txtFiltro = new System.Windows.Forms.TextBox();
			this.btnFiltrar = new System.Windows.Forms.Button();
			this.btnEliminarFiltro = new System.Windows.Forms.Button();
			this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.dgvConsultar)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvConsultar
			// 
			this.dgvConsultar.AllowUserToAddRows = false;
			this.dgvConsultar.AllowUserToDeleteRows = false;
			this.dgvConsultar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvConsultar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNroPresup,
            this.cFecha,
            this.cCliente,
            this.cTotal,
            this.cAccion,
            this.cAccion2});
			this.dgvConsultar.Location = new System.Drawing.Point(12, 106);
			this.dgvConsultar.Name = "dgvConsultar";
			this.dgvConsultar.ReadOnly = true;
			this.dgvConsultar.RowHeadersVisible = false;
			this.dgvConsultar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvConsultar.Size = new System.Drawing.Size(544, 426);
			this.dgvConsultar.TabIndex = 0;
			this.dgvConsultar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultar_CellContentClick);
			// 
			// cNroPresup
			// 
			this.cNroPresup.HeaderText = "Numero Presupuesto";
			this.cNroPresup.Name = "cNroPresup";
			this.cNroPresup.ReadOnly = true;
			// 
			// cFecha
			// 
			this.cFecha.HeaderText = "Fecha";
			this.cFecha.Name = "cFecha";
			this.cFecha.ReadOnly = true;
			// 
			// cCliente
			// 
			this.cCliente.HeaderText = "Cliente";
			this.cCliente.Name = "cCliente";
			this.cCliente.ReadOnly = true;
			// 
			// cTotal
			// 
			this.cTotal.HeaderText = "Total";
			this.cTotal.Name = "cTotal";
			this.cTotal.ReadOnly = true;
			// 
			// cAccion
			// 
			this.cAccion.HeaderText = "Accion";
			this.cAccion.Name = "cAccion";
			this.cAccion.ReadOnly = true;
			this.cAccion.Text = "Editar";
			this.cAccion.UseColumnTextForButtonValue = true;
			this.cAccion.Width = 70;
			// 
			// cAccion2
			// 
			this.cAccion2.HeaderText = "Accion";
			this.cAccion2.Name = "cAccion2";
			this.cAccion2.ReadOnly = true;
			this.cAccion2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.cAccion2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.cAccion2.Text = "Borrar";
			this.cAccion2.UseColumnTextForButtonValue = true;
			this.cAccion2.Width = 70;
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(482, 538);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 1;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// lblFiltro
			// 
			this.lblFiltro.AutoSize = true;
			this.lblFiltro.Location = new System.Drawing.Point(46, 27);
			this.lblFiltro.Name = "lblFiltro";
			this.lblFiltro.Size = new System.Drawing.Size(34, 13);
			this.lblFiltro.TabIndex = 2;
			this.lblFiltro.Text = "Filtros";
			// 
			// cboFiltro
			// 
			this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFiltro.FormattingEnabled = true;
			this.cboFiltro.Location = new System.Drawing.Point(102, 23);
			this.cboFiltro.Name = "cboFiltro";
			this.cboFiltro.Size = new System.Drawing.Size(144, 21);
			this.cboFiltro.TabIndex = 3;
			this.cboFiltro.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged);
			// 
			// txtFiltro
			// 
			this.txtFiltro.Location = new System.Drawing.Point(256, 23);
			this.txtFiltro.Name = "txtFiltro";
			this.txtFiltro.Size = new System.Drawing.Size(176, 20);
			this.txtFiltro.TabIndex = 4;
			// 
			// btnFiltrar
			// 
			this.btnFiltrar.Location = new System.Drawing.Point(442, 22);
			this.btnFiltrar.Name = "btnFiltrar";
			this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
			this.btnFiltrar.TabIndex = 5;
			this.btnFiltrar.Text = "Filtrar";
			this.btnFiltrar.UseVisualStyleBackColor = true;
			this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
			// 
			// btnEliminarFiltro
			// 
			this.btnEliminarFiltro.Location = new System.Drawing.Point(12, 538);
			this.btnEliminarFiltro.Name = "btnEliminarFiltro";
			this.btnEliminarFiltro.Size = new System.Drawing.Size(105, 23);
			this.btnEliminarFiltro.TabIndex = 6;
			this.btnEliminarFiltro.Text = "Eliminar Filtro";
			this.btnEliminarFiltro.UseVisualStyleBackColor = true;
			this.btnEliminarFiltro.Click += new System.EventHandler(this.btnEliminarFiltro_Click);
			// 
			// dtpFechaDesde
			// 
			this.dtpFechaDesde.Location = new System.Drawing.Point(102, 68);
			this.dtpFechaDesde.Name = "dtpFechaDesde";
			this.dtpFechaDesde.Size = new System.Drawing.Size(200, 20);
			this.dtpFechaDesde.TabIndex = 7;
			// 
			// dtpFechaHasta
			// 
			this.dtpFechaHasta.Location = new System.Drawing.Point(318, 68);
			this.dtpFechaHasta.Name = "dtpFechaHasta";
			this.dtpFechaHasta.Size = new System.Drawing.Size(200, 20);
			this.dtpFechaHasta.TabIndex = 8;
			// 
			// FrmConsultar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(569, 575);
			this.Controls.Add(this.dtpFechaHasta);
			this.Controls.Add(this.dtpFechaDesde);
			this.Controls.Add(this.btnEliminarFiltro);
			this.Controls.Add(this.btnFiltrar);
			this.Controls.Add(this.txtFiltro);
			this.Controls.Add(this.cboFiltro);
			this.Controls.Add(this.lblFiltro);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.dgvConsultar);
			this.Name = "FrmConsultar";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Consulta Presupuestos";
			this.Load += new System.EventHandler(this.FrmConsultar_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvConsultar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvConsultar;
		private System.Windows.Forms.DataGridViewTextBoxColumn cNroPresup;
		private System.Windows.Forms.DataGridViewTextBoxColumn cFecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn cCliente;
		private System.Windows.Forms.DataGridViewTextBoxColumn cTotal;
		private System.Windows.Forms.DataGridViewButtonColumn cAccion;
		private System.Windows.Forms.DataGridViewButtonColumn cAccion2;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Label lblFiltro;
		private System.Windows.Forms.ComboBox cboFiltro;
		private System.Windows.Forms.TextBox txtFiltro;
		private System.Windows.Forms.Button btnFiltrar;
		private System.Windows.Forms.Button btnEliminarFiltro;
		private System.Windows.Forms.DateTimePicker dtpFechaDesde;
		private System.Windows.Forms.DateTimePicker dtpFechaHasta;
	}
}