using System;
using System.IO;

namespace pa5_TBChain6
{
    public class ListingFile
    {
        public static Listing[] GetAllListings()
        {
            Listing[] myListings = new Listing[50];
            Listing.SetCount(0);

            StreamReader inFile = new StreamReader("listings.txt"); // open file
            string line = inFile.ReadLine(); // priming read

            while(line != null) // condition check
            {
                string[] data = line.Split('#');
                DateTime tempTime = DateTime.Parse(data[2]);
                double tempPrice = double.Parse(data[3]);
                bool tempAvlb = bool.Parse(data[5]);

                myListings[Listing.GetCount()] = new Listing(data[0], data[1], tempTime, tempPrice, data[4], tempAvlb);

                Listing.IncCount();
                line = inFile.ReadLine(); // update read
            }
            inFile.Close(); // close file
            return myListings;
        }
        public static void WriteListings(Listing[] myListings)
        {
            StreamWriter outFile = new StreamWriter("listings.txt"); //initialize writer for listings

            for (int i = 0; i < Listing.GetCount(); i++) 
            {
                outFile.WriteLine(myListings[i].ToFile()); //outputs the toFile
            }

            outFile.Close(); //closes writer
        }
    }
}