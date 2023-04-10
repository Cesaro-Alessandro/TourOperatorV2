using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DizionarioV20
{
    public class TourOperator : IDictionary
    {
        private Dictionary<string, string> cl;
        private string nextClientCode;
        private string clientName;
        private string clientDestination;
        // metodi pubblici
        
        public TourOperator(string initialClientCode)
        {
            cl = new Dictionary<string, string>();
            this.nextClientCode = initialClientCode;
        }
        //prvoid
        void IDictionary.insert(IComparable key, object attribute)
        {
            string[] temp = ((string)attribute).Split('/');
            clientName = temp[0];
            clientDestination = temp[1];
            //nextClientCode = (string)attribute;
            cl.Add((string)key, attribute.ToString());
        }
        object IDictionary.find(IComparable key)
        {
            if(cl.TryGetValue(((string)key), out string dati))
            {
                return dati;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        object IDictionary.remove(IComparable key)
        {
            if (((IDictionary)this).find(key) != key)
            {
                cl.Remove((string)key);
                return cl;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        internal Dictionary<string, string> GetCl()
        {
            return this.cl;
        }
        public void add(string nome, string dest)
        {
            string[] nuovoCodice;
            int numero;
            char lettera;
            ((IDictionary)this).insert(nextClientCode, nome+ "/" +dest);
            nuovoCodice = nextClientCode.Split(nextClientCode[0]);
            numero = Convert.ToInt32(nuovoCodice[1]);
            lettera = nextClientCode[0];
            if(numero > 999)
            {
                numero = 000;
                lettera++;
            }
            else
            {
                numero++;
            }
            nextClientCode = $"{lettera}{numero}";
        }
        public string toString()
        {
            return string.Format($"{nextClientCode} : {clientName} : {clientDestination}");
        }
        public static void main(string[] args)
        {
            TourOperator cliente = new TourOperator(Console.ReadLine());
            Console.WriteLine("Inserisci valori (0 per terminare, 1 per continuare)");
            do
            {
                Console.WriteLine("Inserisci");
                cliente.add(Console.ReadLine(), Console.ReadLine());
                Console.WriteLine("Vuoi continuare?");
            }
            while (Console.ReadLine() != "0");
            cliente.toString();
            Console.ReadLine();
        }
        // classi interne
        private class Client
        {
            string name; // nome del cliente
            string dest; // destinazione del viaggio
            Client(string aName, string aDest)
            {
                name = aName;
                dest = aDest;
            }
        }

        private class Coppia : IComparable
        {
            string code;
            Client client;
            Coppia(string aCode, Client aClient)
            {
                code = aCode;
                client = aClient;
            }
            public int CompareTo(object obj)
            {
                Coppia tmpC = (Coppia)obj;
                return code.CompareTo(tmpC.code);
            }
        }

    }
}
