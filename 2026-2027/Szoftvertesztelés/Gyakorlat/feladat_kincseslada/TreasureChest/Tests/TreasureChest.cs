using Treasure;
using TreasureChest;

namespace Tests
{
    public class TreasureChest
    {
        Treasure.Treasure treasure;
        Chest chest;

        [SetUp]
        public void Setup()
        {
            chest = new Chest("chest", 0);
        }

        [Test]
        public void VolumeIsGreaterThanNull()
        {
            Treasure.Treasure treasureCopy = new Treasure.Treasure("gold", 1);
            Assert.That(treasureCopy.Volume, Is.GreaterThan(0));
        }

        [Test]
        public void VolumeIsNotLessThanNull()
        {
            Chest chestCopy = new Chest("chestCopy", 0);
            Assert.That(chestCopy.Volume, Is.Not.LessThan(0));
        }

        [Test]
        public void ThrowsException()
        {
            Assert.Throws<VolumeException>(() => treasure = new Treasure.Treasure("gold", -1));
            Assert.Throws<VolumeException>(() => chest = new Chest("chest", -1));
        }

        [Test]
        public void ChestIsLockedAndCantBeOpenedAfterInicialization()
        {
            Assert.That(chest.IsLocked, Is.True);
            Assert.That(chest.IsOpen, Is.False);
        }

        [Test]
        public void ChestIsClosedAfterInicialization()
        {
            Assert.That(chest.Close(), Is.False); // can't close the chest if it's already closed
        }

        [Test]
        public void ChestIsLockedAfterInicialization()
        {
            Assert.That(chest.Lock(), Is.False); // can't lock the chest if it's already locked
        }

        [Test]
        public void ChestIsEmptyAfterInicialization()
        {
            Assert.That(chest.Volume, Is.EqualTo(0));
        }

        [Test]
        public void ChestCanBeOpenedAndClosed()
        {
            chest.IsLocked = false;
            chest.IsOpen = false;
            Assert.That(chest.Open(), Is.True);
            Assert.That(chest.Close(), Is.True); // you should be able to close the chest after opening it
        }

        [Test]
        public void ChestCantBeClosedBeforeOpeningIt()
        {
            chest.IsLocked = false;
            chest.IsOpen = false;
            Assert.That(chest.Close, Is.False);
            Assert.That(chest.Open, Is.True);
            Assert.That(chest.Close, Is.True);
        }

        [Test]
        public void ChestCanOnlyBeOpenedIfItsClosed()
        {
            Assert.That(chest.Open(), Is.False);
            Assert.That(chest.Close(), Is.False);
            chest.IsLocked = false;
            chest.IsOpen = false;
            Assert.That(chest.Open(), Is.True);
        }

        [Test]
        public void ChestCanBeLocked()
        {
            chest.IsLocked = false;
            chest.IsOpen = false;
            Assert.That(chest.Lock(), Is.True);
        }

        [Test]
        public void ChestCanBeUnLocked()
        {
            chest.IsLocked = true;
            chest.IsOpen = false;
            Assert.That(chest.UnLock(), Is.True);
        }

        [Test]
        public void StoringTreasuresInEmptyClosedChest()
        {
            Chest chestCopy = new Chest("chestCopy", 3);
            chestCopy.IsOpen = false;
            treasure = new Treasure.Treasure("gold", 1);
            Assert.That(chestCopy.Store(treasure), Is.False);
        }

        [Test]
        public void StoringTreasuresInEmptyOpenChest()
        {
            Chest chestCopy = new Chest("chestCopy", 3);
            chestCopy.IsOpen = true;
            treasure = new Treasure.Treasure("gold", 1);
            Assert.That(chestCopy.Store(treasure), Is.True);
        }

        [Test]
        public void StoringTreasuresInFullChest()
        {
            Chest chestCopy = new Chest("chestCopy", 13);
            chestCopy.IsOpen = true;
            treasure = new Treasure.Treasure("gold", 67);
            Assert.That(chestCopy.Store(treasure), Is.False);
        }

        [Test]
        public void StoringMultipleTreasuresInEmptyChest()
        {
            Chest chestCopy = new Chest("chestCopy", 13);
            chestCopy.IsOpen = true;
            Treasure.Treasure treasureCopy1 = new Treasure.Treasure("gold", 6);
            Treasure.Treasure treasureCopy2 = new Treasure.Treasure("diamond", 7);
            Assert.That(chestCopy.Store(treasureCopy1), Is.True);
            Assert.That(chestCopy.Store(treasureCopy2), Is.True);
        }

        [Test]
        public void StoringMultipleTreasuresInEmptyChestButRunningOutOfSpace()
        {
            Chest chestCopy = new Chest("chestCopy", 13);
            chestCopy.IsOpen = true;
            Treasure.Treasure treasureCopy1 = new Treasure.Treasure("gold", 6);
            Treasure.Treasure treasureCopy2 = new Treasure.Treasure("diamond", 7);
            Assert.That(chestCopy.Store(treasureCopy1), Is.True);
            Assert.That(chestCopy.Store(treasureCopy2), Is.True);
            treasure = new Treasure.Treasure("gold", 1);
            Assert.That(chestCopy.Store(treasure), Is.False);
        }

        [Test]
        public void StoringMultipleTreasuresInEmptyChestButClosingIt()
        {
            Chest chestCopy = new Chest("chestCopy", 15);
            chestCopy.IsOpen = true;
            Treasure.Treasure treasureCopy1 = new Treasure.Treasure("gold", 6);
            Treasure.Treasure treasureCopy2 = new Treasure.Treasure("diamond", 7);
            Assert.That(chestCopy.Store(treasureCopy1), Is.True);
            Assert.That(chestCopy.Store(treasureCopy2), Is.True);
            chestCopy.IsOpen = false;
            treasure = new Treasure.Treasure("gold", 1);
            Assert.That(chestCopy.Store(treasure), Is.False);
        }
    }
}