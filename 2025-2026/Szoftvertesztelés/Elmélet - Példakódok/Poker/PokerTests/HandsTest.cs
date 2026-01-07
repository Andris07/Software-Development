using PokerLib;

namespace PokerTests;

public class HandsTest
{
    private Hand _hand;
    
    [SetUp]
    public void Setup()
    {
        _hand = new();
    }

    [Test]
    public void EmptyHandHasNoCards()
    {
        Assert.That(_hand.Cards.Count, Is.EqualTo(0));
    }

    [Test]
    public void OneCardIsAddedToHand()
    {
        _hand.AddCard(Hand.Faces.Two, Hand.Suites.Clubs);
        Assert.That(_hand.Cards.Count, Is.EqualTo(1));
        Assert.That(_hand.Cards[0].Face, Is.EqualTo(Hand.Faces.Two));
        Assert.That(_hand.Cards[0].Suite, Is.EqualTo(Hand.Suites.Clubs));
    }

    [Test]
    public void TwoCardsAreAddedToHand()
    {
        _hand.AddCard(Hand.Faces.Two, Hand.Suites.Clubs);
        _hand.AddCard(Hand.Faces.Ace, Hand.Suites.Diamonds);
        Assert.That(_hand.Cards.Count, Is.EqualTo(2));
        
    }

    [Test]
    public void TwoIdenticalCardsCannotBeAddedToHand()
    {
        _hand.AddCard(Hand.Faces.Ten, Hand.Suites.Diamonds);
        _hand.AddCard(Hand.Faces.Ten, Hand.Suites.Diamonds);
        Assert.That(_hand.Cards.Count, Is.EqualTo(1));
    }

    [Test]
    public void FiveCardsCanBeAdded()
    {
        _hand.AddCard(Hand.Faces.Four, Hand.Suites.Hearts);
        _hand.AddCard(Hand.Faces.Queen, Hand.Suites.Spades);
        _hand.AddCard(Hand.Faces.Three, Hand.Suites.Hearts);
        _hand.AddCard(Hand.Faces.Six, Hand.Suites.Clubs);
        _hand.AddCard(Hand.Faces.Jack, Hand.Suites.Clubs);
        Assert.That(_hand.Cards.Count, Is.EqualTo(5));
    }
    [Test]
    public void SixCardsCannotBeAdded()
    {
        _hand.AddCard(Hand.Faces.Four, Hand.Suites.Hearts);
        _hand.AddCard(Hand.Faces.Queen, Hand.Suites.Spades);
        _hand.AddCard(Hand.Faces.Three, Hand.Suites.Hearts);
        _hand.AddCard(Hand.Faces.Six, Hand.Suites.Clubs);
        _hand.AddCard(Hand.Faces.Jack, Hand.Suites.Clubs);
        _hand.AddCard(Hand.Faces.King, Hand.Suites.Clubs);
        Assert.That(_hand.Cards.Count, Is.EqualTo(5));
    }

    [Test]
    public void GivenAStringAHandCanBeConstructed()
    {
        _hand.AddHand("HA, D2, S3, HK, C10");
        Assert.That(_hand.Cards.Count, Is.EqualTo(5));
        Assert.That(_hand.Cards[0].Face, Is.EqualTo(Hand.Faces.Ace));
        Assert.That(_hand.Cards[0].Suite, Is.EqualTo(Hand.Suites.Hearts));

        Assert.That(_hand.Cards[1].Face, Is.EqualTo(Hand.Faces.Two));
        Assert.That(_hand.Cards[1].Suite, Is.EqualTo(Hand.Suites.Diamonds));

        Assert.That(_hand.Cards[2].Face, Is.EqualTo(Hand.Faces.Three));
        Assert.That(_hand.Cards[2].Suite, Is.EqualTo(Hand.Suites.Spades));

        Assert.That(_hand.Cards[3].Face, Is.EqualTo(Hand.Faces.King));
        Assert.That(_hand.Cards[3].Suite, Is.EqualTo(Hand.Suites.Hearts));

        Assert.That(_hand.Cards[4].Face, Is.EqualTo(Hand.Faces.Ten));
        Assert.That(_hand.Cards[4].Suite, Is.EqualTo(Hand.Suites.Clubs));

    }

    [Test]
    public void HandIsCleared()
    {
        _hand.AddHand("HA, D2, S3, HK, C10");
        _hand.RemoveAllCards();
        Assert.That(_hand.Cards.Count, Is.EqualTo(0));
    }
    
}