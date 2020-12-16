﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLoadingOfBook;
using BookUserRatingLib;
using AIRecommendationApp.PearsonEngine;
using Books;

namespace AIRecommendationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVDataLoader cSVDataLoader = new CSVDataLoader();
            BookDetails bookDetails = cSVDataLoader.Load();

            Console.WriteLine(bookDetails);

            RatingAggrigator ratingAggrigator = new RatingAggrigator();
            Preferance preferance = new Preferance();
            preferance.ISBN = "0195153448";
            preferance.Age = 32;
            preferance.state = "california";

            Dictionary<string, List<int>> ans = ratingAggrigator.Aggrigate(bookDetails, preferance);

            for (int i = 0; i < ans["0195153448"].Count; i++)
            {
                Console.WriteLine(ans["0195153448"][0]);
            }

            DBLoading dBLoading = new DBLoading();
            BookDetails bookDetails1 = dBLoading.Load();


        }
    }
}