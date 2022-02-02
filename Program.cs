using System;

namespace imcPOO
{
    class ImcValores//dados do usuario;
    {
        private string nome;//"private" significa nao visivel/ acessivel para outras classes
        private double peso, altura;
        //
        public string nomePublico//maneira de "interagir com variavel privada";
        {//Dependendo do uso da variavel "nomePublico", sera usado o metodo GET(mostrar) ou SET(atribuir);
            get { return nome; }//Metodo que obtem valor direto da variavel privada; ex de uso: Console.WriteLine...
            set { nome = value; }//Metodo que atribui valor direto para variavel privada; ex de uso nomePublico =...
        }
        public double pesoPublico
        {
            get { return peso; }
            set { peso = value; }
        }
        public double alturaPublico
        {
            get { return altura; }
            set { altura = value; }
        }
        public ImcValores(string nome, double peso, double altura)//Construtora -> obriga que propriedades sejam passadas;
        {
            nomePublico = nome;
            pesoPublico = peso;
            alturaPublico = altura;
        }
    }
    class ImcResultado//calculo e retorno;
    {
        public double CalculaImc(ImcValores usuarioValores)
        {
            double imc;
            imc = usuarioValores.pesoPublico / (usuarioValores.alturaPublico * usuarioValores.alturaPublico);
            return imc;
        }

        public void MostraImc(double Imc, ImcValores usuarioValores)
        {
            Console.WriteLine(usuarioValores.nomePublico + " o seu imc é de " + Math.Round(Imc,2));//Nota-se que um método chama o outro
            MostraSituacao(Imc);
        }
        public void MostraSituacao(double imc)
        {
            if (imc < 20)
            {
                Console.WriteLine("Você está abaixo do peso ideal");
            }
            else
            {
                if (imc > 25)
                {
                    Console.WriteLine("Você está acima peso ideal");
                }
                else
                {
                    Console.WriteLine("Você está na faixa de peso ideal");
                }
            }
        }
    }
}

class Program//classe do programa principal(vem definida por padrao)(roda as outras)
{
    static void Main(string[] args)
    {

        Console.WriteLine("Digite o seu nome:");
        string Nome = Console.ReadLine(); //captura de valores
        //
        Console.WriteLine("Digite o peso:");
        double Peso = Convert.ToDouble(Console.ReadLine());
        //
        Console.WriteLine("Digite a altura:");
        double Altura = Convert.ToDouble(Console.ReadLine());
        //
        imcPOO.ImcValores usuarioValores = new imcPOO.ImcValores(Nome, Peso, Altura);

        imcPOO.ImcResultado usuarioResultado = new imcPOO.ImcResultado();
        usuarioResultado.MostraImc(usuarioResultado.CalculaImc(usuarioValores), usuarioValores);


    }
}
