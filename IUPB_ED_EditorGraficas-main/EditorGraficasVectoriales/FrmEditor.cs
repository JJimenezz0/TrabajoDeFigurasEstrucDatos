using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EditorGraficasVectoriales
{
    public partial class FrmEditor : Form
    {
        private Point puntoInicial;
        private Point puntoFinal;
        private bool dibujando = false;
        private List<Figura> figuras = new List<Figura>();
        private Figura figuraSeleccionada = null;
        private string modoActual = "Ninguno";
        private bool moviendo = false;

        public FrmEditor()
        {
            InitializeComponent();
            cmbTrazo.SelectedIndex = 0;
            btnGuardar.Click += BtnGuardar_Click;
            btnAbrir.Click += BtnAbrir_Click;
            btnDibujar.Click += (s, e) => { CambiarModo("Dibujar"); };
            btnSeleccionar.Click += (s, e) => { CambiarModo("Seleccionar"); };
            btnBorrar.Click += (s, e) => { CambiarModo("Borrar"); };
            btnLimpiar.Click += (s, e) => { Limpiar(); };
        }

        private void Limpiar()
        {
            figuras.Clear();
            figuraSeleccionada = null;
            pnlDibujo.Invalidate();
        }

        private void pnlDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoActual == "Dibujar" && e.Button == MouseButtons.Left)
            {
                puntoInicial = e.Location;
                dibujando = true;
            }
            else if (modoActual == "Seleccionar" && e.Button == MouseButtons.Left)
            {
                foreach (var figura in figuras)
                {
                    if (figura.Contains(e.Location))
                    {
                        if (figuraSeleccionada != null)
                        {
                            figuraSeleccionada.Color = Color.White;
                        }
                        figuraSeleccionada = figura;
                        figuraSeleccionada.Color = Color.Yellow;
                        moviendo = true;
                        pnlDibujo.Invalidate();
                        break;
                    }
                }
            }
            else if (modoActual == "Borrar" && e.Button == MouseButtons.Left)
            {
                for (int i = figuras.Count - 1; i >= 0; i--)
                {
                    if (figuras[i].Contains(e.Location))
                    {
                        figuras.RemoveAt(i);
                        figuraSeleccionada = null;
                        pnlDibujo.Invalidate();
                        break;
                    }
                }
            }
        }

        private void pnlDibujo_MouseMove(object sender, MouseEventArgs e)
        {
            if (dibujando)
            {
                puntoFinal = e.Location;
                pnlDibujo.Invalidate();
            }
            else if (moviendo && figuraSeleccionada != null)
            {
                figuraSeleccionada.Mover(e.Location);
                pnlDibujo.Invalidate();
            }
        }

        private void pnlDibujo_MouseUp(object sender, MouseEventArgs e)
        {
            if (modoActual == "Dibujar" && e.Button == MouseButtons.Left)
            {
                dibujando = false;
                puntoFinal = e.Location;
                Figura figura = null;
                switch (cmbTrazo.SelectedIndex)
                {
                    case 0:
                        figura = new Linea(puntoInicial, puntoFinal);
                        break;
                    case 1:
                        figura = new Rectangulo(puntoInicial, puntoFinal);
                        break;
                    case 2:
                        figura = new Elipse(puntoInicial, puntoFinal);
                        break;
                }
                if (figura != null)
                {
                    figuras.Add(figura);
                }
                pnlDibujo.Invalidate();
            }
            else if (modoActual == "Seleccionar" && e.Button == MouseButtons.Left)
            {
                moviendo = false;
            }
        }

        private void pnlDibujo_Paint(object sender, PaintEventArgs e)
        {
            foreach (var figura in figuras)
            {
                figura.Dibujar(e.Graphics);
            }
            if (dibujando)
            {
                using (Pen pen = new Pen(Color.White, 2))
                {
                    switch (cmbTrazo.SelectedIndex)
                    {
                        case 0:
                            e.Graphics.DrawLine(pen, puntoInicial, puntoFinal);
                            break;
                        case 1:
                            e.Graphics.DrawRectangle(pen, new RectangleF(puntoInicial,
                                new Size(puntoFinal.X - puntoInicial.X, puntoFinal.Y - puntoInicial.Y)));
                            break;
                        case 2:
                            e.Graphics.DrawEllipse(pen, new RectangleF(puntoInicial,
                                new Size(puntoFinal.X - puntoInicial.X, puntoFinal.Y - puntoInicial.Y)));
                            break;
                    }
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivos de texto (*.txt)|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(sfd.FileName))
                    {
                        foreach (var figura in figuras)
                        {
                            writer.WriteLine(figura.Guardar());
                        }
                    }
                }
            }
        }

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de texto (*.txt)|*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    figuras.Clear();
                    using (StreamReader reader = new StreamReader(ofd.FileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            switch (parts[0])
                            {
                                case "Linea":
                                    figuras.Add(new Linea(new Point(int.Parse(parts[1]), int.Parse(parts[2])),
                                                           new Point(int.Parse(parts[3]), int.Parse(parts[4]))));
                                    break;
                                case "Rectangulo":
                                    figuras.Add(new Rectangulo(new Point(int.Parse(parts[1]), int.Parse(parts[2])),
                                                                new Point(int.Parse(parts[1]) + int.Parse(parts[3]),
                                                                          int.Parse(parts[2]) + int.Parse(parts[4]))));
                                    break;
                                case "Elipse":
                                    figuras.Add(new Elipse(new Point(int.Parse(parts[1]), int.Parse(parts[2])),
                                                            new Point(int.Parse(parts[1]) + int.Parse(parts[3]),
                                                                      int.Parse(parts[2]) + int.Parse(parts[4]))));
                                    break;
                            }
                        }
                    }
                    pnlDibujo.Invalidate();
                }
            }
        }

        private void CambiarModo(string nuevoModo)
        {
            if (figuraSeleccionada != null)
            {
                figuraSeleccionada.Color = Color.White;
                figuraSeleccionada = null;
                pnlDibujo.Invalidate();
            }
            modoActual = nuevoModo;
        }
    }
}