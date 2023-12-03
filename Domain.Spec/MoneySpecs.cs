using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
namespace Domain.Spec;


public class MoneySpecs
{
    [Theory, AutoData]
    public void Money_cannot_be_negative(decimal amount)
        => new Action(() =>               //Arrange

           new Money(-Math.Abs(amount))   //Act

        ).Should().Throw<Exception>(); //Assert

    [Theory, AutoData]
    public void Supports_subtraction(decimal left, decimal right)
    {
        //Arrange
        Money first = Math.Abs(left);
        Money second = Math.Abs(right);

        //Act
        (left >= right ? first - second : second - first)

        //Assert
        .Value.Should().Be(Math.Abs(left - right));
    }

    [Theory, AutoData]
    public void Supports_addition(decimal left, decimal right)
    {
        //Arrange
        Money first = Math.Abs(left);
        Money second = Math.Abs(right);

        //Act
        (first + second)

        //Assert
        .Value.Should().Be(left + right);
    }

    [Theory, AutoData]
    public void Supports_greater_than(decimal value)
    {
        //Arange
        Money smallerNumber = Math.Abs(value);
        Money biggerNumber = Math.Abs(value + 2);

        //Act
        (biggerNumber > smallerNumber)

        //Assert
        .Should().BeTrue();
    }

    [Theory, AutoData]
    public void Supports_lower_than(decimal value)
    {
        //Arange
        Money smallerNumber = Math.Abs(value);
        Money biggerNumber = Math.Abs(value + 2); ;

        //Act
        (smallerNumber < biggerNumber)

        //Assert
        .Should().BeTrue();
    }

    [Theory, AutoData]
    public void Supports_equal_or_greater_than(decimal value)
    {
        //Arange
        Money smallerNumber = Math.Abs(0);
        Money biggerNumber = Math.Abs(0 * 2);

        //Act
        (biggerNumber >= smallerNumber)

        //Assert
        .Should().BeTrue();
    }

    [Theory, AutoData]
    public void Supports_equal_or_lower_than(decimal value)
    {
        //Arange
        Money smallerNumber = Math.Abs(value);
        Money biggerNumber = Math.Abs(value * 2);

        //Act
        (smallerNumber <= biggerNumber)

        //Assert
        .Should().BeTrue();
    }

    [Theory, AutoData]
    public void Supports_assignment_with_decimal_value(decimal oldValue, decimal newValue)
    {
        //Arange
        var money = new Money(oldValue);

        //Act
        money = newValue;

        //Assert
        money.Value.Should().Be(newValue);
    }



}