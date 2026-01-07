using NUnit.Framework.Internal;
using PokerLib;

namespace PokerTests;

public class PokerTest
{
    private Poker _poker;
    
    [SetUp]
    public void Setup()
    {
        _poker = new();
    } 
    
    [Test]
    public void TestDealWithTwoPlayers()
    {
        _poker.AddPlayers(2);
        _poker.Deal();
        Assert.That(_poker.PlayerCount, Is.EqualTo(2));
        Assert.That(_poker.Hands[0].Cards.Count, Is.EqualTo(5));
        Assert.That(_poker.Hands[1].Cards.Count, Is.EqualTo(5));
    }

    [Test]
    public void RoyalFlushWins()
    {
        _poker.AddPlayers(2);
        _poker.Hands[0].RemoveAllCards();
        _poker.Hands[1].RemoveAllCards();
        _poker.Hands[1].AddHand("HA, HK, HQ, HJ, H10");
        _poker.Hands[0].AddHand("SA, SQ, C10, C8, D6");
        Assert.That(_poker.PickWinner(), Is.EqualTo(1));
    }
}