using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;
using Xunit;

namespace MinesweeperTests
{
    public class BoardServiceTests
    {
        [Fact]
        public void BoardModel_WhenCreated_HasCorrectSize()
        {
            // arrange
            BoardModel board = new BoardModel(5);

            // act
            int actualSize = board.Size;

            // assert
            Assert.Equal(5, actualSize);
        }

        [Fact]
        public void BoardModel_WhenCreated_FillsEveryCell()
        {
            // arrange
            BoardModel board = new BoardModel(5);

            // act and assert
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    Assert.NotNull(board.Cells[row, col]);
                }
            }
        }

        [Fact]
        public void CellModel_WhenCreated_HasCorrectRowAndColumn()
        {
            // arrange
            CellModel cell = new CellModel(2, 3);

            // assert
            Assert.Equal(2, cell.Row);
            Assert.Equal(3, cell.Column);
        }

        [Fact]
        public void SetupBombs_WhenCalled_PlacesAtLeastOneBomb()
        {
            // arrange
            BoardModel board = new BoardModel(5);
            BoardService service = new BoardService(board);

            // act
            service.SetupBombs();

            bool bombFound = false;

            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    if (board.Cells[row, col].IsBomb)
                    {
                        bombFound = true;
                    }
                }
            }

            // assert
            Assert.True(bombFound);
        }

        [Fact]
        public void CountBombsNearby_WhenBombIsInCenter_UpdatesNeighborCounts()
        {
            // arrange
            BoardModel board = new BoardModel(3);
            BoardService service = new BoardService(board);

            board.Cells[1, 1].IsBomb = true;

            // act
            service.CountBombsNearby();

            // assert
            Assert.Equal(1, board.Cells[0, 0].NumberOfBombNeighbors);
            Assert.Equal(1, board.Cells[0, 1].NumberOfBombNeighbors);
            Assert.Equal(1, board.Cells[0, 2].NumberOfBombNeighbors);
            Assert.Equal(1, board.Cells[1, 0].NumberOfBombNeighbors);
            Assert.Equal(1, board.Cells[1, 2].NumberOfBombNeighbors);
            Assert.Equal(1, board.Cells[2, 0].NumberOfBombNeighbors);
            Assert.Equal(1, board.Cells[2, 1].NumberOfBombNeighbors);
            Assert.Equal(1, board.Cells[2, 2].NumberOfBombNeighbors);
        }
    }
}