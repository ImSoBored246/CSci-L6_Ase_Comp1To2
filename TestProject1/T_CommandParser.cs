using CSci_L6_Ase_Comp1To2;
using TestProject1;

namespace T_CSci_L6_Ase_Comp1To2
{
    [TestClass]
    public class TCommandParser_Exc
    {
        ///<summary>Tests the CommandParser's ability to execute code. Note that error checks will be handled by CheckSyntax(..) regardless, so that method is also tested here</summary>
        ///
        [TestMethod]
        public void CP_Throws_Exc_EmptyNull()
        {
        ///<summary>Checks if empty/null exceptions are thrown appropriately</summary>
        ///
        string[] test_code = new string[] {
                null,
                "",
                " \t\r\n"
            }; // test cases are null, empty, whitespace only
        try { CommandParser.CheckSyntax(test_code[0]); }
        catch (ArgumentNullException) { /*success*/ }
        try { CommandParser.CheckSyntax(test_code[1]); }
        catch (ArgumentException) { /*success*/ }
        try { CommandParser.CheckSyntax(test_code[2]); }
        catch (ArgumentException) { /*success*/ }
        }
        [TestMethod]
        public void CP_Throws_Exc_Runtime()
        {
        ///<summary>Checks if code runtime errors are thrown appropriately</summary>
        ///
        string[] test_code = new string[] {
                "circle 50\n" +
                "moveto 100 100\n" +
                "bake me a pie", // invalidcmd, expect err, line 3, argumentex, 0

                "moveto 100 100\n" +
                "MoveTo 60 60\n" +
                "moveto 100 test", // moveto,  expect err, line 3, formatex,    1

                "moveto 100 100\n" +
                "MoveTo 60 60\n" +
                "moveto 900 900", // moveto,  expect err, line 3, argumentex,  2

                "Circle 100\n" +
                "MoveTo 60 60\n" +
                "circle word", //   circle,    expect err, line 3, formatex,    3

                "circle 100\n" +
                "MoveTo 60 60\n" +
                "circle 0",    //   circle,    expect err, line 3, argumentex,  4

                "rectangle 100 80\n" +
                "MoveTo 60 60\n" +
                "rect len width", //   rect,   expect err, line 3, formatex,    5

                "rectangle 100 80\n" +
                "rect 100 -143", // rect,    expect err, line 2, argumentex,  6

                "drawTo 100 100\n" +
                "DrawTo 60 60\n" +
                "drawto 10.4 test", // drawto,  expect err, line 3, formatex,    7

                "drawto 100 100\n" +
                "drawto 60 60\n" +
                "drawto 900 100", // drawto,  expect err, line 3, argumentex,  8

                "triangle 60\n" + 
                "triangle size",   // trian,   expect err, line 2, formatex,    9

                "moveto 50 50\n" +
                "triangle -20\n" +
                "triangle 20",    // trian,   expect err, line 2, argumentex,  10

                "pen red\n" + 
                "pen wred",     // pen,     expect err, line 2, argumentex, 11

                "pen one two" // pen,   expect err, line 1, argumentex, 12
            };
        try { CommandParser.CheckSyntax(test_code[0]); Assert.Fail("No exception, test 0"); }
        catch (ArgumentException ex) { Assert.AreEqual("Line 3 ERR! \"bake me a pie\" is an invalid command", ex.Message); }

        try { CommandParser.CheckSyntax(test_code[1]); Assert.Fail("No exception, test 1"); }
        catch (FormatException ex) { Assert.AreEqual("Line 3 ERR! MoveTo command expects 2x integer args", ex.Message); }

        try { CommandParser.CheckSyntax(test_code[2]); Assert.Fail("No exception, test 2"); }
        catch (ArgumentException ex) { Assert.AreEqual("Line 3 ERR! Canvas size is (10,10) to (476, 445).", ex.Message); }

        try { CommandParser.CheckSyntax(test_code[3]); Assert.Fail("No exception, test 3"); }
        catch (FormatException ex) { Assert.AreEqual("Line 3 ERR! Circle command expects integer arg", ex.Message); }

        try { CommandParser.CheckSyntax(test_code[4]); Assert.Fail("No exception, test 4"); }
        catch (ArgumentException ex) { Assert.AreEqual("Line 3 ERR! Circle radius too small.", ex.Message); }

        try { CommandParser.CheckSyntax(test_code[5]); Assert.Fail("No exception, test 5"); }
        catch (FormatException ex) { Assert.AreEqual("Line 3 ERR! Rectangle command expects 2x integer args", ex.Message); }

        try { CommandParser.CheckSyntax(test_code[6]); Assert.Fail("No exception, test 6"); }
        catch (ArgumentException ex) { Assert.AreEqual("Line 2 ERR! Side length too small.", ex.Message); }

        try { CommandParser.CheckSyntax(test_code[7]); Assert.Fail("No exception, test 7"); }
        catch (FormatException ex) { Assert.AreEqual("Line 3 ERR! DrawTo command expects 2x integer args", ex.Message); }

        try { CommandParser.CheckSyntax(test_code[8]); Assert.Fail("No exception, test 8"); }
        catch (ArgumentException ex) { Assert.AreEqual("Line 3 ERR! Canvas size is (10,10) to (476, 445).", ex.Message); }

        try { CommandParser.CheckSyntax(test_code[9]); Assert.Fail("No exception, test 9"); }
        catch (FormatException ex) { Assert.AreEqual("Line 2 ERR! Triangle command expects integer arg", ex.Message); }

        try { CommandParser.CheckSyntax(test_code[10]); Assert.Fail("No exception, test 10"); }
        catch (ArgumentException ex) { Assert.AreEqual("Line 2 ERR! Triangle radius too small.", ex.Message); }

        try { CommandParser.CheckSyntax(test_code[11]); Assert.Fail("No exception, test 11"); }
        catch (ArgumentException ex) { Assert.AreEqual("Line 2 ERR! Invalid colour chosen", ex.Message); }

        try { CommandParser.CheckSyntax(test_code[12]); Assert.Fail("No exception, test 12"); }
        catch (ArgumentException ex) { Assert.AreEqual("Line 1 ERR! Pen colour needs one argument", ex.Message); }
        }
    }
    [TestClass]
    public class TCommandParser_Io
    {
        ///<summary>Tests the CommandParser's ability to save and load code.</summary>
        ///
        [TestMethod]
        public void CP_Throws_Sav()
        {
        ///<summary>Checks if exception is thrown using dummy SaveFile(..) method</summary>
        ///
        try { D_CommandParser.SaveFile("line 1\nline 2\nend of code"); }
        catch (IOException ex) { Assert.AreEqual(ex.Message, "Dummy Check"); } // catch failure
        try { D_CommandParser.SaveFile(null); } 
        catch (ArgumentNullException) { /*success*/ } // catch null
        try { D_CommandParser.SaveFile(""); }
        catch (ArgumentException ex) { /*success*/  } // catch empty
        try { D_CommandParser.SaveFile("line 1\nline 2\nend of code", false); }
        catch (Exception ex) { Assert.AreEqual(ex.Message, "File Dialog aborted! Your file has NOT saved!"); } // catch manual abort
        }

        [TestMethod]
        public void CP_Throws_Loa()
        {
        ///<summary>Checks if exception is thrown using dummy LoadFile() method</summary>
        ///
        try { D_CommandParser.OpenFile(); }
        catch (IOException ex) { Assert.AreEqual(ex.Message, "Dummy Check"); }
        }
    }

}