using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TekgemExercise.CitySearch;

namespace TekgemExerciseUnitTests
{
    [TestClass]
    public class CityTreeTests
    {
        /// <summary>
        /// Ensure that a singular item can be added and retrieved from the tree.
        /// </summary>
        [TestMethod]
        public void TestSingularAddToTree()
        {
            string text = "content";
            CityTreeNode tree = new CityTreeNode();
            tree.Add(text);

            string result = tree.GetEntries(1)[0];
            Assert.AreEqual(result, text);
        }

        /// <summary>
        /// Ensure that multiple items can be added and retrieved from the tree.
        /// </summary>
        [TestMethod]
        public void TestMultipleAddToTree()
        {
            List<string> text = new List<string>(new string[] { "content", "john smith", "test" });
            CityTreeNode tree = new CityTreeNode();
            text.ForEach(content => tree.Add(content));

            List<string> results = tree.GetEntries(3);

            foreach(string result in results)
            {
                Assert.AreEqual(true, text.Contains(result));
            }
        }

        /// <summary>
        /// Ensure that only valid letter suggestions are being returned from the tree.
        /// </summary>
        [TestMethod]
        public void TestValidLetterSuggestions()
        {
            List<string> text = new List<string>(new string[] { "abcdef", "abd", "acdef" });
            CityTreeNode tree = new CityTreeNode();
            text.ForEach(content => tree.Add(content));

            string search = "a";
            List<string> nextLetters = tree.GetNextLetters(search);
            CollectionAssert.AreEqual(new List<string>(new string[] { "b", "c" }), nextLetters);


            search = "ab";
            nextLetters = tree.GetNextLetters(search);
            CollectionAssert.AreEqual(new List<string>(new string[] { "c", "d" }), nextLetters);
        }

        /// <summary>
        /// Ensure that an invalid input returns no letter suggestions.
        /// </summary>
        [TestMethod]
        public void TestInvalidLetterSuggestions()
        {
            List<string> text = new List<string>(new string[] { "abcdef", "abd", "acdef" });
            CityTreeNode tree = new CityTreeNode();
            text.ForEach(content => tree.Add(content));

            string search = "z";
            List<string> nextLetters = tree.GetNextLetters(search);
            CollectionAssert.AreEqual(new List<string>(), nextLetters);
        }
    }
}
