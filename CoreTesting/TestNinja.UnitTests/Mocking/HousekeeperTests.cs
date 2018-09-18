using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;
using static TestNinja.Mocking.HousekeeperHelper;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class HousekeeperTests
    {
        private Mock<IUnitOfWork> _mockDB;
        private Mock<IEmailSender> _mockEmail;
        private Mock<IXtraMessageBox> _mockMB;
        private Mock<IStatementGenerator> _mockStatement;
        private HousekeeperHelper _service;
        private DateTime _serviceDate = new DateTime(2018, 1, 1);
        private Housekeeper _testHouseKeeper;
        private string _filename;

        [SetUp]
        public void SetUp()
        {
            _testHouseKeeper = new Housekeeper { Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" };
            _mockDB = new Mock<IUnitOfWork>();
            _mockDB.Setup(x => x.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                _testHouseKeeper

            }.AsQueryable());

            _filename = "filename";
            _mockStatement = new Mock<IStatementGenerator>();
            _mockStatement.Setup(s => s.SaveStatement(_testHouseKeeper.Oid, _testHouseKeeper.FullName, _serviceDate))
                .Returns(()=>_filename);
            _mockMB = new Mock<IXtraMessageBox>();
            _mockEmail = new Mock<IEmailSender>();
            _service = new HousekeeperHelper(_mockDB.Object, _mockStatement.Object, _mockEmail.Object, _mockMB.Object);
        }

        [Test]
        public void SendStateEmail_WhenCalled_GeneratesEmailStatements()
        {
            _service.SendStatementEmails(_serviceDate);
            _mockStatement.Verify(s => s.SaveStatement(_testHouseKeeper.Oid, _testHouseKeeper.FullName, _serviceDate));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void SendStateEmail_HKEmailIsInvalid_NotGeneratesEmailStatementForIt(string email)
        {
            _testHouseKeeper.Email = email;
            _service.SendStatementEmails(_serviceDate);
            _mockStatement.Verify(
                s => s.SaveStatement(_testHouseKeeper.Oid, _testHouseKeeper.FullName, _serviceDate), Times.Never);
        }

        [Test]
        public void SendStateEmail_WhenCalled_EmailsStatement()
        {
            _service.SendStatementEmails(_serviceDate);
            _mockEmail.Verify(e => e.EmailFile(_testHouseKeeper.Email,_testHouseKeeper.StatementEmailBody,_filename,It.IsAny<string>()));
            
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void SendStateEmail_EmailIsEmptyOrWhiteSpace_NotEmailsStatement(string retValue)
        {
            _filename = retValue;
            _service.SendStatementEmails(_serviceDate);
            _mockEmail.Verify(e => e.EmailFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),Times.Never);

        }

        [Test]
        public void SendStateEmail_ProblemWithSendingEmail_ShowMsgBox()
        {
            _mockEmail.Setup(e => e.EmailFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Throws<Exception>();
            _service.SendStatementEmails(_serviceDate);
            _mockMB.Verify(m => m.Show(It.IsAny<string>(),It.IsAny<string>(),MessageBoxButtons.OK));
        }


    }
}
