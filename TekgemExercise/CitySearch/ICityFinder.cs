using System;
using System.Collections.Generic;
using System.Text;

namespace TekgemExercise.CitySearch
{
    /// <summary>
    /// City Finder interface, designating its core functionality for implementation.
    /// </summary>
    public interface ICityFinder
    {
        ICityResult Search(string searchString);
    }
}
