using Froggies.Web.Model.Levels;
using Xunit;

namespace Froggies.Tests.Levels
{
    public class SerializationTest
    {
        private const string TestJson = "[[\"E\",\"N\"],[\"R\",\"G\"]]"; // [["E","N"],["R","G"]]

        private static readonly Cell[][] TestCells =
        {
            new[] {Cell.Empty, Cell.None},
            new[] {Cell.RedFrog, Cell.GreenFrog},
        };

        [Fact]
        public void Serialize()
        {
            var lvl = new Level
            {
                Cells = SerializationTest.TestCells
            };

            Assert.Equal(TestJson, lvl.CellsJson);
        }

        [Fact]
        public void Deserialize()
        {
            var lvl = new Level
            {
                CellsJson = SerializationTest.TestJson
            };

            int size = TestCells.GetLength(0);

            for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
            {
                Assert.Equal(lvl[i][j], TestCells[i][j]);
            }
        }
    }
}