namespace BlogAppMVC;

public static class Includes
{
    public static readonly string[] TagIncludes =
    {
        "BlogTags",
        "BlogTags.Blog.BlogImages",
        "BlogTags.Blog.Reviews",
        "BlogTags.Blog.SavedItems.User",
    };
    public static readonly string[] BlogIncludes =
    {
        "BlogImages",
        "BlogTags.Tag",
        "SavedItems.User",
        "Reviews.User",
     };
    public static readonly string[] UserIncludes =
{
        "SavedItems.Blog",
        "Reviews.Blog",
     };
    public static readonly string[] ReviewIncludes = {
        "Blog.BlogImages",
        "User"
    };
}
