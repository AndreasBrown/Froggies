using Froggies.Web.Model.Levels;
using Xunit;

namespace Froggies.Tests.Levels
{
    public class SerializationTest
    {
        const string testJson = "[[\"E\",\"N\"],[\"R\",\"G\"]]"; // [["E","N"],["R","G"]]

        private readonly static Cell[][] testCells = 
        new[]
        {
            new [] { Cell.Empty, Cell.None },
            new [] { Cell.RedFrog, Cell.GreenFrog },
        };

        [Fact]
        public void Serialize()
        {
            var lvl = new Level
            {
                Cells = testCells
            };

            Assert.Equal(testJson, lvl.CellsJson);
        }

        [Fact]
        public void Deserialize()
        {
            var lvl = new Level
            {
                CellsJson = testJson
            };

            int size = testCells.GetLength(0);

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    Assert.Equal(lvl[i][j], testCells[i][j]);
                }
        }
    }
}
