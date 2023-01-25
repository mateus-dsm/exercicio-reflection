using System.Reflection;

internal class Program
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Genero { get; set; }
        public long CPF { get; set; }

        public Pessoa()
        {

        }

        public Pessoa(string nome, int idade, char genero, long cpf)
        {
            Nome = nome;
            Idade = idade;
            Genero = genero;
            CPF = cpf;
        }
    }

    public static void ReturnPropertiesAndMethods<T>(T obj)
    {
        Console.WriteLine("Propriedades do objeto: ");

        PropertyInfo[] propertyInfos = typeof(T).GetProperties();
        foreach (PropertyInfo propertyInfo in propertyInfos)
        {
            Console.WriteLine($"  {propertyInfo.Name}, do tipo '{propertyInfo.PropertyType.Name}', com valor '{propertyInfo.GetValue(obj)}'.");
        }

        Console.WriteLine("Metodos do objeto: ");

        MethodInfo[] methodInfos = typeof(T).GetMethods();
        foreach (MethodInfo methodInfo in methodInfos)
        {
            Console.WriteLine($"  {methodInfo.Name}, que retorna o tipo '{methodInfo.ReturnType}'.");
        }
    }

    public T CreateAnInstanceOfTheObject<T>(T obj)
    {
        T newInstance = Activator.CreateInstance<T>();
        return newInstance;
    }

    static void Main(string[] args)
    {
        var program = new Program();

        Pessoa pessoa = new Pessoa("Mateus", 22, 'M', 12345678910);
        Pessoa novaPessoa = program.CreateAnInstanceOfTheObject(pessoa);
        Console.WriteLine("Objeto original: ");
        ReturnPropertiesAndMethods(pessoa);
        Console.WriteLine();
        Console.WriteLine("Nova instancia: ");
        ReturnPropertiesAndMethods(novaPessoa);
    }
}