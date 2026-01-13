namespace password_unit_tests;

[TestClass]
public sealed class Validation
{
    // 4. feladat
    [TestMethod]
    public void IsValidPassword()
    {
        string password = "Abc123";

        Assert.IsTrue(password_class_lib.Password.IsValid(password));
    }

    // Csináltam egy IsValidPassword ellentétet is, ami csak azt nézi, hogy invalid-e az előre megadott jelszó
    [TestMethod]
    public void IsInvalidPassword()
    {
        string password = "";
        
        Assert.IsFalse(password_class_lib.Password.IsValid(password));
    }

    // 5. feladat
    [TestMethod]
    public void IsInValidPassword1()
    {
        string password = "ABC123";
        
        Assert.IsFalse(password_class_lib.Password.IsValid(password));
    }

    [TestMethod]
    public void IsInValidPassword2()
    {
        string password = "abc123";
        
        Assert.IsFalse(password_class_lib.Password.IsValid(password));
    }

    [TestMethod]
    public void IsInValidPassword3()
    {
        string password = "Abcdef";
        
        Assert.IsFalse(password_class_lib.Password.IsValid(password));
    }

    [TestMethod]
    public void IsInValidPassword4()
    {
        string password = "Nig67";
        
        Assert.IsFalse(password_class_lib.Password.IsValid(password));
    }

    // 6. feladat
    [TestMethod]
    public void IsValidPassword1()
    {
        string password = "Aáb123";
        
        Assert.IsTrue(password_class_lib.Password.IsValid(password));
    }

    [TestMethod]
    public void IsValidPassword2()
    {
        string password = "Áab123";
        
        Assert.IsTrue(password_class_lib.Password.IsValid(password));
    }

    [TestMethod]
    public void IsValidPassword3()
    {
        string password = "Abc12$";
        
        Assert.IsTrue(password_class_lib.Password.IsValid(password));
    }
}