using PAC.Data.Animals.Breeds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Utilities.BreedUitilities
{
    public static class CsvReaderDogBreeds
    {
        private static string _csvFilePath =
      @"D:\_PopsAnimalControl\PopsAnimalControl\PAC.Models\AnimalModels\BreedModels\BreedStuff\Stuff\fci-breeds/fci-breeds_Modified.csv";
        public static List<Breed> ReadAllBreeds()
        {
            List<Breed> breeds = new List<Breed>();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //read header line
                sr.ReadLine();

                string csvLine;
                while ((csvLine = sr.ReadLine()) != null && (csvLine = sr.ReadLine()) != "")
                {
                    breeds.Add(ReadBreedFromCsvLine(csvLine));
                }
            }

            return breeds;
        }
        private static Breed ReadBreedFromCsvLine(string csvLine)
        {
            string[] breedObjSections = csvLine.Split(',');

            string breedName = breedObjSections[1];
            string section = breedObjSections[2];
            string country = breedObjSections[3];

            var breed = new Breed(breedName, section, country);
            return breed;
        }
    }

}
