
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
			this.btnCancelar = new System.Windows.Forms.Button();
			this.lblFiltro = new System.Windows.Forms.Label();
			this.cboFiltro = new System.Windows.Forms.ComboBox();
			this.txtFiltro = new System.Windows.Forms.TextBox();
			this.btnFiltrar = new System.Windows.Forms.Button();
			this.btnEliminarFiltro = new System.Windows.Forms.Button();
			this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
			this.btnNuevoP = new System.Windows.Forms.Button();
			this.lblFechaDesde = new System.Windows.Forms.Label();
			this.lblFechaHasta = new System.Windows.Forms.Label();
			this.chkInactivos = new System.Windows.Forms.CheckBox();
			this.btnEditar = new System.Windows.Forms.Button();
			this.btnBorrar = new System.Windows.Forms.Button();
			this.lblParametro = new System.Windows.Forms.Label();
			this.cNroPresup = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cAccion = new System.Windows.Forms.DataGridViewButtonColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvConsultar)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvConsultar
			// 
			this.dgvConsultar.AllowUserToAddRows = false;
			this.dgvConsultar.AllowUserToDeleteRows = false;
			this.dgvConsultar.AllowUserToResizeRows = false;
			this.dgvConsultar.ColumnHeadersHeight = 30;
			this.dgvConsultar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvConsultar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNroPresup,
            this.cFecha,
            this.cCliente,
            this.cDescuento,
            this.cTotal,
            this.cAccion});
			this.dgvConsultar.Location = new System.Drawing.Point(12, 172);
			this.dgvConsultar.MultiSelect = false;
			this.dgvConsultar.Name = "dgvConsultar";
			this.dgvConsultar.ReadOnly = true;
			this.dgvConsultar.RowHeadersVisible = false;
			this.dgvConsultar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvConsultar.Size = new System.Drawing.Size(543, 429);
			this.dgvConsultar.TabIndex = 0;
			this.dgvConsultar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultar_CellContentClick);
			this.dgvConsultar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultar_CellDoubleClick);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(482, 604);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 26);
			this.btnCancelar.TabIndex = 1;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// lblFiltro
			// 
			this.lblFiltro.AutoSize = true;
			this.lblFiltro.Location = new System.Drawing.Point(12, 29);
			this.lblFiltro.Name = "lblFiltro";
			this.lblFiltro.Size = new System.Drawing.Size(34, 13);
			this.lblFiltro.TabIndex = 2;
			this.lblFiltro.Text = "Filtros";
			// 
			// cboFiltro
			// 
			this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFiltro.FormattingEnabled = true;
			this.cboFiltro.Location = new System.Drawing.Point(67, 25);
			this.cboFiltro.Name = "cboFiltro";
			this.cboFiltro.Size = new System.Drawing.Size(408, 21);
			this.cboFiltro.TabIndex = 3;
			this.cboFiltro.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged);
			// 
			// txtFiltro
			// 
			this.txtFiltro.Location = new System.Drawing.Point(80, 64);
			this.txtFiltro.Name = "txtFiltro";
			this.txtFiltro.Size = new System.Drawing.Size(200, 20);
			this.txtFiltro.TabIndex = 4;
			// 
			// btnFiltrar
			// 
			this.btnFiltrar.Location = new System.Drawing.Point(481, 24);
			this.btnFiltrar.Name = "btnFiltrar";
			this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
			this.btnFiltrar.TabIndex = 5;
			this.btnFiltrar.Text = "Filtrar";
			this.btnFiltrar.UseVisualStyleBackColor = true;
			this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
			// 
			// btnEliminarFiltro
			// 
			this.btnEliminarFiltro.Location = new System.Drawing.Point(12, 607);
			this.btnEliminarFiltro.Name = "btnEliminarFiltro";
			this.btnEliminarFiltro.Size = new System.Drawing.Size(105, 23);
			this.btnEliminarFiltro.TabIndex = 6;
			this.btnEliminarFiltro.Text = "Eliminar Filtro";
			this.btnEliminarFiltro.UseVisualStyleBackColor = true;
			this.btnEliminarFiltro.Click += new System.EventHandler(this.btnEliminarFiltro_Click);
			// 
			// dtpFechaDesde
			// 
			this.dtpFechaDesde.Location = new System.Drawing.Point(80, 90);
			this.dtpFechaDesde.Name = "dtpFechaDesde";
			this.dtpFechaDesde.Size = new System.Drawing.Size(200, 20);
			this.dtpFechaDesde.TabIndex = 7;
			// 
			// dtpFechaHasta
			// 
			this.dtpFechaHasta.Location = new System.Drawing.Point(355, 90);
			this.dtpFechaHasta.Name = "dtpFechaHasta";
			this.dtpFechaHasta.Size = new System.Drawing.Size(200, 20);
			this.dtpFechaHasta.TabIndex = 8;
			// 
			// btnNuevoP
			// 
			this.btnNuevoP.Location = new System.Drawing.Point(12, 138);
			this.btnNuevoP.Name = "btnNuevoP";
			this.btnNuevoP.Size = new System.Drawing.Size(75, 26);
			this.btnNuevoP.TabIndex = 9;
			this.btnNuevoP.Text = "Nuevo";
			this.btnNuevoP.UseVisualStyleBackColor = true;
			this.btnNuevoP.Click += new System.EventHandler(this.btnNuevoP_Click);
			// 
			// lblFechaDesde
			// 
			this.lblFechaDesde.AutoSize = true;
			this.lblFechaDesde.Location = new System.Drawing.Point(9, 94);
			this.lblFechaDesde.Name = "lblFechaDesde";
			this.lblFechaDesde.Size = new System.Drawing.Size(44, 13);
			this.lblFechaDesde.TabIndex = 10;
			this.lblFechaDesde.Text = "Desde: ";
			// 
			// lblFechaHasta
			// 
			this.lblFechaHasta.AutoSize = true;
			this.lblFechaHasta.Location = new System.Drawing.Point(305, 94);
			this.lblFechaHasta.Name = "lblFechaHasta";
			this.lblFechaHasta.Size = new System.Drawing.Size(41, 13);
			this.lblFechaHasta.TabIndex = 11;
			this.lblFechaHasta.Text = "Hasta: ";
			// 
			// chkInactivos
			// 
			this.chkInactivos.AutoSize = true;
			this.chkInactivos.Location = new System.Drawing.Point(456, 147);
			this.chkInactivos.Name = "chkInactivos";
			this.chkInactivos.Size = new System.Drawing.Size(99, 17);
			this.chkInactivos.TabIndex = 12;
			this.chkInactivos.Text = "Incluir inactivos";
			this.chkInactivos.UseVisualStyleBackColor = true;
			// 
			// btnEditar
			// 
			this.btnEditar.Location = new System.Drawing.Point(93, 138);
			this.btnEditar.Name = "btnEditar";
			this.btnEditar.Size = new System.Drawing.Size(75, 26);
			this.btnEditar.TabIndex = 13;
			this.btnEditar.Text = "Editar";
			this.btnEditar.UseVisualStyleBackColor = true;
			this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
			// 
			// btnBorrar
			// 
			this.btnBorrar.Location = new System.Drawing.Point(174, 138);
			this.btnBorrar.Name = "btnBorrar";
			this.btnBorrar.Size = new System.Drawing.Size(75, 26);
			this.btnBorrar.TabIndex = 14;
			this.btnBorrar.Text = "Borrar";
			this.btnBorrar.UseVisualStyleBackColor = true;
			this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
			// 
			// lblParametro
			// 
			this.lblParametro.AutoSize = true;
			this.lblParametro.Location = new System.Drawing.Point(9, 67);
			this.lblParametro.Name = "lblParametro";
			this.lblParametro.Size = new System.Drawing.Size(58, 13);
			this.lblParametro.TabIndex = 15;
			this.lblParametro.Text = "Parametro:";
			// 
			// cNroPresup
			// 
			this.cNroPresup.HeaderText = "Presupuesto";
			this.cNroPresup.Name = "cNroPresup";
			this.cNroPresup.ReadOnly = true;
			this.cNroPresup.Width = 85;
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
			// cDescuento
			// 
			this.cDescuento.HeaderText = "Descuento";
			this.cDescuento.Name = "cDescuento";
			this.cDescuento.ReadOnly = true;
			this.cDescuento.Width = 80;
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
			this.cAccion.Text = "Ver";
			this.cAccion.UseColumnTextForButtonValue = true;
			this.cAccion.Width = 75;
			// 
			// FrmConsultar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(569, 643);
			this.Controls.Add(this.lblParametro);
			this.Controls.Add(this.btnBorrar);
			this.Controls.Add(this.btnEditar);
			this.Controls.Add(this.chkInactivos);
			this.Controls.Add(this.lblFechaHasta);
			this.Controls.Add(this.lblFechaDesde);
			this.Controls.Add(this.btnNuevoP);
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
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Label lblFiltro;
		private System.Windows.Forms.ComboBox cboFiltro;
		private System.Windows.Forms.TextBox txtFiltro;
		private System.Windows.Forms.Button btnFiltrar;
		private System.Windows.Forms.Button btnEliminarFiltro;
		private System.Windows.Forms.DateTimePicker dtpFechaDesde;
		private System.Windows.Forms.DateTimePicker dtpFechaHasta;
		private System.Windows.Forms.Button btnNuevoP;
		private System.Windows.Forms.Label lblFechaDesde;
		private System.Windows.Forms.Label lblFechaHasta;
		private System.Windows.Forms.CheckBox chkInactivos;
		private System.Windows.Forms.Button btnEditar;
		private System.Windows.Forms.Button btnBorrar;
		private System.Windows.Forms.Label lblParametro;
		private System.Windows.Forms.DataGridViewTextBoxColumn cNroPresup;
		private System.Windows.Forms.DataGridViewTextBoxColumn cFecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn cCliente;
		private System.Windows.Forms.DataGridViewTextBoxColumn cDescuento;
		private System.Windows.Forms.DataGridViewTextBoxColumn cTotal;
		private System.Windows.Forms.DataGridViewButtonColumn cAccion;
	}
}