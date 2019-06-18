using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests

    {
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
