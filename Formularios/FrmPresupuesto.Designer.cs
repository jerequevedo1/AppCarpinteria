
namespace WinFormCarpinteria.Formularios
{
	partial class FrmPresupuesto
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
			this.lblNroPresupuesto = new System.Windows.Forms.Label();
			this.lblFecha = new System.Windows.Forms.Label();
			this.lblCliente = new System.Windows.Forms.Label();
			this.lblDescuento = new System.Windows.Forms.Label();
			this.lblSubtotal = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this.txtFecha = new System.Windows.Forms.TextBox();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.txtDescuento = new System.Windows.Forms.TextBox();
			this.cboProducto = new System.Windows.Forms.ComboBox();
			this.txtCantidad = new System.Windows.Forms.TextBox();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.dgvDetalles = new System.Windows.Forms.DataGridView();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColAccion = new System.Windows.Forms.DataGridViewButtonColumn();
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.txtSubtotal = new System.Windows.Forms.TextBox();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
			this.SuspendLayout();
			// 
			// lblNroPresupuesto
			// 
			this.lblNroPresupuesto.AutoSize = true;
			this.lblNroPresupuesto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNroPresupuesto.Location = new System.Drawing.Point(30, 22);
			this.lblNroPresupuesto.Name = "lblNroPresupuesto";
			this.lblNroPresupuesto.Size = new System.Drawing.Size(139, 19);
			this.lblNroPresupuesto.TabIndex = 0;
			this.lblNroPresupuesto.Text = "Presupuesto Nº: ";
			// 
			// lblFecha
			// 
			this.lblFecha.AutoSize = true;
			this.lblFecha.Location = new System.Drawing.Point(142, 55);
			this.lblFecha.Name = "lblFecha";
			this.lblFecha.Size = new System.Drawing.Size(37, 13);
			this.lblFecha.TabIndex = 1;
			this.lblFecha.Text = "Fecha";
			// 
			// lblCliente
			// 
			this.lblCliente.AutoSize = true;
			this.lblCliente.Location = new System.Drawing.Point(140, 94);
			this.lblCliente.Name = "lblCliente";
			this.lblCliente.Size = new System.Drawing.Size(39, 13);
			this.lblCliente.TabIndex = 2;
			this.lblCliente.Text = "Cliente";
			// 
			// lblDescuento
			// 
			this.lblDescuento.AutoSize = true;
			this.lblDescuento.Location = new System.Drawing.Point(109, 136);
			this.lblDescuento.Name = "lblDescuento";
			this.lblDescuento.Size = new System.Drawing.Size(70, 13);
			this.lblDescuento.TabIndex = 3;
			this.lblDescuento.Text = "% Descuento";
			// 
			// lblSubtotal
			// 
			this.lblSubtotal.AutoSize = true;
			this.lblSubtotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSubtotal.Location = new System.Drawing.Point(367, 395);
			this.lblSubtotal.Name = "lblSubtotal";
			this.lblSubtotal.Size = new System.Drawing.Size(94, 19);
			this.lblSubtotal.TabIndex = 4;
			this.lblSubtotal.Text = "Sub Total $";
			// 
			// lblTotal
			// 
			this.lblTotal.AutoSize = true;
			this.lblTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotal.Location = new System.Drawing.Point(402, 433);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(59, 19);
			this.lblTotal.TabIndex = 5;
			this.lblTotal.Text = "Total $";
			// 
			// txtFecha
			// 
			this.txtFecha.Enabled = false;
			this.txtFecha.Location = new System.Drawing.Point(201, 52);
			this.txtFecha.Name = "txtFecha";
			this.txtFecha.Size = new System.Drawing.Size(152, 20);
			this.txtFecha.TabIndex = 6;
			// 
			// txtCliente
			// 
			this.txtCliente.Location = new System.Drawing.Point(201, 91);
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.Size = new System.Drawing.Size(284, 20);
			this.txtCliente.TabIndex = 7;
			// 
			// txtDescuento
			// 
			this.txtDescuento.Location = new System.Drawing.Point(201, 133);
			this.txtDescuento.Name = "txtDescuento";
			this.txtDescuento.Size = new System.Drawing.Size(100, 20);
			this.txtDescuento.TabIndex = 8;
			// 
			// cboProducto
			// 
			this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboProducto.FormattingEnabled = true;
			this.cboProducto.Location = new System.Drawing.Point(34, 183);
			this.cboProducto.Name = "cboProducto";
			this.cboProducto.Size = new System.Drawing.Size(311, 21);
			this.cboProducto.TabIndex = 9;
			// 
			// txtCantidad
			// 
			this.txtCantidad.Location = new System.Drawing.Point(351, 183);
			this.txtCantidad.Name = "txtCantidad";
			this.txtCantidad.Size = new System.Drawing.Size(100, 20);
			this.txtCantidad.TabIndex = 10;
			this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(457, 181);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(110, 23);
			this.btnAgregar.TabIndex = 11;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// dgvDetalles
			// 
			this.dgvDetalles.AllowUserToAddRows = false;
			this.dgvDetalles.AllowUserToDeleteRows = false;
			this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ColProd,
            this.ColPrecio,
            this.ColCantidad,
            this.ColAccion});
			this.dgvDetalles.Location = new System.Drawing.Point(34, 210);
			this.dgvDetalles.Name = "dgvDetalles";
			this.dgvDetalles.ReadOnly = true;
			this.dgvDetalles.RowHeadersVisible = false;
			this.dgvDetalles.RowHeadersWidth = 51;
			this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDetalles.Size = new System.Drawing.Size(533, 169);
			this.dgvDetalles.TabIndex = 12;
			this.dgvDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalles_CellContentClick);
			// 
			// Id
			// 
			this.Id.HeaderText = "ID";
			this.Id.MinimumWidth = 6;
			this.Id.Name = "Id";
			this.Id.ReadOnly = true;
			this.Id.Visible = false;
			this.Id.Width = 125;
			// 
			// ColProd
			// 
			this.ColProd.HeaderText = "Producto";
			this.ColProd.MinimumWidth = 6;
			this.ColProd.Name = "ColProd";
			this.ColProd.ReadOnly = true;
			this.ColProd.Width = 230;
			// 
			// ColPrecio
			// 
			this.ColPrecio.HeaderText = "Precio";
			this.ColPrecio.MinimumWidth = 6;
			this.ColPrecio.Name = "ColPrecio";
			this.ColPrecio.ReadOnly = true;
			// 
			// ColCantidad
			// 
			this.ColCantidad.HeaderText = "Cantidad";
			this.ColCantidad.MinimumWidth = 6;
			this.ColCantidad.Name = "ColCantidad";
			this.ColCantidad.ReadOnly = true;
			// 
			// ColAccion
			// 
			this.ColAccion.HeaderText = "Acciones";
			this.ColAccion.MinimumWidth = 6;
			this.ColAccion.Name = "ColAccion";
			this.ColAccion.ReadOnly = true;
			this.ColAccion.Text = "Quitar";
			this.ColAccion.UseColumnTextForButtonValue = true;
			// 
			// txtTotal
			// 
			this.txtTotal.Enabled = false;
			this.txtTotal.Location = new System.Drawing.Point(467, 434);
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.Size = new System.Drawing.Size(100, 20);
			this.txtTotal.TabIndex = 14;
			// 
			// txtSubtotal
			// 
			this.txtSubtotal.Enabled = false;
			this.txtSubtotal.Location = new System.Drawing.Point(467, 395);
			this.txtSubtotal.Name = "txtSubtotal";
			this.txtSubtotal.Size = new System.Drawing.Size(100, 20);
			this.txtSubtotal.TabIndex = 13;
			// 
			// btnAceptar
			// 
			this.btnAceptar.Location = new System.Drawing.Point(361, 477);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(100, 23);
			this.btnAceptar.TabIndex = 15;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = true;
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(467, 477);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(100, 23);
			this.btnCancelar.TabIndex = 16;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// FrmPresupuesto
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(604, 512);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnAceptar);
			this.Controls.Add(this.txtTotal);
			this.Controls.Add(this.txtSubtotal);
			this.Controls.Add(this.dgvDetalles);
			this.Controls.Add(this.btnAgregar);
			this.Controls.Add(this.txtCantidad);
			this.Controls.Add(this.cboProducto);
			this.Controls.Add(this.txtDescuento);
			this.Controls.Add(this.txtCliente);
			this.Controls.Add(this.txtFecha);
			this.Controls.Add(this.lblTotal);
			this.Controls.Add(this.lblSubtotal);
			this.Controls.Add(this.lblDescuento);
			this.Controls.Add(this.lblCliente);
			this.Controls.Add(this.lblFecha);
			this.Controls.Add(this.lblNroPresupuesto);
			this.Name = "FrmPresupuesto";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Nuevo Presupuesto";
			this.Load += new System.EventHandler(this.FrmNuevoPresupuesto_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblNroPresupuesto;
		private System.Windows.Forms.Label lblFecha;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.Label lblDescuento;
		private System.Windows.Forms.Label lblSubtotal;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.TextBox txtFecha;
		private System.Windows.Forms.TextBox txtCliente;
		private System.Windows.Forms.TextBox txtDescuento;
		private System.Windows.Forms.ComboBox cboProducto;
		private System.Windows.Forms.TextBox txtCantidad;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.DataGridView dgvDetalles;
		private System.Windows.Forms.TextBox txtTotal;
		private System.Windows.Forms.TextBox txtSubtotal;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColProd;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColPrecio;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColCantidad;
		private System.Windows.Forms.DataGridViewButtonColumn ColAccion;
	}
}