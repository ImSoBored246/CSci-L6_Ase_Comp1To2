using CSci_L6_Ase_Comp1To2;
namespace T_CSci_L6_Ase_Comp1To2
{
    /*[TestClass]
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
            try { CommandParser.Execute(test_code[0]); }
            catch (ArgumentNullException ex) { Assert.AreEqual("ERR! Null exception. This shouldn't have happened...", ex.Message); }
            try { CommandParser.Execute(test_code[1]); }
            catch (ArgumentException ex) { Assert.AreEqual("ERR! No code!", ex.Message); }
            try { CommandParser.Execute(test_code[2]); }
            catch (ArgumentException ex) { Assert.AreEqual("ERR! No code!", ex.Message); }
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

                "", // moveto,  expect err, line X, formatex,    1

                "", // moveto,  expect err, line X, argumentex,  2

                "", // circle,  expect err, line X, formatex,    3

                "", // circle,  expect err, line X, argumentex,  4

                "", // rect,    expect err, line X, formatex,    5

                "", // rect,    expect err, line X, argumentex,  6

                "", // drawto,  expect err, line X, formatex,    7

                "", // drawto,  expect err, line X, argumentex,  8

                "", // trian,   expect err, line X, formatex,    9

                "", // trian,   expect err, line X, argumentex,  10
            };
            try { CommandParser.Execute(test_code[0]); Assert.Fail("No exception, test 0"); }
            catch (ArgumentException ex) { Assert.AreEqual("Line 3 ERR! \"bake me a pie\" is an invalid command", ex.Message); }

            try { CommandParser.Execute(test_code[1]); Assert.Fail("No exception, test 1"); }
            catch (FormatException ex) { Assert.AreEqual("Line X ERR! MoveTo command expects 2x integer args", ex.Message); }

            try { CommandParser.Execute(test_code[2]); Assert.Fail("No exception, test 2"); }
            catch (ArgumentException ex) { Assert.AreEqual("Line X ERR! Canvas size is (10,10) to (476, 445).", ex.Message); }

            try { CommandParser.Execute(test_code[3]); Assert.Fail("No exception, test 3"); }
            catch (FormatException ex) { Assert.AreEqual("Line X ERR! Circle command expects integer arg", ex.Message); }

            try { CommandParser.Execute(test_code[4]); Assert.Fail("No exception, test 4"); }
            catch (ArgumentException ex) { Assert.AreEqual("Line X ERR! Circle radius too small.", ex.Message); }

            try { CommandParser.Execute(test_code[5]); Assert.Fail("No exception, test 5"); }
            catch (FormatException ex) { Assert.AreEqual("Line X ERR! Rectangle command expects 2x integer args", ex.Message); }

            try { CommandParser.Execute(test_code[6]); Assert.Fail("No exception, test 6"); }
            catch (ArgumentException ex) { Assert.AreEqual("Line X ERR! Side length too small.", ex.Message); }

            try { CommandParser.Execute(test_code[7]); Assert.Fail("No exception, test 7"); }
            catch (FormatException ex) { Assert.AreEqual("Line X ERR! DrawTo command expects 2x integer args", ex.Message); }

            try { CommandParser.Execute(test_code[8]); Assert.Fail("No exception, test 8"); }
            catch (ArgumentException ex) { Assert.AreEqual("Line X ERR! Canvas size is (10,10) to (476, 445).", ex.Message); }

            try { CommandParser.Execute(test_code[9]); Assert.Fail("No exception, test 9"); }
            catch (FormatException ex) { Assert.AreEqual("Line X ERR! Triangle command expects integer arg", ex.Message); }

            try { CommandParser.Execute(test_code[10]); Assert.Fail("No exception, test 10"); }
            catch (ArgumentException ex) { Assert.AreEqual("Line X ERR! Triangle radius too small.", ex.Message); }
        }
    }
    [TestClass]
    public class TCommandParser_Io
    {
        ///<summary>Tests the CommandParser's ability to save and load code.</summary>
        ///
        [TestMethod]
        public void CP_Throws_Sav_Io()
        {
            ///<summary>Checks if IO exception is thrown using dummy SaveFile(..) method</summary>
            ///
            // TODO
        }
        [TestMethod]
        public void CP_Throws_Loa_Io()
        {
            ///<summary>Checks if IO exception is thrown using dummy LoadFile() method</summary>
            ///
            // TODO
        }
        [TestMethod]
        public void CP_Ok_Sav()
        {
            ///<summary>Checks if SaveFile(..) method works under normal circumstances</summary>
            ///
            // TODO
        }
        [TestMethod]
        public void CP_Ok_Loa()
        {
            ///<summary>Checks if LoadFile() method works under normal circumstances</summary>
            ///
            // TODO
        }
    }
    */
}