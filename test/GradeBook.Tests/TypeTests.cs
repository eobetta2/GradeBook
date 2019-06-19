using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests

    {
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

            Assert.Equal("New Name", book.Name);

        }

        private void GetBookSetName(out Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue() {
            Book book = GetBook("Book 1");
            GetBookSetName(book, "New Name");

            Assert.Equal("Book 1", book.Name);

        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name); 
        }

        [Fact]
        public void CanSetNameFromReference() {
            Book book = GetBook("Book 1");
            SetName(book, "New Name");

            Assert.Equal("New Name", book.Name);

        }

        private void SetName(Book book, string name)
        {
            book.Name = name; 
        }

        [Fact]
        public void GetBookHasDistinctReturns() {
            Book book = GetBook("Book 1");
            Book book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book.Name);
            Assert.Equal("Book 2", book2.Name);

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