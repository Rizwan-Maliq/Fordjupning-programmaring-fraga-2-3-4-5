﻿using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Statistics
{
    public static class Statistics
    {
        // Ingen "public" behövs här eftersom det är en statisk medlem i en statisk klass
        static int[] source = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"));

        // Ingen "public" behövs här eftersom det är en statisk metod i en statisk klass
        public static dynamic DescriptiveStatistics()
        {
            Dictionary<string, dynamic> StatisticsList = new Dictionary<string, dynamic>()
            {
                { "Maximum", Maximum() },
                { "Minimum", Minimum() },
                { "Medelvärde", Mean() },
                { "Median", Median() },
                /*{ "Typvärde", String.Join(", ", Mode()) }, */
                { "Variationsbredd", Range() },
                { "Standardavvikelse", StandardDeviation() }
            };

            string output =
                $"Maximum: {StatisticsList["Maximum"]}\n" +
                $"Minimum: {StatisticsList["Minimum"]}\n" +
                $"Medelvärde: {StatisticsList["Medelvärde"]}\n" +
                $"Median: {StatisticsList["Median"]}\n" +
                /*$"Typvärde: {StatisticsList["Typvärde"]}\n" +*/
                $"Variationsbredd: {StatisticsList["Variationsbredd"]}\n" +
                $"Standardavvikelse: {StatisticsList["Standardavvikelse"]}";

            return output;
        }

        public static int Maximum()
        {
            Array.Sort(source);
            Array.Reverse(source);
            int result = source[0];
            return result;
        }

        public static int Minimum()
        {
            Array.Sort(source);
            int result = source[0];
            return result;
        }

        public static double Mean()
        {
            double total = 0; // Ändrat från -88
            for (int i = 0; i < source.Length; i++)
            {
                total += source[i];
            }
            return total / source.Length;
        }

        public static double Median()
        {
            Array.Sort(source);
            int size = source.Length;
            int mid = size / 2;
            int dbl = source[mid];
            return dbl;
        }

        //public static int[] Mode()
        //{

        //}

        public static int Range()
        {
            Array.Sort(source);
            int min = source[0];
            int max = source[0];

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] > max)
                {
                    max = source[i];
                }
            }

            int range = max - min;
            return range;
        }

        public static double StandardDeviation()
        {
            double average = source.Average();
            double sumOfSquaresOfDifferences = source.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / source.Length);

            double round = Math.Round(sd, 1);
            return round;
        }
    }
}
