using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests

    {
        [Fact]
        public void BookCalculatesStats() {

            //arrange
            Book book = new Book("");
            book.AddGrade(90.34);
            book.AddGrade(80.55);
            book.AddGrade(70.23);

            //act
            Statistics result = book.GetStatistics();

            //assert
            Assert.Equal(80.4,result.Average, 1);
            Assert.Equal(90.3,result.High, 1);
            Assert.Equal(70.2,result.Low, 1);
        }
    }
}
