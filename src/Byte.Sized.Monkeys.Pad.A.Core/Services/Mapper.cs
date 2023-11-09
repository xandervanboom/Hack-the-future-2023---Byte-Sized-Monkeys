using Byte.Sized.Monkeys.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Sized_Monkeys_Pad_A.Core.Services
{
    public static class Mapper
    {

        public static string MapMayanHieroglyphicsToString(string mayanString)
        {

            var response = new string(mayanString.Select(c => HieroglyphAlphabet.Characters.TryGetValue(c, out char value) ? value : c).ToArray());
            return response;
            
        }

        public static string GetVineEndDestination(VineNavigationChallengeDto vineDto)
        {

            double size = Math.Sqrt(vineDto.AmountOfVines);

            int currentX = int.Parse(vineDto.Start.Split(",")[0]);
            int currentY = int.Parse(vineDto.Start.Split(",")[1]);


            foreach (string direction in vineDto.Directions)
            {

                switch (direction)
                {
                    case "U":
                        if ((currentY + 1) < size) currentY++;
                        break;

                    case "D":
                    if ((currentY - 1) >= 0) currentY--;
                        break;

                    case "R":
                        if ((currentX + 1) < size) currentX++;
                        break;

                    case "L":
                        if ((currentX - 1) >= 0) currentX--;
                        break;

                    case "UR":
                        if ((currentY + 1) < size && (currentX + 1) < size)
                        {
                            currentY++;
                            currentX++;
                        }
                        break;

                    case "UL":
                        if ((currentY + 1) < size && (currentX - 1) >= 0)
                        {
                            currentY++;
                            currentX--;
                        }
                        break;

                    case "DR":
                        if ((currentY - 1) >= 0 && (currentX + 1) < size)
                        {
                            currentY--;
                            currentX++;
                        }
                        break;

                    case "DL":
                        if ((currentY - 1) >= 0 && (currentX - 1) >= 0)
                        {
                            currentY--;
                            currentX--;
                        }
                        break;
                }

            }

            return $"{currentX},{currentY}";

        }

        public static string[] CreateAnimalNameChain(List<Animal> animals)
        {

            List<Animal> chain = new List<Animal>
            {
                animals[0]
            };
            animals.Remove(animals[0]);

            while (animals.Any())
            {
                var nextAnimal = animals.FirstOrDefault(a =>
                                                    a.Species.Equals(chain.Last().Species) ||
                                                    a.AgeInDays.Equals(chain.Last().AgeInDays) ||
                                                    a.HeightInCm.Equals(chain.Last().HeightInCm)
                                                    );
                if( nextAnimal is not null)
                {
                    chain.Add(nextAnimal);
                    animals.Remove(nextAnimal);
                }

                else
                {
                    chain.Reverse();
                    chain.Add(animals[0]);
                    animals.Remove(animals[0]);
                }

            }

            return chain.Select(a => a.Name).ToArray();
            
        }

        

    }
}
