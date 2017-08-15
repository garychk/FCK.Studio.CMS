namespace FCK.Studio.Entities
{
    public interface IStandardObjModel<CategoryPrimaryKey>
    {
        string Title { get; set; }
        string Contents { get; set; }
        string Keywords { get; set; }
        string Intro { get; set; }
        string Tags { get; set; }
        CategoryPrimaryKey CategoryId { get; set; }
    }
}
