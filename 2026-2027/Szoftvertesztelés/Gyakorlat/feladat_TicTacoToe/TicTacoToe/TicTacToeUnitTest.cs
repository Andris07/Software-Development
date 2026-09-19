using TicTacToe_Lib;
namespace TicTacoToe_Test

{
    public class Tests
    {
        TicTacToe game;

        [SetUp]
        public void Setup()
        {
            game = new();
        }

        [Test]
        public void TestCanPlaceOnEmptyField()
        {
            Assert.That(game.isEmpty(0, 0), Is.True, "By default, the field should be empty");
            Assert.That(game.Place(0, 0), Is.True, "Should be able to place on empty space");

        }
        [Test]
        public void TestCanNotPlaceOnTakenField()
        {
            Assert.That(game.isEmpty(0, 0), Is.True, "By default, the field should be empty");
            Assert.That(game.Place(0, 0), Is.True, "Should be able to place on empty space");
            Assert.That(game.Place(0, 0), Is.False, "Can't place on taken field");
        }
        [Test]
        public void TestPlayerTurnChange()
        {
            Assert.That(game.actualPlayer, Is.EqualTo(1), "At game start, actual player should be #1");
            Assert.That(game.Place(0, 0), Is.True, "Should be able to place on empty space");
            Assert.That(game.actualPlayer, Is.EqualTo(2), "After placing, the player should change from #1 to #2");
            Assert.That(game.Place(1, 0), Is.True, "Should be able to place on other empty space");
            Assert.That(game.actualPlayer, Is.EqualTo(1), "After placing, the player should change from #2 to #1");
        }
        [Test]
        public void TestNoMoreMove()
        {
            Assert.That(game.NoMoreMoves(), Is.False, "at the game start, there should be more possible moves");
            Assert.That(game.Place(0, 0), Is.True, "place first");
            Assert.That(game.Place(1, 0), Is.True, "place second");
            Assert.That(game.Place(2, 0), Is.True, "place third");
            Assert.That(game.NoMoreMoves(), Is.False, "after a few turns, there should be more possible moves");
            Assert.That(game.Place(0, 1), Is.True);
            Assert.That(game.Place(1, 1), Is.True);
            Assert.That(game.Place(2, 1), Is.True);
            Assert.That(game.Place(1, 2), Is.True);
            Assert.That(game.Place(0, 2), Is.True);
            Assert.That(game.Place(2, 2), Is.True);
            Assert.That(game.NoMoreMoves(), Is.True, "after the board is full and there is no winner, there should be no more moves");
        }
        [Test]
        public void TestGameWon()
        {
            Assert.That(game.NoMoreMoves(), Is.False, "at the game start, there should be more possible moves");
            Assert.That(game.GameWon(), Is.False, "at the game start, the should not be in won state");
            Assert.That(game.Place(0, 0), Is.True);
            Assert.That(game.Place(1, 0), Is.True);
            Assert.That(game.Place(2, 0), Is.True);
            Assert.That(game.NoMoreMoves(), Is.False, "after a few turns, there should be more possible moves");
            Assert.That(game.Place(0, 1), Is.True);
            Assert.That(game.Place(1, 1), Is.True);
            Assert.That(game.Place(2, 1), Is.True);
            Assert.That(game.Place(0, 2), Is.True);
            Assert.That(game.GameWon(), Is.True, "Last move was a winning move, Game should be in a Won State");
            Assert.That(()=>game.Place(1, 2) , Throws.Exception,"Game is won, no more moves allowed");
        }
    }
}
