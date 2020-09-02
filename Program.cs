using System;
using System.Collections.Generic;
using System.Linq;

namespace c_assignment_crud_ldgraham92
{
    class Program
    {
        static public void Main(string[] args)
        /*
        Title: C# Introduction Assignment - CRUD
        Purpose: The purpose of this assignment is to challenge C# skills including decisions, iteration, and data structures. This will be an application that will maintain a dataset of items and allow the user to manipulate the data.
        Author: Lindsey Graham
        Last Modified Date: Aug 16th, 2020
        */

        {
            // Variables
            List<int> numInput = new List<int>{};
            var indexMethods = new SwitchMethods();

            
            Console.WriteLine("Welcome! This app will take in and store Area Codes"); // Welcome the user
            List<int> myNums = AreaCodeMethod(numInput);
            myNums.Sort(); // Sorting
                      
            
            bool switchValid = true;
            do
            {
            // Menu Display
            Console.WriteLine("MENU:\n----------\n1. Display the currently saved list\n2. Add an item to the currently saved list\n3. Edit an item in the currently saved list\n4. Delete an item from the currently stored list\n5. Exit Program");
            Console.Write("Please enter a menu choice:");
            //int mainSwitch = int.Parse(Console.ReadLine());
            char mainSwitch = char.Parse(Console.ReadLine());
            switch (mainSwitch){

                case '1': // Display the currently saved list
                    Console.WriteLine("Sorted Area Codes:");
                    Console.WriteLine(string.Join(",", myNums.ToArray()));
                    break;

                case '2': // Add an item to the currently saved list
                    Console.WriteLine("Please enter an area code to add to the list:");
                    myNums = indexMethods.AddAreaCode(myNums); 
                    break;

                case '3': // Edit an item in the currently saved list
                    Console.WriteLine("Please enter an area code you would like to change from the list:");
                    indexMethods.IndexOutput(myNums); // Call Index Method
                    myNums = indexMethods.EditRemove(myNums); // Call Edit Method               
                    break;
                
                case '4': // Delete an item from the currently stored list
                    Console.WriteLine("Please enter an area code to remove from the list:");
                    indexMethods.IndexOutput(myNums); // Call Index Method
                    myNums = indexMethods.DeleteAreaCode(myNums);// Call Delete Method
                    break;

                case '5': // Exit the program.
                    switchValid = false;
                    break;

                default: // Error if input != an int
                    Console.WriteLine("Please enter a valid menu option");
                    break;
            }
            } while (switchValid);
            
        }

        static List<int> AreaCodeMethod(List<int> numInput)
            {
            return GetValidInt("Please enter a 3 digit area code you wish to store (Ex: 780, 403). Once you've entered all your numbers, type \"quit\" or \"q\" to finish", 100, 999, numInput);
            }

        static List<int> GetValidInt(string userPrompt, int low, int high, List<int> numInput)
        {
            // Variables
            bool valid = false;
            string input = "";
            int count = 0;
            int inputNums = -1;
            string quitInput = "";

            do{
                valid = false;
                Console.WriteLine(userPrompt);
                {
                    input = Console.ReadLine();
                    try{
                        inputNums = int.Parse(input);
                        if (inputNums == 666){
                            Console.WriteLine("SPOOKY CHOICE!"); // Spooky Unexpected Feature!
                            numInput.Add(inputNums);
                            valid = true;
                            count++;
                        }                        
                        else if (inputNums >= low && inputNums <= high) {
                            numInput.Add(inputNums);
                            valid = true;
                            count++;
                        }
                    }
                    
                    catch {
                        valid = true;
                        if (input.ToLower() == "quit" || input.ToLower() == "q"){
                            Console.WriteLine("Are you sure you are completed with your numbers? Yes/No");
                            quitInput = Console.ReadLine().ToLower();
                            if (quitInput == "yes"){
                                valid = false;
                            }
                            else if (quitInput == "no"){
                                valid = true;
                            }
                        }
                        else Console.WriteLine("Invalid Input, Please Ensure you are entering a 3 digit number");
                    }
                }                   
            } while (valid); // List Size is now infinite. To add a hard limit to the loop, revert to 'while (valid && count < 10)' for 10, etc.

            return numInput;
        }

    }
    public class SwitchMethods { // Define Switch Methods Class
    public void IndexOutput(List<int> numInput){
        Console.WriteLine("The Current Stored List is:");
        for (int i = 0; i < numInput.Count; i++)
        {
                Console.WriteLine("{0}: {1}", (i+1), numInput[i]);
        }
    }
    public List<int> EditRemove(List<int> numInput){
        string removeString = Console.ReadLine();
        int removeAreaCode = (int.Parse(removeString)) - 1;
        numInput.RemoveAt(removeAreaCode);

        Console.WriteLine("Please specify a new number for the list:");
        string editAdd = Console.ReadLine();
        int editAddAreaCode = int.Parse(editAdd);
        numInput.Add(editAddAreaCode);
 
        return numInput;
    }

    public List<int> DeleteAreaCode(List<int> numInput){
        string delString = Console.ReadLine();
        int delAreaCode = int.Parse(delString) - 1;
        numInput.RemoveAt(delAreaCode);

        return numInput;
    }

    public List<int> AddAreaCode(List<int> numInput){
        int addValue;
        addValue = int.Parse(Console.ReadLine());
        if (!numInput.Contains(addValue)) {
            numInput.Add(addValue);
        }
        numInput.Sort(); // Sorting list when new item added

        return numInput;
    }
    }
}
