using System;
using System.Collections.Generic;
using System.Text;

namespace CakeFactory.CakeFactory
{
   public abstract class Utility
   {
        public static int id = 1;
        public static Random r = new Random();
        public static string[] addreses = { "Sofia, Lulin 10, blok 726", "Plovdiv, kv.Kurshaka, bl10", "Varna, kv Asparuhovo,str.Saturn 10", "Sofia, Lozenec, str.Vishneva 15" };
        public static string[] names = {"Ani", "Lusi", "Petyr", "Goro", "Misho", "Niki","Yana", "Mina" };
        public static string[] telephones = { "088245678", "08974512", "08236145", "089512369", "098763145"};
        public static string[] eventNames = { "Teambillding", "Chrismas Party", "Weekend", "Annuversary", "BirthdayDay" };

        public static int GetRandomInt(int min,int max)
        {
            return r.Next(min, max);
        }

        public static bool GetRandomBoolean()
        {
            return r.Next(2) == 1;
        }

        public static double GetRandomDouble(double min, double max)
        {
            return r.NextDouble() * (max - min) + min;
        }

        public static int GetOrderId()
        {
            return id++;
        }

        public static string GetRandomAddress()
        {
            return addreses[r.Next(addreses.Length)];
        }

        public static string GetRandomName()
        {
            int n = r.Next(names.Length);
            return (names[n] + n);
        }

        public static string GetRandomTelephone()
        {
            int n = r.Next(telephones.Length);
            return (telephones[n] + n);
        }

        public static string GetRandomEventName()
        {
            int i = r.Next(eventNames.Length);
            return eventNames[i];
        }

        public static bool ValidateString(string text)
        {
            if (string.IsNullOrEmpty(text) || text.Length > 150)
            {
                return false;
            }
            return true;
        }

        public static double CalculatePrivateClientDiscount()
        {
            double sum = 0;
            int number = Utility.GetRandomInt(1, 4);
            for (int i = 0; i < number; i++)
            {
                sum += Utility.GetRandomDouble(10, 30);
            }
            return sum;
        }
    }
}
