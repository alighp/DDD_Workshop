using AutoFixture.Xunit2;
using FluentAssertions;

namespace Domain.Spec
{
    public class TransactionIdSpecs
    {
        [Theory, AutoData]
        public void Supports_Equality(string id)
        {
            //Assert
            var left = new TransactionId(id);
            var right = new TransactionId(id);

            //Act
            (left == right)

            //Assert
            .Should().BeTrue();
        }

        [Theory, AutoData]
        public void Supports_nonEquality(string leftId, string rightId)
        {
            //Assert
            var left = new TransactionId(leftId);
            var right = new TransactionId(rightId);

            //Act
            (left != right)

            //Assert
            .Should().BeTrue();
        }

        [Fact]
        public void Id_can_not_be_null()
        {
            //Act
            Action expected = () => new TransactionId(null);


            //Assert
            expected.Should().Throw<Exception>(); ;
        }

        [Fact]
        public void Id_can_not_be_empty()
        {
            //Act
            Action expected = () => new TransactionId(string.Empty);


            //Assert
            expected.Should().Throw<Exception>(); ;
        }
    }
}
