using InvoicingLib;

namespace InvoicingTest;

public class InvoicingTests
{
    private Invoicing _invoicing;
    
    [SetUp]
    public void Setup()
    {
        _invoicing = new();
    }

    [Test]
    public void EmptyInvoiceHasZeroTotal()
    {
        Assert.That(_invoicing.NetTotal, Is.EqualTo(0));
    }

    [Test]
    public void AddingAnItemIncreasesTotal()
    {
        var current = _invoicing.NetTotal;
        _invoicing.Add("Tej", 100);
        Assert.That(_invoicing.NetTotal, Is.EqualTo(current + 100));
    }

    [Test]
    public void AddMoreItemsIncreasesTotalByBothAmounts()
    {
        var current = _invoicing.NetTotal;
        _invoicing.Add("Tej", 100);
        _invoicing.Add("Kenyér", 1200);
        Assert.That(_invoicing.NetTotal, Is.EqualTo(current + 1300));
    }

    [Test]
    public void VatIsAddedToTotalVat()
    {
        _invoicing.Add("Tej", 100);
        Assert.That(_invoicing.TotalVat, Is.EqualTo(27));
    }

    [Test]
    public void TotalEqualsNetTotalPlusTotalVat()
    {
        _invoicing.Add("Tej", 100);
        _invoicing.Add("Kenyér", 1200);
        Assert.That(_invoicing.Total, Is.EqualTo(1300 * 1.27));
    }

    [Test]
    public void VatIsDifferentForChicken()
    {
        _invoicing.Add("Csirkefarhát", 100);
        Assert.That(_invoicing.TotalVat, Is.EqualTo(5));
    }

    [Test]
    public void MultipleVatItemsAreAccounted()
    {
        _invoicing.Add("Tej", 100);
        _invoicing.Add("Csirkefarhát", 100);
        Assert.That(_invoicing.TotalVat, Is.EqualTo(27+5));
        
    }
}