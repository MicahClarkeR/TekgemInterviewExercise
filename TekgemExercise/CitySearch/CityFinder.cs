using System;
using System.Collections.Generic;
using System.Text;

namespace TekgemExercise.CitySearch
{
    /// <summary>
    /// CityFinder implementation, class responsible for adding cities and searching database for valid letters and suggestions.
    /// </summary>
    public class CityFinder : ICityFinder
    {
        private CityTreeNode Root; // The root starting CityTreeNode for the database.
        private int NumberOfSuggestions = -1;

        public CityFinder()
        {
            Root = new CityTreeNode();
        }

        /// <summary>
        /// Search the database for the given search string.
        /// </summary>
        /// <param name="searchString">The search term.</param>
        /// <returns>A ICityResult giving city suggestions and valid letters.</returns>
        public ICityResult Search(string searchString)
        {
            CityResult result = new CityResult(Root);

            // Get the next valid letters and suggestions from the city name database.
            Root.GetNextLetters(searchString).ForEach(letter => result.NextLetters.Add(letter));
            Root.GetSuggestions(searchString, NumberOfSuggestions).ForEach(suggestion => result.NextCities.Add(suggestion));

            return result;
        }

        /// <summary>
        /// Adds a city to the database.
        /// </summary>
        /// <param name="city"></param>
        public void Add(string city)
        {
            Root.Add(city);
        }
    }
}
