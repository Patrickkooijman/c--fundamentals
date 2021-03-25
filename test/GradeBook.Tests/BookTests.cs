using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnGrades()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            
            // act
            var result = book.GetStatistics();
            
            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High,1);
            Assert.Equal(77.3, result.Low,1);
            Assert.Equal('B', result.Letter);
        }
        [Fact]
        public void AddGradeShouldVerify()
        {
            var ints = new Dictionary<int, int>()
            {
                {-1, 0},
                {1, 1},
                {100, 100},
                {101, 0}
            };
            Assert.All(ints, entry =>
            {
                var book = new InMemoryBook("");
                book.AddGrade(entry.Key);
                Assert.Equal(entry.Value, book.GetStatistics().Average);
            });
        }
    }
}
