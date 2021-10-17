using _008_collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace _008_collections_tests
{
    public class CollectionHelperTest
    {
        [Fact]
        public void AddToCollection_List_OneValue()
        {
            var dictionaryList = new Dictionary<string, List<string>>();

            var listKey = "list 1 key";

            CollectionHelper.AddToCollection<List<string>, string>("item 1 value",
                                                                   listKey,
                                                                   dictionaryList);

            
            Assert.Single(dictionaryList);
            Assert.Single(dictionaryList[listKey]);
            Assert.Equal("item 1 value", dictionaryList[listKey][0]);

        }

        [Fact]
        public void AddToCollection_List_MultiplesValues()
        {
            var dictionaryList = new Dictionary<string, List<string>>();

            var listKey = "list 1 key";

            for (int i = 1; i <= 10; i++)
            {
                CollectionHelper.AddToCollection<List<string>, string>($"item {i} value",
                                                                   listKey,
                                                                   dictionaryList);
            }

            Assert.Single(dictionaryList);
            Assert.Equal(10, dictionaryList[listKey].Count);
            Assert.Equal("item 1 value", dictionaryList[listKey][0]);
            Assert.Equal("item 10 value", dictionaryList[listKey][9]);

        }


        [Fact]
        public void AddToCollection_HashSet_OneValue()
        {
            var dictionaryList = new Dictionary<string, HashSet<string>>();

            var listKey = "list 1 key";

            CollectionHelper.AddToCollection<HashSet<string>, string>("item 1 value",
                                                                   listKey,
                                                                   dictionaryList);


            Assert.Single(dictionaryList);
            Assert.Single(dictionaryList[listKey]);
            Assert.Equal("item 1 value", dictionaryList[listKey].First());

        }

        [Fact]
        public void AddToCollection_HashSet_MultiplesValues()
        {
            var dictionaryList = new Dictionary<string, HashSet<string>>();

            var listKey = "list 1 key";

            for (int i = 1; i <= 10; i++)
            {
                CollectionHelper.AddToCollection<HashSet<string>, string>($"item {i} value",
                                                                   listKey,
                                                                   dictionaryList);
            }

            Assert.Single(dictionaryList);
            Assert.Equal(10, dictionaryList[listKey].Count);
            Assert.Equal("item 1 value", dictionaryList[listKey].First());
            Assert.Equal("item 10 value", dictionaryList[listKey].Last());

        }
    }
}