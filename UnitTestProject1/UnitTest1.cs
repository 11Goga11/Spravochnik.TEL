using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Телефонный_справочник;


namespace Телефонный_справочник_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IContactRepository> _mockContactRepository;
        private PhoneBookService _phoneBookService;
        [TestMethod]
        public void Setup()
        {
            _mockContactRepository = new Mock<IContactRepository>();
            _phoneBookService = new PhoneBookService(_mockContactRepository.Object);
        }
        public void AddContact_WhenCalled_ShouldAddContactToRepository()
        {
            // Arrange
            var contact = new Contact { Name = "John Doe", PhoneNumber = "1234567890" };

            // Act
            _phoneBookService.AddContact(contact);
        }
        public void GetAllContacts_WhenCalled_ShouldReturnAllContactsFromRepository()
        {
            // Arrange
            var contacts = new List<Contact>
        {
            new Contact { Name = "John Doe", PhoneNumber = "1234567890" },
            new Contact { Name = "Jane Doe", PhoneNumber = "0987654321" }
        };
            _mockContactRepository.Setup((contacts));

            // Act
            var result = _phoneBookService.GetAllContacts();

            // Assert
            Assert.AreEqual(contacts, result);
        }
    }

    internal class Times
    {
        internal static object Once;
    }

    internal class Mock<T>
    {
        internal IContactRepository Object;

        internal void Setup(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        internal void Setup(List<Contact> contacts)
        {
            throw new NotImplementedException();
        }

        internal void Verify(Func<object, object> p, object once)
        {
            throw new NotImplementedException();
        }
    }

    internal class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    internal class PhoneBookService
    {
        private IContactRepository @object;

        public PhoneBookService(IContactRepository @object)
        {
            this.@object = @object;
        }

        internal void AddContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        internal List<Contact> GetAllContacts()
        {
            throw new NotImplementedException();
        }
    }

    internal interface IContactRepository
    {
        void Add(Contact contact);
        void GetAllContacts(List<Contact> contacts);
    }
}

