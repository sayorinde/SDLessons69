﻿using _06_StreamingContent_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_StreamingContent_Console
{
    public class ProgramUI
    {
        private StreamingContent_Repo _repo = new StreamingContent_Repo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Show all streaming content\n" +
                    "2. Find streaming content by title\n" +
                    "3. Add new streaming content\n" +
                    "4. Update existing streaming content\n" +
                    "5. Remove streaming content\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // Show all content
                        ShowAllContent();
                        break;
                    case "2":
                        //Get content by title
                        break;
                    case "3":
                        //Create new streaming content
                        CreateNewContent();
                        break;
                    case "4":
                        //Update existing content
                        break;
                    case "5":
                        // Delete existing content
                        break;
                    case "6":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowAllContent()
        {
            Console.Clear();

            List<StreamingContent> listOfContent = _repo.GetContents();

            foreach (StreamingContent content in listOfContent)
            {
                Console.WriteLine($"Title: {content.Title}");
                Console.WriteLine($"Description: {content.Description}");
                Console.WriteLine($"Star Rating: {content.StarRating}");
                Console.WriteLine($"Maturity Rating: {content.MaturityRating}");
                Console.WriteLine($"Genre: {content.Genre}");
                Console.WriteLine($"Is it family friendly? {content.IsFamilyFriendly}");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void CreateNewContent()
        {
            Console.Clear();

            StreamingContent newContent = new StreamingContent();

            Console.WriteLine("Please enter a title.");
            newContent.Title = Console.ReadLine();

            Console.WriteLine("Please enter a description.");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("Please enter a star rating (1.0 - 10.0) for this content.");
            string ratingAsString = Console.ReadLine();
            double ratingAsDouble = double.Parse(ratingAsString);
            newContent.StarRating = ratingAsDouble;

            Console.WriteLine("Select a genre.");
            Console.WriteLine("1.Horror");
            Console.WriteLine("2.RomCom");
            Console.WriteLine("3.SciFi");
            Console.WriteLine("4.Action");
            Console.WriteLine("5.Documentary");
            Console.WriteLine("6.Musical");
            Console.WriteLine("7.Drama");
            Console.WriteLine("8.Mystery");

            string genreInput = Console.ReadLine();
            int genreAsInt = int.Parse(genreInput);
            newContent.Genre = (Genre)genreAsInt;


            bool stopRunning = false;
            while (!stopRunning)
            {

                Console.WriteLine("Select a maturity rating.");
                Console.WriteLine("1. G");
                Console.WriteLine("2. PG");
                Console.WriteLine("3. PG_13");
                Console.WriteLine("4. R");
                Console.WriteLine("5. NC_17");

                string maturityRating = Console.ReadLine();


                switch (maturityRating)
                {
                    case "1":
                        newContent.MaturityRating = MaturityRating.G;
                        stopRunning = true;
                        break;
                    case "2":
                        newContent.MaturityRating = MaturityRating.PG;
                        stopRunning = true;
                        break;
                    case "3":
                        newContent.MaturityRating = MaturityRating.PG_13;
                        stopRunning = true;
                        break;
                    case "4":
                        newContent.MaturityRating = MaturityRating.R;
                        stopRunning = true;
                        break;
                    case "5":
                        newContent.MaturityRating = MaturityRating.NC_17;
                        stopRunning = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input.");
                        stopRunning = false;
                        break;
                }
            }
            bool wasAdded = _repo.AddContentToDirectory(newContent);
            if (wasAdded == true)
            {
                Console.WriteLine("Your content was succesfully added.");
            }
            else
            {
                Console.WriteLine("Oops something went wrong. Your content was not added.");
            }
        }
    }
}
