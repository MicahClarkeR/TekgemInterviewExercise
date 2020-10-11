using System;
using System.Collections.Generic;
using System.Text;

namespace TekgemExercise.CitySearch
{
    /// <summary>
    /// Struct to implement ICityResult inferface, contains all information returned by the database search functionality.
    /// </summary>
    public struct CityResult : ICityResult
    {
        public ICollection<string> NextLetters { get; set; }
        public ICollection<string> NextCities { get; set; }

        public CityResult(CityTreeNode root)
        {
            NextLetters = new List<string>();
            NextCities = new List<string>();
        }
    }
}
