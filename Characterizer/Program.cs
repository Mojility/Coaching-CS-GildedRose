using System.Collections.Generic;
using System.IO;
using Characterizer.characterize;
using GildedRoseLibrary;
using Newtonsoft.Json;

namespace Characterizer
{
    class Program
    {
        private static int[] Tolerances = new int[] {-1, 0, 1};

        class Data
        {
            public int quality { get; set; }
            public int sellIn { get; set; }
        }

        class Record
        {
            public Data input { get; set; }
            public Data output { get; set; }
            public string name { get; set; }
        }

        static void Main(string[] args)
        {
            List<Record> results = new List<Record>();

            foreach (var name in InterestingData.Names)
            {
                foreach (var qualityBoundary in InterestingData.QualityBoundaries)
                {
                    foreach (var qualityTolerance in Tolerances)
                    {
                        foreach (var sellInBoundary in InterestingData.SellInBoundaries)
                        {
                            foreach (var sellInTolerance in Tolerances)
                            {
                                var inputData = new Data()
                                {
                                    quality = qualityBoundary + qualityTolerance,
                                    sellIn = sellInBoundary + sellInTolerance
                                };

                                var g = new GildedRose(
                                    name,
                                    inputData.quality,
                                    inputData.sellIn
                                );

                                g.Tick();

                                var outputData = new Data()
                                {
                                    quality = g.Quality,
                                    sellIn = g.SellIn
                                };

                                var record = new Record()
                                {
                                    name = name,
                                    input = inputData,
                                    output = outputData
                                };

                                results.Add(record);
                            }
                        }
                    }
                }
            }

            File.WriteAllText(@"..\..\behavior.json", JsonConvert.SerializeObject(results));
        }
    }
}