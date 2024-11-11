namespace EditorGraficasVectoriales
{
    partial class FrmEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStrip1 = new ToolStrip();
            btnAbrir = new ToolStripButton();
            cmbTrazo = new ToolStripComboBox();
            btnDibujar = new ToolStripButton();
            btnSeleccionar = new ToolStripButton();
            btnBorrar = new ToolStripButton();
            btnGuardar = new ToolStripButton();
            btnLimpiar = new ToolStripButton();
            pnlDibujo = new Panel();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnAbrir, cmbTrazo, btnDibujar, btnSeleccionar, btnBorrar, btnGuardar, btnLimpiar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(753, 55);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAbrir
            // 
            btnAbrir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAbrir.Image = Properties.Resources.Abrir;
            btnAbrir.ImageScaling = ToolStripItemImageScaling.None;
            btnAbrir.ImageTransparentColor = Color.Magenta;
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(52, 52);
            btnAbrir.Text = "toolStripButton3";
            btnAbrir.ToolTipText = "Abrir";
            // 
            // cmbTrazo
            // 
            cmbTrazo.Items.AddRange(new object[] { "Línea", "Rectángulo", "Elipse" });
            cmbTrazo.Name = "cmbTrazo";
            cmbTrazo.Size = new Size(121, 55);
            cmbTrazo.ToolTipText = "Trazo";
            // 
            // btnDibujar
            // 
            btnDibujar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDibujar.Image = Properties.Resources.Editar;
            btnDibujar.ImageScaling = ToolStripItemImageScaling.None;
            btnDibujar.ImageTransparentColor = Color.Magenta;
            btnDibujar.Name = "btnDibujar";
            btnDibujar.Size = new Size(52, 52);
            btnDibujar.Text = "btnDibujar";
            btnDibujar.ToolTipText = "Dibujar";
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSeleccionar.Image = Properties.Resources.Seleccionar;
            btnSeleccionar.ImageScaling = ToolStripItemImageScaling.None;
            btnSeleccionar.ImageTransparentColor = Color.Magenta;
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(52, 52);
            btnSeleccionar.Text = "toolStripButton1";
            btnSeleccionar.ToolTipText = "Seleccionar";
            // 
            // btnBorrar
            // 
            btnBorrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnBorrar.Image = Properties.Resources.Eliminar;
            btnBorrar.ImageScaling = ToolStripItemImageScaling.None;
            btnBorrar.ImageTransparentColor = Color.Magenta;
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(52, 52);
            btnBorrar.Text = "toolStripButton1";
            btnBorrar.ToolTipText = "Borrar";
            // 
            // btnGuardar
            // 
            btnGuardar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnGuardar.Image = Properties.Resources.Guardar;
            btnGuardar.ImageScaling = ToolStripItemImageScaling.None;
            btnGuardar.ImageTransparentColor = Color.Magenta;
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(52, 52);
            btnGuardar.Text = "toolStripButton2";
            btnGuardar.ToolTipText = "Guardar";
            // 
            // btnLimpiar
            // 
            btnLimpiar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnLimpiar.Image = Properties.Resources.Limpiar;
            btnLimpiar.ImageScaling = ToolStripItemImageScaling.None;
            btnLimpiar.ImageTransparentColor = Color.Magenta;
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(52, 52);
            btnLimpiar.Text = "Limpiar";
            // 
            // pnlDibujo
            // 
            pnlDibujo.BackColor = Color.Black;
            pnlDibujo.Dock = DockStyle.Fill;
            pnlDibujo.Location = new Point(0, 55);
            pnlDibujo.Name = "pnlDibujo";
            pnlDibujo.Size = new Size(753, 353);
            pnlDibujo.TabIndex = 1;
            pnlDibujo.Paint += pnlDibujo_Paint;
            pnlDibujo.MouseDown += pnlDibujo_MouseDown;
            pnlDibujo.MouseMove += pnlDibujo_MouseMove;
            pnlDibujo.MouseUp += pnlDibujo_MouseUp;
            // 
            // FrmEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 408);
            Controls.Add(pnlDibujo);
            Controls.Add(toolStrip1);
            Name = "FrmEditor";
            Text = "Editor Gráficas";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripComboBox cmbTrazo;
        private ToolStripButton btnDibujar;
        private Panel pnlDibujo;
        private ToolStripButton btnSeleccionar;
        private ToolStripButton btnBorrar;
        private ToolStripButton btnGuardar;
        private ToolStripButton btnAbrir;
        private ToolStripButton btnLimpiar;
    }
}
