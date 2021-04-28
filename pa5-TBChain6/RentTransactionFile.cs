using System;
using System.IO;

namespace pa5_TBChain6
{
    public class RentTransactionFile
    {
        public static RentTransaction[] GetAllRentTransactions()
        {
            RentTransaction[] myTransactions = new RentTransaction[50];
            RentTransaction.SetCount(0);

            StreamReader inFile = new StreamReader("transactions.txt"); // open file
            string line = inFile.ReadLine(); // priming read

            while(line != null) // condition check
            {
                string[] data = line.Split('#');
                double tempRentalAmt = double.Parse(data[3]);
                DateTime tempRentalDate = DateTime.Parse(data[4]);
                DateTime tempCheckOutDate = DateTime.Parse(data[5]);

                myTransactions[RentTransaction.GetCount()] = new RentTransaction(data[0], data[1], data[2], tempRentalAmt, tempRentalDate, tempCheckOutDate, data[6]);

                RentTransaction.IncCount();
                line = inFile.ReadLine(); // update read
            }

            inFile.Close(); // close file
            return myTransactions;
        }
        public static void WriteTransactions(RentTransaction[] myTransactions)
        {
            StreamWriter outFile = new StreamWriter("transactions.txt"); //initialize writer for transactions

            for (int i = 0; i < RentTransaction.GetCount(); i++) 
            {
                outFile.WriteLine(myTransactions[i].ToFile()); // outputs the ToFile
            }

            outFile.Close(); //closes writer
        }
    }
}