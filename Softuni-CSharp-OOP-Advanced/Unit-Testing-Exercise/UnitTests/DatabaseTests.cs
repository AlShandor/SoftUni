


namespace UnitTests
{
    using NUnit.Framework;
    using Database;

    public class DatabaseTests
    {
        [Test]
        public void DatabaseCannotHaveMoreThan16Integers()
        {
            Assert.That(() => new Database(new int[17]), Throws.InvalidOperationException.With.Message.EqualTo("Database cannot store more than 16 integers!"));
        }

        [Test]
        public void AddMethodAddsElementAtNextFreeIndex()
        {
            int[] array = {0, 1, 2};
            var database = new Database(array);

            database.Add(3);

            Assert.That(database.IntegerRepo[3], Is.EqualTo(3));
        }

        [Test]
        public void AddMethodThrowsExceptionWhenAddingMoreThan16Elements()
        {
            int[] array = new int[16];
            var database = new Database(array);

            Assert.That(() => database.Add(1), Throws.InvalidOperationException.With.Message.EqualTo("Database cannot store more than 16 integers!"));
        }

        [Test]
        public void RemoveMethodRemovesLastElement()
        {
            int[] array = { 0, 1, 2 };
            var database = new Database(array);
            database.Remove();
            Assert.That(database.IntegerRepo[2], Is.EqualTo(0));
            Assert.That(database.NextFreeIndex, Is.EqualTo(2));
        }

        [Test]
        public void TryingToRemoveFromEmptyDatabaseThrowsException()
        {
            var database = new Database();

            Assert.That(() => database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("Database is empty, cannot remove element!"));
        }

        [Test]
        public void FetchMethodReturnsArrayCorrectly()
        {
            int[] array = { 0, 1, 2 };
            var database = new Database(array);
            var result = database.Fetch();

            Assert.That(result, Is.EquivalentTo(array));
        }
    }
}
