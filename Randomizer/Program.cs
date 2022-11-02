using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Police.BD;
using System.Collections.ObjectModel;

namespace Randomizer
{
    public class Program
    {
        public static Case casee = new Case();

        public static Random caseLevel = new Random();

        public static ObservableCollection<Level> listLevel { get; set; }

        public static Random caseCrime = new Random();

        public static ObservableCollection<CrimeType> listCrime { get; set; }

        public static Random caseClient = new Random();

        public static ObservableCollection<Client> listClient { get; set; }

        public static int levelrnd;
        public static int crimernd;
        public static int clientrnd;

        static void Main(string[] args)
        {
            listLevel = new ObservableCollection<Level>(Bd_connection.connection.Level.ToList());
            listCrime = new ObservableCollection<CrimeType>(Bd_connection.connection.CrimeType.ToList());
            listClient = new ObservableCollection<Client>(Bd_connection.connection.Client.ToList());

            for (int i = 0; i <= 10; i++)
            {
                levelrnd = caseLevel.Next(1, listLevel.Count()+1);

                crimernd = caseCrime.Next(1, listCrime.Count()+1);

                clientrnd = caseClient.Next(1, listClient.Count()+1);

                casee.IdLevel = levelrnd;
                casee.IdClient = clientrnd;
                casee.IdCrimeType = crimernd;
                casee.IsDeleted = false;

                Bd_connection.connection.Case.Add(casee);
                Bd_connection.connection.SaveChanges();

                Console.WriteLine("ADDED!");
            }
            Console.ReadKey();
        }
    }
}
