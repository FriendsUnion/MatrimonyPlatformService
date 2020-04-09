using MPS.Shared.Cryptography;
using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User
            {
                DOB = Convert.ToDateTime("12/02/1992"),
                Gender = "Male",
                Married = false,
                Name = "Shiva kumar subramanyam"
            };

            Console.WriteLine($"Data before encryption: Name: {user.Name}, DOB: {user.DOB}, Gender: {user.Gender}, Married: {user.Married} \n");
            var encryptedData = Cryptography.Encrypt<User>(user, "AkashBharathShivaSampath");
            Console.WriteLine($"Encrypted User data: Name: {encryptedData.Name}, DOB: {encryptedData.DOB}, Gender: {encryptedData.Gender}, Married: {encryptedData.Married} \n");
            var decrypteddata = Cryptography.Decrypt<User>(encryptedData, "AkashBharathShivaSampath");

            Console.WriteLine("\n plain text #! to be encrypted\n");
            Console.WriteLine($"Decrypted User data: Name: {decrypteddata.Name}, DOB: {decrypteddata.DOB}, Gender: {decrypteddata.Gender}, Married: {decrypteddata.Married} \n");
            var encryptedText = Cryptography.Encrypt("#!", "AkashBharathShivaSampath");
            Console.WriteLine($"Encrypted plain text: {encryptedText.ToString()}\n");
            var decryptedText = Cryptography.Decrypt(encryptedText, "AkashBharathShivaSampath");
            Console.WriteLine($"Decrypted plain text: {decryptedText.ToString()}\n");
            Console.ReadKey();
        }
    }
}
