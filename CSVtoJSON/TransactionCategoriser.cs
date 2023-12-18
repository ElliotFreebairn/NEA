using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NEAScripts
{
    public class TransactionCategoriser
    {
        Categories categories = new Categories();
        public TransactionCategoriser()
        {

        }

        public bool CheckGeneralCategory(TransactionData transactionData, string whatCategory)
        {
            List<string> details = transactionData.Details.Split(" ").ToList();
            var foodShops = GetDictionariesForCategories(whatCategory);
            foreach(var category in foodShops)
            {
                foreach (KeyValuePair<string, List<string>> kvp in category)
                { 
                    List<string> list = kvp.Value;

                    if (kvp.Key == whatCategory)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            for (int j = 0; j < details.Count; j++)
                            {
                                if (LevenshteinDistance(details[j].ToUpper(), list[i].ToUpper()))
                                {
                                    Console.WriteLine(transactionData.Details);
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool LevenshteinDistance(string transactionDetails, string wordFromDictionary) //Method to find the minimum edit distance between two strings 
        {
            int[,] matrix = new int[transactionDetails.Length + 1, wordFromDictionary.Length + 1]; //create a matrix with empty character at 0,0
                                                                                                   //then transactionDetails on the x axis and wordFromDictionary on the Y

            for(int i  = 0 ; i < transactionDetails.Length + 1; i++) //Fill in the first row from 0-length of input string + 1. This is due to transforming input string
            {                                                        // to an empty string you need to delete the index(length of string) to find empty string
                matrix[i,0] = i;
            }

            for(int j = 0; j < wordFromDictionary.Length + 1; j++) //Same process for the wordFromDictionary but it fills in the first column and this is due to the amount
            {                                                      //of insertion operations needed to transform empty string to wordFromDictionary index
                matrix[0, j] = j;
            }

            for(int row = 1; row < transactionDetails.Length + 1; row++) //Loops through rows starting at index [1,0]
            {
                for(int col = 1; col < wordFromDictionary.Length + 1; col++)  //Loops through columns starting at index[1,1]
                {
                    if (transactionDetails[row - 1] == wordFromDictionary[col - 1]) //Case if characters are match which means the matrix position equals the previous
                    {                                                               //Solution the subproblem at the diagonal column
                        matrix[row, col] = matrix[row - 1, col - 1];
                    }
                    else //case if character are a mismatch, it will find the minimum edit distance from the previous matrix positions which represent insertion,replace and delete operations
                    {    
                        matrix[row, col] = Math.Min(Math.Min(matrix[row, col - 1] + 1, matrix[row - 1, col] + 1), matrix[row - 1, col - 1] + 1);
                    }
                }
            }

            double maxLenghtOfStrings = Math.Max(transactionDetails.Length, wordFromDictionary.Length);
            double similarityOfStrings = 1.0 - (matrix[transactionDetails.Length, wordFromDictionary.Length] / maxLenghtOfStrings);

            double thresholdForSimilarityOfStrings = 0.7;

            return similarityOfStrings >= thresholdForSimilarityOfStrings; //returns max index of the matrix which represents the minimum edit distance

        }

        private List<Dictionary<string, List<string>>> GetDictionariesForCategories(string whatCategories)
        {
            List<Dictionary<string, List<string>>> list = new List<Dictionary<string, List<string>>>();
            foreach (var categories in categories.GetCategoriesAsDictionaries())
            {
                foreach(var category in categories)
                {
                    if(category.Key.ToUpper() == whatCategories.ToUpper())
                    {
                        list.Add(categories);
                    }
                }
            }
            return list;
        }
        public bool CheckIfInwardPayment(string transactionType)
        {
            switch (transactionType)
            {
                case "Inward Payment":
                    return true;
                default:
                    return false;
            }
        }

        public bool CheckIfObjectIsEmpty(TransactionData data)
        {
            bool isInvalid = false;
            if (data.DateOfTransaction == null || data.Details == null || data.TransactionType == null || (data.MoneyIn == 0 && data.MoneyOut == 0) || data.Balance == 0)
            {
                isInvalid = true;
            }

            return isInvalid;
        }
    }
}
