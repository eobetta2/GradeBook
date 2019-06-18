using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests

    {
        [Fact]
        public void Test1() {
            Book book = GetBook("Book 1");
            Book book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book.Name);
            Assert.Equal("Book 2", book2.Name);

        }

        Book GetBook(string name) {
            return new Book(name);
        }
    }
}
