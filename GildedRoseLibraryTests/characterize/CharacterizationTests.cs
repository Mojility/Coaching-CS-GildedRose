using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using Characterizer;
using GildedRoseLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GildedRoseLibraryTests.characterize
{
    [TestClass]
    public class CharacterizationTests
    {
        [TestMethod]
        public void FromDataFile()
        {
            List<Record> results = JsonConvert.DeserializeObject<List<Record>>(File.ReadAllText(@"..\..\characterize\behavior.json"));

            foreach (var result in results)
            {
                var g = new GildedRose(result.name, result.input.quality, result.input.sellIn);
                g.Tick();
                Assert.AreEqual(result.output.quality, g.Quality, $"{result.name} quality");
                Assert.AreEqual(result.output.sellIn, g.SellIn, $"{result.name} sellIn");
            }
        }
    }
}
