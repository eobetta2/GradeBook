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
            InMemoryBook book = GetBook("Book 1");
            GetBookSetName(out book, "New Name");

            Assert.Equal("New Name", book.Name);

        }

        private void GetBookSetName(out InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue() {
            InMemoryBook book = GetBook("Book 1");
            GetBookSetName(book, "New Name");

            Assert.Equal("Book 1", book.Name);

        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name); 
        }

        [Fact]
        public void CanSetNameFromReference() {
            InMemoryBook book = GetBook("Book 1");
            book.Name = "New Name";

            Assert.Equal("New Name", book.Name);

        }

        [Fact]
        public void GetBookHasDistinctReturns() {
            InMemoryBook book = GetBook("Book 1");
            InMemoryBook book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book.Name);
            Assert.Equal("Book 2", book2.Name);

        }

        [Fact]
        public void TwoVarsReferenceSameObject() {
            InMemoryBook book = GetBook("Book 1");
            InMemoryBook book2 = book;

            Assert.Same(book2, book);
            Assert.True(Object.ReferenceEquals(book,book2));
        }

        InMemoryBook GetBook(string name) {
            return new InMemoryBook(name);
        }
    }
}