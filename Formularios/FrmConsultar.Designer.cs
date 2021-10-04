
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvConsultar = new System.Windows.Forms.DataGridView();
			this.cNroPresup = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cFechaBaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cAccion = new System.Windows.Forms.DataGridViewButtonColumn();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.lblFiltro2 = new System.Windows.Forms.Label();
			this.cboFiltro = new System.Windows.Forms.ComboBox();
			this.txtFiltro = new System.Windows.Forms.TextBox();
			this.btnConsultar = new System.Windows.Forms.Button();
			this.btnEliminarFiltro = new System.Windows.Forms.Button();
			this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
			this.btnNuevoP = new System.Windows.Forms.Button();
			this.lblFechaDesde = new System.Windows.Forms.Label();
			this.lblFechaHasta = new System.Windows.Forms.Label();
			this.chkBajas = new System.Windows.Forms.CheckBox();
			this.btnEditar = new System.Windows.Forms.Button();
			this.btnBorrar = new System.Windows.Forms.Button();
			this.cboFiltrarFecha = new System.Windows.Forms.ComboBox();
			this.lblFiltro1 = new System.Windows.Forms.Label();
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
            this.cFechaBaja,
            this.cAccion});
			this.dgvConsultar.Location = new System.Drawing.Point(12, 164);
			this.dgvConsultar.MultiSelect = false;
			this.dgvConsultar.Name = "dgvConsultar";
			this.dgvConsultar.ReadOnly = true;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvConsultar.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvConsultar.RowHeadersVisible = false;
			this.dgvConsultar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvConsultar.Size = new System.Drawing.Size(643, 429);
			this.dgvConsultar.TabIndex = 0;
			this.dgvConsultar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultar_CellContentClick);
			this.dgvConsultar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultar_CellDoubleClick);
			this.dgvConsultar.SelectionChanged += new System.EventHandler(this.dgvConsultar_SelectionChanged);
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
			// cFechaBaja
			// 
			this.cFechaBaja.HeaderText = "Fecha Baja";
			this.cFechaBaja.Name = "cFechaBaja";
			this.cFechaBaja.ReadOnly = true;
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
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(580, 596);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 26);
			this.btnCancelar.TabIndex = 1;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// lblFiltro2
			// 
			this.lblFiltro2.AutoSize = true;
			this.lblFiltro2.Location = new System.Drawing.Point(58, 71);
			this.lblFiltro2.Name = "lblFiltro2";
			this.lblFiltro2.Size = new System.Drawing.Size(29, 13);
			this.lblFiltro2.TabIndex = 2;
			this.lblFiltro2.Text = "Filtro";
			// 
			// cboFiltro
			// 
			this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFiltro.FormattingEnabled = true;
			this.cboFiltro.Location = new System.Drawing.Point(93, 64);
			this.cboFiltro.Name = "cboFiltro";
			this.cboFiltro.Size = new System.Drawing.Size(179, 21);
			this.cboFiltro.TabIndex = 3;
			// 
			// txtFiltro
			// 
			this.txtFiltro.Location = new System.Drawing.Point(281, 64);
			this.txtFiltro.Name = "txtFiltro";
			this.txtFiltro.Size = new System.Drawing.Size(242, 20);
			this.txtFiltro.TabIndex = 4;
			// 
			// btnConsultar
			// 
			this.btnConsultar.Location = new System.Drawing.Point(529, 60);
			this.btnConsultar.Name = "btnConsultar";
			this.btnConsultar.Size = new System.Drawing.Size(75, 26);
			this.btnConsultar.TabIndex = 5;
			this.btnConsultar.Text = "Consultar";
			this.btnConsultar.UseVisualStyleBackColor = true;
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			// 
			// btnEliminarFiltro
			// 
			this.btnEliminarFiltro.Location = new System.Drawing.Point(12, 596);
			this.btnEliminarFiltro.Name = "btnEliminarFiltro";
			this.btnEliminarFiltro.Size = new System.Drawing.Size(105, 23);
			this.btnEliminarFiltro.TabIndex = 6;
			this.btnEliminarFiltro.Text = "Eliminar Filtro";
			this.btnEliminarFiltro.UseVisualStyleBackColor = true;
			this.btnEliminarFiltro.Click += new System.EventHandler(this.btnEliminarFiltro_Click);
			// 
			// dtpFechaDesde
			// 
			this.dtpFechaDesde.CustomFormat = "";
			this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaDesde.Location = new System.Drawing.Point(328, 9);
			this.dtpFechaDesde.Name = "dtpFechaDesde";
			this.dtpFechaDesde.Size = new System.Drawing.Size(109, 20);
			this.dtpFechaDesde.TabIndex = 7;
			// 
			// dtpFechaHasta
			// 
			this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaHasta.Location = new System.Drawing.Point(495, 9);
			this.dtpFechaHasta.Name = "dtpFechaHasta";
			this.dtpFechaHasta.Size = new System.Drawing.Size(109, 20);
			this.dtpFechaHasta.TabIndex = 8;
			// 
			// btnNuevoP
			// 
			this.btnNuevoP.Location = new System.Drawing.Point(12, 126);
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
			this.lblFechaDesde.Location = new System.Drawing.Point(278, 13);
			this.lblFechaDesde.Name = "lblFechaDesde";
			this.lblFechaDesde.Size = new System.Drawing.Size(44, 13);
			this.lblFechaDesde.TabIndex = 10;
			this.lblFechaDesde.Text = "Desde: ";
			// 
			// lblFechaHasta
			// 
			this.lblFechaHasta.AutoSize = true;
			this.lblFechaHasta.Location = new System.Drawing.Point(448, 13);
			this.lblFechaHasta.Name = "lblFechaHasta";
			this.lblFechaHasta.Size = new System.Drawing.Size(41, 13);
			this.lblFechaHasta.TabIndex = 11;
			this.lblFechaHasta.Text = "Hasta: ";
			// 
			// chkBajas
			// 
			this.chkBajas.AutoSize = true;
			this.chkBajas.Location = new System.Drawing.Point(264, 132);
			this.chkBajas.Name = "chkBajas";
			this.chkBajas.Size = new System.Drawing.Size(82, 17);
			this.chkBajas.TabIndex = 12;
			this.chkBajas.Text = "Incluir bajas";
			this.chkBajas.UseVisualStyleBackColor = true;
			// 
			// btnEditar
			// 
			this.btnEditar.Location = new System.Drawing.Point(93, 126);
			this.btnEditar.Name = "btnEditar";
			this.btnEditar.Size = new System.Drawing.Size(75, 26);
			this.btnEditar.TabIndex = 13;
			this.btnEditar.Text = "Editar";
			this.btnEditar.UseVisualStyleBackColor = true;
			this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
			// 
			// btnBorrar
			// 
			this.btnBorrar.Location = new System.Drawing.Point(174, 126);
			this.btnBorrar.Name = "btnBorrar";
			this.btnBorrar.Size = new System.Drawing.Size(75, 26);
			this.btnBorrar.TabIndex = 14;
			this.btnBorrar.Text = "Borrar";
			this.btnBorrar.UseVisualStyleBackColor = true;
			this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
			// 
			// cboFiltrarFecha
			// 
			this.cboFiltrarFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFiltrarFecha.FormattingEnabled = true;
			this.cboFiltrarFecha.Location = new System.Drawing.Point(93, 10);
			this.cboFiltrarFecha.Name = "cboFiltrarFecha";
			this.cboFiltrarFecha.Size = new System.Drawing.Size(179, 21);
			this.cboFiltrarFecha.TabIndex = 15;
			this.cboFiltrarFecha.SelectedIndexChanged += new System.EventHandler(this.cboFiltrarFecha_SelectedIndexChanged);
			// 
			// lblFiltro1
			// 
			this.lblFiltro1.AutoSize = true;
			this.lblFiltro1.Location = new System.Drawing.Point(58, 16);
			this.lblFiltro1.Name = "lblFiltro1";
			this.lblFiltro1.Size = new System.Drawing.Size(29, 13);
			this.lblFiltro1.TabIndex = 16;
			this.lblFiltro1.Text = "Filtro";
			// 
			// FrmConsultar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(666, 632);
			this.Controls.Add(this.lblFiltro1);
			this.Controls.Add(this.cboFiltrarFecha);
			this.Controls.Add(this.btnBorrar);
			this.Controls.Add(this.btnEditar);
			this.Controls.Add(this.chkBajas);
			this.Controls.Add(this.lblFechaHasta);
			this.Controls.Add(this.lblFechaDesde);
			this.Controls.Add(this.btnNuevoP);
			this.Controls.Add(this.dtpFechaHasta);
			this.Controls.Add(this.dtpFechaDesde);
			this.Controls.Add(this.btnEliminarFiltro);
			this.Controls.Add(this.btnConsultar);
			this.Controls.Add(this.txtFiltro);
			this.Controls.Add(this.cboFiltro);
			this.Controls.Add(this.lblFiltro2);
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
		private System.Windows.Forms.Label lblFiltro2;
		private System.Windows.Forms.ComboBox cboFiltro;
		private System.Windows.Forms.TextBox txtFiltro;
		private System.Windows.Forms.Button btnConsultar;
		private System.Windows.Forms.Button btnEliminarFiltro;
		private System.Windows.Forms.DateTimePicker dtpFechaDesde;
		private System.Windows.Forms.DateTimePicker dtpFechaHasta;
		private System.Windows.Forms.Button btnNuevoP;
		private System.Windows.Forms.Label lblFechaDesde;
		private System.Windows.Forms.Label lblFechaHasta;
		private System.Windows.Forms.CheckBox chkBajas;
		private System.Windows.Forms.Button btnEditar;
		private System.Windows.Forms.Button btnBorrar;
		private System.Windows.Forms.ComboBox cboFiltrarFecha;
		private System.Windows.Forms.Label lblFiltro1;
		private System.Windows.Forms.DataGridViewTextBoxColumn cNroPresup;
		private System.Windows.Forms.DataGridViewTextBoxColumn cFecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn cCliente;
		private System.Windows.Forms.DataGridViewTextBoxColumn cDescuento;
		private System.Windows.Forms.DataGridViewTextBoxColumn cTotal;
		private System.Windows.Forms.DataGridViewTextBoxColumn cFechaBaja;
		private System.Windows.Forms.DataGridViewButtonColumn cAccion;
	}
}