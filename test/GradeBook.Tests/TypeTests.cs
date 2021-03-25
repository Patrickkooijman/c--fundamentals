using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        private delegate string WriteLogDelegate(string logMessage);
        private int _count;
        
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            log += ReturnMessage;
            log += IncrementCount;

            Assert.Equal(3, _count);
        }

        string IncrementCount(string message)
        {
            _count++;
            return message.ToLower();
        }
        
        string ReturnMessage(string message)
        {
            _count++;
            return message;
        }
        
        [Fact]
        public void SendIntAsReferenceType()
        {
            var x = GetInt();
            SetInt(ref x);
            
            Assert.Equal(42, x);
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            var name = "Patrick";
            var upper = MakeUppercase(name);
            
            Assert.Equal("Patrick", name);
            Assert.Equal("PATRICK", upper);
        }

        private string MakeUppercase(string name)
        {
            return name.ToUpper();
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }        
        
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(ReferenceEquals(book1, book2));
        }
        
        [Fact]
        public void CSharpCanPassByRef()
        {
            var book = GetBook("Book 1");
            GetBookSetName(out book, "New Name");

            Assert.Equal("New Name", book.Name);
        }
        
        private void GetBookSetName(out InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook = new InMemoryBook(name);
        }
                
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book = GetBook("Book 1");
            GetBookSetName(book, "New Name");

            Assert.Equal("Book 1", book.Name);
        }    
                
        private void GetBookSetName(InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook = new InMemoryBook(name);
        }
        
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook.Name = name;
        }

        private static InMemoryBook GetBook(string name)
        {
            return new(name);
        }
    }
}
