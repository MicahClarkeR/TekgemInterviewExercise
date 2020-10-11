using System;
using System.Collections.Generic;
using System.Text;

namespace TekgemExercise.CitySearch
{
    /// <summary>
    /// City Result interface, designating attributes to be implemented and hold information from the ICityFinder search method.
    /// </summary>
    public interface ICityResult
    {
        ICollection<string> NextLetters { get; set; }
        ICollection<string> NextCities { get; set; }
    }
}
