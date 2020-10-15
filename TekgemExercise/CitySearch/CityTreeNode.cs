using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace TekgemExercise.CitySearch
{
    /// <summary>
    /// Database datastructure that uses recursive method calling to create a binary tree-like structure that stores
    /// information into stored dictionaries, with an emphasis on high performance.
    /// </summary>
    public class CityTreeNode
    {
        public bool WordComplete = false;   // Mark if this node completes a valid data-entry.
        public string Word, Letter;
        private bool Root;                  // Designate if this node is the root node for the database.

        // Contain all the child CityTreeNodes sorted by their string key.
        private SortedDictionary<string, CityTreeNode> Children = new SortedDictionary<string, CityTreeNode>();

        /// <summary>
        /// CityTreeNode constructor.
        /// </summary>
        /// <param name="root">Set if this CityTreeNode forms the root of the database.</param>
        public CityTreeNode(bool root = false, string letter = "")
        {
            Root = root;
            Letter = letter;
        }

        /// <summary>
        /// Adds the given content string to the database.
        /// </summary>
        /// <param name="content">Content to add to the database.</param>
        /// <param name="addIndex">An index used to keep track of adding to the tree.</param>
        public void Add(string content, int addIndex = 0)
        {
            // If this content has 0 length, then this node completes a city name.
            if ((content.Length - 1) == addIndex)
            {
                WordComplete = true;
                Word = content;
            }
            else // Otherwise...
            {
                // Get the first letter.
                string letter = content[addIndex].ToString().ToLower();

                // If this node's children exist for this letter, add the remaining content to the child.
                if (Children.ContainsKey(letter))
                {
                    addIndex++;
                    Children[letter].Add(content, addIndex);
                }
                else // Otherwise...
                {
                    // Create the requied child and add this content to it.
                    Children.Add(letter, new CityTreeNode(false, letter));
                    Add(content, addIndex);
                }
            }
        }

        /// <summary>
        /// Returns a list of valid letters for the search query thus far.
        /// </summary>
        /// <param name="search">A valid search query to check for next letters.</param>
        /// <returns>All valid next letter entries.</returns>
        public List<string> GetNextLetters(string search)
        {
            
            // If this is not the last node in the search tree...
            if(search.Length > 0)
            {
                // Get the get and remove the first letter from the search term
                string letter = search[0].ToString();
                search = search[1..];

                // If child dictionary contains the letter, check it for next letters
                if (Children.ContainsKey(letter))
                {
                    return Children[letter].GetNextLetters(search);
                }
                else // Otherwise return an empty list
                {
                    return new List<string>();
                }
            }
            else // Otherwise, return all child dictionary keys
            {
                List<string> letters = new List<string>();
                letters.AddRange(Children.Keys);

                if(letters.Count == 0 && WordComplete)
                    letters.Add(Word[Word.Length - 1].ToString());

                return letters;
            }
        }

        /// <summary>
        /// Get a number of entries from the database, if there aren't enough entries then this will return all entries.
        /// </summary>
        /// <param name="amount">Number of entires to get.</param>
        /// <returns>Found valid entires from the databse.</returns>
        public List<string> GetEntries(int amount = -1)
        {
            List<string> entries = new List<string>();

            // Check through children...
            foreach (KeyValuePair<string, CityTreeNode> value in Children)
            {
                string letter = value.Key;
                CityTreeNode child = value.Value;

                // Get entires from the current child CityTreeNode
                List<string> tempEntries = new List<string>(child.GetEntries(amount));

                // Add the temporary entries to the total entries.
                entries.AddRange(tempEntries);

                // If enough is found, leave the loop.
                if(amount != -1 && tempEntries.Count >= amount)
                {
                    break;
                }
            }

            // If this node completes a work, add it to the entries.
            if (WordComplete)
            {
                entries.Add(Word);
            }

            // Return found entires.
            return entries;
        }

        /// <summary>
        /// Get a number of suggestions from the databases given the search term input.
        /// </summary>
        /// <param name="search">The search term to search database for.</param>
        /// <param name="amount">Number of suggestions to return.</param>
        /// <returns>Suggestions from the database.</returns>
        public List<string> GetSuggestions(string search, int amount)
        {
            List<string> suggestions = new List<string>();

            if (search.Length > 0) // If we need to traverse the database more
            {
                string letter = search[0].ToString();

                // And we have a child with valid key
                if (Children.ContainsKey(letter))
                {
                    search = search[1..];

                    // Get the suggestions from the child
                    suggestions = Children[letter].GetSuggestions(search, amount);
                }
            }
            else // Otherise, get the requried amount of valid entries from the children
            {
                suggestions = GetEntries(amount);

                if(amount != -1 && suggestions.Count > amount)
                    suggestions = suggestions.GetRange(0, amount);
            }

            return suggestions;
        }
    }
}
