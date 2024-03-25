namespace Cs_razorweb.Helpers;

public class PagingModel
{
    public int currenpage { get; set; }
    public int countpage { get; set; }
    
    public Func<int?, string> generateUrl { get; set; }
}