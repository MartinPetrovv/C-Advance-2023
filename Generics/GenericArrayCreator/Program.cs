
using System.Net.Mail;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main()
        {
            string[] list = ArrayCreator.Create(300, "Dimitrichko");

            Console.WriteLine(string.Join(", ", list));


        }


    }


}

