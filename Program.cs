using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    /*Ejercicio en el que vamos a definir la clase abstracta figura 
    y posteriormente vamos a crear 3 figuras para calcuar su area y perimetro.
    El diagrama del ejercicio lo encontrareis en el repositorio.*/

    //Clase abstracta figura.
    abstract class Figura
    {
        //Tipo enumerado para indicar el color de la figura.
        public enum Color
        {
        Rojo, Azul, Verde, Naranja, Blanco, Violeta, Marrón, Amarillo, Negro
        }
        //Atributos, accesores y mutadores de la clase abstracta.
        private Color color;
        private Color GetColor() => color;
        public void SetColor(in Color color) => this.color = color;
        protected Figura(in Color color) => SetColor(color);

        //Métodos abstractos de la clase abstracta Figura. Al ser abstractos, 
        //estos se deberán implementar en las siguientes clases que herden de la clase abstracta figura obligatoriamente.
        //Como queremos calcular el area y el perímetro de todas las figuras, es lógico que estos métodos sean abstractos,
        //y obligatorios en todas las clases hijas.
        abstract public double Area();
        abstract public double Perimetro();

        //Invalidamos el ToString para la salida por consola.
        public override string ToString() => $"Color: {GetColor()}\nArea: {Area()} cm2\nPerímetro: {Perimetro()} cm";
    }
    //Clase Circulo que hereda de la clase Figura.
    class Circulo : Figura
    {
        //Atributos, accesores, mutadores y contructor de la clase Circulo.
        private double radio_cm;
        public void SetRadio(in double radio_cm) => this.radio_cm = radio_cm;
        private double GetRadio() => radio_cm;
        public Circulo(in Color color, in double radio_cm) : base(color)
        {
            SetRadio(radio_cm);
        }
        //Métodos obligatorios de la clase abstracta Figura. 
        //Sino los implementamos, el IDE nos marcaría un error.
        //Se pueden implementar automáticamente, aunque en este caso a nosotros no nos interesa, ya que queremos definir el método con el cáluclo
        //del area y el perimetro de la figura. En este caso, un circulo.
        public override double Area() => Math.PI * Math.Pow(GetRadio(), 2);
        public override double Perimetro() => Math.PI * GetRadio() * 2;
        
        //Invalidamos el método ToString para la salida por consola, más la salida ya implementada de la clase abstracta Figura.
        public override string ToString() => $"- Circulo\nRadio: {GetRadio()} cm\n{base.ToString()}";
    }
    class Cuadrado : Figura
    {
        //Esta clase es igual que la de Circulo, pero con los calculos de un Cuadrado.
        private double lado_cm;
        public void SetLado(in double lado_cm) => this.lado_cm = lado_cm;
        private double GetLado() => lado_cm;
        public Cuadrado(in Color color, in double lado_cm) : base(color)
        {
            SetLado(lado_cm);
        }
        public override double Area() => GetLado() * GetLado();
        public override double Perimetro() => GetLado() * 4;
        public override string ToString() => $"- Cuadrado\nLado: {GetLado()} cm\n{base.ToString()}";
    }
    class Rombo : Figura
    {
        //Esta clase es igual que la de Ciruclo y Cuadrado, pero con los calculos de un Rombo.
        private double diagonal1_cm;
        private double diagonal2_cm;
        public void SetDiagonal1(in double diagonal1_cm) => this.diagonal1_cm = diagonal1_cm;
        private double GetDiagonal1() => diagonal1_cm;
        public void SetDiagonal2(in double diagonal2_cm) => this.diagonal2_cm = diagonal2_cm;
        private double GetDiagonal2() => diagonal2_cm;
        private double GetLado() => Math.Sqrt(Math.Pow(GetDiagonal1() / 2, 2) + Math.Pow(GetDiagonal2() / 2, 2));
        public Rombo(in Color color, in double diagonal1_cm, in double diagonal2_cm) : base(color)
        {
            SetDiagonal1(diagonal1_cm);
            SetDiagonal2(diagonal2_cm);
        }
        public override double Area() => GetDiagonal1() * GetDiagonal2() / 2;
        public override double Perimetro() => GetLado() * 4;
        public override string ToString() => $"- Rombo\nDiagonal 1: {GetDiagonal1()} cm\nDiagonal 2: {GetDiagonal2()} cm\nLado: {GetLado()} cm\n{base.ToString()}";
    }
    class Program
    {
        static void Main(string[] args)
        {
            //El poliformismo de datos lo vamos a poder realizar, pero no vamos a poder crear ninguna figura directamente.
            //Esto quiere decir, que no podemos instanciar objetos de la clase Figura, ya que es una clase abstracta.
            //Sin embargo, podremos definir objetos para sus subclases.
            Figura[] figuras = new Figura[]
            {
                new Cuadrado(Figura.Color.Rojo, 5),
                new Rombo(Figura.Color.Azul, 6, 2),
                new Circulo(Figura.Color.Verde, 8)
            };
            foreach(Figura f in figuras){
                Console.WriteLine(f);
            }
        }
    }
}
