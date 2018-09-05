using System;
using NUnit.Framework;

namespace FileData.Test
{
    [TestFixture]
    public class FileDataCommandTests
    {
        [Test]
        [TestCase("-v")]
        [TestCase("--v")]
        [TestCase("/v")]
        [TestCase("--version")]
        public void Valid_Version_Cammand_Should_Return_Valid_Result(string cmdText)
        {
            //Arrange
            var cmd = new FileDataCommand(cmdText, "c:/test.txt");
            //Act
           var cmdResult= cmd.Execute();
            //Assert
            Assert.AreEqual(CommandType.Version, cmd.TypeOfCommand);
            Assert.AreEqual(cmdResult.GetType(), typeof(string));
        }

        [Test]
        [TestCase("-s")]
        [TestCase("--s")]
        [TestCase("/s")]
        [TestCase("--size")]
        public void Valid_Size_Cammand_Should_Return_Valid_Result(string cmdText)
        {
            //Arrange
            var cmd = new FileDataCommand(cmdText, "c:/test.txt");
            //Act
            var cmdResult = cmd.Execute();
            //Assert
            Assert.AreEqual(CommandType.Size, cmd.TypeOfCommand);
            Assert.AreEqual(cmdResult.GetType(), typeof(int));
        }

        [Test]
        [TestCase("-S")]
        [TestCase("---s")]
        [TestCase("/ss")]
        [TestCase("--size-")]
        public void InValid_Cammand_Should_Return_Empty_String(string cmdText)
        {
            //Arrange
            var cmd = new FileDataCommand(cmdText, "c:/test.txt");
            //Act
            var cmdResult = cmd.Execute();
            //Assert
            Assert.AreEqual(string.Empty, cmdResult);
        }
    }
}
