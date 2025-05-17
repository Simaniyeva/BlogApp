namespace BlogApp.API;

public static class Includes
{
    public static readonly string[] TagIncludes =
    {
    };
    public static readonly string[] BlogIncludes =
    {
     };
    public static readonly string[] UserIncludes =
{
        "SavedItems.Blog",
        "Reviews.Blog",
     };
    public static readonly string[] ReviewIncludes = {
    };
}
