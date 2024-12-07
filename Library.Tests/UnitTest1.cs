//Creating tests here is a little weird, because the results are always intentionally random. So I'm just checking that the results are within the desired parameters in those cases.
public class UnitTest1
{
    [Fact]
    public void DrawCardTest()
    {
        Assert.True(Library.DrawCard() >= 0);
        Assert.True(Library.DrawCard() <= 13);

    }
    [Fact]
    public void CreateDeckTest()
    {
        Assert.True(Library.CreateDeck().Length == 14);
    }
    [Fact]
    public void CountCardScoreTest()
    {
        Assert.Equal(175, Library.CountCardScore([1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]));
        Assert.Equal(0, Library.CountCardScore([0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]));
    }
    [Fact]
    public void CanPlaceCardsTest()
    {
        Assert.True(Library.CanPlaceCards(new List<int[]> { new int[] { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }, 1));
        Assert.True(Library.CanPlaceCards(new List<int[]> { new int[] { 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 } }, 1));
        Assert.True(Library.CanPlaceCards(new List<int[]> { new int[] { 0, 1, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }, 1));
        Assert.False(Library.CanPlaceCards(new List<int[]> { new int[] { 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }, 1));
        Assert.True(Library.CanPlaceCards(new List<int[]> { new int[] { 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }, 1));
    }
    [Fact]
    public void CanCreateMeldTest()
    {
        Assert.True(Library.CanCreateMeld([0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1], 2));
        Assert.True(Library.CanCreateMeld([0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1], 2));
        Assert.True(Library.CanCreateMeld([0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], 3));
        Assert.False(Library.CanCreateMeld([0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1], 2));
        Assert.False(Library.CanCreateMeld([0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], 2));
        Assert.True(Library.CanCreateMeld([0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], 2));
        Assert.True(Library.CanCreateMeld([0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0], 11));
    }
}