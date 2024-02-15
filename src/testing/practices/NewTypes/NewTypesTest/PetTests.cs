using NewTypes.Pets;

namespace NewTypesTest;

public class PetTests
{
    [Fact]
    public void DogTalkToOwnerReturnWoof()
    {
        var expected = "Woof!";
        var actual = new Dog().TalkToOwner();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CatTalkToOwnerReturnMeow()
    {
        var expected = "Meow!";
        var actual = new Cat().TalkToOwner();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BirdTalkToOwnerReturnTweet()
    {
        var expected = "Tweet!";
        var actual = new Bird().TalkToOwner();

        Assert.Equal(expected, actual);
    }
}