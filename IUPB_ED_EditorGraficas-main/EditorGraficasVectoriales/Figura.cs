using System;
using System.Drawing;

public abstract class Figura
{
    public Color Color { get; set; } = Color.White; // Color por defecto
    public abstract void Dibujar(Graphics g);
    public abstract string Guardar();
    public abstract bool Contains(Point point); // Método para verificar si un punto está dentro de la figura
    public abstract void Mover(Point nuevaPosicion); // Método para mover la figura
}

public class Linea : Figura
{
    private Point puntoInicial;
    private Point puntoFinal;

    public Linea(Point inicial, Point final)
    {
        puntoInicial = inicial;
        puntoFinal = final;
    }

    public override void Dibujar(Graphics g)
    {
        using (Pen pen = new Pen(Color, 2)) // Usar el color de la figura
        {
            g.DrawLine(pen, puntoInicial, puntoFinal);
        }
    }

    public override string Guardar()
    {
        return $"Linea,{puntoInicial.X},{puntoInicial.Y},{puntoFinal.X},{puntoFinal.Y}";
    }

    public override bool Contains(Point point)
    {
        // Comprobar si el punto está cerca de la línea
        float distance = Math.Abs((puntoFinal.Y - puntoInicial.Y) * point.X - (puntoFinal.X - puntoInicial.X) * point.Y + puntoFinal.X * puntoInicial.Y - puntoFinal.Y * puntoInicial.X) /
                         (float)Math.Sqrt(Math.Pow(puntoFinal.Y - puntoInicial.Y, 2) + Math.Pow(puntoFinal.X - puntoInicial.X, 2));
        return distance < 5; // Ajusta el umbral según sea necesario
    }

    public override void Mover(Point nuevaPosicion)
    {
        // Calcular el desplazamiento
        int deltaX = nuevaPosicion.X - (puntoInicial.X + (puntoFinal.X - puntoInicial.X) / 2);
        int deltaY = nuevaPosicion.Y - (puntoInicial.Y + (puntoFinal.Y - puntoInicial.Y) / 2);

        // Mover la línea
        puntoInicial = new Point(puntoInicial.X + deltaX, puntoInicial.Y + deltaY);
        puntoFinal = new Point(puntoFinal.X + deltaX, puntoFinal.Y + deltaY);
    }
}

public class Rectangulo : Figura
{
    private Rectangle rect;

    public Rectangulo(Point inicial, Point final)
    {
        rect = new Rectangle(inicial.X, inicial.Y, final.X - inicial.X, final.Y - inicial.Y);
    }

    public override void Dibujar(Graphics g)
    {
        using (Pen pen = new Pen(Color, 2)) // Usar el color de la figura
        {
            g.DrawRectangle(pen, rect);
        }
    }

    public override string Guardar()
    {
        return $"Rectangulo,{rect.X},{rect.Y},{rect.Width},{rect.Height}";
    }

    public override bool Contains(Point point)
    {
        return rect.Contains(point);
    }

    public override void Mover(Point nuevaPosicion)
    {
        // Calcular el desplazamiento
        int deltaX = nuevaPosicion.X - (rect.X + rect.Width / 2);
        int deltaY = nuevaPosicion.Y - (rect.Y + rect.Height / 2);

        // Mover el rectángulo
        rect.X += deltaX;
        rect.Y += deltaY;
    }
}

public class Elipse : Figura
{
    private Rectangle rect;

    public Elipse(Point inicial, Point final)
    {
        rect = new Rectangle(inicial.X, inicial.Y, final.X - inicial.X, final.Y - inicial.Y);
    }

    public override void Dibujar(Graphics g)
    {
        using (Pen pen = new Pen(Color, 2)) // Usar el color de la figura
        {
            g.DrawEllipse(pen, rect);
        }
    }

    public override string Guardar()
    {
        return $"Elipse,{rect.X},{rect.Y},{rect.Width},{rect.Height}";
    }

    public override bool Contains(Point point)
    {
        float a = (rect.Width / 2f);
        float b = (rect.Height / 2f);
        float h = rect.X + a;
        float k = rect.Y + b;

        // Fórmula de la elipse
        return Math.Pow((point.X - h) / a, 2) + Math.Pow((point.Y - k) / b, 2) <= 1;
    }

    public override void Mover(Point nuevaPosicion)
    {
        // Calcular el desplazamiento
        int deltaX = nuevaPosicion.X - (rect.X + rect.Width / 2);
        int deltaY = nuevaPosicion.Y - (rect.Y + rect.Height / 2);

        // Mover la elipse
        rect.X += deltaX;
        rect.Y += deltaY;
    }
}