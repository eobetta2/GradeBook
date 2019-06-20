using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
         int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod() {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage; 
            log += IncrementCount;

            var result = log("Hello");

            Assert.Equal(3, count);
        }

        string IncrementCount(string message) {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message) {
            count++;
            return message;
        }

        [Fact] 
        public void ValueTypesAlsoPassByValue() {
            int x = GetInt();
            SetInt(ref x);
        }

        private void SetInt(ref int z) {
            z = 42;
        }

        [Fact]
        public void StrignsBehaveLikeValTypes() {
            string name = "Scott";
            string upper = MakeUpperCase(name);

            Assert.Equal("SCOTT", upper);
            Assert.Equal("Scott", name);

        }

        private string MakeUpperCase(string paramter) {
            return paramter.ToUpper();
        }

        [Fact]
        public void Test1() {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3,x);

        }

        private void SetInt(int x) {
            x = 42;
        }

        private int GetInt() {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef() {
            Book book = GetBook("Book 1");
            GetBookSetName(out book, "New Name");

            Assert.Equal("New Name", book.name);

        }

        private void GetBookSetName(out Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue() {
            Book book = GetBook("Book 1");
            GetBookSetName(book, "New Name");

            Assert.Equal("Book 1", book.name);

        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name); 
        }

        [Fact]
        public void CanSetNameFromReference() {
            Book book = GetBook("Book 1");
            SetName(book, "New Name");

            Assert.Equal("New Name", book.name);

        }

        private void SetName(Book book, string name)
        {
            book.name = name; 
        }

        [Fact]
        public void GetBookHasDistinctReturns() {
            Book book = GetBook("Book 1");
            Book book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book.name);
            Assert.Equal("Book 2", book2.name);

        }

        [Fact]
        public void TwoVarsReferenceSameObject() {
            Book book = GetBook("Book 1");
            Book book2 = book;

            Assert.Same(book2, book);
            Assert.True(Object.ReferenceEquals(book,book2));
        }

        Book GetBook(string name) {
            return new Book(name);
        }
    }
}