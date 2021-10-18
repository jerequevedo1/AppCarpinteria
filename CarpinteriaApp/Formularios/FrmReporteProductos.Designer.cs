
namespace WinFormCarpinteria.Formularios
{
	partial class FrmReporteProductos
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
			this.components = new System.ComponentModel.Container();
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.dSProductos = new WinFormCarpinteria.Reportes.DSProductos();
			this.tPRODUCTOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.t_PRODUCTOSTableAdapter = new WinFormCarpinteria.Reportes.DSProductosTableAdapters.T_PRODUCTOSTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.dSProductos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tPRODUCTOSBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// reportViewer1
			// 
			this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			reportDataSource1.Name = "DataSet1";
			reportDataSource1.Value = this.tPRODUCTOSBindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "WinFormCarpinteria.Reportes.rptProductos.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(0, 0);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ServerReport.BearerToken = null;
			this.reportViewer1.Size = new System.Drawing.Size(800, 450);
			this.reportViewer1.TabIndex = 0;
			// 
			// dSProductos
			// 
			this.dSProductos.DataSetName = "DSProductos";
			this.dSProductos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// tPRODUCTOSBindingSource
			// 
			this.tPRODUCTOSBindingSource.DataMember = "T_PRODUCTOS";
			this.tPRODUCTOSBindingSource.DataSource = this.dSProductos;
			// 
			// t_PRODUCTOSTableAdapter
			// 
			this.t_PRODUCTOSTableAdapter.ClearBeforeFill = true;
			// 
			// FrmReporteProductos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.reportViewer1);
			this.Name = "FrmReporteProductos";
			this.Text = "FrmReporteProductos";
			this.Load += new System.EventHandler(this.FrmReporteProductos_Load);
			((System.ComponentModel.ISupportInitialize)(this.dSProductos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tPRODUCTOSBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private Reportes.DSProductos dSProductos;
		private System.Windows.Forms.BindingSource tPRODUCTOSBindingSource;
		private Reportes.DSProductosTableAdapters.T_PRODUCTOSTableAdapter t_PRODUCTOSTableAdapter;
	}
}