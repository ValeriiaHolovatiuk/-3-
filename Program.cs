using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class CaesarCrypt
    {
        const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private string CodeEncrypt(string text, int key)
        {
            string fullAlphabetEnglish = EnglishAlphabet + EnglishAlphabet.ToLower();
            int sizeEnglishAlphabet = fullAlphabetEnglish.Length;
            string retVal = "";

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                int index = fullAlphabetEnglish.IndexOf(c);

                if (index < 0)
                {
                    retVal += c.ToString();
                }
                else
                {
                    int codeIndex = (sizeEnglishAlphabet + index + key) % sizeEnglishAlphabet;
                    retVal += fullAlphabetEnglish[codeIndex];
                }
            }

            return retVal;
        }

        public string Encrypt(string plainMessage, int key)
        {
           return CodeEncrypt(plainMessage, key);
        }

        public string Decrypt(string encryptedMessage, int key)
        {
            return CodeEncrypt(encryptedMessage, -key);
        }
    }

    class AtbashCrypt
    {
        const string EnglishAlphabet = "abcdefghijklmnopqrstuvwxyz";
        
        private string Reverse(string inputText)
        {
            string reversedText = string.Empty;

            foreach(char s in inputText)
            {
                reversedText = s + reversedText;
            }

            return reversedText;
        }

        private string EncryptDecrypt(string text, string symbols, string cipher)
        {
            text = text.ToLower();
            int index;

            string outputText = string.Empty;

            for(int i = 0; i < text.Length; i++)
            {
                index = symbols.IndexOf(text[i]);
                
                if(index >= 0)
                {
                    outputText += cipher[index].ToString();
                }
            }

            return outputText;
        }

        public string EncryptText(string plainText)
        {
            return EncryptDecrypt(plainText, EnglishAlphabet, Reverse(EnglishAlphabet));
        }

        public string DecryptText(string encreptedText)
        {
            return EncryptDecrypt(encreptedText, Reverse(EnglishAlphabet), EnglishAlphabet);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CaesarCrypt caesarCrypt = new CaesarCrypt();
            AtbashCrypt atbashCrypt = new AtbashCrypt();

            Console.Write("Введите текст на английском: ");
            string message = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Введите ключ: ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Шифруем и расшифровываем текст с помощью шифра Цезаря.");

            string encryptedTextCaesar = caesarCrypt.Encrypt(message, key);

            Console.WriteLine("Зашифрованное сообщение: {0}", encryptedTextCaesar);
            Console.WriteLine("Расшифрованное сообщение: {0}", caesarCrypt.Decrypt(encryptedTextCaesar, key));

            Console.WriteLine("Шифруем и расшифровываем текст с помощью шифра Атбаш.");

            string encryptedTextAtbash = atbashCrypt.EncryptText(message);
            Console.WriteLine("Зашифрованное сообщение: {0}", encryptedTextAtbash);

            string decryptedTextAtbash = atbashCrypt.DecryptText(encryptedTextAtbash);
            Console.WriteLine("Расшифрованное сообщение: {0}", decryptedTextAtbash);
        }
    }
}
