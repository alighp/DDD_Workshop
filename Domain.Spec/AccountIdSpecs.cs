using AutoFixture.Xunit2;
using FluentAssertions;

namespace Domain.Spec
{
    public class AccountIdSpecs
    {
        [Theory, AutoData]
        public void Supports_Equality(string id)
        {
            //Assert
            var left = new AccountId(id);
            var right = new AccountId(id);

            //Act
            (left == right)

            //Assert
            .Should().BeTrue();
        }

        [Theory, AutoData]
        public void Supports_nonEquality(string leftId, string rightId)
        {
            //Assert
            var left = new AccountId(leftId);
            var right = new AccountId(rightId);

            //Act
            (left != right)

            //Assert
            .Should().BeTrue();
        }

        [Fact]
        public void Id_can_not_be_null()
        {
            //Act
            Action expected = () => new AccountId(null);


            //Assert
            expected.Should().Throw<Exception>(); ;
        }

        [Fact]
        public void Id_can_not_be_empty()
        {
            //Act
            Action expected = () => new AccountId(string.Empty);


            //Assert
            expected.Should().Throw<Exception>(); ;
        }
    }
}
